using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class AddEquipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
        }

        protected void btnSendNoti_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            if(!database.generateEquipment(200))
            {
                lblMessages.Text = Database.getError();

            }
            /*Database database = new Database();
            int UserID = int.Parse(Session["UserID"].ToString());
            string category = database.RemoveSpecialCharacters(tbCategory.Text); ;
            string eName = database.RemoveSpecialCharacters(tbNAme.Text);
            string serialNum = database.RemoveSpecialCharacters(tbSerial.Text); ;
            string details = database.RemoveSpecialCharacters(tbDetails.Text);

            string query = $"INSERT INTO [Equipment] (UserID, Category, EquipmentName) VALUES ({UserID},'{category}','{eName}','{serialNum}')";
            if(database.insert(query))
            {
                Response.Redirect("Equipment.aspx");
            }
            else
            {
                lblMessages.Text = "Unable to add new data";
                lblMessages.ForeColor = System.Drawing.Color.Red;
            }*/
        }
    }
}