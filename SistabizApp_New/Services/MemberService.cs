using SistabizApp.Authentication;
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

        public RegisterModel GetEmployeeById(string email)
        {
            var employee = dbContext.TblMember.Where(x => x.Email == email).Select(e => new RegisterModel
            {

                Email = e.Email,
                Password = e.Password,
                FirstName = e.FirstName,
                LastName = e.LastName,
                ProfileUrl = e.ProfileImage,
                Mobile = e.Mobile,
                StateId =(int) e.StateId,
                City = e.City,
                Address = e.Address,
                ZipCode = e.ZipCode,
              

            }).FirstOrDefault();
            return employee;
        }
    }
}
