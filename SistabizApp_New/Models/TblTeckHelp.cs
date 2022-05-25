using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblTeckHelp
    {
        public long TechHelpId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BookingDate { get; set; }
        public TimeSpan? BookingTime { get; set; }
        public long? AssignBy { get; set; }
        public long? AssignTo { get; set; }
        public int? Status { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual TblMember AssignByNavigation { get; set; }
        public virtual TblMember AssignToNavigation { get; set; }
        public virtual TblMember CreatedByNavigation { get; set; }
    }
}
