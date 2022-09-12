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
           // btnGenerate.Visible = false;
           // btnGenerate.Enabled = false;

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            string query = "SELECT EquipmentID, UserID, Category, EquipmentName, Manufacturer, SerialNumber, Available FROM Equipment";
            displayData(query); 
        }

        public void displayData(string query)
        {

            equipment = new List<IEquipment>();
            //lblMessages.Text = "";
            Database database = new Database();
            User user = new User();
            SqlDataReader reader = database.execReader(query);
            
            string eMessage = Database.getError();
            if (eMessage.Length != 0)
                lblMessages.Text = "Error: " + eMessage;

            if (reader != null)
            {
                lblMessages.Text = "";
                while (reader.Read())
                {
                    string EquipmentID = reader.GetValue(0).ToString();
                    string UserID = reader.GetValue(1).ToString();
                    string Category = reader.GetValue(2).ToString();
                    string EquipmentName = reader.GetValue(3).ToString();
                    string Manufacturer = reader.GetValue(4).ToString();
                    string SerialNumber = reader.GetValue(5).ToString();
                    bool Avail = bool.Parse(reader.GetValue(6).ToString());

                    equipment.Add(new IEquipment()
                    {
                        EquipmentID = EquipmentID,
                        UserID = UserID,
                        Category = Category,
                        EquipmentName = EquipmentName,
                        Manufacturer = Manufacturer,
                        SerialNumber = SerialNumber,
                        Available = Avail,
                    });
                }
            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            Database database = new Database();

            if (Session["UserID"] != null)
            {
                if (database.generateEquipment(100))
                    lblMessages.Text = "Sucess";
                else
                    lblMessages.Text = "Eror: " + Database.getError();
            }
            else
            {
                lblMessages.Text = "User not recognized";
            }
        }

        protected void lblFilter_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            string query= "SELECT *  FROM Equipment ORDER BY EquipmentID ASC";

            if(!String.IsNullOrEmpty(tbSearch.Text))
            {
                if (Request.QueryString["filter"] != null)
                {
                    string filter = Request.QueryString["filter"];
                    if (filter.Equals("equipmentname") || filter.Equals("manufacturer") ||  filter.Equals("category")) 
                        query = $"SELECT * FROM Equipment WHERE {Request.QueryString["filter"]} LIKE '{search}%'";
                    if(filter.Equals("userid"))
                        query = $"SELECT * FROM Equipment WHERE UserID = {search}";
                }
                else
                    query = $"SELECT * FROM Equipment WHERE EquipmentName LIKE '{search}%'";
            }
            displayData(query);

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
        public string ModName { get; set; }
        public bool Available { get; set; }
    }
}