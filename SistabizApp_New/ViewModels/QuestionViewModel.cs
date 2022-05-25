using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class QuestionViewModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public List<QuestionAnswerViewModel> lstQuestionANswer { get; set; } = new List<QuestionAnswerViewModel>();

    }
    public class QuestionAnswerViewModel
    {
        public long? QuestionId { get; set; }
        public string Question { get; set; }
        public long? AnswerId { get; set; }
        public long? MemberId { get; set; }

        public string Answer { get; set; }


    }
}
