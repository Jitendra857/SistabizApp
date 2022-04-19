using SistabizApp_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.IServices
{
  public  interface IMemberService
    {
        TblMember AddEmployee(TblMember employee);
    }
}
