using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ModulePermission(new[] { PermissionEnum.Modules.EVENTS })] //Check Permission for method
    public class EventController : ControllerBase
    {

        private readonly IBLLService eventService;

        public EventController(IBLLService eventservice)
        {
            eventService = eventservice;
        }

        [HttpGet]
        [Route("getevent")]
        public async Task<IActionResult> GetAllEvent(int ordering = 0)
        {
            var result = eventService.GetEventList();
            return Ok(new APIResponse(true, Constant.Success, "event list", ordering == 2 ? result.OrderByDescending(r => r.EventId).ToList() : result));
        }

        [HttpGet]
        [Route("geteventbyid")]
        public async Task<IActionResult> GetAllEventById(int eventid)
        {

            return Ok(new APIResponse(true, Constant.Success, "event details by id", eventService.GetEventListById(eventid)));
        }
        [HttpGet]
        [Route("searchevent")]
        public async Task<IActionResult> SearchGroup(string search)
        {
            var result = eventService.SearchEventList(search);
            return Ok(new APIResponse(true, Constant.Success, "event list by search", result));

        }
        [HttpPost]
        [Route("geteventlistbyfilter")]
        public async Task<IActionResult> GetAllEventByFilter(EventFilterViewModel model)
        {
            var result = eventService.GetEventListByFilter(model);
            return Ok(new APIResponse(true, Constant.Success, "event list by filter", model.Ordering == 2 ? result.OrderByDescending(r => r.EventId).ToList() : result));

        }
        [HttpPost]
        [Route("eventbookmark")]
        public async Task<IActionResult>EventBookmark(EventBookmarkViewModel model)
        {
            var result = eventService.EventBookmark(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Event " + result + " sucessfully"));
        }



        [HttpPost]
        [Route("addupdateevent")]
        public async Task<IActionResult> ManageEvent([FromForm] EventViewModel model)
        {

            List<TblEventAttachment> eventlist = new List<TblEventAttachment>();

            // add/update event
            long eventid = eventService.ManageEvent(model);

            // upload document

            if (model.EventId == 0 || model.IsUpdateAttachment == true)
            {
                foreach (var item in model.Image)
                {
                    if (item.Length > 0)
                    {
                        var eventfilename = Path.GetFileName(Guid.NewGuid() + "_" + item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.Event, eventfilename);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {

                            item.CopyTo(fileStream);
                            eventlist.Add(new TblEventAttachment { EventId = eventid, FileName = eventfilename });
                        }
                    }
                }
            }

            // add/update attachment
            if (eventlist.Count > 0)
            {
                eventService.UploadEventAttachment(eventlist);
            }



            return Ok(new APIResponse(true, Constant.Success, "", "Event Added sucessfully"));
        }

        [HttpPost]
        [Route("registereventmember")]
        public async Task<IActionResult> RegisterEventMember(RegisterMemberEventViewModel model)
        {
            var result = eventService.RegisterEventMember(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Member register for event sucessfully"));
        }

        [HttpPost]
        [Route("updateeventstatus")]
        public async Task<IActionResult> UpdateEventStatus(RegisterMemberEventViewModel model)
        {
            var result = eventService.UpdateEventStatus(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Event update sucessfully"));
        }


        [HttpGet]
        [Route("deleteevent")]
        public async Task<IActionResult> DeleteEvent(int eventid)
        {
            var result = eventService.DeleteEvent(eventid);

            return Ok(new APIResponse(true, Constant.Success, "", "Event deleted sucessfully"));
        }

        [HttpGet]
        [Route("deleteeventattachment")]
        public async Task<IActionResult> DeleteEventAttachment(int eventid)
        {
            var result = eventService.DeleteEventAttachment(eventid);

            return Ok(new APIResponse(true, Constant.Success, "", "Event attachment deleted sucessfully"));
        }
    }
}
