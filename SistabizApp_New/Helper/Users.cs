using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Right { get; set; }
    }

    public class SubscriptionType
    {
       public int SubscriptionTypeId { get; set; }
        public string SubscriptionName { get; set; }
    }
}
