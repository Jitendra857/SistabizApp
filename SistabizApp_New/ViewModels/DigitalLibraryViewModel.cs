using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class DigitalLibraryViewModel
    {
        public long DigitalLibraryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public string PaymentType { get; set; }
        public double? Price { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsUpdateAttachment { get; set; } = false;
        public long? CategoryType { get; set; }
        public string CategoryName { get; set; }
        public string CreateByName { get; set; }
        public string CreateByProfile { get; set; }
        public bool IsBookmark { get; set; }
        public List<IFormFile> Image { get; set; } = new List<IFormFile>();
        public IFormFile GroupIcon { get; set; }
        public string GroupIconPath { get; set; }

        public List<DigitalLibraryAttachmentViewModel> lstDigitalLibraryAttachment { get; set; } = new List<DigitalLibraryAttachmentViewModel>();
    }

    public class DigitalLibraryFilterViewModel
    {
        public long? MemberId { get; set; }
        public long? CategoryId { get; set; }
        public long? DigitalLibrary { get; set; }
        public bool IsSaved { get; set; } = false;
        public int Ordering { get; set; } = 0;
    }
    public class DigitalLibraryAttachmentViewModel
    {
        public long LibraryAttachmentId { get; set; }
        public long? DigitalLibaryId { get; set; }
        public string FileName { get; set; }


    }
    public class DigitalLibraryBookmarkViewModel
    {
        public long? BookmarkId { get; set; }
        public long? MemberId { get; set; }
        public long? CategoryId { get; set; }
        public long? DigitalLibraryId { get; set; }
    }

    public class DigitalLibraryCategoryViewModel
    {
        
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsChecked { get; set; } = false;


    }
}
