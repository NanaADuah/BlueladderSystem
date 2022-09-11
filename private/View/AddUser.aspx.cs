using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
namespace bcms
{
    public partial class AddUser1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessages.Text = "";
            lblMessages.ForeColor = System.Drawing.Color.Black;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string email = inputEmail.Text;
            string gender = tbGender.Value;
            string jobStatus = inputStatus.Text;
            string defaultPassword = inputDefaultPassword.Text;
            string role = tbRole.Value.ToString();
            DateTime date = DateTime.Now.Date;

            if(!role.Equals("worker",StringComparison.OrdinalIgnoreCase))
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Selected system role not allowed";
            }
            else
            {
                AddUser user = new AddUser();

                try
                {

                    int value = user.UserAdd(role, defaultPassword);
                    if (value != -1)
                    {
                        user.EmployeeAdd(int.Parse(Session["UserID"].ToString()),value,jobStatus,date, firstName, lastName, gender, email);
                    }
                    else
                        lblMessages.Text = Database.getError();

                }
                catch(Exception ex)
                {
                    lblMessages.Text = $"Error: {ex.Message}";
                    lblMessages.ForeColor = System.Drawing.Color.Red;
                
                }
                finally
                {
                    lblMessages.Text = Database.getError();
                    //Response.Redirect("dashboard.aspx");
                }
            }
        }
    }
}