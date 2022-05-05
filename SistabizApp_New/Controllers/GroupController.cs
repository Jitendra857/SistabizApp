
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
    public class GroupController : ControllerBase
    {

        private readonly IBLLService groupService;

        public GroupController(IBLLService groupservice)
        {
            groupService = groupservice;
        }

        [HttpGet]
        [Route("getallgroup")]
        public async Task<IActionResult> GetAllGroup()
        {

            return Ok(new APIResponse(true, Constant.Success, "group list", groupService.GetGroupList()));
        }

        [HttpPost]
        [Route("addupdategroup")]
        public async Task<IActionResult> ManageGroup([FromForm] GroupViewModel model)
        {

            List<TblGroupAttachment> groupattachment = new List<TblGroupAttachment>();

            return Ok(new APIResponse(true, Constant.Success, "", "Group Added successfully"));

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
                            groupattachment.Add(new TblGroupAttachment { GroupId = groupid, Attachment = eventfilename });
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

        [HttpGet]
        [Route("deletegroup")]
        public async Task<IActionResult> RemoveGroup(int groupid)
        {
            var result = groupService.RemoveGroup(groupid);

            return Ok(new APIResponse(true, Constant.Success, "", "Group delete sucessfully"));
        }


    }
}
