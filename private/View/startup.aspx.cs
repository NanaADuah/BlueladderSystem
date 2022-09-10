using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace bcms
{
    public partial class startup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UI instance = new UI();
            Database database = new Database();
            if (!database.connect())
            {
                infoDisplay.Text = "Error connecting to system database...";
                infoDisplay.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                infoDisplay.Text = "Connecting to system database successful!";
                infoDisplay.ForeColor = System.Drawing.Color.Green;
                
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }
    }
}