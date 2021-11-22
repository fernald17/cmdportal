using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IToversite.Models
{
    public class ITDashBoard
    {


        public int Id { get; set; }

        public List<Escalation> EscList { get; set; }

    }
}