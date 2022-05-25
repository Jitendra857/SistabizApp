using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class GoalActivityViewModel
    {

        public long GoalId { get; set; }
        public string Title { get; set; }
        public string What { get; set; }
        public string Start { get; set; }
        public string Who { get; set; }
        public string How { get; set; }
        public DateTime? StartDate { get; set; }
         public DateTime? EndDate { get; set; }
        public DateTime? PostponeDate { get; set; }
        public int? Status { get; set; }
        public string StatusName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public List<GoalCategoryViewModel> lstGoalCategory { get; set; } = new List<GoalCategoryViewModel>();
        public List<GoalMachesViewModel> lstGoalMaches { get; set; } = new List<GoalMachesViewModel>();
    }
    public class GoalCategoryViewModel
    {
        public long GoalMappingId { get; set; }
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
      
    }
    public class GoalPostponeViewModel
    {
        public long GoalId { get; set; }
        public DateTime? PostponeDate { get; set; }
    }

    public class GoalCompletedViewModel
    {
        public long GoalId { get; set; }
       public int Status { get; set; }
    }

    public class GoalMachesViewModel
    {
        public long? MemberId { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
    }
}
