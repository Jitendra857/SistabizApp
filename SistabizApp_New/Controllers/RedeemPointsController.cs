using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedeemPointsController : ControllerBase
    {

        private readonly IBLLService redeemService;


        public RedeemPointsController(IBLLService redeemservice)
        {
            redeemService = redeemservice;
        }
        [HttpGet]
        [Route("getredeempointslist")]
        public async Task<IActionResult> GetRedeemPointList()
        {
           
            return Ok(new APIResponse(true, Constant.Success, "Redeem points listing", redeemService.GetAllRedeemPoint()));
        }

        [HttpGet]
        [Route("getmemberearnpointdetails")]
        public async Task<IActionResult> GetMemberEarnPointDetails(int memberid=0)
        {

            return Ok(new APIResponse(true, Constant.Success, "Redeem points listing By Member", redeemService.GetAllRedeemPointByMember(memberid)));
        }

        [HttpPost]
        [Route("requestearnpoint")]
        public async Task<IActionResult> RequestEarnPoints(RedeemPointsViewModel model)
        {
            var redeempoint = redeemService.RedeemEarnPointRequest(model);
            return Ok(new APIResponse(true, Constant.Success, "Redeem points earn request submitted successfully", ""));
        }
        [HttpPost]
        [Route("acceptreferredeemrequest")]
        public async Task<IActionResult> AcceptReferRedeemRequest(RedeemPointsViewModel model)
        {
            var redeempoint = redeemService.AcceptReferRedeemRequest(model);
            return Ok(new APIResponse(true, Constant.Success, "Redeem point accpeted by membersuccessfully", ""));
        }
    }
}
