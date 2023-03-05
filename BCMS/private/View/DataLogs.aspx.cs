using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace bcms
{
    public partial class DataLogs : System.Web.UI.Page
    {
        protected IList<DataLog> datalogs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin") && !instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            string eMessage = Database.getError();
            datalogs = new List<DataLog>();

            Database database = new Database();
            string query = "SELECT TOP 50 * FROM [Logs] ORDER BY TIME DESC";
            if (eMessage.Length != 0)
                lblMessages.Text = "Error: " + eMessage;

            SqlDataReader reader = database.execReader(query);
            if (reader != null)
                while (reader.Read())
                {
                    datalogs.Add(new DataLog()
                    {
                        LogID = int.Parse(reader.GetValue(0).ToString()),
                        UserID = int.Parse(reader.GetValue(1).ToString()),
                        Action = reader.GetValue(2).ToString(),
                        Time = Convert.ToDateTime(reader.GetValue(3).ToString()),
                        StrTime = Database.TimeAgo(Convert.ToDateTime(reader.GetValue(3).ToString())),

                    });
                }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            database.writeCSV("Logs", int.Parse(Session["UserID"].ToString()));
        }
    }

    public class DataLog
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string Action{ get; set; }
        public DateTime Time { get; set; }
        public string StrTime { get; set; }
    }
}