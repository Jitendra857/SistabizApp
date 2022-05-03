using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblPost
    {
        public TblPost()
        {
            TblPostAttachment = new HashSet<TblPostAttachment>();
            TblPostFeedback = new HashSet<TblPostFeedback>();
        }

        public long PostId { get; set; }
        public string Post { get; set; }
        public DateTime? CreateOn { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<TblPostAttachment> TblPostAttachment { get; set; }
        public virtual ICollection<TblPostFeedback> TblPostFeedback { get; set; }
    }
}
