using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberPhotoLikeComment
    {
        public long Id { get; set; }
        public long? AttachmentId { get; set; }
        public long? MemberId { get; set; }
        public int? LikeUnlike { get; set; }
        public string Comments { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual TblMemberAttachment Attachment { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
