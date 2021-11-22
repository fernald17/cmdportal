using IToversite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IToversite
{
    public class DbActions : DBConnection
    {
        DBConnection dbCon = new DBConnection();
        //register useres
        public void AddUser(string User, string Pwd, int RoleId, string Role, string Email )
        {
            cmd.Connection = dbCon.Conn();
            cmd.CommandText = "INSERT INTO Login(Username,UserRole,RoleId,Password,Email)" + 
                "VALUES ('" +User+ "','"+Role+"','" +RoleId.ToString()+"','"+Pwd+"','"+Email+"' )"; 
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery(); 
        }
          //login using username and password
        public string GoToLogin(string username, string password )
        {
            ds = new DataSet();
            cmd.Connection = dbCon.Conn() ;  
            cmd.Parameters.AddWithValue("@Username", username);           
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.CommandText = "select Password,Username,RoleId from Login where Username = @Username and Password=@Password"; 
            da.SelectCommand = cmd; 
            da.Fill(ds); 
            return ds.Tables[0].Rows[0]["RoleId"].ToString(); 
        }

      //  addescalation
        public string AddEscalation(Escalation model)
        {

            cmd.Connection = dbCon.Conn(); 
            cmd.CommandText = "insert into Esc_User_Main( EmpId, GroupCompany,     CRFIdOrHelpdeskTicket, CRFOrHelpDeskTitle, Impact, TrgDate, DaysDely, ITActOwn, IssuDtls, EntryDate)" +
                "values('" + model.EmpId + "','" + model.GroupCompany + "','" + model.CRFIdOrHelpdeskTicket + "','" + model.CRFOrHelpDeskTitle + "','" + model.Impact + "','" + model.TrgDt + "','" + model.DaysDely + "','" + model.ITActOwn + "','" + model.IssuDtls + "' ,getdate())";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            return "";

        }
        //escList
        public DataSet EscalationList()
        {
            ds = new DataSet();
            cmd.Connection = dbCon.Conn(); 
            cmd.CommandText = "select *  from  Esc_user_main  ";
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }


        public DataTable EscalationById(int Id)
        {
            ds = new DataSet();
            cmd.Connection = dbCon.Conn();
            cmd.CommandText = " select  A.EscId,A.EmpId,A.GroupCompany,A.CRFOrHelpDeskTitle," +
                               "A.Impact,A.TrgDate,A.DaysDely,A.ITActOwn,A.IssuDtls,A.EntryDate," + 
                               "A.Status,A.CRFIdOrHelpdeskTicket, b.EmpName from  Esc_user_main A left join Employee_user_main b on A.EmpId = b.EmpId where EscId = " + Id.ToString();
                         
            da.SelectCommand = cmd; 
            da.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable EscDetailsById(int Id)
        {
            ds = new DataSet();
            cmd.Connection = dbCon.Conn();
            cmd.CommandText = "select *  from  Esc_Details where EscId=" + Id.ToString();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds.Tables[0];
        }

                

        //view esc details
        public string AddEscDetails(EscDetails model)
        {
            ds = new DataSet();
            cmd.Connection = dbCon.Conn();
            cmd.CommandText = "insert into Esc_Details(EscId, EmpId,comment ,EntryDate)" +
                "values('" + model.EscId + "','"   + model.EmpId + "','" + model.comment + "',getdate())";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            return "";

        }


        public string UpdateEscalation(int id)
        {
            cmd.Connection = dbCon.Conn();
            cmd.CommandText = "update  Esc_User_Main set Status = 0 where EscId =" + id; 
            cmd.CommandType = System.Data.CommandType.Text;
            return  cmd.ExecuteNonQuery().ToString();  
        }

        public Employee GetEmpDetailsByMailid(string mail)
        {
            
            ds = new DataSet();
            cmd.Connection = dbCon.Conn();
            cmd.CommandText = "select *  from  Employee_User_Main where Email='" + mail+"'";
            da.SelectCommand = cmd;
            da.Fill(ds);

            if (ds != null)
                return new Employee()
                {
                    EmpName = ds.Tables[0].Rows[0]["EmpName"].ToString(),
                    EmpId = (int)ds.Tables[0].Rows[0]["EmpId"],
                    Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString(),
                    RoleId = (int)ds.Tables[0].Rows[0]["RoleId"],
                    Email = ds.Tables[0].Rows[0]["Email"].ToString()

                };
            else

                return new Employee();
        }  


        public  UserLogin GetMailByUsr (string usr)
        {
            ds = new DataSet();
            cmd.Connection = dbCon.Conn();
            cmd.CommandText = "select *  from  [Login] where Username='" + usr + "'";
            da.SelectCommand = cmd;
            da.Fill(ds);

            if (ds != null)
                return new UserLogin()
                {
                    Email = ds.Tables[0].Rows[0]["Email"].ToString(),
                    
                };
            else

                return new UserLogin();  
        }  
    }
}