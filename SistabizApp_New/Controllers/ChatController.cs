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
    public class ChatController : ControllerBase
    {

        private readonly IBLLService chatService;

        public ChatController(IBLLService chatservice)
        {
            chatService = chatservice;
        }

        [HttpGet]
        [Route("getallchathistory")]
        public async Task<IActionResult> GetChatHistory()
        {
         
            return Ok(new APIResponse(true, Constant.Success, "chat history list", chatService.GetChatHistory()));
        }

        [HttpPost]
        [Route("addchat")]
        public async Task<IActionResult> ManageChat(ChatViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "chat added successfully.",chatService.ManageChat(model)));

        }
    }
}
