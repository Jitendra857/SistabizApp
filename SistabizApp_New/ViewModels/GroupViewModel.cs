using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class GroupViewModel
    {

        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string GroupDoc { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateByName { get; set; }

        public int JoiningTotalMembers { get; set; }

        public bool IsUpdateAttachment { get; set; }
        public List<IFormFile> Image { get; set; } = new List<IFormFile>();
    }

    public class GroupJoinMemberViewModel
    {
        public long JoinId { get; set; }
        public long? GroupId { get; set; }
        public long? JoinMemberId { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
