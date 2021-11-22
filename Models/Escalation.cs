using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IToversite.Models
{
    public class Escalation
    {
        public int EscId { get; set; }

        public int EmpId { get; set; }

        //public string EmpName { get; set; }

        [DisplayName("Group Company")]
        public string GroupCompany { get; set; }

        //public string MobileNo { get; set; }

        //public string Department { get; set; }


        [DisplayName("CRF Number")]
        public string CRFIdOrHelpdeskTicket { get; set; }


        [DisplayName("Title")]
        public string CRFOrHelpDeskTitle  { get; set; }

        [DisplayName("Impact")]
        public string Impact { get; set; }


        [DisplayName("Target Date")]
        public DateTime? TrgDate { get; set; }

        public string TrgDt { get; set; }
        public int? DaysDely { get; set; }


        [DisplayName("IT Action Owner")]
        public string ITActOwn { get; set; }


        [DisplayName("Issue Details")]
        public string IssuDtls { get; set; }

        //public int  ITEmpId { get; set; }

        //public string ITEmailId { get; set; }

        public DateTime EntryDate { get; set; }
 
        public string Action { get; set; }


        //public string UserEmailId { get; set; }


        public bool Status { get; set; }


        [DisplayName("Comment")]
        public string UserComment { get; set; }

        public List<EscDetails> DetailsList { get; set; }



    }
}