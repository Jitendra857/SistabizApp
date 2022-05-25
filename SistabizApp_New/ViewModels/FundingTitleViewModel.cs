using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class FundingTitleViewModel
    {
        public long FundingSectionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }
        public IFormFile FundingTitleIcon { get; set; }
        public string FundingTitlePath { get; set; }
    }
}
