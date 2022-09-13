using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class UserSettings : System.Web.UI.Page
    {
        protected string currentPage = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            if (String.IsNullOrEmpty(Request.QueryString["task"]))
                Response.Redirect("ManageUsers.aspx");
            else
            {
                string temp = Request.QueryString["task"];
                if(temp.Equals("setting", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("permission", StringComparison.CurrentCultureIgnoreCase))
                    currentPage = temp;
                else
                    Response.Redirect("ManageUsers.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}