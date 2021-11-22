using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IToversite
{
    public   class DBConnection
    {

        public string strCon = "Data Source=208.91.198.59;Initial Catalog=itcne3ho_mssql_db;Persist Security Info=True;User ID=mssqldbadmin;Password=mssqldbadmin@123";


        public SqlConnection con = new SqlConnection();  
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter da = new SqlDataAdapter();
        public DataSet ds = new DataSet();
       



        public  SqlConnection  Connect()
        {
            con = new SqlConnection(strCon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection Conn()
        {
            con = new SqlConnection(strCon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }


    }
}