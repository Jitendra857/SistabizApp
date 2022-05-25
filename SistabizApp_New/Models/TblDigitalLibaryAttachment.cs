using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblDigitalLibaryAttachment
    {
        public long LibraryAttachmentId { get; set; }
        public long? DigitalLibaryId { get; set; }
        public string FileName { get; set; }

        public virtual TblDigitalLibrary DigitalLibary { get; set; }
    }
}
