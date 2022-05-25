﻿
using Microsoft.AspNetCore.Mvc;
using SistabizApp_New.Helper;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading.Tasks;

namespace SistabizApp_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [ModulePermission(new[] { PermissionEnum.Rights.BASIC, PermissionEnum.Rights.BOOST, PermissionEnum.Rights.BREAKTHROUGH })] //Check Permission for method
    [ModulePermission(new[] { PermissionEnum.Modules.GROUP })] //Check Permission for method
    public class GroupController : ControllerBase
    {

        private readonly IBLLService groupService;

        public GroupController(IBLLService groupservice)
        {
            groupService = groupservice;
        }

        [HttpGet]
        [Route("getallgroup")]
        public async Task<IActionResult> GetAllGroup(int ordering=0)
        {
            var result = groupService.GetGroupList();
            return Ok(new APIResponse(true, Constant.Success, "group list", ordering==2?result.OrderByDescending(r=>r.GroupId).ToList():result));
        }

        [HttpGet]
        [Route("getgroupdetailsbyid")]
        public async Task<IActionResult> GetGroupDetailsById(int groupid)
        {

            return Ok(new APIResponse(true, Constant.Success, "group list", groupService.GetGroupDetailsById(groupid)));
        }

        [HttpGet]
        [Route("getgroupdetailsbymember")]
        public async Task<IActionResult> GetGroupDetailsByMember(int memberid=0)
        {

            return Ok(new APIResponse(true, Constant.Success, "group list", groupService.GetGroupDetailsByMember(memberid)));
        }

        [HttpGet]
        [Route("getgroupdiscussionlist")]
        public async Task<IActionResult> GetGroupDiscussionList(int groupid = 0)
        {

            return Ok(new APIResponse(true, Constant.Success, "group list", groupService.GetGroupDiscussionList(groupid)));
        }

        [HttpGet]
        [Route("getgroupcategory")]
        public async Task<IActionResult> GetAllGroupCategory()
        {

            return Ok(new APIResponse(true, Constant.Success, "group category list", groupService.GetAllCategory()));
        }



        [HttpPost]
        [Route("getgrouplistbyfilter")]
        public async Task<IActionResult> GetAllGroupByFilter(GroupFilterViewModel model)
        {
            var result = groupService.GetGroupListByFilter(model);
            return Ok(new APIResponse(true, Constant.Success, "group list by filter", model.Ordering == 2 ? result.OrderByDescending(r => r.GroupId).ToList() : result));
            
        }
        [HttpGet]
        [Route("searchgroup")]
        public async Task<IActionResult> SearchGroup(string search)
        {
            var result = groupService.GetGroupListBySearch(search);
            return Ok(new APIResponse(true, Constant.Success, "group list by search", result));
           
        }


        [HttpPost]
        [Route("addupdategroup")]
        public async Task<IActionResult> ManageGroup([FromForm] GroupViewModel model)
        {

            List<TblGroupAttachment> groupattachment = new List<TblGroupAttachment>();
           
                if (model.GroupIcon.Length > 0)
                {
                    var eventfilename = Path.GetFileName(Guid.NewGuid() + "_" + model.GroupIcon.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.GroupIcon, eventfilename);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {

                        model.GroupIcon.CopyTo(fileStream);
                        model.GroupIconPath = eventfilename;
                    }
                }
          
            // add/update event
            long groupid = groupService.ManageGroup(model);

            // upload document

            if (model.GroupId == 0 || model.IsUpdateAttachment == true)
            {
                foreach (var item in model.Image)
                {
                    if (item.Length > 0)
                    {
                        var eventfilename = Path.GetFileName(Guid.NewGuid() + "_" + item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), Constant.Group, eventfilename);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {

                            item.CopyTo(fileStream);
                            groupattachment.Add(new TblGroupAttachment { GroupId = groupid, Attachment = eventfilename,Title=model.Title,Description=model.DocumentDescription });
                        }
                    }
                }
            }

           

            // add/update attachment
            if (groupattachment.Count > 0)
            {
                groupService.UploadGroupAttachment(groupattachment);
            }
            //if (model.lstJoinMembers.Count > 0)
            //{
            //    List<TblGroupJoinMember> lstgroupjoinmembers = new List<TblGroupJoinMember>();
            //    foreach (var item in model.lstJoinMembers)
            //    {
            //        lstgroupjoinmembers.Add(new TblGroupJoinMember { GroupId = groupid, JoinMemberId = item.JoinMemberId, JoinDate = Convert.ToDateTime(item.JoinDate),IsActive=true});

            //    }

            //    groupService.AddGroupMembers(lstgroupjoinmembers);
            //}



            return Ok(new APIResponse(true, Constant.Success, "", "Group Added successfully"));
        }

        [HttpPost]
        [Route("groupjoinmember")]
        public async Task<IActionResult> GroupJoinMember(GroupJoinMemberViewModel model)
        {
            var result = groupService.GroupJoinMembers(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Group join by member sucessfully"));
        }

        [HttpPost]
        [Route("groupbookmark")]
        public async Task<IActionResult> GroupBookmark(GroupBookmarkViewModel model)
        {
            var result = groupService.GroupBookmark(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Group "+ result + " sucessfully"));
        }

        [HttpPost]
        [Route("groupattachmentbookmark")]
        public async Task<IActionResult> GroupAttachmentBookmark(GroupAttachmentBookmarkViewModel model)
        {
            var result = groupService.GroupAttachmentBookmark(model);

            return Ok(new APIResponse(true, Constant.Success, "", "Group attachment " + result + " sucessfully"));
        }

        [HttpGet]
        [Route("deletegroup")]
        public async Task<IActionResult> RemoveGroup(int groupid)
        {
            var result = groupService.RemoveGroup(groupid);

            return Ok(new APIResponse(true, Constant.Success, "", "Group delete sucessfully"));
        }

        [HttpPost]
        [Route("groupmeeting")]
        public async Task<IActionResult> GroupMeeting(GroupmeetingViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "group meeting added successfully.", groupService.ManageGroupMeeting(model)));
        }

        [HttpPost]
        [Route("groupdiscussion")]
        public async Task<IActionResult> GroupDiscussion(GroupDiscussionViewModel model)
        {

            return Ok(new APIResponse(true, Constant.Success, "group discussion added successfully.", groupService.GroupDiscussion(model)));
        }

    }
}
