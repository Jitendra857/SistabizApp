using Microsoft.EntityFrameworkCore;
using SistabizApp_New.Helper;
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

        public List<GoalActivityViewModel> GetAllGoalAndActivity(int memberid, string year=null)
        {
            if (!string.IsNullOrEmpty(year))
            {
                int yearofnumber = Convert.ToInt32(year);
                var result = _entityDbContext.TblGoal.Where(e => e.IsDeleted != true && e.CreatedBy == memberid)
               .Include(s => s.TblGoalMaches)
               .ThenInclude(s => s.Member)
                .Include(s => s.TblGoalCategoryMapping)
                .ThenInclude(s => s.Category)
               .ToList();

                return result.Where(e => Convert.ToDateTime(e.StartDate).Year == yearofnumber).Select(r => new GoalActivityViewModel
                {
                    Title = r.Title,
                    GoalId = r.GoalId,
                    What = r.What,
                    Start = r.Start,
                    CreatedBy = r.CreatedBy,
                    Who = r.Who,
                    How = r.How,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    PostponeDate = r.PostponeDate,
                    Status = r.Status,
                    StatusName = r.Status == 1 ? "Pending" : "Completed",
                    lstGoalCategory = r.TblGoalCategoryMapping.Count > 0 ? r.TblGoalCategoryMapping.Select(t => new GoalCategoryViewModel
                    {
                        GoalMappingId = t.GoalMappingId,
                        CategoryId = t.CategoryId,
                        CategoryName = t.Category.CategoryName
                    }).ToList() : null,
                    lstGoalMaches = r.TblGoalMaches.Count > 0 ? r.TblGoalMaches.Select(y => new GoalMachesViewModel
                    {
                        MemberId = y.MemberId,
                        Name = y.Member.FirstName + " " + y.Member.LastName,
                        ProfileImage = y.Member != null ? Constant.livebaseurl + "Profiles/" + y.Member.ProfileImage : null,
                    }).ToList() : null

                }).ToList();
            }
            else
            {
                var result = _entityDbContext.TblGoal.Where(e => e.CreatedBy == memberid && e.IsDeleted != true)
   .Include(s => s.TblGoalMaches)
   .ThenInclude(s => s.Member)
    .Include(s => s.TblGoalCategoryMapping)
    .ThenInclude(s => s.Category)
   .ToList();
                return result.Select(r => new GoalActivityViewModel
                {
                    Title = r.Title,
                    GoalId = r.GoalId,
                    What = r.What,
                    Start = r.Start,
                    CreatedBy = r.CreatedBy,
                    Who = r.Who,
                    How = r.How,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    PostponeDate = r.PostponeDate,
                    Status = r.Status,
                    StatusName = r.Status == 1 ? "Pending" : "Completed",
                    lstGoalCategory = r.TblGoalCategoryMapping.Count > 0 ? r.TblGoalCategoryMapping.Select(t => new GoalCategoryViewModel
                    {
                        GoalMappingId = t.GoalMappingId,
                        CategoryId = t.CategoryId,
                        CategoryName = t.Category.CategoryName
                    }).ToList() : null,
                    lstGoalMaches = r.TblGoalMaches.Count > 0 ? r.TblGoalMaches.Select(y => new GoalMachesViewModel
                    {
                        MemberId = y.MemberId,
                        Name = y.Member.FirstName + " " + y.Member.LastName,
                        ProfileImage = y.Member != null ? Constant.livebaseurl + "Profiles/" + y.Member.ProfileImage : null,
                    }).ToList() : null

                }).OrderByDescending(t => t.GoalId).ToList();
            }
           

           
        }

        public List<GoalActivityViewModel> GetAllGoalAndActivityByDate(string year)
        {
            int yearofnumber = Convert.ToInt32(year);

            var result = _entityDbContext.TblGoal.Where(e => e.IsDeleted != true)
                .Include(s => s.TblGoalMaches)
                .ThenInclude(s => s.Member)
                 .Include(s => s.TblGoalCategoryMapping)
                 .ThenInclude(s => s.Category)
                .ToList();

            return result.Where(e => Convert.ToDateTime(e.StartDate).Year == yearofnumber).Select(r => new GoalActivityViewModel
            {
                Title = r.Title,
                GoalId = r.GoalId,
                What = r.What,
                Start = r.Start,
                CreatedBy = r.CreatedBy,
                Who = r.Who,
                How = r.How,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                PostponeDate = r.PostponeDate,
                Status = r.Status,
                StatusName = r.Status == 1 ? "Pending" : "Completed",
                lstGoalCategory = r.TblGoalCategoryMapping.Count > 0 ? r.TblGoalCategoryMapping.Select(t => new GoalCategoryViewModel
                {
                    GoalMappingId = t.GoalMappingId,
                    CategoryId = t.CategoryId,
                    CategoryName = t.Category.CategoryName
                }).ToList() : null,
                lstGoalMaches = r.TblGoalMaches.Count > 0 ? r.TblGoalMaches.Select(y => new GoalMachesViewModel
                {
                    MemberId = y.MemberId,
                    Name = y.Member.FirstName + " " + y.Member.LastName,
                    ProfileImage = y.Member != null ? Constant.livebaseurl + "Profiles/" + y.Member.ProfileImage : null,
                }).ToList() : null

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
            goal.PostponeDate = model.EndDate;
            goal.Status = 1;
            goal.IsActive = true;
            goal.IsDeleted = false;

            if (model.GoalId == 0)
                _entityDbContext.TblGoal.Add(goal);

            _entityDbContext.SaveChanges();
            ManageGoalMaches((int)goal.CreatedBy, goal.Title);
            return "Success";
        }


        public string ManageGoalMaches(int? memberid, string message)
        {
            var checkgoalmach = _entityDbContext.TblGoal.Where(e => e.Title.ToLower().Contains(message.ToLower()) && e.CreatedBy != memberid).FirstOrDefault();
            if (checkgoalmach != null)
            {
                TblGoalMaches mach = new TblGoalMaches();
                mach.GoalId = checkgoalmach.GoalId;
                mach.MemberId = memberid;
                _entityDbContext.TblGoalMaches.Add(mach);
                _entityDbContext.SaveChanges();
            }

            return Constant.Success;
        }

        public string GoalPostpone(GoalPostponeViewModel model)
        {
            TblGoal goal = new TblGoal();
            if (model.GoalId > 0)
                goal = GetGoalById((int)model.GoalId);
            goal.EndDate = goal.PostponeDate;
            goal.PostponeDate = model.PostponeDate;
            _entityDbContext.SaveChanges();
            return "Success";
        }

        public string GoalCompleted(GoalCompletedViewModel model)
        {
            TblGoal goal = new TblGoal();
            if (model.GoalId > 0)
                goal = GetGoalById((int)model.GoalId);
            goal.Status = model.Status;
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
