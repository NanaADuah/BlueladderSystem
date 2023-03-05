using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class EquipmentReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            int eID = 0;
            Database database = new Database();
            User user = new User();
            bool attempt = int.TryParse(tbEquipmentID.Text, out eID);
            try
            {

                if (attempt)
                {
                    if (database.getCount($"SELECT COUNT(*) AS Total FROM [Equipment] WHERE [EquipmentID] = {eID}") == 0)
                    {
                        lblMessages.Text = "Equipment not found";
                    }
                    else
                    {
                        string selectEquip = database.get($"SELECT Available FROM [Equipment] WHERE EquipmentID = {eID}");
                        bool available = Convert.ToBoolean(selectEquip);

                        if (!available)
                        {
                            int ownerID = int.Parse(database.get($"SELECT [UserID] FROM [Equipment] WHERE EquipmentID = {eID}"));
                            if (ownerID == int.Parse(Session["UserID"].ToString()) || user.getRole(int.Parse(Session["UserID"].ToString())).Equals("Owner")|| user.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                            {

                                lblMessages.Text = "";
                                string query = $"UPDATE [Equipment] SET Available = 1, LastModified = '{DateTime.Now}',[UserID] = {Session["UserID"].ToString()} WHERE EquipmentID = {eID}";
                                if (database.update(query))
                                {
                                    if(database.getCount($"SELECT COUNT(*) AS Total FROM [EquipmentRequest] WHERE [EquipmentID] = {eID}") >= 0)
                                    {
                                        lblMessages.Text = "Equipment returned back!";

                                        if(database.delete($"DELETE FROM [EquipmentRequest] WHERE [EquipmentID] = {eID}"))
                                        {
                                            int targetID = int.Parse($"SELECT [UserID] FROM [EquipmentRequest] WHERE [EquipmentID] = {eID}");
                                            string message = "The equipment you requested for has been returned";
                                            string title = "Requested Equipment Returned";
                                            string notiQuery = $"INSERT INTO [Notifications] (SenderID, TargetID, Info, Time, Title) VALUES (0,{targetID},'{message}','{DateTime.Now}','{title}')";
                                            if(database.insert(notiQuery))
                                            {
                                                database.logInfo(int.Parse(Session["UserID"].ToString()),$"Equipment with ID: {eID}, has been returned by request");
                                                lblMessages.Text = "Equipment returned back and requests cleared!";
                                                lblMessages.ForeColor = System.Drawing.Color.Black;
                                            }
                                        }
                                    }
                                }
                                else
                                    lblMessages.Text = Database.getError();
                            }
                            else
                            {
                                lblMessages.Text = $"You cannot return equipment you did not request for";
                                lblMessages.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblMessages.Text = $"This equipment is already available. You cannot check it in";
                            lblMessages.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {
                    lblMessages.Text = "Invalid equipment ID, please try again";
                }
            }
            catch
            {
                lblMessages.Text = "Request not understood, please try again";
            }
        }
    }
}