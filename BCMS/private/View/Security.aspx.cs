using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class Security : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            User instance = new User();
            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            if (!IsPostBack)
            {
                chkStatus.Visible = false;
                lblMessages.Text = "";

            }

        }

        protected void btnUpdateEnable_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (!user.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
            {
                Response.Redirect("dashboard.aspx");
            }
            else

            {
                int userValue;
                Database database = new Database();
                if (int.TryParse(tbUpdateEnables.Text, out userValue))
                {
                    chkStatus.Visible = true;
                    ViewState["ID"] = userValue;
                    if (userValue == int.Parse(Session["UserID"].ToString()))
                    {
                        lblMessages.Text = "You cannot change your status";
                        lblMessages.ForeColor = System.Drawing.Color.Red;
                        ViewState["ID"] = null;
                        chkStatus.Visible = false;
                    }
                    else
                    {
                        if (database.UserExists(userValue))
                        {
                            bool value = Convert.ToBoolean(database.get($"SELECT [Enabled] FROM [User] WHERE UserID = {userValue}").ToString());
                            if (value)
                                chkStatus.Checked = true;
                            else
                                chkStatus.Checked = false;
                        }
                        else
                        {
                            ViewState["ID"] = null;
                            chkStatus.Visible = false;
                            lblMessages.Text = "Invalid user ID";
                            lblMessages.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {
                    lblMessages.Text = "Invalid user ID";
                    lblMessages.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            User user= new User();
            if (!user.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin")) 
            {
                Response.Redirect("dashboard.aspx");
            }
            else
            {

                int userValue;
                Database database = new Database();
                string password = tbPassword.Text;
                try
                {

                    if (int.TryParse(tbUserID.Text, out userValue))
                    {
                        if (database.UserExists(userValue))
                        {
                            if (String.IsNullOrEmpty(password))
                            {
                                if (password.Length < 4)
                                {
                                    lblMessages.Text = "Password must have a minimum of 4 characters";
                                    lblMessages.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    if (database.updatePassword(int.Parse(Session["UserID"].ToString()), password))
                                    {
                                        database.logInfo(int.Parse(Session["UserID"].ToString()), $"Updated password for ID:{userValue}");
                                        tbPassword.Text = "";
                                        tbUserID.Text = "";
                                    }
                                }
                            }
                            else
                            {
                                lblMessages.Text = "Enter a password";
                                lblMessages.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblMessages.Text = "Invalid user ID";
                            lblMessages.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch
                {
                    lblMessages.Text = "Invalid data entered";
                    lblMessages.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            Database database = new Database();
            if (ViewState["ID"] != null)
            {
                int userID = int.Parse(ViewState["ID"].ToString());
                int value = 0;
                if (chkStatus.Checked)
                    value = 1;
                else
                if (!chkStatus.Checked)
                    value = 0;

                string query = $"UPDATE [User] SET Enabled = {value} WHERE UserID = {userID}";
                database.update(query);
                database.logInfo(userID, "Changed 'Enabled' setting for user");
                Response.Redirect("Security.aspx");
            } else
            {
                lblMessages.Text = "Values not updated";
            }

            chkStatus.Visible = false;
            ViewState["ID"] = null;
        }
    }
}