using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IToversite.Models
{
    public class UserDashBoard
    {

        public int ID { get; set; }


        public List<Escalation> EscList { get; set; }

    }
}