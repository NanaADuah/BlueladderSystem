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
    public partial class EmployeeReport : System.Web.UI.Page
    {
        protected EReport report;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin") && !instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Owner"))
                Response.Redirect("dashboard.aspx");


            Database database = new Database();
            report = new EReport();
            List<JobTable> jobTypes = new List<JobTable>();
            List<NameHours> namehours = new List<NameHours>();
           
            try
            {
                
                int numEmployees = database.getCount("SELECT COUNT(*) AS Count FROM [Employee]");
                report.TotalEmployees = numEmployees;
                SqlDataReader differentJobs = database.execReader("SELECT JobStatus, COUNT(JobStatus) AS Value  FROM [Employee] GROUP BY JobStatus");
                if(differentJobs != null)
                {
                    while(differentJobs.Read())
                    {
                        jobTypes.Add(new JobTable()
                        {
                            Name = differentJobs.GetValue(0).ToString(),
                            Count = int.Parse(differentJobs.GetValue(1).ToString())
                        });
                    }
                    report.JobStatus = jobTypes;
                }
                
                SqlDataReader employeeHoursName  = database.execReader("SELECT JobStatus, AVG(HoursWorked) FROM [Employee] GROUP BY JobStatus");
                if(employeeHoursName != null)
                {
                    while(employeeHoursName.Read())
                    {
                        namehours.Add(new NameHours()
                        {
                            Name = employeeHoursName.GetValue(0).ToString(),
                            Hours = int.Parse(employeeHoursName.GetValue(1).ToString())
                        });
                    }
                    report.EmployeeHours = namehours;
                }


                //var result = String.Join(", ", jobTypes.ToArray());

                /*
                EmpReport.Items.Add("Employee Count" + "\t" + "Employee ID" + "\t" + "Name" + "\t\t" + "Surname" + "\t\t" + "Job Status" + "\t\t" + "Hours Worked");

                for (int count = 0; count <= 250 ; count++)
                {
                    EmpReport.Items.Add((count + 1) + "\t" + database.GetType(userID).ToString() + "\t" + database.GetType(userName).ToString() + "\t\t" + database.GetType(userSurname).ToString() + "\t\t" + database.GetType(jobStatus).ToString() + "\t\t" + database.GetType(hoursWorked).ToString());
                }*/

                tbTotalEmp.Text = report.TotalEmployees.ToString();

                DataSet ds = new DataSet();
                SqlDataAdapter da = database.getAdapterQuery("SELECT JobStatus, Count (*) AS VALUE FROM [Employee] GROUP BY JobStatus");
                da.Fill(ds);
                Chart1.DataSource = ds;
                Chart1.Series[0].XValueMember = "JobStatus";
                Chart1.Series[0].YValueMembers = "VALUE";
                Chart1.Titles.Add("Employee Job Stats");
                Chart1.DataBind();

                
            }catch
            {
                lblInfo.Text = "An error occurred";
            }
        }

        public class EReport
        {
            public int TotalEmployees { get; set; }
            public List<JobTable> JobStatus{ get; set; }
            public List<NameHours> EmployeeHours{ get; set; }
        }

        public class JobTable
        {
            public String Name { get; set; }
            public int Count { get; set; }
        }
        
        public class NameHours
        {
            public String Name { get; set; }
            public int Hours { get; set; }
        }
    }
}