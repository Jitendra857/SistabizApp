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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ModulePermission(new[] { PermissionEnum.Modules.Funding })]
    public class FundingResourcesController : ControllerBase
    {

        private readonly IBLLService fundingService;

        public FundingResourcesController(IBLLService fundingservice)
        {
            fundingService = fundingservice;
        }

        [HttpGet]
        [Route("geallfundingdetails")]
        public async Task<IActionResult> GetAllFundingList(int ordering = 0)
        {
            var result = fundingService.GetAllFundingResource();
            return Ok(new APIResponse(true, Constant.Success, "funding list", ordering == 2 ? result.OrderByDescending(r => r.CreateOn).ToList() : result));

        }

        [HttpGet]
        [Route("geallfundingdetailsById")]
        public async Task<IActionResult> GetAllFundingListById(int id)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding list by id", fundingService.GetAllFundingResourceById(id)));
        }

        [HttpGet]
        [Route("gefundinglistbycategory")]
        public async Task<IActionResult> GetAllFundingListByCategory(int categoryid, int ordering = 0)
        {
            var result = fundingService.GetAllFundingResourceByCategory(categoryid);
            return Ok(new APIResponse(true, Constant.Success, "funding list by category", ordering == 2 ? result.OrderByDescending(r => r.CreateOn).ToList() : result));
        }

        [HttpGet]
        [Route("geallfundingbydate")]
        public async Task<IActionResult> GetAllFundingListByDate(string date)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding list by date", fundingService.GetAllFundingResourceByDate(date)));
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

        [HttpPost]
        [Route("fundingresourcebookmark")]
        public async Task<IActionResult> FundingResourceBookmark(FundingBookmarkViewModel model)
        {
            var result = fundingService.FundingResourceBookmark(model);

            return Ok(new APIResponse(true, Constant.Success, "", "funding "+ result + " sucessfully"));
        }
        [HttpGet]
        [Route("searchfundingresource")]
        public async Task<IActionResult> SearchFundingResource(string search)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding resource data", fundingService.SearchFundingResource(search)));
        }

        [HttpGet]
        [Route("deletefunding")]
        public async Task<IActionResult> DeleteFunding(int fundingid)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding resources deleted", fundingService.DeleteFundingResource(fundingid)));
        }
    }
}
