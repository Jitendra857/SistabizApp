using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGoal
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
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }

        public virtual TblMember CreatedByNavigation { get; set; }
    }
}
