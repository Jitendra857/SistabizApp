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
    public class TechHelpController : ControllerBase
    {
        private readonly IBLLService techhelpService;

        public TechHelpController(IBLLService techhelpservice)
        {
            techhelpService = techhelpservice;
        }

        [HttpGet]
        [Route("gettechhelplist")]
        public async Task<IActionResult> GetTechHelpListing(int id)
        {
            var result = techhelpService.GetTechhelpDetails(id);

            return Ok(new APIResponse(true, Constant.Success, "Tech help listing!", result));
        }

        [HttpPost]
        [Route("addupdatetechhelp")]
        public async Task<IActionResult> ManageTechHelp(TechHelpRequestViewModel model)
        {
            var result = techhelpService.ManageTechHelp(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Tech help added successfully!"));
        }

        [HttpPost]
        [Route("assigntechhelp")]
        public async Task<IActionResult> AssignTechHelp(TechHelpAssignedViewModel model)
        {
            var result = techhelpService.AssignTechHelp(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Tech help assign successfully!"));
        }
    }
}
