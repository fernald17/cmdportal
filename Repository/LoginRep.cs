using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IToversite;
using IToversite.Models;

namespace Repository
{
    public  class LoginRep
    {


      DbActions dba = new DbActions();
      public Employee  GetEmployeeDetailsByMailId(string  mail)
      { 
            return dba.GetEmpDetailsByMailid(mail); 
      }
        
      public UserLogin GetEmailByUsr(string usr)
      {
          return dba.GetMailByUsr(usr);
      }
    }
}
