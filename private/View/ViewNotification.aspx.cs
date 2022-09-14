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

        public static string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("about {0} {1} ago",
                years, years == 1 ? "year" : "years");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("about {0} {1} ago",
                months, months == 1 ? "month" : "months");
            }
            if (span.Days > 0)
                return String.Format("about {0} {1} ago",
                span.Days, span.Days == 1 ? "day" : "days");
            if (span.Hours > 0)
                return String.Format("about {0} {1} ago",
                span.Hours, span.Hours == 1 ? "hour" : "hours");
            if (span.Minutes > 0)
                return String.Format("about {0} {1} ago",
                span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            if (span.Seconds > 5)
                return String.Format("about {0} seconds ago", span.Seconds);
            if (span.Seconds <= 5)
                return "just now";
            return string.Empty;
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