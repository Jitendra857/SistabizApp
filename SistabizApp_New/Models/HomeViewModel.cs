using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Models
{
    public class HomeViewModel
    {
        public List<MemberViewModel> lstmemberlist = new List<MemberViewModel>();

        public List<GroupViewModel> lstGrouplist { get; set; } = new List<GroupViewModel>();
       public List<GoalActivityViewModel> lstGoalActivity { get; set; } = new List<GoalActivityViewModel>();
    }
}
