using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace bcms
{
    public partial class ViewRequests : System.Web.UI.Page
    {
        protected IList<Requests> request;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            int userID = int.Parse(Session["UserID"].ToString());
            string query = $"SELECT LocationID, EquipmentID, UserID, Time FROM [EquipmentRequest] WHERE UserID = {userID}";
            Database database = new Database();
            SqlDataReader reader = database.execReader(query);
            request = new List<Requests>();

            try
            {
                if(reader != null)
                {
                    while (reader.Read())
                    {
                        request.Add(new Requests()
                        {
                            LocationID = int.Parse(reader.GetValue(0).ToString()),
                            EquipmentID = int.Parse(reader.GetValue(1).ToString()),
                            UserID = int.Parse(reader.GetValue(2).ToString()),
                            Time = Convert.ToDateTime(reader.GetValue(3).ToString()),
                            StrTime = Database.TimeAgo(Convert.ToDateTime(reader.GetValue(3).ToString())),
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

    public class Requests
    {
        public int UserID { get; set; }
        public int EquipmentID { get; set; }
        public int LocationID { get; set; }
        public DateTime Time { get; set; }
        public string StrTime { get; set; }
    }
}