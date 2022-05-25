using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommanController : ControllerBase
    {

        private readonly IBLLService commanService;

        public CommanController(IBLLService commanservice)
        {
            commanService = commanservice;
        }

        [HttpGet]
        [Route("getbookmarklisting")]
        public async Task<IActionResult> GetAllConversationQuestion(int type,int memberid)
        {

            return Ok(new APIResponse(true, Constant.Success, "Conversation question list", commanService.GetBookmarkList(type,memberid)));
        }
    }
}
