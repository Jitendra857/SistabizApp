using Microsoft.EntityFrameworkCore;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService:IBLLService
    {
        
        public ServiceRequestViewModel AddServiceRequest(ServiceRequestViewModel serviceRequest)
        {
            if (serviceRequest != null)
            {
                _entityDbContext.TblServiceRequest.Add(Convertor(serviceRequest));
                _entityDbContext.SaveChanges();

                //member earn point
                RedeemPointsViewModel reddem = new RedeemPointsViewModel();
                reddem.MemberId = serviceRequest.MemberId;
                reddem.Description = "Earn Point By Consult A Coach";
                reddem.ReddemPoint = 15;
                RedeemEarnPointOtherActivity(reddem);
               
                return serviceRequest;
            }
            return null;
        }

        public List<ServiceRequestViewModel> GetServiceRequestList()
        {
            var servicerequest = _entityDbContext.TblServiceRequest.Select(e => new ServiceRequestViewModel
            {
                RequestId = e.RequestId,
                RequestType = e.RequestType,
                RequestDate = e.RequestDate,
                Contributions = e.Contributions,
                Summary = e.Summary,
                ResumeLink = e.ResumeLink,
                MemberId = e.MemberId,
                Status = e.Status,
                Description = e.Description,
                RequestStatusTrack = CommanHelper.GetServiceRequestStatus((int)e.Status),
                RequestedFor = CommanHelper.GetServiceRequestFor((int)e.RequestType),
                MemberName=e.Member!=null?e.Member.FirstName+" "+e.Member.LastName:""

            }).ToList();

            return servicerequest;
        }

        public List<ServiceRequestViewModel> GetServiceRequestListByStatus(int Status)
        {
            return ConvertToViewModel(_entityDbContext.TblServiceRequest.Where(r => r.Status == Status).ToList());
        }

        public string AcceptRejectServiceRequest(ServiceRequestChangeViewModel model)
        {
            var result = _entityDbContext.TblServiceRequest.Where(r => r.RequestId == model.RequestId )
                .Include(s=>s.Member)
                .FirstOrDefault();
            if (result != null)
            {
                if(model.Status==3)
                result.Member.RoleId = 1;
                else
                    result.Member.RoleId = result.RequestType;

                result.Status = model.Status;
                result.Description = model.Description;
                _entityDbContext.SaveChanges();
            }

            return Constant.Success;
        }

        public List<ServiceRequestViewModel> GetServiceRequestListByMember(int MemberId)
        {
            return ConvertToViewModel(_entityDbContext.TblServiceRequest.Where(r => r.MemberId == MemberId).ToList());
        }
        public TblServiceRequest GetServiceRequestById(int RequestId)
        {
           return _entityDbContext.TblServiceRequest.Where(e=>e.RequestId== RequestId).FirstOrDefault();

        }


        public TblServiceRequest Convertor(ServiceRequestViewModel model)
        {
           return   new TblServiceRequest()
            {
                RequestType = model.RequestType,
                RequestDate = DateTime.Now,
                Contributions = model.Contributions,
                Summary = model.Summary,
                ResumeLink = model.ResumeLink,
                MemberId = model.MemberId,
                Status = 1,
                Description = model.Description,

            };

        }

        public List<ServiceRequestViewModel> ConvertToViewModel(List<TblServiceRequest> servicerequest)
        {

            return servicerequest.Select(e => new ServiceRequestViewModel
            {
                RequestType = e.RequestType,
                RequestDate = DateTime.Now,
                Contributions = e.Contributions,
                Summary = e.Summary,
                ResumeLink = e.ResumeLink,
                MemberId = e.MemberId,
                Status = e.Status,
                Description = e.Description,
                MemberName = e.Member.FirstName + " " + e.Member.LastName

            }).ToList();

        }
        public void SaveChanges()
        {

            _entityDbContext.SaveChanges();
        }

    }
}
