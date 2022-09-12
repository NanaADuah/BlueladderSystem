using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace bcms
{
    public partial class Backup : System.Web.UI.Page
    {
        int countSaves = 0;
        protected IList<IBackup> backups;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            string eMessage = Database.getError();
            backups = new List<IBackup>();

            Database database = new Database();

            string query = "SELECT * FROM BackUp ORDER BY TIME ASC";

            SqlDataReader reader = database.execReader(query);
            if (eMessage.Length != 0)
                InfoDisplay.Text = "Error: " + eMessage;

            if (reader != null)
                while (reader.Read())
                {
                    backups.Add(new IBackup()
                    {
                        BackupID = int.Parse(reader.GetValue(0).ToString()),
                        FileName = reader.GetValue(1).ToString(),
                        Time = Convert.ToDateTime(reader.GetValue(2).ToString()),
                        UserID = reader.GetValue(3).ToString(),
                        Type = reader.GetValue(4).ToString(),
                    });
                }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime currentDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);

            string folder = Server.MapPath("~/Scripts/");
            string fileName = "";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            Database database = new Database();


            if (database != null)
            {
                string dbName = "";
                fileName = $"{dbName}.sql";
                StreamWriter fs = File.CreateText(fileName);
                fs.Write(fs);
                fs.Close();
                InfoDisplay.Text = "Backup created.";
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string folder = Server.MapPath("~/Scripts/");
            string fileName = "";
            if (!Directory.Exists(folder))
            {
                Directory.Delete(folder);
                InfoDisplay.Text = "Backup Deleted";
            }
        }

        protected void btnViewOptions_Click(object sender, EventArgs e)
        {
            Response.Redirect("BackupInfo.aspx");
        }
    }

    public class IBackup
    {
        public int BackupID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string UserID { get; set; }
        public DateTime Time { get; set; }
    }
}