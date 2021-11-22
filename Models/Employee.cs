using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IToversite.Models
{
    public class Employee
    {

        public int EmpId { get; set; } 
        public string EmpName { get; set; } 
        public  int RoleId { get; set; } 
        public string Email { get; set; } 
        public string Mobile { get; set; } 
        public string Department { get; set; } 
        public  string  EmployeeCode { get; set; }


    }
}