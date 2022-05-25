using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblMemberSkills
    {
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public long? MemberId { get; set; }

        public virtual TblMember Member { get; set; }
    }
}
