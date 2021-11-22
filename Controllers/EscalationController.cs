using IToversite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Repository;



namespace IToversite.Controllers
{
    public class EscalationController : Controller
    {

        DbActions dba = new DbActions();
         

        // GET: Escalation
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddEscalation()
        {            
            Escalation model = new Escalation();
            return View(model);
        }

        public ActionResult AddEscDetails(int Id)
        {

            EscalationRep eRep = new EscalationRep();
            EscDetails model = eRep.AddEscDetailsById(Id);
            return View(model);
        }


        [HttpPost]
        public ActionResult AddEscalation(Escalation model)
        {
            model.EmpId = UserInfo.UserEmpId;
            dba.AddEscalation(model);

            //MailMessage mail = new MailMessage();
            //mail.To.Add(model.ITEmailId);
            //mail.From = new MailAddress("taskmanager@manappuram.com");
            //mail.Subject = model.CRFOrHelpDeskTitle;
            //mail.Body = model.IssuDtls;
            //mail.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.office365.com";
            //smtp.Port = 587;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("taskmanager@manappuram.com","CMD@1234");
            //smtp.EnableSsl = true;
            //smtp.Send(mail);
           
            return RedirectToAction("UserDashBoard", "Login");
        }


        [HttpPost]
        public ActionResult AddEscDetails(EscDetails model)
        {
            dba.AddEscDetails(model);
            return RedirectToAction("ITDashBoard", "Login");
        }
         
       public ActionResult  EscDetails(int id)
       {
            EscalationRep eRep = new EscalationRep();
            Escalation esc = eRep.EscalationById(id); 
            return View(esc); 
       }


        [HttpPost]
        public JsonResult CloseTicket(int id)
        { 
          string str =   dba.UpdateEscalation(id);
          return Json(str, JsonRequestBehavior.AllowGet); 

        }


        [HttpPost] 
        public JsonResult AddUserComment(int id, string comment )
        {
            EscDetails model = new EscDetails
            {
                comment = comment,
                EscId = id,
                EmpId = UserInfo.UserEmpId
            };

            dba.AddEscDetails(model);
            return Json("1", JsonRequestBehavior.AllowGet); 
        }  
    }
    
}