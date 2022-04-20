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
    public class ServiceRequestService: IServiceRequestService
    {
        SistabizAppContext dbContext;

        public ServiceRequestService(SistabizAppContext _db)
        {
            dbContext = _db;
        }
        public ServiceRequestViewModel AddServiceRequest(ServiceRequestViewModel serviceRequest)
        {
            if (serviceRequest != null)
            {
                dbContext.TblServiceRequest.Add(Convertor(serviceRequest));
                dbContext.SaveChanges();
                return serviceRequest;
            }
            return null;
        }

        public List<ServiceRequestViewModel> GetServiceRequestList()
        {
            var servicerequest = dbContext.TblServiceRequest.Select(e => new ServiceRequestViewModel
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
                RequestedFor = CommanHelper.GetServiceRequestFor((int)e.RequestType)

            }).ToList();

            return servicerequest;
        }

        public List<ServiceRequestViewModel> GetServiceRequestListByStatus(int Status)
        {
            return ConvertToViewModel(dbContext.TblServiceRequest.Where(r => r.Status == Status).ToList());
        }

        public List<ServiceRequestViewModel> GetServiceRequestListByMember(int MemberId)
        {
            return ConvertToViewModel(dbContext.TblServiceRequest.Where(r => r.MemberId == MemberId).ToList());
        }
        public TblServiceRequest GetServiceRequestById(int RequestId)
        {
           return dbContext.TblServiceRequest.Where(e=>e.RequestId== RequestId).FirstOrDefault();

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
                Status = model.Status,
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
                //MemberName = e.Member.FirstName + " " + e.Member.LastName

            }).ToList();

        }
        public void SaveChanges()
        {
          
                dbContext.SaveChanges();
        }

    }
}
