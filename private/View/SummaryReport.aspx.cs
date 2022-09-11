using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class SummaryReport : System.Web.UI.Page
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


            }


        }
    }
}