using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Math;
using System.Data.SqlClient;

namespace bcms
{
    public partial class SummaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double salary, income, revenue, hoursC, hoursA, hoursO, totalHours;

            Database database = new Database();
            database.connect();

            if (!database.isActive())
            {
                string error = Database.getError();
                infoDisplay.Text = $"Error connecting to system database|{error}";
                infoDisplay.ForeColor = System.Drawing.Color.Red;
            }


            else
            {
                infoDisplay.Text = "Connecting to system database successful!";
                infoDisplay.ForeColor = System.Drawing.Color.Green;

                for (int count = 0; count <= 250; count++)
                {
                    string query = "SELECT hoursWorked FROM Employee WHERE jobStatus = "'construction worker'" ";
                    SqlDataReader reader = database.execReader(query);
                    hoursC = reader;
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

                    totalHours = hoursC + hoursA + hoursO;

                }

                revenue = income - salary;

                SumList.Items.Add("Total hours worked in CONSTRUCTION:" + "\t" + "Total hours worked in ADMINASTRATION:" + "\t" + "Total hours worked as OWNER:");
                SumList.Items.Add(hoursC.toString() + "\t" + hoursA.toString() + "\t" + hoursO.toString() + "\t" + income.toString());
                SumList.Items.Add("Total income acquired:");
                SumList.Items.Add("R" + income);
                SumList.Items.Add("Total revenue received:");
                SumList.Items.Add("R"+round(revenue.ToString(),2));
            }

           



        }
    }


}