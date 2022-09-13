using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class ViewAll : System.Web.UI.Page
    {
        protected IList<IUser> users;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            string eMessage = "";

            
            string query = "SELECT UserID, Role FROM [User]";

            displayData(query);
            
            if (eMessage.Length != 0)
                lblMessages.Text = "Error: " + eMessage;
        }

        public void displayData(string query)
        {
            users = new List<IUser>();
            Database database = new Database();
            SqlDataReader reader = database.execReader(query);

            if (reader != null)
                while (reader.Read())
                {
                    users.Add(new IUser()
                    {
                        UserID = reader.GetValue(0).ToString(),
                        Role = reader.GetValue(1).ToString(),
                    });
                }
        }
        protected void lblFilter_TextChanged(object sender, EventArgs e)
        {
            string query;

            if(lblFilter.Text.Equals(""))
                query = "SELECT UserID, Role FROM [User]";
            else
                query = $"SELECT UserID, Role FROM [User] WHERE Role LIKE '%{lblFilter.Text}%'";

            displayData(query);
        }
    }
    public class IUser
    {
        public string Role { get; set; }
        public string UserID { get; set; }
    }
}