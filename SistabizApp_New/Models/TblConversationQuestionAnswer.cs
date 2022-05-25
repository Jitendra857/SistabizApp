using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblConversationQuestionAnswer
    {
        public long QuestionAnswerId { get; set; }
        public long? QuestionId { get; set; }
        public long? AnswerId { get; set; }
        public long? MemberId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblConversationAnswer Answer { get; set; }
        public virtual TblMember Member { get; set; }
        public virtual TblOnboardingConversation Question { get; set; }
    }
}
