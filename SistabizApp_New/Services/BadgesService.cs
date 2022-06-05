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
        public List<BadgesViewModel> GetAllBadges()
        {
            var result = _entityDbContext.TblBadges.Select(r => new BadgesViewModel
            {
                BadgesId=r.BadgesId,
                BadgesName=r.BadgesName,
                ImgaeUrl = Constant.livebaseurl + "Badges/" + r.Image,

            }).ToList();
            return result;
        }

        public List<BadgesViewModel> GetAllBadgesByMember(int memberid=0)
        {
            var assignbadgesmember = _entityDbContext.TblBadgesAssignMember.Where(r => r.MemberId == memberid)
                .Include(k=>k.Badges)
                .ToList();

            var result = assignbadgesmember.Select(r => new BadgesViewModel
            {
                BadgesId = r.Badges.BadgesId,
                BadgesName = r.Badges.BadgesName,
                ImgaeUrl = Constant.livebaseurl + "Badges/" + r.Badges.Image,

            }).ToList();
            return result;
        }

        public string ManageBadges(BadgesViewModel model)
        {
            TblBadges badges = new TblBadges();
            if (model.BadgesId > 0)
                badges = GetbadgesById((int)model.BadgesId);
            badges.BadgesName = model.BadgesName;
            badges.Image = model.ImgaeUrl;
            badges.CreatedBy = model.CreatedBy;
            badges.CreatedOn = DateTime.Now;
            badges.IsDeleted = false;
            if (model.BadgesId == 0)
                _entityDbContext.TblBadges.Add(badges);
                _entityDbContext.SaveChanges();

            return Constant.Success;
        }

        public string BadgesAssignMember(BadgesAssignViewMidel model)
        {
            TblBadgesAssignMember badges = new TblBadgesAssignMember();
            if (model.BadgesAssignId > 0)
                badges = GetbadgesassignById((int)model.BadgesAssignId);
            badges.BadgesId = model.BadgesId;
            badges.MemberId = model.MemberId;
          
            badges.AssginDate = DateTime.Now;
           
            if (model.BadgesAssignId == 0)
                _entityDbContext.TblBadgesAssignMember.Add(badges);
            _entityDbContext.SaveChanges();

            return Constant.Success;
        }

        public string RemoveBadges(int badgesid = 0)
        {
            if (badgesid > 0)
            {
                var result= GetbadgesById((int)badgesid);
                if (result != null)
                {
                    _entityDbContext.TblBadges.Remove(result);
                    _entityDbContext.SaveChanges();
                }
            }
            return Constant.Success;
        }
        public TblBadgesAssignMember GetbadgesassignById(int badgesid = 0)
        {
            return _entityDbContext.TblBadgesAssignMember.Where(e => e.BadgesAssignId == badgesid).FirstOrDefault();
        }

        public TblBadges GetbadgesById(int badgesid=0)
        {
            return _entityDbContext.TblBadges.Where(e => e.BadgesId == badgesid).FirstOrDefault();
        }
    }
}
