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
        public async Task<IActionResult> GetAllFundingList(int ordering = 0, int memberid = 0)
        {
            var result = fundingService.GetAllFundingResource();
            if (memberid > 0)
                result = result.Where(t => t.CreatedBy == memberid).ToList();
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
        public async Task<IActionResult> GetAllFundingListByCategory(int categoryid, int ordering = 0,int memberid=0)
        {
            var result = fundingService.GetAllFundingResourceByCategory(categoryid);
            if (memberid > 0)
                result = result.Where(t => t.CreatedBy == memberid).ToList();
            return Ok(new APIResponse(true, Constant.Success, "funding list by category", ordering == 2 ? result.OrderByDescending(r => r.CreateOn).ToList() : result));
        }

        [HttpGet]
        [Route("geallfundingbydate")]
        public async Task<IActionResult> GetAllFundingListByDate(string date,int memberid=0)
        {
            var result = fundingService.GetAllFundingResourceByDate(date);
            if (memberid > 0)
                result = result.Where(t => t.CreatedBy == memberid).ToList();
            return Ok(new APIResponse(true, Constant.Success, "funding list by date", result));
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
        public async Task<IActionResult> SearchFundingResource(string search,int memberid=0)
        {
            var result = fundingService.SearchFundingResource(search);
            if (memberid > 0)
                result = result.Where(t => t.CreatedBy == memberid).ToList();
            return Ok(new APIResponse(true, Constant.Success, "funding resource data",result));
        }
        
        [HttpGet]
        [Route("deletefunding")]
        public async Task<IActionResult> DeleteFunding(int fundingid)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding resources deleted", fundingService.DeleteFundingResource(fundingid)));
        }
    }
}
