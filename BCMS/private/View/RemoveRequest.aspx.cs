using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class RemoveRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            if (Request.QueryString["id"] != null)
            {
                Database database = new Database();
                int eID = int.Parse(Request.QueryString["id"]);
                try
                {
                    string query = $"DELETE FROM [EquipmentRequest] WHERE EquipmentID = {eID}";
                    if(database.delete(query))
                    {
                        Response.Redirect("ViewRequests.aspx");
                    }
                }
                catch
                {
                    Response.Redirect("ViewRequests.aspx");
                }
            }else
            {

            }    

        }
    }
}