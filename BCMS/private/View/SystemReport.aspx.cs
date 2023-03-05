using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class SystemReport : System.Web.UI.Page
    {
        protected SReport report;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();
            Database database = new Database();
            report = new SReport();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin") || instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Owner"))
                Response.Redirect("dashboard.aspx");

            try
            {

                int numLogs = database.getCount("SELECT COUNT(*) AS Total FROM [Logs] WHERE Actions LIKE 'login%' GROUP BY DAY(Time)");
                report.AverageLogins = numLogs;

                int monthLogs = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE 'login%' GROUP BY MONTH(Time)");
                report.MonthlyLogs = monthLogs;

                int totalLogs = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE 'login%'");
                report.TotalLogins = totalLogs;

                int passwordChangeRequests = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE 'Password%'");
                report.PasswordChangeRequests = passwordChangeRequests;

                
                int notificatonsSent = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE '%notification%'");
                report.NotificationsSent = notificatonsSent; 
                
                int dailyNotificatonsSent = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE '%notification%' GROUP BY DAY(Time)");
                report.DailyNotificationsSent = dailyNotificatonsSent;



                tbTotal.Text = report.TotalLogins.ToString();
                tbMonthlyTotal.Text = report.MonthlyLogs.ToString();
                tbAverage.Text = report.AverageLogins.ToString();
                tbPasswordRequest.Text = report.PasswordChangeRequests.ToString();
                tbNotifications.Text= report.NotificationsSent.ToString();
                tbDailyNoti.Text= report.DailyNotificationsSent.ToString();

            }
            catch
            {
                lblMessages.Text = "An error occurred";
            }


        }

    }

    public class SReport
    {
        public int AverageLogins { get; set; } 
        public int TotalLogins { get; set; } 
        public int MonthlyLogs { get; set; }
        public int PasswordChangeRequests { get; set; }
        public int NotificationsSent { get; set; }
        public int DailyNotificationsSent { get; set; }


    }
}