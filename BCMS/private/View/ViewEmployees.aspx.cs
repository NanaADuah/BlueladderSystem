using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

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
            string defaultImage  = "placeholder.png";

            if (reader != null)
            {
                while (reader.Read())
                {
                    string eID = reader.GetValue(0).ToString();
                    string uID = reader.GetValue(1).ToString();
                    string fName = reader.GetValue(2).ToString();
                    string lName = reader.GetValue(3).ToString();
                    string status = reader.GetValue(4).ToString();
                    string gender = reader.GetValue(5).ToString();
                    string bDate = reader.GetValue(6).ToString();
                    string image = reader.GetValue(7).ToString();

                    if (image.Equals("") || image == null)
                    {
                        string link = "../../public/includes/profile/";
                        if (gender.Equals("female", StringComparison.OrdinalIgnoreCase))
                            image = link + "female.jpg";
                        else
                        if (gender.Equals("male", StringComparison.OrdinalIgnoreCase))
                            image = link + "male.jpg";
                        else
                            image = link + defaultImage;
                    }

                    employees.Add(new Employee()
                    {
                        EmployeeID = eID,
                        UserID = uID,
                        Name = fName,
                        Surname = lName,
                        JobStatus = status,
                        Gender = gender,
                        Birthdate = Convert.ToDateTime(bDate),
                        Image = image,

                    });
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserID { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Image { get; set; }
        public string JobStatus{ get; set; }
        public string EmployeeID { get; set; }
    }
}