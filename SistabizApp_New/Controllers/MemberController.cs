using Microsoft.AspNetCore.Authorization;
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

namespace SistabizApp_New.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IBLLService memberService;


        public MemberController(IBLLService member)
        {
            memberService = member;
        }


        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetProfile(int memberid)
        {
            return Ok(new APIResponse(true, Constant.Success, "", memberService.GetEmployeeById(memberid)));
        }

        [HttpPost]
        [Route("updateprofile")]
        public async Task<IActionResult> UpdateProfile([FromForm] MemberViewModel model)
        {
          var getfilename=  Path.GetFileName(Guid.NewGuid() + "_" + model.Image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.ProfilePath, getfilename);
            if (model.Image.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    model.Image.CopyTo(fileStream);
                    model.ProfileImage = getfilename;
                }
            }
            var result = memberService.Updateprofile(model);


            return Ok(new APIResponse(true, Constant.Success, "Profile updat sucessfully", "Profile updat sucessfully"));
        }

    }
}
