using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class EventViewModel
    {

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
        public string EventStatusTrack { get; set; }
        public DateTime? EventDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public DateTime? EventEndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int EventType { get; set; }
        public string EventLink { get; set; }
        public List<IFormFile> Image { get; set; } = new List<IFormFile>();
        public bool IsUpdateAttachment { get; set; }

        public List<EventAttachment> lstEventAttachment { get; set; } = new List<EventAttachment>();

    }

    public class EventResponseViewModel
    {

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
        public string EventStatusTrack { get; set; }
        public DateTime? EventDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public DateTime? EventEndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        public long? CreatedBy { get; set; }
        public string CreatedByMember { get; set; }
        public DateTime? CreatedOn { get; set; }
       public int Attendee { get; set; }
        public long EventAttachmentId { get; set; }
        public bool IsBookmark { get; set; }
        public List<EventAttachment> lstEventAttachment { get; set; } = new List<EventAttachment>();
        public List<EventJoinMemberViewModel> lstEventJoinMembers { get; set; } = new List<EventJoinMemberViewModel>();

    }
    public class EventJoinMemberViewModel
    {
        public long JoinId { get; set; }
        
        public string MemberName { get; set; }
        public long? JoinMemberId { get; set; }
      
        public string MemberProfile { get; set; }
    }
    public class EventFilterViewModel
    {
        public long? Type { get; set; }
       
        public int Ordering { get; set; } = 0;
        public long? MemberiD { get; set; }
    }
    public class EventBookmarkViewModel
    {
        public long BookmarkId { get; set; }
        public long? MemberId { get; set; }
      
        public long? EventId { get; set; }
    }

    public class RegisterMemberEventViewModel
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? RegisterMemberId { get; set; }
        public int Status { get; set; }


    }

    public class EventAttachment
    {
        public long EventAttachmentId { get; set; }
        public long? EventId { get; set; }
        public string FileName { get; set; }
       

    }
}
