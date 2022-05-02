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


        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [HttpGet]
        [Route("gethomedata")]
        public async Task<IActionResult> GetServiceRequestByMember(int MemberId)
        {
            HomeViewModel model = new HomeViewModel();
            model.lstmemberlist = commanService.MemberList();
            model.lsteventlist = commanService.GetEventList();
            model.lstservicerequestlist = commanService.GetServiceRequestList();
            return Ok(new APIResponse(true, Constant.Success, "", model));
        }
    }
}
