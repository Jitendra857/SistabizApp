using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberAttachment
    {
        public TblMemberAttachment()
        {
            TblMemberPhotoLikeComment = new HashSet<TblMemberPhotoLikeComment>();
            TblMemberPostLikeComment = new HashSet<TblMemberPostLikeComment>();
        }

        public long AttachmentId { get; set; }
        public string PhotoVideoUrl { get; set; }
        public long? MemberId { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblMember Member { get; set; }
        public virtual ICollection<TblMemberPhotoLikeComment> TblMemberPhotoLikeComment { get; set; }
        public virtual ICollection<TblMemberPostLikeComment> TblMemberPostLikeComment { get; set; }
    }
}
