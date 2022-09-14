using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            int ID;
            bool attempt = int.TryParse(tbID.Text, out ID);
            DateTime now = DateTime.Now;
            string email = emailReset.Text;

            if (attempt) 
            { 
                if (Response.Cookies["RequestChange"] == null && Response.Cookies["RequestChange"].Expires < DateTime.Now)
                {
                    try
                    {
                        Database database = new Database();

                        if (!database.UserExists(ID))
                        {
                            lblMessages.Text = "Invalid user ID";
                        }else
                        {

                            HttpCookie requestTimer = new HttpCookie("RequestChange");
                            requestTimer.Value = ID.ToString();
                            requestTimer.Expires = now.AddMinutes(1);
                            database.requestPassChange(email,ID);
                            database.logInfo(ID, "Password change request");
                        }
                    }
                    catch (Exception)
                    {
                        lblMessages.Text = "Error occured, please try again later";
                    }
                }
                else
                { 
                   lblMessages.Text = "You recently requested, please wait and try again later";
                    lblMessages.ForeColor = System.Drawing.Color.Red;

                }
            }else
            {
                lblMessages.Text = "Invalid user ID";
            }
        }
    }
}