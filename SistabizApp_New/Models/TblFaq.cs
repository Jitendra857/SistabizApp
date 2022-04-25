using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblFaq
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public long? FaqCategoryId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblFaqCategory FaqCategory { get; set; }
    }
}
