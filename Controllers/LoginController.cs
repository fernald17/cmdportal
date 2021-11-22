using IToversite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;

namespace IToversite.Controllers
{
     

    public class LoginController : Controller
    {
        public DbActions dba = new DbActions();


        // GET: Login reg
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            UserLogin model = new UserLogin();
            return View(model);
        }


        public ActionResult Login()
        {
            UserInfo.Buttontxt = "";
            Login model = new Login();
            return View(model);
        }

        [HttpPost]       
        public ActionResult CreateUser( UserLogin model )
        {
            dba.AddUser(model.Username, model.Password, model.RoleId, model.UserRole, model.Email);
            return null;
        }

        //login

        [HttpPost]
        public ActionResult Login(Login model)
        {
            
            LoginRep lRep = new LoginRep(); 
            UserLogin user = lRep.GetEmailByUsr(model.Username);
            Employee emp = lRep.GetEmployeeDetailsByMailId(user.Email); 
            UserInfo.UserEmpId = emp.EmpId;
            UserInfo.UsrEmpName = emp.EmpName;
            UserInfo.Email = emp.Email;
            UserInfo.RoleId = emp.RoleId;
            string role = dba.GoToLogin(model.Username, model.Password); 
            if (role == "1")
            {
                return RedirectToAction("ITDashBoard" , "Login");
            }
            else
            {
                return RedirectToAction("UserDashBoard", "Login");
            } 
        }
        
        public ActionResult ITDashBoard()
        { 
            return View(new ITDashBoard()); 
        }
        
        public ActionResult UserDashBoard()
        {
            return View(new UserDashBoard());
        }

        [HttpPost]
        public JsonResult GetList()
        { 
            EscalationRep erep = new EscalationRep(); 
            List<Escalation> EscList = erep.GetEscDetails();   
            return Json(EscList,JsonRequestBehavior.AllowGet);  
        }


        [HttpPost]
        public JsonResult GetITList()
        { 
            EscalationRep eRep = new EscalationRep();
            List<Escalation> EscList = eRep.GetITEscalation();
            return Json(EscList, JsonRequestBehavior.AllowGet);  

        }
    }
}