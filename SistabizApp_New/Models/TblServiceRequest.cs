using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblServiceRequest
    {
        public long RequestId { get; set; }
        public int? RequestType { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Contributions { get; set; }
        public string Summary { get; set; }
        public string ResumeLink { get; set; }
        public long? MemberId { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }

        public virtual TblMember Member { get; set; }
    }
}
