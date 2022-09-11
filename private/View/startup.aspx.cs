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
            if (Session["UserID"] != null)
                Session.Remove("UserID");
            UI instance = new UI();
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            infoDisplay.Text = "Signing in, please wait...";
            int ID;
            Database database = new Database();
            User user = new User();
            bool attempt = int.TryParse(tbWorkID.Text, out ID);

            if(database.isActive())
            {
                if(!attempt)
                {
                    infoDisplay.ForeColor = System.Drawing.Color.Maroon;
                    infoDisplay.Text = "Invalid worker ID";
                }
                else{
                    string password = tbPassword.Text;

                    if (database.check(ID, password))
                        user.login(ID);
                    else
                    {
                        infoDisplay.Text = "Invalid credentials";
                        infoDisplay.Text = Database.getError();
                        infoDisplay.ForeColor = System.Drawing.Color.Red;
                    }
                }  
            }
            else
            {

                string error = Database.getError();
                infoDisplay.Text = $"Error accessing database, try again later | {error}";
                infoDisplay.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}