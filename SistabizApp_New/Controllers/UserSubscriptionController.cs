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
    public class UserSubscriptionController : ControllerBase
    {

        private readonly IBLLService subscriptionService;

        public UserSubscriptionController(IBLLService subscriptionservice)
        {
            subscriptionService = subscriptionservice;
        }

        [HttpGet]
        [Route("getbreakthroughlist")]
        public async Task<IActionResult> GetAllBreakthrough()
        {
            var result = subscriptionService.GetAllBreakThroughList();
            return Ok(new APIResponse(true, Constant.Success, "breakthrough request list", result));

        }
        [HttpPost]
        [Route("sendbreakthroughlink")]
        public async Task<IActionResult> SendBreakthroughList(BreakthroughRequest model)
        {
            try
            {
                var member = subscriptionService.GetMemberDetailsById((int)model.MemberId);
                var getbreakthrough = subscriptionService.GetAllBreakThroughListById((int)model.Id);
                if (member.TblUserSubscription.FirstOrDefault().IsActive == true)
                {
                    return Ok(new APIResponse(true, "Email not sent, Br=eacuse member already active.", "", System.Net.HttpStatusCode.InternalServerError));
                }
                model.RequestLink = model.RequestLink + "?UserId=" + getbreakthrough.MemberId + "&SubscriptiontypeId=" + getbreakthrough.SubscriptionType + "&SubscriptionType=" + 3 + "";
                //  var confirmationLink = Url.Action("Breakthrough Signup", "Confirm", new { token, email = user.Email }, Request.Scheme);
                EmailHelper emailHelper = new EmailHelper();
                bool emailResponse = emailHelper.SendEmail(member.Email, model.RequestLink);


                if (emailResponse != true)
                    return Ok(new APIResponse(false, "Email not sent.", "", System.Net.HttpStatusCode.InternalServerError));

                var result = subscriptionService.UpdateBreakthrough((int)model.Id);

                return Ok(new APIResponse(true, "Link Sent Succesfully.", System.Net.HttpStatusCode.OK.ToString(), model));

            }
            catch (Exception e)
            {
                throw e;
            }
          

        }

    }
}
