using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGoalCategory
    {
        public TblGoalCategory()
        {
            TblGoalCategoryMapping = new HashSet<TblGoalCategoryMapping>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TblGoalCategoryMapping> TblGoalCategoryMapping { get; set; }
    }
}
