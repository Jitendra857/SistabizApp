using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    [ModulePermission(new[] { PermissionEnum.Modules.DigitalLibrary })]

    public class DigitalLibraryController : ControllerBase
    {

        private readonly IBLLService digitallibraryService;

        public DigitalLibraryController(IBLLService digitallibraryservice)
        {
            digitallibraryService = digitallibraryservice;
        }

        [HttpGet]
        [Route("getalldigitallibrary")]
        public async Task<IActionResult> GetAllDigitalLibrary(int ordering = 0)
        {
            var result = digitallibraryService.GetDigitalLibraryList();
            return Ok(new APIResponse(true, Constant.Success, "digital library list", ordering == 2 ? result.OrderByDescending(r => r.DigitalLibraryId).ToList() : result));
        }

        [HttpGet]
        [Route("searchdigitallibrary")]
        public async Task<IActionResult> SearchDigitalLibrary(string search)
        {
            var result = digitallibraryService.GetDigitalLibraryList(search);
            return Ok(new APIResponse(true, Constant.Success, "digital library list", result));
            
        }
        [HttpPost]
        [Route("getdigitallibrarylistbyfilter")]
        public async Task<IActionResult> GetDigitalLibraryByFilter(DigitalLibraryFilterViewModel model)
        {

            var result = digitallibraryService.GetGroupListByFilter(model);
            return Ok(new APIResponse(true, Constant.Success, "digital library list by filter", model.Ordering == 2 ? result.OrderByDescending(r => r.DigitalLibraryId).ToList() : result));
          
        }

        [HttpGet]
        [Route("getdigitallibrarybycategory")]
        public async Task<IActionResult> GetDigitalLibraryByCategory(int category)
        {
            var result = digitallibraryService.GetDigitalLibraryListByCategory(category);
            return Ok(new APIResponse(true, Constant.Success, "digital library list",result));

          
        }

        [HttpPost]
        [Route("digitallibrarybookmark")]
        public async Task<IActionResult> DigitalLibraryBookmark(DigitalLibraryBookmarkViewModel model)
        {
            var result = digitallibraryService.DigitalLibraryBookmark(model);

            return Ok(new APIResponse(true, Constant.Success, "", "digital library "+ result + " saved sucessfully"));
        }

        [HttpGet]
        [Route("gedigitallibrarycategory")]
        public async Task<IActionResult> GetAllDigitalLibraryCategory()
        {

            return Ok(new APIResponse(true, Constant.Success, "digital library category list. category list", digitallibraryService.GetCategoryList()));
        }

        [HttpPost]
        [Route("addupdatedigitallibrary")]
        public async Task<IActionResult> ManageDigitalLibrary([FromForm] DigitalLibraryViewModel model)
        {

            List<TblDigitalLibaryAttachment> digitallibraryattachment = new List<TblDigitalLibaryAttachment>();
            if (model.GroupIcon.Length > 0)
            {
                var eventfilename = Path.GetFileName(Guid.NewGuid() + "_" + model.GroupIcon.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.GroupIcon, eventfilename);


                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    model.GroupIcon.CopyTo(fileStream);
                    model.GroupIconPath = eventfilename;
                }
            }


            // add/update event
            long groupid = digitallibraryService.ManageDigitalLibrary(model);

            // upload document

            if (model.DigitalLibraryId == 0 || model.IsUpdateAttachment == true)
            {
                foreach (var item in model.Image)
                {
                    if (item.Length > 0)
                    {
                        var digitallibraryfilename = Path.GetFileName(Guid.NewGuid() + "_" + item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.DigitalLibrary, digitallibraryfilename);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {

                            item.CopyTo(fileStream);
                            digitallibraryattachment.Add(new TblDigitalLibaryAttachment { DigitalLibaryId = groupid, FileName = digitallibraryfilename });
                        }
                    }
                }
            }

            // add/update attachment
            if (digitallibraryattachment.Count > 0)
            {
                digitallibraryService.UploadDigitalLibraryAttachment(digitallibraryattachment);
            }
           



            return Ok(new APIResponse(true, Constant.Success, "", "Digital library update successfully"));
        }

        
        [HttpGet]
        [Route("deletedigitallibrary")]
        public async Task<IActionResult> RemoveDigitalLibrary(int digitallibraryid)
        {
            var result = digitallibraryService.RemoveDigitalLibrary(digitallibraryid);

            return Ok(new APIResponse(true, Constant.Success, "", "Digital library deleted sucessfully"));
        }

       
    }
}
