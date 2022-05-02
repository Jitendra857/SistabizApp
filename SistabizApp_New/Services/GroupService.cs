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

        public List<GroupViewModel> GetGroupList()
        {
            var eventdetails = _entityDbContext.TblGroup.Select(e => new GroupViewModel
            {
                GroupId = e.GroupId,
                GroupName = e.GroupName,
                Description = e.Description,
                CreatedBy = e.CreatedBy,
                CreatedOn = e.CreatedOn,
                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreateByName=e.CreatedByNavigation.FirstName+" "+e.CreatedByNavigation.LastName,

                //lstEventAttachment = e.TblEventAttachment.Count > 0 ? e.TblEventAttachment.Select(r => new EventAttachment {
                //    EventAttachmentId=r.EventAttachmentId,
                //    EventId=r.EventId,
                //    FileName=r.FileName
                //}).ToList():null,
                JoiningTotalMembers = e.TblGroupJoinMember.Count,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

            return eventdetails;
        }

        public long ManageGroup(GroupViewModel model)
        {
            TblGroup group = new TblGroup();
            if (model.GroupId > 0)
                group = GetById((int)model.GroupId);

            group.GroupName = model.GroupName;
            group.Description = model.Description;
            group.CreatedBy = model.CreatedBy;
            group.CreatedOn = DateTime.Now;
            group.IsActive = true;
            group.IsDeleted = false;
           

           
            if (model.GroupId == 0)
                _entityDbContext.TblGroup.Add(group);

            _entityDbContext.SaveChanges();
            return group.GroupId;
        }


        public string UploadGroupAttachment(List<TblGroupAttachment> attchment)
        {

            _entityDbContext.TblGroupAttachment.AddRange(attchment);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }
        public GroupJoinMemberViewModel GroupJoinMembers(GroupJoinMemberViewModel model)
        {
            TblGroupJoinMember joinmember = new TblGroupJoinMember();
            joinmember.GroupId = model.GroupId;
            joinmember.JoinMemberId = model.JoinMemberId;
            if (string.IsNullOrEmpty(model.LeavingDate.ToString()))
            {
                joinmember.JoinDate =Convert.ToDateTime(model.JoinDate);
                joinmember.IsActive = true;
            }
            else
            {
                joinmember.LeavingDate = Convert.ToDateTime(model.LeavingDate);
                joinmember.IsActive = false;
            }
                
            _entityDbContext.TblGroupJoinMember.Add(joinmember);

            _entityDbContext.SaveChanges();
            return model;
        }

        public string RemoveGroup(int groupid)
        {
            var group = GetById(groupid);
            if (group != null)
            {
                group.IsDeleted = true;
                _entityDbContext.SaveChanges();
            }
            return "Success";
        }

        public TblGroup GetById(int groupid)
        {
            return _entityDbContext.TblGroup.Where(e => e.GroupId == groupid).FirstOrDefault();
        }

    }
}
