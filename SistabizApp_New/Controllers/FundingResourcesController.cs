using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FundingResourcesController : ControllerBase
    {

        private readonly IBLLService fundingService;

        public FundingResourcesController(IBLLService fundingservice)
        {
            fundingService = fundingservice;
        }

        [HttpGet]
        [Route("geallfundingdetails")]
        public async Task<IActionResult> GetAllFundingList()
        {

            return Ok(new APIResponse(true, Constant.Success, "funding list", fundingService.GetAllFundingResource()));
        }

        [HttpGet]
        [Route("gefundingcategory")]
        public async Task<IActionResult> GetAllFundingCategory()
        {

            return Ok(new APIResponse(true, Constant.Success, "funding category list", fundingService.GetAllFundingCategory()));
        }

        [HttpPost]
        [Route("addupdatefunding")]
        public async Task<IActionResult> ManageFundingResource(FundingViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding resources updated successfully", fundingService.ManageFundingResources(model)));
        }

        [HttpGet]
        [Route("deletefunding")]
        public async Task<IActionResult> DeleteFunding(int fundingid)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding resources deleted", fundingService.DeleteFundingResource(fundingid)));
        }
    }
}
