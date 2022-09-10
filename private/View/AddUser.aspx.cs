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

            User logUser = new User();
            AddUser user = new AddUser();

            try
            {

                user.add(logUser,defaultPassword,role,date, firstName, lastName, gender);
                string output = user.getOutput();
                lblMessages.Text = output;

            }
            catch(Exception ex)
            {
                lblMessages.Text = $"Error: {ex.Message}";
                lblMessages.ForeColor = System.Drawing.Color.Red;
                
            }
            finally
            {
                Response.Redirect("dashboard.aspx");
            }
        }
    }
}