using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqQuestionController : ControllerBase
    {
        private readonly IBLLService faqQuestionService;

        public FaqQuestionController(IBLLService faqquestionservice)
        {
            faqQuestionService = faqquestionservice;
        }


        [HttpGet]
        [Route("geallfaqquestiondetails")]
        public async Task<IActionResult> GetAllFaqUestionList()
        {

            return Ok(new APIResponse(true, Constant.Success, "faq question list", faqQuestionService.GetFaqQuestionList()));
        }

        [HttpPost]
        [Route("addupdatefaqquestion")]
        public async Task<IActionResult> ManageFaqQuestion(FaqQuestionViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "faq question updated successfully", faqQuestionService.ManageFaqQuestion(model)));
        }


        [HttpGet]
        [Route("deletefaqquestion")]
        public async Task<IActionResult> DeleteFaqQuestion(int id)
        {

            return Ok(new APIResponse(true, Constant.Success, "faq question deleted", faqQuestionService.DeleteFaq(id)));
        }
    }
}
