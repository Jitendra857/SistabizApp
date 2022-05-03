using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.ViewModels
{
    public class GoalActivityViewModel
    {

        public long GoalId { get; set; }
        public string What { get; set; }
        public string Start { get; set; }
        public string Who { get; set; }
        public string How { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Status { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
    }
}
