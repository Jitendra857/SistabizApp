using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundingSectionController : ControllerBase
    {
        private readonly IBLLService fundingSectionService;

        public FundingSectionController(IBLLService fundingsectionservice)
        {
            fundingSectionService = fundingsectionservice;
        }

        [HttpGet]
        [Route("geallfundingsection")]
        public async Task<IActionResult> GetFundingSection()
        {

            return Ok(new APIResponse(true, Constant.Success, "funding section details", fundingSectionService.GetFundingTitleDetails()));
        }

        [HttpPost]
        [Route("addupdatefundingtitle")]
        public async Task<IActionResult> ManageFundingTitle([FromForm] FundingTitleViewModel model)
        {

            List<TblDigitalLibaryAttachment> digitallibraryattachment = new List<TblDigitalLibaryAttachment>();
            if (model.FundingTitleIcon.Length > 0)
            {
                var eventfilename = Path.GetFileName(Guid.NewGuid() + "_" + model.FundingTitleIcon.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.GroupIcon, eventfilename);


                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    model.FundingTitleIcon.CopyTo(fileStream);
                    model.FundingTitlePath = eventfilename;
                }
            }


            // add/update event
             fundingSectionService.ManageFundingTitle(model);

            // upload document

          


            return Ok(new APIResponse(true, Constant.Success, "", "funding section update successfully"));
        }

        [HttpGet]
        [Route("deletefundingsection")]
        public async Task<IActionResult> DeleteFundingSection(int fundingid)
        {

            return Ok(new APIResponse(true, Constant.Success, "funding title deleted", fundingSectionService.DeleteFundingTitle(fundingid)));
        }


    }
}
