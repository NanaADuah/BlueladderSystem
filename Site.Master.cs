using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
            Response.Write("<script>alert('Login not implemented yet, just click login');</script>");   //TODO: Remove
        }
    }
}