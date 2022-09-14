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
        protected DateTime FfileCreation;
        protected string FfileExtension;
        protected string FfileName;
        protected int FfileSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            FileInfo oFileInfo;
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
                        oFileInfo = new FileInfo(filename);
                        FfileName= oFileInfo.Name;
                        FfileCreation = oFileInfo.CreationTime;
                        FfileSize = int.Parse(oFileInfo.Length.ToString());
                        FfileExtension = oFileInfo.Extension;

                    }
                }
                else
                    Response.Redirect("Backup.aspx");
            }
        }

        public string GetBytesReadable(long i)
        {
            // Get absolute value
            long absolute_i = (i < 0 ? -i : i);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (i >> 50);
            }
            else if (absolute_i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (i >> 40);
            }
            else if (absolute_i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (i >> 30);
            }
            else if (absolute_i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (i >> 20);
            }
            else if (absolute_i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (i >> 10);
            }
            else if (absolute_i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
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