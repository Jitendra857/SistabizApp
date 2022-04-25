using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblFundingResources
    {
        public long FundingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public long? CategoryId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblFundingCategory Category { get; set; }
    }
}
