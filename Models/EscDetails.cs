using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IToversite.Models
{
    public class EscDetails
    {
        public int EscId { get; set; }
        //public int CRFIdOrHelpdeskTicket { get; set; }
       // public int StatusId { get; set; }
        public int EmpId { get; set; }


        [DisplayName("User")]
        public string EmpName { get; set; }


        [DisplayName("Issue Details")]
        public  string IssueDtls { get; set; }

        [DisplayName("Comment")]
        public string comment { get; set; }
       // public int ITEmpID { get; set; }
       // public string ITEmailId { get; set; }
        public DateTime EntryDate { get; set; }
        
        public List<EscDetails> DetailsList { get; set; }




    }
}