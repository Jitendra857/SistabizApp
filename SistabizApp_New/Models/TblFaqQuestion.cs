using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblFaqQuestion
    {
        public long FaqQuestionId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public long? MemberId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblMember Member { get; set; }
    }
}
