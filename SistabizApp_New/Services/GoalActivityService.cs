using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService
    {

        public List<GoalActivityViewModel> GetAllGoalAndActivity(int memberid)
        {
            return _entityDbContext.TblGoal.Where(e => e.CreatedBy == memberid && e.IsDeleted != true).Select(r => new GoalActivityViewModel
            {
                Title=r.Title,
                GoalId=r.GoalId,
                What = r.What,
                Start = r.Start,
                CreatedBy = r.CreatedBy,
                Who = r.Who,
                How = r.How,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                PostponeDate = r.PostponeDate,
                Status = r.Status,

            }).ToList();
        }

        public string ManageGoalActivity(GoalActivityViewModel model)
        {
            TblGoal goal = new TblGoal();
            if (model.GoalId > 0)
                goal = GetGoalById((int)model.GoalId);
            goal.Title = model.Title;
            goal.What = model.What;
            goal.Start = model.Start;
            goal.CreatedBy = model.CreatedBy;
            goal.Who = model.Who;
            goal.How = model.How;
            goal.StartDate = model.StartDate;
            goal.EndDate = model.EndDate;
            goal.PostponeDate = model.PostponeDate;
            goal.Status = model.Status;
            goal.IsActive = true;
            goal.IsDeleted = false;



            if (model.GoalId == 0)
                _entityDbContext.TblGoal.Add(goal);

            _entityDbContext.SaveChanges();
            return "Success";
        }

        public string GoalPostpone(GoalPostponeViewModel model)
        {
            TblGoal goal = new TblGoal();
            if (model.GoalId > 0)
                goal = GetGoalById((int)model.GoalId);
            goal.PostponeDate = model.PostponeDate;
            _entityDbContext.SaveChanges();
            return "Success";
        }

        public string RemoveGoal(int goalid)
        {
            var goal = GetGoalById(goalid);
            if (goal != null)
            {
                goal.IsDeleted = true;
                _entityDbContext.SaveChanges();
            }
            return "Success";
        }

        public TblGoal GetGoalById(int goalid)
        {
            return _entityDbContext.TblGoal.Where(e => e.GoalId == goalid).FirstOrDefault();
        }
    }
}
