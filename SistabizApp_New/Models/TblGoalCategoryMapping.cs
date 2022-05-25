using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblGoalCategoryMapping
    {
        public long GoalMappingId { get; set; }
        public long? CategoryId { get; set; }
        public long? GoalId { get; set; }

        public virtual TblGoalCategory Category { get; set; }
        public virtual TblGoal Goal { get; set; }
    }
}
