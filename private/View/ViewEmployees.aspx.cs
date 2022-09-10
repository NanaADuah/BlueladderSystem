using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class ViewEmployees : System.Web.UI.Page
    {
        protected IList<Employee> employees;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            string eMessage = "";
            employees = new List<Employee>();

            Database database = new Database();
            string query = "SELECT * FROM Employee";
            SqlDataReader reader = database.execReader(query);
            if (eMessage.Length != 0)
                lblMessages.Text = "Error: " + eMessage;

            if (reader != null)
                while (reader.Read())
                {
                    employees.Add(new Employee()
                    {
                        EmployeeID = reader.GetValue(0).ToString(),
                        UserID = reader.GetValue(3).ToString(),
                        Name = reader.GetValue(1).ToString(),
                        Surname = reader.GetValue(2).ToString(),
                        JobStatus= reader.GetValue(4).ToString(),
                        Gender = reader.GetValue(4).ToString(),
                        Birthdate = reader.GetValue(4).ToString(),
                    }) ;
                }

        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserID { get; set; }
        public string Gender { get; set; }
        public string Birthdate { get; set; }
        public string Image { get; set; }
        public string JobStatus{ get; set; }
        public string EmployeeID { get; set; }
    }
}