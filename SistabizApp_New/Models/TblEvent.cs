using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblEvent
    {
        public TblEvent()
        {
            TblEventAttachment = new HashSet<TblEventAttachment>();
            TblEventRegisterMember = new HashSet<TblEventRegisterMember>();
        }

        public long EventId { get; set; }
        public string Title { get; set; }
        public string EventName { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long? Country { get; set; }
        public long? State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerPhone { get; set; }
        public string OrganizerWebsite { get; set; }
        public string OrganizerEmail { get; set; }
        public string EventWebsite { get; set; }
        public double? EventCost { get; set; }
        public int? EventStatus { get; set; }
        public DateTime? EventDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public DateTime? EventEndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual ICollection<TblEventAttachment> TblEventAttachment { get; set; }
        public virtual ICollection<TblEventRegisterMember> TblEventRegisterMember { get; set; }
    }
}
