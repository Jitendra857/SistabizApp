using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class ServiceRequestViewModel
    {
        public long RequestId { get; set; }
        public int? RequestType { get; set; }
        public string RequestedFor { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Contributions { get; set; }
        public string Summary { get; set; }
        public string ResumeLink { get; set; }
        public long? MemberId { get; set; }
        public int? Status { get; set; }
        public string RequestStatusTrack { get; set; }
        public string Description { get; set; }
        public string MemberName { get; set; }

    }

    public class ServiceRequestChangeViewModel
    {
        public long RequestId { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }
      
    }
}
