using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.ViewModels;

namespace SistabizApp_New.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> ManagePost(PostViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "post updated successfully", postService.ManagePost(model)));
        }

        [HttpGet]
        [Route("deletepost")]
        public async Task<IActionResult> DeletePostr(int postid)
        {

            return Ok(new APIResponse(true, Constant.Success, "post resources deleted", postService.DeletePost(postid)));
        }
    }
}
