using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class BorrowedEquipment : System.Web.UI.Page
    {
        protected IList<BEquipment> borrows;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            int userID = int.Parse(Session["UserID"].ToString());
            string query = $"SELECT EquipmentID, LastModified, SerialNumber, EquipmentName, UserID FROM [Equipment] WHERE UserID = {userID}";
            Database database = new Database();
            SqlDataReader reader = database.execReader(query);
            borrows = new List<BEquipment>();

            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        borrows.Add(new BEquipment()
                        {
                            EquipmentID = int.Parse(reader.GetValue(0).ToString()),
                            LastModified = Convert.ToDateTime(reader.GetValue(1).ToString()),
                            Serial = reader.GetValue(2).ToString(),
                            EquipmentName = reader.GetValue(3).ToString(),
                            StrTime = Database.TimeAgo(Convert.ToDateTime(reader.GetValue(1).ToString())),
                        }
                        );
                    }
                }
            }
            catch
            {
                Response.Redirect("ManageEquipment.aspx");
            }
        }
    }

    public class BEquipment{
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string Serial{ get; set; }
        public string Detail { get; set; }
        public DateTime LastModified{ get; set; }
        public string StrTime { get; set; }
    }

}