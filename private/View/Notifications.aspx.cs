using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected IList<Notification> notifications;
        protected string role = "worker";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User user = new User();
            role = user.getRole(int.Parse(Session["UserID"].ToString()));
            getNotifications();
        }
        public void getNotifications()
        {
            notifications = new List<Notification>();
            Database database = new Database();
            int ID = int.Parse(Session["UserID"].ToString());
            try
            {
                string query = $"SELECT * FROM [Notifications] WHERE TargetID = {ID}";
                SqlDataReader reader = database.execReader(query);

                if(reader != null)
                {
                    while (reader.Read())
                    {
                        notifications.Add(new Notification
                        {
                            NotificationID = int.Parse(reader.GetValue(0).ToString()),
                            SenderID = int.Parse(reader.GetValue(1).ToString()),
                            TargetID = int.Parse(reader.GetValue(2).ToString()),
                            Info = reader.GetValue(3).ToString(),
                            Time = Convert.ToDateTime(reader.GetValue(4).ToString()),
                            Title = (reader.GetValue(5).ToString())
                        });
                    }
                }
            }
            catch
            {
                lblMessages.Text = "Error retrieving notifications";
            }
        }
        public string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        protected void btnSendNoti_Click(object sender, EventArgs e)
        {
            int targetID;
            Database database = new Database();
            int senderID = int.Parse(Session["UserID"].ToString());
            lblNoti.Text = "";
            string message = RemoveSpecialCharacters(tbInfo.Text);
            bool attempt = int.TryParse(tbUserRecepientID.Text, out targetID);
            int wordLength = message.Length;
            string title = RemoveSpecialCharacters(tbTitle.Text);
            if (!attempt)
            {
                lblNoti.Text = "Invalid ID input, enter a valid ID";
                lblNoti.ForeColor = System.Drawing.Color.Red;
            }
            else
            if(String.IsNullOrEmpty(title) || title.Length > 25){ 
            }
                lblNoti.Text = "Invalid Title";
            {
                if (wordLength > 255)
                {
                    lblNoti.Text = "Notification too long, please shorten it";
                    lblNoti.ForeColor = System.Drawing.Color.Red;
                }
                else
                if (database.UserExists(targetID))
                {

                    if (targetID == int.Parse(Session["UserID"].ToString())) 
                    {
                        lblNoti.Text = "You cannot send notifications to yourself";
                        lblNoti.ForeColor = System.Drawing.Color.Red;
                    } else
                    {
                        
                        string query = $"INSERT INTO [Notifications] (SenderID, TargetID, Info, Time, Title) VALUES ({senderID},{targetID},'{message}','{DateTime.Now}','{title}')";
                        lblNoti.Text = "";
                        lblNoti.ForeColor = System.Drawing.Color.Black;

                        if (database.insert(query))
                        {
                            lblNoti.Text = "Notification submitted";
                            Response.Redirect("Notifications.aspx");
                        }
                        else
                        {
                            //lblNoti.Text = "Error, notification not sent, please try again";
                            lblNoti.Text = Database.getError();
                            lblNoti.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                } else
                {
                    lblNoti.Text = $"There is no user  within the system with User ID: {targetID}";
                    lblNoti.ForeColor = System.Drawing.Color.Red;
                } 
            }
        }

        public string Truncate(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        protected void btView_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }


    public class Notification
    {
        public int NotificationID { get; set; }
        public int SenderID { get; set; }
        public int TargetID { get; set; }
        public string Info { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
    }
}