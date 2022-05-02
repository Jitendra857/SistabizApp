using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGroupAttachment
    {
        public long AttachmentId { get; set; }
        public long? GroupId { get; set; }
        public string Attachment { get; set; }

        public virtual TblGroup Group { get; set; }
    }
}
