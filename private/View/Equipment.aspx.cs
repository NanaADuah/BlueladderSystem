using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class Equipment : System.Web.UI.Page
    {
        protected IList<IEquipment> equipment;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            equipment = new List<IEquipment>();
            lblMessages.Text = "";
            Database database = new Database();
            string query = "SELECT * FROM Equipment";
            SqlDataReader reader = database.execReader(query);

            string eMessage = Database.getError();
            if (eMessage.Length != 0)
                lblMessages.Text = "Error: " + eMessage;

            if (reader != null)
                while (reader.Read())
                {
                    equipment.Add(new IEquipment()
                    {
                        EquipmentID = reader.GetValue(0).ToString(),
                        UserID = reader.GetValue(1).ToString(),
                        Category = reader.GetValue(2).ToString(),
                        EquipmentName = reader.GetValue(0).ToString(),
                        Manufacturer = reader.GetValue(2).ToString(),
                        SerialNumber = reader.GetValue(3).ToString(),
                    });
                }
        }
    }

    public class IEquipment
    {
        public string EquipmentName { get; set; }
        public string EquipmentID { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber{ get; set; }
        public string UserID{ get; set; }
    }
}