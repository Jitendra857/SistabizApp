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
            return Ok(new APIResponse(true, Constant.Success, "member profile details.", memberService.GetEmployeeById(memberid)));
        }
        [HttpGet]
        [Route("searchmember")]
        public async Task<IActionResult> Searchmember(string search)
        {
            var result = memberService.SearchMember(search);
            return Ok(new APIResponse(true, Constant.Success, "search member list.",result));

           
        }
        [HttpGet]
        [Route("getmemberrolelist")]
        public async Task<IActionResult> GetMemberRole()
        {
            return Ok(new APIResponse(true, Constant.Success, "Meber role list.", memberService.GetMemberRoleDetails()));
        }

        [HttpGet]
        [Route("getmemberbyrole")]
        public async Task<IActionResult> GetMemberByRole(int roleid)
        {
            var result = memberService.GetMemberByRole(roleid);
            return Ok(new APIResponse(true, Constant.Success, "Meber list by role.",result));

        }

        [HttpPost]
        [Route("updateprofile")]
        public async Task<IActionResult> UpdateProfile([FromForm] MemberProfileViewModel model)
        {

            List<TblMemberAttachment> postattachment = new List<TblMemberAttachment>();
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

            if (model.PostImageAndVideo.Count > 0)
            {
                foreach (var item in model.PostImageAndVideo)
                {
                    if (item.Length > 0)
                    {
                        var eventfilename = Path.GetFileName(Guid.NewGuid() + "_" + item.FileName);
                        var attachmentpath = Path.Combine(Directory.GetCurrentDirectory(), Constant.MemberPost, eventfilename);


                        using (var fileStream = new FileStream(attachmentpath, FileMode.Create))
                        {

                            item.CopyTo(fileStream);
                            postattachment.Add(new TblMemberAttachment { MemberId = result.MemberId, PhotoVideoUrl = eventfilename, CreateOn = DateTime.Now, IsDeleted = false });
                        }
                    }
                }
            }
            // add/update attachment
            if (postattachment.Count > 0)
            {
                memberService.UploadMemberPostAttachment(postattachment);
            }


            return Ok(new APIResponse(true, Constant.Success, "Profile updat sucessfully", "Profile updat sucessfully"));
        }

        [HttpPost]
        [Route("photovideolikecomments")]
        public async Task<IActionResult> PhotoVideoLineComments(PhotoLikeCommentViewModel model)
        {
            var postlikecomments = memberService.PhotoVideoLikeComments(model);
            return Ok(new APIResponse(true, Constant.Success, "photo video like/comment successfully", ""));
        }

        [HttpPost]
        [Route("bookmark")]
        public async Task<IActionResult> BookMark(BookmrkViewModel model)
        {
         
            var result = memberService.MemberBookmark(model);

            return Ok(new APIResponse(true, Constant.Success, "member "+ result + " sucessfully", ""));
        }

        [HttpPost]
        [Route("getmemberlistbyfilter")]
        public async Task<IActionResult> GetAllMemberByFilter(MemberFilterViewModel model)
        {
            var result = memberService.GetGroupListByFilter(model);
            return Ok(new APIResponse(true, Constant.Success, "group list by filter", model.Ordering == 2 ? result.OrderByDescending(r => r.MemberId).ToList() : result));

        }


        [HttpGet]
        [Route("deletemember")]
        public async Task<IActionResult> DeleteMember(int memberid)
        {
            return Ok(new APIResponse(true, Constant.Success, "Member delete successfully", memberService.GetEmployeeById(memberid)));
        }
        [HttpGet]
        [Route("getmemberlist")]
        public async Task<IActionResult> GetMemberList(int ordering=0)
        {
            var result = memberService.MemberList();
            return Ok(new APIResponse(true, Constant.Success, "member list.", ordering == 2 ? result.OrderByDescending(r => r.MemberId).ToList() : result));

        }

    }
}
