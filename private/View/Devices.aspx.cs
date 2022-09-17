using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class Devices : System.Web.UI.Page
    {
        protected IList<Device> devices;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            string eMessage = Database.getError();
            lblMessages.Text = "Top [10] most recent device logins";
            devices = new List<Device>();
            Database database = new Database();
            string query = "SELECT TOP 10 DeviceName, UserID, DeviceType, DeviceID, Time FROM Devices ORDER BY TIME desc";
            if (eMessage.Length != 0)
                lblMessages.Text = "Error: " + eMessage;

            SqlDataReader reader = database.execReader(query);
            if(reader != null)
                while(reader.Read())
                {
                    devices.Add(new Device()
                    {
                        Name = reader.GetValue(0).ToString(),
                        UserID = reader.GetValue(1).ToString(),
                        Type = reader.GetValue(2).ToString(),
                        DeviceID = reader.GetValue(3).ToString(),
                        Time = Convert.ToDateTime(reader.GetValue(4).ToString()),
                        StrTime = Database.TimeAgo(Convert.ToDateTime(reader.GetValue(4).ToString())),
                    }) ; 
                }
        }
    }

    public class Device
    {
        public string Name { get; set; }
        public string Type { get; set; } 
        public string DeviceID { get; set; }
        public string UserID { get; set; }
        public DateTime Time { get; set; }
        public string StrTime { get; set; }
    }
}