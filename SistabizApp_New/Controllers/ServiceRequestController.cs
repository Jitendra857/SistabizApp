using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp.Authentication;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
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
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService serviceRequestService;

        public ServiceRequestController(IServiceRequestService serviceRequest)
        {
            serviceRequestService = serviceRequest;
        }

        [HttpGet]
        [Route("getservicerequest")]
        public async Task<IActionResult> GetServiceRequest()
        {
            return Ok(new APIResponse(true, Constant.Success, "", serviceRequestService.GetServiceRequestList()));
        }

        [HttpGet]
        [Route("getservicerequestbystatus")]
        public async Task<IActionResult> GetServiceRequestByStatus(int Status)
        {
            return Ok(new APIResponse(true, Constant.Success, "", serviceRequestService.GetServiceRequestListByStatus(Status)));
        }

        [HttpGet]
        [Route("getservicerequestbymember")]
        public async Task<IActionResult> GetServiceRequestByMember(int MemberId)
        {
            return Ok(new APIResponse(true, Constant.Success, "", serviceRequestService.GetServiceRequestListByMember(MemberId)));
        }

        [HttpPost]
        [Route("addservicerequest")]
        public async Task<IActionResult> ManageServiceRequest(ServiceRequestViewModel model)
        {
            if (model != null)
            {
                serviceRequestService.AddServiceRequest(model);
                return Ok(new APIResponse(true, Constant.Success, "", "Service request created successfully!"));
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Service request creation failed! Please check request details and try again." });
        }

        [HttpPost]
        [Route("updateservicerequest")]
        public async Task<IActionResult> UpdateServiceRequest(ServiceRequestChangeViewModel model)
        {
            if (model.RequestId>0)
            {
                var checkServiceRequest = serviceRequestService.GetServiceRequestById((int)model.RequestId);
                if(checkServiceRequest!=null)
                {

                    checkServiceRequest.Status = model.Status;
                    checkServiceRequest.Description = model.Description;
                  
                }
                
                serviceRequestService.SaveChanges();
                return Ok(new APIResponse(true, Constant.Success, "", "Service request updated successfully!"));
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Service request creation failed! Please check request details and try again." });
        }
    }
}
