using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly IBLLService commanService;

        public CommonController(IBLLService commanservice)
        {
            commanService = commanservice;
        }

        [HttpGet]
        [Route("getbookmarklisting")]
        public async Task<IActionResult> GetAllConversationQuestion(int type,int memberid)
        {

            return Ok(new APIResponse(true, Constant.Success, "Conversation question list", commanService.GetBookmarkList(type,memberid)));
        }

        [HttpPost]
        [Route("downloadresoureces")]
        public async Task<IActionResult> DownloadDigitalLibrary(SendFileModel model)
        {

           // EmailHelper.SendResources(model);
            EmailHelper.SendResourcesTest(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Resources send on email sucessfully, You can download from there."));
        }


    }
}
