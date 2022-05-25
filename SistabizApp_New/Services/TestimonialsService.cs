using SistabizApp_New.Helper;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService
    {
        public List<TestimonialsResponseViewModel> getAllTestimonialsList(int memberid)
        {
            return _entityDbContext.TblTestimonials.Where(r => r.IsDeleted != true && r.MemberId== memberid).Select(e => new TestimonialsResponseViewModel
            {
                TestimonialId = e.TestimonialId,
                Quotes = e.Quotes,
                CreatedOn = e.CreatedOn,
                MemberName=e.Member!=null?e.Member.FirstName+" "+e.Member.LastName:null,
                MemberProfile = e.Member != null ? Constant.livebaseurl + "Profiles/" + e.Member.ProfileImage : null,
                lstdesignation=e.Member.TblMemberDesignation.Count>0? e.Member.TblMemberDesignation.Select(t=>new DesignationViewModel
                {
                    DesignationId=t.DesignationId,
                    Designation=t.Designation
                }).ToList():null
            }).ToList();
        }
    }
}
