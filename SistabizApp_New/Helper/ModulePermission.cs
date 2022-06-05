using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistabizApp_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class ModulePermission: TypeFilterAttribute
    {
       
        
        public ModulePermission(PermissionEnum.Modules[] item) : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { item };
        }
        public class AuthorizeActionFilter : IAuthorizationFilter
        {
            private readonly PermissionEnum.Rights[] _item;
            private readonly SistabizAppContext _entityDbContext;
            public AuthorizeActionFilter(PermissionEnum.Rights[] item, SistabizAppContext _entitydbContext)
            {
                _item = item;
                _entityDbContext = _entitydbContext;
            }
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                
            
              //  rights.Add(_item[1].ToString());
                //string subscriptiontype = context.HttpContext.Request?.Headers["SubscriptionTypeId"].ToString();
               // int role =Convert.ToInt32(context.HttpContext.Request?.Headers["Role"].ToString());

                var subscriptionList = SubscriptionTypeList();  // Need to get this list from DB as per user
                var _right = _item[0].ToString();
                // bool isUserPermission = subscriptionList.Where(w => w.SubscriptionTypeId == Convert.ToInt32(subscriptiontype) && rights.Contains(w.SubscriptionName)).Any();

                bool isUserPermission = true;// _entityDbContext.TblModulePermission.Where(w => w.ModuleId == Convert.ToInt32(_item[0]) && w.SubscriptionType== Convert.ToInt32(subscriptiontype) && w.MemberRole==role).Any();

                if (!isUserPermission)
                {
                    var _res = new { status = 401, Message = "Unauthorized Access", Data = "Unauthorized Access" };
                    context.Result = new JsonResult(_res);
                    return;
                }

            }

            public List<SubscriptionType> SubscriptionTypeList()
            {
                List<SubscriptionType> subscription = new List<SubscriptionType>
                {
                    new SubscriptionType { SubscriptionTypeId = 1, SubscriptionName = "BASIC"},
                     new SubscriptionType { SubscriptionTypeId = 2, SubscriptionName = "BOOST"},
                      new SubscriptionType { SubscriptionTypeId = 3, SubscriptionName = "BREAKTHROUGH"},
                   
                };
                return subscription;
            }
        }
    }
}