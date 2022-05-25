using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {


        private readonly IBLLService TestimonialsService;

        public TestimonialsController(IBLLService testimonialsservice)
        {
            TestimonialsService = testimonialsservice;
        }


        [HttpGet]
        [Route("getallestimonials")]
        public async Task<IActionResult> GetAllTestimonials(int memberid)
        {

            return Ok(new APIResponse(true, Constant.Success, "group list", TestimonialsService.getAllTestimonialsList(memberid)));
        }
    }
}
