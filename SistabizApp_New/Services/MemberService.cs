using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public class MemberService: IMemberService
    {

        SistabizAppContext dbContext;

        public MemberService(SistabizAppContext _db)
        {
            dbContext = _db;
        }

        public TblMember AddEmployee(TblMember employee)
        {
            if (employee != null)
            {
                dbContext.TblMember.Add(employee);
                dbContext.SaveChanges();
                return employee;
            }
            return null;
        }
    }
}
