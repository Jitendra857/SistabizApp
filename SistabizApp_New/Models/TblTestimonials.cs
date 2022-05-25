using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblTestimonials
    {
        public long TestimonialId { get; set; }
        public string Quotes { get; set; }
        public long? MemberId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPublish { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual TblMember Member { get; set; }
    }
}
