using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Models
{
    public class HomeViewModel
    {
        public List<MemberViewModel> lstmemberlist = new List<MemberViewModel>();

        public List<EventResponseViewModel> lsteventlist = new List<EventResponseViewModel>();
        public List<ServiceRequestViewModel> lstservicerequestlist = new List<ServiceRequestViewModel>();
    }
}
