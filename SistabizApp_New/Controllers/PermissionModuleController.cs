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
    public class PermissionModuleController : ControllerBase
    {

        private readonly IBLLService moduleService;

        public PermissionModuleController(IBLLService moduleservice)
        {
            moduleService = moduleservice;
        }
        [HttpGet]
        [Route("getallsubscriptionlist")]
        public async Task<IActionResult> GetSubscriptionList()
        {
            var result = moduleService.GetSubscriptionList();
            return Ok(new APIResponse(true, Constant.Success, "subscription type list", result));
        }
        [HttpGet]
        [Route("getallmodule")]
        public async Task<IActionResult> GetAllModule()
        {
            var result = moduleService.GetModuleList();
            return Ok(new APIResponse(true, Constant.Success, "module list", result));
        }

        [HttpPost]
        [Route("addupdatemodule")]
        public async Task<IActionResult> ManageModule(ModuleViewModel model)
        {
            var result = moduleService.ManageModule(model);
            return Ok(new APIResponse(true, Constant.Success, "module update successfully.", result));
        }

        [HttpGet]
        [Route("deletemodule")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var result = moduleService.DeleteModule(id);
            return Ok(new APIResponse(true, Constant.Success, "module deleted suceessfully.", result));
        }

        [HttpPost]
        [Route("assignmodulepermission")]
        public async Task<IActionResult> ManageModulePermission(ModulePermissionViewModel model)
        {
            var result = moduleService.AssingModulePermission(model);
            return Ok(new APIResponse(true, Constant.Success, "permission assign successfully.", result));
        }
    }
}
