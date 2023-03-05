using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class dashboard : System.Web.UI.Page
    {
        User user;
        protected string role = "worker";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            user = new User();

            string exMessage = "";

            role = user.getRole(int.Parse(Session["UserID"].ToString()));
            exMessage = Database.getError();

            if(exMessage.Length != 0)
            {
                lblMessage.Text = "Error: " + exMessage;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }else
            {
                lblMessage.ForeColor = System.Drawing.Color.Black;
                lblMessage.Text = "";

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(System.Object sender, System.EventArgs e)
        {
            Response.Redirect("ViewReports.aspx");
        }
    }
}