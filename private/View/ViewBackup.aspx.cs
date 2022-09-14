using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class ViewBackup : System.Web.UI.Page
    {

        protected int viewID;
        protected string filename;
        protected string title = "Filename";
        protected bool fileExists = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            if (String.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("Backup.aspx");
            else
            {
                int temp = int.Parse(Request.QueryString["id"]);
                Database database = new Database();
                if (database.getCount($"SELECT COUNT(*) AS Total FROM [Backup] WHERE BackupID = {temp}") != 0)
                {
                    string fname = database.get($"SELECT FileName FROM [Backup] WHERE BackupID = {temp}");
                    title = fname;
                    filename = HttpContext.Current.Server.MapPath("~") +  fname;
                    if (backupExists(filename))
                    { 
                        viewID = temp;
                        fileExists = true; 
                    }
                }
                else
                    Response.Redirect("Backup.aspx");
            }
        }

        public bool backupExists(string filename)
        {
            if(File.Exists(filename))
            {
                return true;
            }
            return false;
        }
    }
}