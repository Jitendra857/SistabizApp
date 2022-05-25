using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class TestimonialsViewModel
    {

        public long TestimonialId { get; set; }
        public string Quotes { get; set; }
        public long? MemberId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPublish { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

    public class TestimonialsResponseViewModel
    {

        public long TestimonialId { get; set; }
        public string Quotes { get; set; }
        public long? MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberProfile { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<DesignationViewModel> lstdesignation { get; set; } = new List<DesignationViewModel>();
    }

    public class DesignationViewModel
    {

        public long DesignationId { get; set; }
        public string Designation { get; set; }
       
    }
}
