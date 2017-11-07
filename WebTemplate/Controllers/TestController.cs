using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTemplate.Models;

namespace WebTemplate.Controllers
{
    public class TestController : Controller
    {
        private SqlConnection con;

        // GET: AddEmployee  
        public ActionResult AddEmployee()
        {
            return View();
        }
        //Post method to add details    
        [HttpPost]
        public ActionResult AddEmployee(EmpModel obj)   
        {
            AddDetails(obj);

            return View();
        }

        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);

        }

        //To add Records into database     
        private void AddDetails(EmpModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddEmp", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}