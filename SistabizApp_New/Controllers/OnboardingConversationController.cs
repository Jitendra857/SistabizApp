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
    public class OnboardingConversationController : ControllerBase
    {
        private readonly IBLLService conversationService;

        public OnboardingConversationController(IBLLService conversationservice)
        {
            conversationService = conversationservice;
        }

        [HttpGet]
        [Route("getallconversationquestion")]
        public async Task<IActionResult> GetAllConversationQuestion()
        {

            return Ok(new APIResponse(true, Constant.Success, "Conversation question list", conversationService.GetAllConversationQuestion()));
        }

        [HttpGet]
        [Route("getallquestionanswer")]
        public async Task<IActionResult> GetAllQuestionAnswer()
        {

            return Ok(new APIResponse(true, Constant.Success, "Conversation question with answer list", conversationService.GetAllQuestionAnswer()));
        }

        [HttpPost]
        [Route("questionanswer")]
        public async Task<IActionResult> ManageQuestionAnswer(List<QuestionAnswerViewModel> model)
        {

            return Ok(new APIResponse(true, conversationService.ManageQuestionAnswer(model), "Conversation question with answer list", ""));
        }
    }
}
