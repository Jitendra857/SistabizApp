using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.ViewModels;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ModulePermission(new[] { PermissionEnum.Modules.Faq })]
    public class FaqController : ControllerBase
    {

        private readonly IBLLService faqService;

        public FaqController(IBLLService faqservice)
        {
            faqService = faqservice;
        }

        [HttpGet]
        [Route("geallfaqdetails")]
        public async Task<IActionResult> GetAllFaqList(string search)
        {

            return Ok(new APIResponse(true, Constant.Success, "faq list", faqService.GetAllFaq(search)));
        }
        [HttpGet]
        [Route("gefaqlistbycategory")]
        public async Task<IActionResult> GetFaqListByCategoryt()
        {

            return Ok(new APIResponse(true, Constant.Success, "faq list by category", faqService.GetAllFaqByCategory()));
        }

        [HttpGet]
        [Route("gefaqcategory")]
        public async Task<IActionResult> GetFaqCategory()
        {

            return Ok(new APIResponse(true, Constant.Success, "faq category list", faqService.GetAllFaqCategory()));
        }

        [HttpPost]
        [Route("addupdatefaq")]
        public async Task<IActionResult> ManageFaq(FaqViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "faq updated successfully", faqService.ManageFaq(model)));
        }

        [HttpGet]
        [Route("deletefaq")]
        public async Task<IActionResult> DeleteFaq(int fundingid)
        {

            return Ok(new APIResponse(true, Constant.Success, "faq deleted successfully.", faqService.DeleteFaq(fundingid)));
        }
    }
}
