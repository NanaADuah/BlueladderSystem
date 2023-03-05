using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using static System.Math;

namespace bcms
{
    public partial class SummaryReport : System.Web.UI.Page
    {
        protected Report report;
        protected double totalReveunue;
        protected IList<SalaryCategory> categoryData;
        protected IList<EEmployee> empData;
        protected double TotalSalary = 0;
        protected double TotalRevenue = 0;
        protected string tabView = "overview";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            Database database = new Database();

            List<String> jobs = new List<String>();
            List<String> JobTypes = new List<String>();
            categoryData = new List<SalaryCategory>();
            empData = new List<EEmployee>();

            if (Request.QueryString["tab"] != null)
            {

                if (String.IsNullOrEmpty(Request.QueryString["tab"].ToString()))
                    tabView = "overview";
                else
                {
                    tabView = Request.QueryString["tab"].ToString();
                }
            }
            
            try
            {
                infoDisplay.ForeColor = System.Drawing.Color.Green;

                string query = "SELECT DISTINCT JobStatus FROM [Employee]";
                SqlDataReader reader = database.execReader(query);
                if(reader != null)
                {
                    while (reader.Read())
                    {
                        JobTypes.Add(reader.GetValue(0).ToString());
                    }

                }

                categoryData.Add(new SalaryCategory(){Type = "Brick mason",Amount = 87});
                categoryData.Add(new SalaryCategory(){Type = "Construction Inspector",Amount = 102});
                categoryData.Add(new SalaryCategory(){Type = "Construction worker",Amount = 201});
                categoryData.Add(new SalaryCategory(){Type = "Flooring installer",Amount = 302});
                categoryData.Add(new SalaryCategory(){Type = "Glazier",Amount = 358});
                categoryData.Add(new SalaryCategory(){Type = "Roofer",Amount = 307});
                categoryData.Add(new SalaryCategory(){Type = "Surveyor",Amount = 198});
                categoryData.Add(new SalaryCategory(){Type = "Tile setter",Amount = 319});

                Random rand = new Random();
                for (int i = 0; i < JobTypes.Count;i++)
                {
                    double value = (double)rand.Next(50,400);
                }

                string empQuery = "SELECT EmployeeID, FirstName, LastName, JobStatus, HoursWorked FROM [Employee] ORDER BY UserID";
                reader = database.execReader(empQuery);
                if (reader != null) 
                { 
                    while (reader.Read())
                    {
                        int eID = int.Parse(reader.GetValue(0).ToString());
                        string  eFName = reader.GetValue(1).ToString();
                        string  eLName = reader.GetValue(2).ToString();
                        string eJob = reader.GetValue(3).ToString();
                        int eHours = int.Parse(reader.GetValue(4).ToString());
                        var finalValue = categoryData.First(item => item.Type.Equals(eJob, StringComparison.CurrentCultureIgnoreCase)).Amount * eHours;
                        TotalSalary += finalValue;
                        empData.Add(new EEmployee()
                        {
                            EmployeeID = eID,
                            EmployeeFName = eFName,
                            EmployeeLName = eLName,
                            JobType = eJob,
                            EmployeeHours = eHours,
                            FinalSalary = finalValue ,

                        }) ;
                    }
                }

                tbTotal.Text = "R " + TotalSalary.ToString("F2");

                double TotalIncome = TotalSalary * 1.65;
                TotalRevenue = TotalIncome - TotalSalary;

                tbIncome.Text = "R " + TotalIncome.ToString("F2");
                tbRevenue.Text = "R " + TotalRevenue.ToString("F2");


            } catch(Exception ex)
            {
                lblMessages.Text = ex.Message;
                    //"An error occurred, please try again";
            }

        }
    }


    public class Report
    {
        public double Salary { get; set; }
        public double Income { get; set; }
        public double HoursC { get; set; }
        public double Hours0 { get; set; }
        public double HoursA { get; set; }
        public double Total { get; set; }


    }

    public class SalaryCategory
    {
        public string Type { get; set; }
        public double Amount { get; set; } 
    }


    public class EEmployee
    {
        public int EmployeeID { get; set; }
        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }
        public int EmployeeHours { get; set; }
        public string JobType{ get; set; }
        public double FinalSalary { get; set; }
    }

}