using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class EmployeeReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                EmpReport.Items.Add("Employee Count" + "\t" + "Employee ID" + "\t" + "Name" + "\t\t" + "Surname" + "\t\t" + "Job Status");

                for (int count = 0; count < 30; count++)
                {

                    EmpReport.Items.Add((count + 1) + "\t" + database.GetType(userID).ToString() + "\t" + database.GetType(userName).ToString() + "\t\t" + database.GetType(userSurname).ToString() + "\t\t" + database.GetType(jobStatus).ToString());
                }
            }
        }
    }
}