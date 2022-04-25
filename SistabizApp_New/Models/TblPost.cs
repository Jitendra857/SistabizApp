using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblPost
    {
        public long PostId { get; set; }
        public string Post { get; set; }
        public DateTime? CreateOn { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
