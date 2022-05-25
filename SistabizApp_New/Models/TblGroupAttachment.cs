using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroupAttachment
    {
        public TblGroupAttachment()
        {
            TblAttachmentBookmark = new HashSet<TblAttachmentBookmark>();
        }

        public long AttachmentId { get; set; }
        public long? GroupId { get; set; }
        public string Attachment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DocumnetType { get; set; }

        public virtual TblGroup Group { get; set; }
        public virtual ICollection<TblAttachmentBookmark> TblAttachmentBookmark { get; set; }
    }
}
