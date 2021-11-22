using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IToversite;
using IToversite.Models;

namespace Repository
{
    public class EscalationRep
    {

        DbActions dbac = new DbActions();
         
        public List<Escalation> GetEscDetails()
        {

            DataSet ds = dbac.EscalationList();

            List<Escalation> EscList = new List<Escalation>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                var esc = new Escalation
                {
                    TrgDt = dr["TrgDate"].ToString(),
                    CRFIdOrHelpdeskTicket = dr["CRFIdOrHelpdeskTicket"].ToString(),
                    CRFOrHelpDeskTitle = dr["CRFOrHelpDeskTitle"].ToString(),
                    DaysDely = (int)dr["DaysDely"],                 
                    GroupCompany = dr["GroupCompany"].ToString(), 
                    Action = "<a class='btn btn-primary btn-sm'   href='" + "/Escalation/EscDetails/" + dr["EscId"] +"'>Details</a>"

                };
                EscList.Add(esc);
            }

            return EscList;

        }
         
        public List<Escalation> GetITEscalation()
        {
             
            DataSet ds = dbac.EscalationList(); 
            List<Escalation> EscList = new List<Escalation>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                var esc = new Escalation
                {
                    TrgDt = dr["TrgDate"].ToString(),
                    CRFIdOrHelpdeskTicket = dr["CRFIdOrHelpdeskTicket"].ToString(),
                    CRFOrHelpDeskTitle = dr["CRFOrHelpDeskTitle"].ToString(),
                    DaysDely = (int)dr["DaysDely"],
                    GroupCompany = dr["GroupCompany"].ToString(), 
                    Action = "<a class='btn btn-primary btn-sm' href='" + "/Escalation/AddEscDetails/" + dr["EscId"] + "'>Details</a>"
 
                };
                EscList.Add(esc);
            }
            return EscList; 
        } 
         
        public EscDetails AddEscDetailsById(int Id)
        {

            DataTable dt = dbac.EscalationById(Id);
            EscDetails model = new EscDetails()
            {

                EscId = Id,
                EmpId = (int)dt.Rows[0]["EmpId"],
                IssueDtls = dt.Rows[0]["IssuDtls"].ToString(),
                EmpName = dt.Rows[0]["EmpName"].ToString()

                //CRFIdOrHelpdeskTicket= (int)dt.Rows[0]["CRFIdOrHelpdeskTicket"]

            };

            model.DetailsList = new List<EscDetails>(); 
            DataTable dtble = dbac.EscDetailsById(Id);


            foreach (DataRow dr in dtble.Rows)
            {

                EscDetails escd = new EscDetails()
                {
                    comment = dr["comment"].ToString(),
                };
                model.DetailsList.Add(escd);
            }
            return model;
        }
         
        public Escalation EscalationById (int id)
        {

            DataSet ds = dbac.EscalationList();
            var esc = new Escalation();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((int)dr["EscId"] == id)
                {
                    esc = new Escalation
                    {
                        EscId = (int)dr["EscId"],
                        TrgDt = dr["TrgDate"].ToString(),
                        CRFIdOrHelpdeskTicket = dr["CRFIdOrHelpdeskTicket"].ToString(),
                        CRFOrHelpDeskTitle = dr["CRFOrHelpDeskTitle"].ToString(),
                        DaysDely = (int)dr["DaysDely"],
                        Impact = dr["Impact"].ToString(),
                        IssuDtls = dr["IssuDtls"].ToString(),
                        ITActOwn = dr["ITActOwn"].ToString(),
                        GroupCompany = dr["GroupCompany"].ToString(),
                         

                        Action = "<a class='btn btn-primary btn-sm' href='" + "/Escalation/EscDetails/" + dr["EmpId"] + "'>Details</a>"

                    };
                }
            }

            esc.DetailsList = new List<EscDetails>();

            DataTable dtble = dbac.EscDetailsById(id);


            foreach (DataRow dr in dtble.Rows)
            {

                EscDetails escd = new EscDetails()
                {

                    comment = dr["comment"].ToString(),

                };
                esc.DetailsList.Add(escd);

            }

            return esc;

        }


    }
}
