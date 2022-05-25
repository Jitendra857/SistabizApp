using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberGoal
    {
        public long GoalId { get; set; }
        public string GoalName { get; set; }
        public long? MemberId { get; set; }

        public virtual TblMember Member { get; set; }
    }
}
