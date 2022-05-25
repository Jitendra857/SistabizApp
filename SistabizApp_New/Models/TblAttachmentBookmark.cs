using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblAttachmentBookmark
    {
        public long BookmarkId { get; set; }
        public long? AttachmentId { get; set; }
        public long? MemberId { get; set; }

        public virtual TblGroupAttachment Attachment { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
