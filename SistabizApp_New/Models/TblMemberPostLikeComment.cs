using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberPostLikeComment
    {
        public long AttachmentLikeId { get; set; }
        public long? AttachmentId { get; set; }
        public long? MemberId { get; set; }
        public int? LikeUnlike { get; set; }
        public string Comment { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual TblMemberAttachment Attachment { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
