using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroupMeeting
    {
        public long MeetingId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? MeetingType { get; set; }
        public string MeetingPlace { get; set; }
        public string Agenda { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? GroupId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual TblGroup Group { get; set; }
    }
}
