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
    public class CountryStateController : ControllerBase
    {
        private readonly IBLLService countrystateService;

        public CountryStateController(IBLLService countrystateservice)
        {
            countrystateService = countrystateservice;
        }

        [HttpGet]
        [Route("getallcountry")]
        public async Task<IActionResult> GetAllCountry()
        {

            return Ok(new APIResponse(true, Constant.Success, "country list", countrystateService.GetAllCountry()));
        }
        [HttpGet]
        [Route("getalstate")]
        public async Task<IActionResult> GetAllstate()
        {

            return Ok(new APIResponse(true, Constant.Success, "state list", countrystateService.GetAllState()));
        }
        [HttpGet]
        [Route("getstatebycountry")]
        public async Task<IActionResult> GetStateByCountry(int countryid)
        {

            return Ok(new APIResponse(true, Constant.Success, "country by state list", countrystateService.GetStateByCountry(countryid)));
        }

    }
}
