using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.IServices
{
  public interface IServiceRequestService
    {
        ServiceRequestViewModel AddServiceRequest(ServiceRequestViewModel serviceRequest);
        List<ServiceRequestViewModel> GetServiceRequestList();
        TblServiceRequest GetServiceRequestById(int RequestId);

        List<ServiceRequestViewModel> GetServiceRequestListByStatus(int Status);
        List<ServiceRequestViewModel> GetServiceRequestListByMember(int MemberId);
        void SaveChanges();
    }
}
