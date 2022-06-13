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

        public List<RedeemPointsDetailsViewModel> GetAllRedeemPoint()
        {
            var redeempointlist = _entityDbContext.TblReddemPoints
                .Include(e => e.Member)
                .Include(e => e.ReddemByNavigation)
                .Include(e => e.ReferToNavigation)
                .ToList();

           return redeempointlist.Select(r => new RedeemPointsDetailsViewModel
            {
                ReddemId=r.ReddemId,
                MemberId=r.MemberId,
                RedeemByName= r.MemberId!=null? r.Member.FirstName+" "+r.Member.LastName:"",
                ReddemBy = r.ReddemBy,
                RedeemToName = r.ReddemBy!=null? r.ReddemByNavigation.FirstName + " " + r.ReddemByNavigation.LastName:"",
                ReferTo = r.ReferTo,
                RedeemReferName = r.ReferTo!=null? r.ReferToNavigation.FirstName + " " + r.ReferToNavigation.LastName:"",
                ReddemPoint = r.ReddemPoint,
                Description = r.Description,
                CreateOn = r.CreateOn,
               Status = r.Status,
               IsAccept =r.Status==2?true:false
              
            }).ToList();
        }

        public MemberErnsPointModel GetAllRedeemPointByMember(int memberid=0)
        {
            MemberErnsPointModel obj = new MemberErnsPointModel();

            var redeempointlist = _entityDbContext.TblReddemPoints.Where(e=>e.MemberId==memberid)
                .Include(e => e.Member)
                .Include(e => e.ReddemByNavigation)
                .Include(e => e.ReferToNavigation)
                .ToList();
            obj.TotalEarnsPoint = redeempointlist.Select(t => t.ReddemPoint).Sum();

            obj.lstEarnsPoint= redeempointlist.Select(r => new RedeemPointsDetailsViewModel
            {
                ReddemId = r.ReddemId,
                MemberId = r.MemberId,
                RedeemByName = r.MemberId != null ? r.Member.FirstName + " " + r.Member.LastName : "",
                ReddemBy = r.ReddemBy,
                RedeemToName = r.ReddemBy != null ? r.ReddemByNavigation.FirstName + " " + r.ReddemByNavigation.LastName : "",
                ReferTo = r.ReferTo,
                RedeemReferName = r.ReferTo != null ? r.ReferToNavigation.FirstName + " " + r.ReferToNavigation.LastName : "",
                ReddemPoint = r.ReddemPoint,
              
                Description = r.Description,
                CreateOn = r.CreateOn,
                Status = r.Status,
                IsAccept = r.Status == 2 ? true : false

            }).ToList();

            return obj;
        }

        public string RedeemEarnPointRequest(RedeemPointsViewModel model)
        {
            TblReddemPoints redeem = new TblReddemPoints();
            redeem.MemberId = model.MemberId;
            redeem.ReddemBy = model.ReddemBy;
            redeem.ReddemPoint = model.ReddemPoint;
            redeem.Status = 1;
            redeem.Description = "Redeem Point Earn Request" ;
            redeem.CreateOn = DateTime.Now;
            _entityDbContext.TblReddemPoints.Add(redeem);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public string AcceptReferRedeemRequest(RedeemPointsViewModel model)
        {
            TblReddemPoints redeem = new TblReddemPoints();
            if (model.IsAccept == true)
            {
                var checkmemberredeempoint = _entityDbContext.TblReddemPoints.Where(r => r.MemberId == model.MemberId).ToList();

                if (checkmemberredeempoint.Count() == 1 && checkmemberredeempoint!=null)
                {

                    redeem = new TblReddemPoints();
                    redeem.MemberId = model.MemberId;
                    redeem.ReddemBy = model.ReddemBy;
                    redeem.ReddemPoint = 100;
                    redeem.Status = 0;
                    redeem.Description = "First Time Redeem Point Earn Extra";
                    redeem.CreateOn = DateTime.Now;
                    _entityDbContext.TblReddemPoints.Add(redeem);
                    _entityDbContext.SaveChanges();
                    
                }

                var getredeem = _entityDbContext.TblReddemPoints.Where(t => t.ReddemId == model.ReddemId).FirstOrDefault();

                redeem = new TblReddemPoints();
                redeem.MemberId = getredeem.ReddemBy;

                int point = -Convert.ToInt32(getredeem.ReddemPoint);
                redeem.ReddemPoint = point;
                redeem.Status = 0;
                redeem.Description = "";
                redeem.CreateOn = DateTime.Now;
                _entityDbContext.TblReddemPoints.Add(redeem);
                _entityDbContext.SaveChanges();

                getredeem.Status = 2;
                _entityDbContext.SaveChanges();
            }
            //TblReddemPoints redeem = new TblReddemPoints();
            //redeem.MemberId = model.MemberId;
            //redeem.ReddemBy = model.ReddemBy;
            //redeem.ReddemPoint = model.ReddemPoint;
            //redeem.Status = 1;
            //redeem.Description = "Redeem Point Earn Request";
            //redeem.CreateOn = DateTime.Now;
            //_entityDbContext.TblReddemPoints.Add(redeem);
            //_entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public TblReddemPoints GetRedeemDetailsByMember(int memberid)
        {
            return _entityDbContext.TblReddemPoints.Where(r => r.MemberId == memberid).FirstOrDefault();
        }
    }
}
