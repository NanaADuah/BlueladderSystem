using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class EquipmentReport : System.Web.UI.Page
    {
        protected EReport report;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();
            Database database = new Database();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin") || instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Owner"))
                Response.Redirect("dashboard.aspx");

            try
            {

                int numEquip = database.getCount("SELECT COUNT(*) AS Total FROM [Equipment] GROUP BY EquipmentName");
                //int nuEquip = database.getCount("SELECT COUNT(DISTINCT EquipmentName) AS Total FROM [Equipment] ");
                report.TotalEquipment = numEquip;

                int numManu = database.getCount("SELECT COUNT(*) AS Value FROM [Equipment] GROUP BY Manufacturer");
                report.TotalManufacturers = numManu;

                /* int totalLogs = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE 'login%'");
                 report.TotalLogins = totalLogs;

                 int passwordChangeRequests = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE 'Password%'");
                 report.PasswordChangeRequests = passwordChangeRequests;


                 int notificatonsSent = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE '%notification%'");
                 report.NotificationsSent = notificatonsSent; 

                 int dailyNotificatonsSent = database.getCount("SELECT COUNT(*) AS Value FROM [Logs] WHERE Actions LIKE '%notification%' GROUP BY DAY(Time)");
                 report.DailyNotificationsSent = dailyNotificatonsSent;
                */


                tbTotal.Text = report.TotalEquipment.ToString();
                tbMonthlyTotal.Text = report.TotalManufacturers.ToString();
                /* tbAverage.Text = report.AverageLogins.ToString();
                 tbPasswordRequest.Text = report.PasswordChangeRequests.ToString();
                 tbNotifications.Text= report.NotificationsSent.ToString();
                 tbDailyNoti.Text= report.DailyNotificationsSent.ToString();*/

            }
            catch
            {
                lblMessages.Text = "An error occurred";
            }
        }
    }

    public class EReport
    {
        public int TotalEquipment { get; set; }
        public int TotalManufacturers { get; set; }
    }
}