﻿using SistabizApp.Authentication;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.IServices
{
  public  interface IBLLService
    {

        //service proivider
        ServiceRequestViewModel AddServiceRequest(ServiceRequestViewModel serviceRequest);
        List<ServiceRequestViewModel> GetServiceRequestList();
        TblServiceRequest GetServiceRequestById(int RequestId);

        List<ServiceRequestViewModel> GetServiceRequestListByStatus(int Status);
        List<ServiceRequestViewModel> GetServiceRequestListByMember(int MemberId);

        //end service provider

        void SaveChanges();

        //employee

        TblMember AddEmployee(TblMember employee);
        MemberViewModel Updateprofile(MemberViewModel model);

        MemberViewModel GetEmployeeById(int memberid);

        //end employee

        //event 

        List<EventResponseViewModel> GetEventList();

        long ManageEvent(EventViewModel model);

        string UploadEventAttachment(List<TblEventAttachment> attchment);

        RegisterMemberEventViewModel RegisterEventMember(RegisterMemberEventViewModel model);

        string UpdateEventStatus(RegisterMemberEventViewModel model);

        string DeleteEvent(int eventid);

        //end event

        //funding resources
        List<FundingCategoryViewModel> GetAllFundingCategory();

        List<FundingViewModel> GetAllFundingResource();

        string ManageFundingResources(FundingViewModel model);

        string DeleteFundingResource(int fundingid);


        // faq
        List<FaqCategoryViewModel> GetAllFaqCategory();
        List<FaqViewModel> GetAllFaq();

        string ManageFaq(FaqViewModel model);

        string DeleteFaq(int id);

        // post
        List<PostViewModel> GetAllPost();
        string ManagePost(PostViewModel model);
        string DeletePost(int id);
    }
}
