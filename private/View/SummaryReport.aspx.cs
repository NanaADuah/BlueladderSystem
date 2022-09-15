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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            Database database = new Database();

            double salary, income, revenue, hoursC, hoursA, hoursO, totalHours;
            List<String> jobs = new List<String>();

            try
            {
                infoDisplay.ForeColor = System.Drawing.Color.Green;

                for (int count = 0; count <= 250; count++)
                {
                    /*
                        string query = "SELECT JobStatus, HoursWorked FROM [Employee] GROUP BY JobStatus";
                        SqlDataReader reader = database.execReader(query);
                        if (reader != null) 
                        { 
                            while (reader.Read())
                            {
                            jobs.Add(reader.GetValue(0).ToString());
                            }
                        }
                            */
                    /*hoursC = reader;
                    salary = hoursC * 50;

                    string query = "SELECT hoursWorked FROM Employee WHERE jobStatus = "'admin worker'" ";
                    SqlDataReader reader = database.execReader(query);
                    hoursA = reader;
                    salary = hoursA * 100;


                    string query = "SELECT hoursWorked FROM Employee WHERE jobStatus = "'owner'" ";
                    SqlDataReader reader = database.execReader(query);
                    hoursO = reader;
                    salary = hoursO * 300;

                    income = "SELECT equipIncome FROM Equipment";

                    totalHours = hoursC + hoursA + hoursO;*/

                }

                /*revenue = income - salary;

                SumList.Items.Add("Total hours worked in CONSTRUCTION:" + "\t" + "Total hours worked in ADMINASTRATION:" + "\t" + "Total hours worked as OWNER:");
                SumList.Items.Add(hoursC.toString() + "\t" + hoursA.toString() + "\t" + hoursO.toString() + "\t" + income.toString());
                SumList.Items.Add("Total income acquired:");
                SumList.Items.Add("R" + income);
                SumList.Items.Add("Total revenue received:");
                SumList.Items.Add("R" + round(revenue.ToString(), 2));*/
            } catch
            {

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


}