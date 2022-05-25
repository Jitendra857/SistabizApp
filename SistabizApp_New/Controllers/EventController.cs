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
        public async Task<IActionResult> GetAllEvent()
        {
           
            return Ok(new APIResponse(true, Constant.Success, "event list", eventService.GetEventList()));
        }

        [HttpGet]
        [Route("geteventtest")]
        public async Task<IActionResult> GetAllEventTes()
        {

            return Ok(new APIResponse(true, Constant.Success, "event list", "Hello world!"));
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
    }
}
