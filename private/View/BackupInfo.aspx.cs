using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class BackupInfo : System.Web.UI.Page
    {
        protected IList<String> dbNames;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemoveBackup_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            int bID = 0;
            if(database.removeBackup(bID))
            {

            }

        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            string backupData;
        }
    }
}