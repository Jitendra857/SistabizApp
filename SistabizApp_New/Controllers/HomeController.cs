using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
  //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        private readonly IBLLService commanService;


        public HomeController(IBLLService comman)
        {
            commanService = comman;
        }


        [HttpGet]
        [Route("gethomedata")]
        public async Task<IActionResult> GetServiceRequestByMember(int MemberId)
        {
            HomeViewModel model = new HomeViewModel();
            model.lstmemberlist = commanService.MemberList();
            model.lstGrouplist = commanService.GetGroupList();
            model.lstGoalActivity = commanService.GetAllGoalAndActivity(MemberId);
            model.lstDigitalLibrary = commanService.GetDigitalLibraryList();
            model.lstPostDetails = commanService.GetPostDetails();

            return Ok(new APIResponse(true, Constant.Success, "", model));
        }

        [HttpGet]
        [Route("searchmember")]
        public async Task<IActionResult> SearchMember(string search)
        {
            HomeViewModel model = new HomeViewModel();
            model.lstmemberlist = commanService.MemberList(search);
            return Ok(new APIResponse(true, Constant.Success, "", model));
        }
    }
}
