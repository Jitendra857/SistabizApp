using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    // [Authorize]
   // [EnableCors("ApiCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IBLLService serviceRequestService;

        public ServiceRequestController(IBLLService serviceRequest)
        {
            serviceRequestService = serviceRequest;
        }

        [HttpGet]
        [Route("getservicerequest")]
        public async Task<IActionResult> GetServiceRequest()
        {
            try
            {
                return Ok(new APIResponse(true, Constant.Success, "", serviceRequestService.GetServiceRequestList()));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }

        [HttpGet]
        [Route("getservicerequestbystatus")]
        public async Task<IActionResult> GetServiceRequestByStatus(int Status)
        {
            try
            {
                return Ok(new APIResponse(true, Constant.Success, "", serviceRequestService.GetServiceRequestListByStatus(Status)));
            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
           
        }

        [HttpPost]
        [Route("acceptrejectservicerequest")]
        public async Task<IActionResult> AcceptRejectServiceRequest(ServiceRequestChangeViewModel model)
        {
            try
            {
                return Ok(new APIResponse(true, Constant.Success, "service request updated successfully.", serviceRequestService.AcceptRejectServiceRequest(model)));

            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }

        [HttpGet]
        [Route("getservicerequestbymember")]
        public async Task<IActionResult> GetServiceRequestByMember(int MemberId)
        {
            try
            {
                return Ok(new APIResponse(true, Constant.Success, "", serviceRequestService.GetServiceRequestListByMember(MemberId)));


            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
        }

        [HttpPost]
        [Route("addservicerequest")]
        public async Task<IActionResult> ManageServiceRequest(ServiceRequestViewModel model)
        {
           
            try
            {
                if (model != null)
                {
                    serviceRequestService.AddServiceRequest(model);
                    return Ok(new APIResponse(true, Constant.Success, "", "Service request created successfully!"));
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Service request creation failed! Please check request details and try again." });


            }
            catch (Exception ex)
            {

                return Ok(new APIResponse(false, Constant.Error, "", ex));
            }
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
