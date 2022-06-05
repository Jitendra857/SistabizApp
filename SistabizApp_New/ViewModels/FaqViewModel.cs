using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class FaqViewModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public long? FaqCategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class FaqCategoryViewModel
    {
        public long FaqCategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsChecked { get; set; } = false;
        public List<FaqViewModel> lstfaq { get; set; } = new List<FaqViewModel>();
    }

    public class FaqQuestionViewModel
    {
        public long FaqQuestionId { get; set; } = 0;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public long? MemberId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
