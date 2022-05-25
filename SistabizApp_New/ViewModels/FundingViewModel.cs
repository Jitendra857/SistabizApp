using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class FundingViewModel
    {

        public long FundingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CreateByName { get; set; }
        public string CreateByProfile { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsBookmark { get; set; } = false;
        public string ApplyHere { get; set; } = "https://www.drupal.org/project/dummy_link";
    }
    public class FundingBookmarkViewModel
    {
      public long? BookmarkId { get; set; }
       public long? MemberId { get; set; }
        public long? CategoryId { get; set; }
        public long? FundingId { get; set; }
    }

    public class FundingCategoryViewModel
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsChecked { get; set; } = false;

        public List<FundingViewModel> lstfundingresources { get; set; } = new List<FundingViewModel>();
    }
}
