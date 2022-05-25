using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblFundingSection
    {
        public long FundingSectionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
