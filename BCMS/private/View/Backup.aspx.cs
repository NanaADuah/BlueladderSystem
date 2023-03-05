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
        protected IList<IBackup> backups;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin") && !instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Owner"))
                Response.Redirect("dashboard.aspx");

            string eMessage = Database.getError();
            backups = new List<IBackup>();

            Database database = new Database();

            string query = "SELECT * FROM [Backup] ORDER BY TIME DESC";

            SqlDataReader reader = database.execReader(query);
            if (eMessage.Length != 0)
                InfoDisplay.Text = "Error: " + eMessage;

            if (reader != null)
            {

                while (reader.Read())
                {
                    backups.Add(new IBackup()
                    {
                        BackupID = int.Parse(reader.GetValue(0).ToString()),
                        FileName = reader.GetValue(1).ToString(),
                        Time = Convert.ToDateTime(reader.GetValue(2).ToString()),
                        UserID = reader.GetValue(3).ToString(),
                        Type = reader.GetValue(4).ToString(),
                        StrTime = Database.TimeAgo(Convert.ToDateTime(reader.GetValue(2).ToString())),
                    });
                }
            }else
            {
                InfoDisplay.Text = $"Error:  {Database.getError()}";

            }    
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
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
        public string StrTime { get; set; }
    }
}