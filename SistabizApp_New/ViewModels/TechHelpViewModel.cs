using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class TechHelpViewModel
    {
        public long TechHelpId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BookingDate { get; set; }
        public TimeSpan? BookingTime { get; set; }
        public long? AssignBy { get; set; }
        public string AssignByName { get; set; }
        public long? AssignTo { get; set; }
        public string AssignToName { get; set; }
        public int? Status { get; set; }
        public string StatusName { get; set; }
        public long? CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }

    }

    public class TechHelpRequestViewModel
    {
        public long TechHelpId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BookingDate { get; set; }
        public TimeSpan? BookingTime { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class TechHelpAssignedViewModel
    {
        public long TechHelpId { get; set; }

        public long? AssignBy { get; set; }

        public long? AssignTo { get; set; }
    }
}
