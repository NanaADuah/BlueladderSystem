using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class ViewNotification : System.Web.UI.Page
    {
        protected IList<SingleNotification> singleNotification;
        protected User valueUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            singleNotification = new List<SingleNotification>();
            valueUser = new User();

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            if (Request.QueryString["id"] == null)
                Response.Redirect("Notifications.aspx");
            else
            {
                int displayID = int.Parse(Request.QueryString["id"].ToString());
                displayNotification(displayID);
            }
            
        }

        private void displayNotification(int ID)
        {
            singleNotification = new List<SingleNotification>();
            Database database = new Database();

            try
            {
                string query = $"SELECT TOP 1 Info, SenderID, TargetID, Time, Title, NotificationID FROM [Notifications] WHERE NotificationID = {ID}";
                SqlDataReader reader = database.execReader(query);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        string NMessage = reader.GetValue(0).ToString();
                        int NSenderID = int.Parse(reader.GetValue(1).ToString());
                        int target = int.Parse(reader.GetValue(2).ToString());
                        DateTime NTime = Convert.ToDateTime(reader.GetValue(3).ToString());
                        string NTitle = reader.GetValue(4).ToString();
                        int NNotificationID = int.Parse(reader.GetValue(5).ToString());

                        if (target != int.Parse(Session["UserID"].ToString()))
                        {
                            Response.Redirect("Notifications.aspx");
                        }
                        singleNotification.Add(new SingleNotification
                        {
                            Message = NMessage,
                            SenderID = NSenderID,
                            Time = NTime,
                            Title = NTitle,
                            NotificationID = NNotificationID,
                        });
                    }
                }
                else
                {
                    lblMessages.Text = "An error occurred, please try again";
                }
            }
            catch
            {
                lblMessages.Text = "An error occurred, please try again";
            }

        }

        public class SingleNotification
        {
            public int NotificationID { get; set; } 
            public int SenderID { get; set; } 
            public string Message{ get; set; }
            public int ID { get; set; } 
            public DateTime Time { get; set; } 
            public string Title { get; set; } 
        }
    }
}