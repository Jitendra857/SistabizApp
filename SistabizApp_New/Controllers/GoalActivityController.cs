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
    [ModulePermission(new[] { PermissionEnum.Modules.GoalActivity })]
    public class GoalActivityController : ControllerBase
    {

        private readonly IBLLService goalactivityService;

        public GoalActivityController(IBLLService goalactivityservice)
        {
            goalactivityService = goalactivityservice;
        }

        [HttpGet]
        [Route("geallgoalactivity")]
        public async Task<IActionResult> GetAllGoalActivityList(int memberid, string year = null)
        {

            return Ok(new APIResponse(true, Constant.Success, "goal and activity list", goalactivityService.GetAllGoalAndActivity(memberid, year)));
        }

        //[HttpGet]
        //[Route("geallgoalactivitybydate")]
        //public async Task<IActionResult> GetAllGoalActivityListByDate(string year)
        //{

        //    return Ok(new APIResponse(true, Constant.Success, "goal and activity list", goalactivityService.GetAllGoalAndActivityByDate(year)));
        //}



        [HttpPost]
        [Route("addupdategoalactivity")]
        public async Task<IActionResult> ManageGoalActivity(GoalActivityViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "goal and activity updated successfully", goalactivityService.ManageGoalActivity(model)));
        }

        [HttpPost]
        [Route("goalpostpone")]
        public async Task<IActionResult> GoalPostpone(GoalPostponeViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "goal postpone successfully", goalactivityService.GoalPostpone(model)));
        }

        [HttpPost]
        [Route("goalactivitycompleted")]
        public async Task<IActionResult> CompletedGoalAndActivity(GoalCompletedViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "goal completede successfully", goalactivityService.GoalCompleted(model)));
        }

        [HttpGet]
        [Route("deletegoalactivity")]
        public async Task<IActionResult> DeleteGoalActivity(int goalid)
        {

            return Ok(new APIResponse(true, Constant.Success, "goals and activity deleted", goalactivityService.RemoveGoal(goalid)));
        }
    }
}
