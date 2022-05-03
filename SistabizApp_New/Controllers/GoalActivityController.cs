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
    public class GoalActivityController : ControllerBase
    {

        private readonly IBLLService goalactivityService;

        public GoalActivityController(IBLLService goalactivityservice)
        {
            goalactivityService = goalactivityservice;
        }

        [HttpGet]
        [Route("geallgoalactivity")]
        public async Task<IActionResult> GetAllGoalActivityList(int memberid)
        {

            return Ok(new APIResponse(true, Constant.Success, "goal and activity list", goalactivityService.GetAllGoalAndActivity(memberid)));
        }

       

        [HttpPost]
        [Route("addupdategoalactivity")]
        public async Task<IActionResult> ManageGoalActivity(GoalActivityViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "goal and activity updated successfully", goalactivityService.ManageGoalActivity(model)));
        }

        [HttpGet]
        [Route("deletegoalactivity")]
        public async Task<IActionResult> DeleteGoalActivity(int goalid)
        {

            return Ok(new APIResponse(true, Constant.Success, "goals and activity deleted", goalactivityService.RemoveGoal(goalid)));
        }
    }
}
