using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;

namespace SistabizApp_New.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IBLLService postService;

        public PostController(IBLLService postservice)
        {
            postService = postservice;
        }

        [HttpGet]
        [Route("geallpostdetails")]
        public async Task<IActionResult> GetAllPost()
        {

            return Ok(new APIResponse(true, Constant.Success, "post list", postService.GetAllPost()));
        }



        [HttpPost]
        [Route("addupdatepost")]
        public async Task<IActionResult> ManagePost([FromForm] PostViewModel model)
        {

            List<TblPostAttachment> postattachment = new List<TblPostAttachment>();

            // add/update event
            long postid = postService.ManagePost(model);

            // upload document

            if (model.PostId == 0 || model.IsUpdateAttachment == true)
            {
                foreach (var item in model.Image)
                {
                    if (item.Length > 0)
                    {
                        var postfilename = Path.GetFileName(Guid.NewGuid() + "_" + item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.Post, postfilename);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {

                            item.CopyTo(fileStream);
                            postattachment.Add(new TblPostAttachment { PostId = postid, FileName = postfilename });
                        }
                    }
                }
            }

            // add/update attachment
            if (postattachment.Count > 0)
            {
                postService.UploadPostAttachment(postattachment);
            }


            return Ok(new APIResponse(true, Constant.Success, "post updated successfully", ""));
        }

        [HttpPost]
        [Route("postlikecomments")]
        public async Task<IActionResult> PostLineComments(PostLikeCommentsViewModel model)
        {
            var postlikecomments = postService.PostLikeComments(model);
            return Ok(new APIResponse(true, Constant.Success, "post updated successfully", ""));
        }

        [HttpPost]
        [Route("postbookmarks")]
        public async Task<IActionResult> PostBookmark(PostBookmarkViewModel model)
        {
            var postlikecomments = postService.PostBookmark(model);
            return Ok(new APIResponse(true, Constant.Success, "post "+ postlikecomments + " successfully", ""));
        }

        [HttpGet]
        [Route("deletepost")]
        public async Task<IActionResult> DeletePostr(int postid)
        {

            return Ok(new APIResponse(true, Constant.Success, "post resources deleted", postService.DeletePost(postid)));
        }
    }
}
