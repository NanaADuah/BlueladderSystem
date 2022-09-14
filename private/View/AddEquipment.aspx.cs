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

            tbLocation.Enabled = false;
            tbLocation.Text = "Magnolia";
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

        protected void btnAddEquipment_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            string eName = database.RemoveSpecialCharacters(tbName.Text);
            string category = database.RemoveSpecialCharacters(tbCategory.Text);
            string serialNumber = database.RemoveSpecialCharacters(tbSerial.Text);
            string details = database.RemoveSpecialCharacters(tbDetails.Text);
            string location = "Mangnolia";
            string manufacturer = database.RemoveSpecialCharacters(tbManufacturer.Text); 

            string query = $"INSERT INTO [Equipment] (UserID, Category, EquipmentName,SerialNumber, Details, LocationID, Manufacturer) VALUES ({int.Parse(Session["UserID"].ToString())},'{category}','{eName}','{serialNumber}','{details}',1,'{manufacturer}')";
            try
            {
                if (database.getCount($"SELECT COUNT(*) AS Total FROM Equipment WHERE SerialNumber = '{serialNumber}'") == 0)
                {

                    if (database.insert(query))
                    {
                        lblMessages.Text = "New equipment added! You can check it out under the Equipment page";
                        tbName.Text = "";
                        tbSerial.Text = "";
                        tbLocation.Text = location;
                        tbDetails.Text = "";
                        tbCategory.Text = "";
                        database.logInfo(int.Parse(Session["UserID"].ToString()), $"New equipment added. SerialNumber: '{serialNumber}'");
                        lblMessages.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblMessages.Text = "An error occurred, equipment could not be added";
                        lblMessages.ForeColor = System.Drawing.Color.Red;
                        database.logInfo(int.Parse(Session["UserID"].ToString()), Database.getError());
                    } 
                }else
                {
                    lblMessages.Text = "Equipment with the same serial number was found!";
                    lblMessages.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                lblMessages.Text = "An error occcurred, equipment could not be added";
                lblMessages.ForeColor = System.Drawing.Color.Red;
                database.logInfo(int.Parse(Session["UserID"].ToString()), Database.getError());
            }
        }
    }
}