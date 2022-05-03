using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblPostAttachment
    {
        public long PostAttachmentId { get; set; }
        public string FileName { get; set; }
        public long? PostId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblPost Post { get; set; }
    }
}
