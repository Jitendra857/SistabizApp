using Microsoft.EntityFrameworkCore;
using SistabizApp_New.Helper;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService
    {

        public string ManageBreakThrough(TblBreakthrough breakthrough)
        {
          
            _entityDbContext.TblBreakthrough.Add(breakthrough);
            _entityDbContext.SaveChanges();

            return Constant.Success;
        }

        public List<BreathroughModel> GetAllBreakThroughList()
        {
            var result = _entityDbContext.TblBreakthrough
                 .Include(s => s.Member)
                  .ThenInclude(s => s.TblUserSubscription)
                 .Include(s=>s.SubscriptionTypeNavigation)
                
              .ToList();


            return result.Select(e => new BreathroughModel
            {
                BreakthroughId=e.BreakthroughId,
                ConsultingDate=e.ConsultingDate,
                Status=e.Status,
                MemberId=e.MemberId,
                IsEmailSent=e.IsEmailSent,
                MemberName=e.Member!=null?e.Member.FirstName+" "+e.Member.LastName:null,
                SubscriptionType=e.SubscriptionType,
                SubscriptionName = e.SubscriptionTypeNavigation != null ? e.SubscriptionTypeNavigation.SubscriptionName : null,
                IsActive=e.Member.TblUserSubscription.FirstOrDefault()!=null? (bool) e.Member.TblUserSubscription.FirstOrDefault().IsActive:false,

            }).ToList();
        }

        public BreathroughModel GetAllBreakThroughListById(int id)
        {
            var result = _entityDbContext.TblBreakthrough.Where(t=>t.BreakthroughId==id)
                 .Include(s => s.Member)
                  .ThenInclude(s => s.TblUserSubscription)
                 .Include(s => s.SubscriptionTypeNavigation)

              .ToList();


            return result.Select(e => new BreathroughModel
            {
                BreakthroughId = e.BreakthroughId,
                ConsultingDate = e.ConsultingDate,
                Status = e.Status,
                MemberId = e.MemberId,
                MemberName = e.Member != null ? e.Member.FirstName + " " + e.Member.LastName : null,
                SubscriptionType = e.SubscriptionType,
                SubscriptionName = e.SubscriptionTypeNavigation != null ? e.SubscriptionTypeNavigation.SubscriptionName : null,
                IsActive = e.Member.TblUserSubscription.FirstOrDefault() != null ? (bool)e.Member.TblUserSubscription.FirstOrDefault().IsActive : false,

            }).FirstOrDefault();
        }

        public string UpdateBreakthrough(int id)
        {
            var result = _entityDbContext.TblBreakthrough.Where(e => e.BreakthroughId == id).FirstOrDefault();
            if (result != null)
            {
                result.IsEmailSent = true;
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }
    }
}
