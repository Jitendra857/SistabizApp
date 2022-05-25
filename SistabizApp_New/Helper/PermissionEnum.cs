using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class PermissionEnum
    {
        public enum Rights
        {
            BASIC = 1,
            BOOST = 2,
            BREAKTHROUGH = 3,

        }
        public enum Modules
        {
            EVENTS = 1,
            GROUP = 2,
            Conversation = 3,
            DigitalLibrary = 4,
            Funding = 5,
            Faq=6,
            GoalActivity=8

        }

    }
}
