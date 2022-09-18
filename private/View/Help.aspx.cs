using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class Help : System.Web.UI.Page
    {
        protected string HelpText = "default";
        protected void Page_Load(object sender, EventArgs e)
        {
            List <String> TabValues = new List<String>();
            TabValues.Add("default");
            TabValues.Add("notifications");
            TabValues.Add("profile");
            TabValues.Add("settings");
            TabValues.Add("equipment");
            TabValues.Add("search");
            TabValues.Add("users");
            TabValues.Add("backups");
            TabValues.Add("profile");
            TabValues.Add("home");
            TabValues.Add("dashboard");
            TabValues.Add("reports");
            TabValues.Add("devices");

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            if (Request.QueryString["tab"] == null)
                Response.Redirect("Help.aspx?tab=default");

            else
            {
                if (!TabValues.Contains(Request.QueryString["tab"].ToString()))
                { 
                    Response.Redirect("Help.aspx?tab=default");
                    HelpText = "default";
                }
                else
                    HelpText = Request.QueryString["tab"].ToString();
            }

        }

        protected void btnViewOptions_Click(object sender, EventArgs e)
        {

        }
    }
}