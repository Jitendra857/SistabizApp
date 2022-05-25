using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroupDiscussion
    {
        public long DiscussionId { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? MessageBy { get; set; }
        public long? GroupId { get; set; }

        public virtual TblGroup Group { get; set; }
        public virtual TblMember MessageByNavigation { get; set; }
    }
}
