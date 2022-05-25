using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGoalMaches
    {
        public long GoalMachId { get; set; }
        public long? GoalId { get; set; }
        public long? MemberId { get; set; }

        public virtual TblGoal Goal { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
