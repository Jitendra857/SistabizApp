using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IBLLService badgesService;

        public BadgesController(IBLLService badgesservice)
        {
            badgesService = badgesservice;
        }
        [HttpGet]
        [Route("getallbadges")]
        public async Task<IActionResult> GetAllBadges()
        {
            try
            {
                var result = badgesService.GetAllBadges();
                return Ok(new APIResponse(true, Constant.Success, "badges list", result));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }

        [HttpPost]
        [Route("addupdatebadges")]
        public async Task<IActionResult> ManageBadges([FromForm] BadgesViewModel model)
        {

            try
            {
                if (model.Image != null)
                {
                    if (model.Image.Length > 0)
                    {
                        var eventfilename = Path.GetFileName(Guid.NewGuid() + "_" + model.Image.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.Badges, eventfilename);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {

                            model.Image.CopyTo(fileStream);
                            model.ImgaeUrl = eventfilename;
                        }
                    }
                }

                badgesService.ManageBadges(model);


                return Ok(new APIResponse(true, Constant.Success, "", "Badges Added successfully"));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }

        [HttpPost]
        [Route("assignbadgestomember")]
        public async Task<IActionResult> BadgesAssignToMember( BadgesAssignViewMidel model)
        {
          var result=  badgesService.BadgesAssignMember(model);
            try
            {
                if (result == false)
                    return Ok(new APIResponse(false, Constant.Error, "", "Same badges already assign to this member"));
                else
                    return Ok(new APIResponse(true, Constant.Success, "", "Badges assign to member successfully"));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }

        }

        [HttpGet]
        [Route("getallbadgesbymember")]
        public async Task<IActionResult> GetAllBadgesByMember(int memberid=0)
        {
            try
            {
                var result = badgesService.GetAllBadgesByMember(memberid);
                return Ok(new APIResponse(true, Constant.Success, "badges assign member list", result));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }


        [HttpGet]
        [Route("deletebadges")]
        public async Task<IActionResult> RemoveBadges(int id)
        {
            try
            {
                var result = badgesService.RemoveBadges(id);

                return Ok(new APIResponse(true, Constant.Success, "", "Badges delete sucessfully"));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }

        [HttpGet]
        [Route("reassignbadges")]
        public async Task<IActionResult> Reassignbadges(int badgesid,int memberid)
        {
            try
            {
                var result = badgesService.ReassignBadges(badgesid, memberid);

                return Ok(new APIResponse(true, Constant.Success, "", "Badges reassign sucessfully"));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }

    }
}
