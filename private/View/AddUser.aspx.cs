using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
namespace bcms
{
    public partial class AddUser1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessages.Text = "";
        }

        public static string EncryptPassword(string Password)
        {
            string result = "default";
            try
            {
                SHA256Managed hasher = new SHA256Managed();

                byte[] passBytes = new UTF8Encoding().GetBytes(Password);
                byte[] keyBytes = hasher.ComputeHash(passBytes);

                hasher.Dispose();
                result = Convert.ToBase64String(keyBytes);
            }catch(Exception ex)
            {
                UI instace = new UI();
                instace.displayMessage(ex.Message);
            }

            return result;

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
            user.add(logUser,defaultPassword,role,date);

            lblMessages.Text = $"Creating account for:{firstName} {lastName}, {gender}, {email}";
        }
    }
}