using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class AddUser2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin") && !instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Owner"))
                Response.Redirect("dashboard.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            int ID;
            string Role = tbRole.Text;
            string password = tbPassword.Text;
            User user = new User();

            if (user.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
            {
                if (Role.Equals("Admin") || Role.Equals("Owner") || Role.Equals("Worker"))
                {
                    Database database = new Database();
                    ID = database.UserAdd(int.Parse(Session["UserID"].ToString()), Role, password);
                    if (ID != -1)
                    {
                        lblMessages.Text = $"New user added. User ID is: {ID}";
                    }else
                    {
                        lblMessages.Text = $"Error occurred, new user not creacted";
                    }
                }
                else
                {
                    Response.Redirect("AddUser.aspx");
                }
            }
        }

       
    }
}