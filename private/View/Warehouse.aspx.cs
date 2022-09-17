using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace bcms
{
    public partial class Warehouse : System.Web.UI.Page
    {
        protected IList<Warehouses> warehouses;
        protected Database database;
        protected void Page_Load(object sender, EventArgs e)
        {
            database = new Database();
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            warehouses = new List<Warehouses>();
            string query = "SELECT * FROM Warehouse";
            try
            {
                SqlDataReader reader = database.execReader(query);
                if(reader != null)
                    while(reader.Read())
                    {
                        warehouses.Add(new Warehouses()
                        {
                            LocationID = int.Parse(reader.GetValue(0).ToString()),
                            Name = reader.GetValue(1).ToString(),
                            Details= reader.GetValue(2).ToString(),
                        }) ; 
                    }
            }catch
            {
                Response.Redirect("dashboard.aspx");
            }
        }
    }

    public class Warehouses
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Details{ get; set; }
    }
}
