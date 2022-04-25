using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblEventAttachment
    {
        public long EventAttachmentId { get; set; }
        public long? EventId { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual TblEvent Event { get; set; }
    }
}
