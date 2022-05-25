using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblOnboardingConversation
    {
        public TblOnboardingConversation()
        {
            TblConversationAnswer = new HashSet<TblConversationAnswer>();
            TblConversationQuestionAnswer = new HashSet<TblConversationQuestionAnswer>();
        }

        public long QuestionId { get; set; }
        public string Question { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblMember CreatedByNavigation { get; set; }
        public virtual ICollection<TblConversationAnswer> TblConversationAnswer { get; set; }
        public virtual ICollection<TblConversationQuestionAnswer> TblConversationQuestionAnswer { get; set; }
    }
}
