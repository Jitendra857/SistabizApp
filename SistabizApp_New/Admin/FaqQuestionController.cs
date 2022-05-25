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
        [Route("geallfundingdetails")]
        public async Task<IActionResult> GetAllFundingList()
        {

            return Ok(new APIResponse(true, Constant.Success, "funding list", faqQuestionService.GetFaqQuestionList()));
        }

        [HttpPost]
        [Route("addupdatefunding")]
        public async Task<IActionResult> ManageFundingResource(FaqQuestionViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding resources updated successfully", faqQuestionService.ManageFaqQuestion(model)));
        }


        [HttpGet]
        [Route("deletefunding")]
        public async Task<IActionResult> DeleteFunding(int id)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding resources deleted", faqQuestionService.DeleteFaq(id)));
        }
    }
}
