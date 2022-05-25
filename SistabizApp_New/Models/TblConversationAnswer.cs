using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblConversationAnswer
    {
        public TblConversationAnswer()
        {
            TblConversationQuestionAnswer = new HashSet<TblConversationQuestionAnswer>();
        }

        public long ConversationAnswerId { get; set; }
        public long? QuestionId { get; set; }
        public string Answer { get; set; }

        public virtual TblOnboardingConversation Question { get; set; }
        public virtual ICollection<TblConversationQuestionAnswer> TblConversationQuestionAnswer { get; set; }
    }
}
