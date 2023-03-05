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
            report = new EReport();
            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin") || instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Owner"))
                Response.Redirect("dashboard.aspx");

            try
            {

                int numEquip = database.getCount("SELECT COUNT(*) AS Total FROM [Equipment]");
                report.TotalEquipment = numEquip;

                int numManu = database.getCount("SELECT COUNT(DISTINCT(Manufacturer)) AS Value FROM [Equipment]");
                report.TotalManufacturers = numManu;

                int currentRequests = database.getCount("SELECT COUNT(*) AS Value FROM [EquipmentRequest]");
                report.TotalRequests = currentRequests;

                int totalBookedEquipment = database.getCount("SELECT * FROM [Equipment] WHERE Available = '0'");
                report.TotalChecked = totalBookedEquipment;

                double averageIncome = double.Parse(database.get("SELECT AVG(Income) FROM [Equipment]"));
                report.AverageIncome = averageIncome;

                tbTotal.Text = report.TotalEquipment.ToString();
                tbTotalManu.Text = report.TotalManufacturers.ToString();
                tbTotalChecked.Text = report.TotalChecked.ToString();
                tbAverageEquipment.Text = "R" + report.AverageIncome.ToString("F2");
                tbRequested.Text = report.TotalRequests.ToString();
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
        public int TotalRequests{ get; set; }
        public int TotalChecked{ get; set; }
        public double AverageIncome{ get; set; }
    }
}