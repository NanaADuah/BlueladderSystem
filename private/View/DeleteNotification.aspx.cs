using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class DeleteNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            if (Request.QueryString["id"] == null)
                Response.Redirect("Notifications.aspx");

            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                deleteNotification(id);
                Response.Redirect("Notifications.aspx");
            }
            catch
            {
                Response.Redirect("Notifications.aspx");
            }

        }
        public void deleteNotification(int ID)
        {
            Database database = new Database();
            string query = $"DELETE FROM [Notifications] WHERE NotificationID = {ID}";
            database.delete(query);
            
        }
    }
}