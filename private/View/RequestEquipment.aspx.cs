using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class RequestEquipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
        }

        protected void btnCanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipment.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            int eID = 0;
            bool attempt = int.TryParse(tbEquipmentID.Text, out eID);
            if (attempt)
            {
                if (database.getCount($"SELECT COUNT(*) AS Total FROM [Equipment] WHERE [EquipmentID] = {eID}" ) <= 0)
                {
                    lblMessages.Text = "Equipment not found";
                }
                if (database.getCount($"SELECT COUNT(*) AS Total FROM [EquipmentRequest] WHERE [EquipmentID] = {eID}") != 0)
                {
                    lblMessages.ForeColor = System.Drawing.Color.Red;
                    if (int.Parse(database.get($"SELECT UserID FROM [EquipmentRequest] WHERE EquipmentID = {eID}")) == int.Parse(Session["UserID"].ToString()))
                        lblMessages.Text = "You have already requested for this equipment, please wait until it's returned.";
                    else
                        lblMessages.Text = "This equipment has been requested for by another user already.";
                }
                else
                {
                    string selectEquip = database.get($"SELECT Available FROM [Equipment] WHERE EquipmentID = {eID}");
                    bool available = Convert.ToBoolean(selectEquip);
                    if (!available)
                    {
                        int ownerID = int.Parse(database.get($"SELECT [UserID] FROM [Equipment] WHERE EquipmentID = {eID}"));
                        if (ownerID == int.Parse(Session["UserID"].ToString()))
                        {
                            lblMessages.Text = $"You checked out this equipment, you cannot request for it to be returned";
                            lblMessages.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            string eName = database.get($"SELECT EquipmentName FROM [Equipment] WHERE EquipmentID = {eID}");
                            lblMessages.Text = $"Requesting for equipment {eName} from user: {ownerID}";
                            string message = $"User has requested that equipment: '{eName}' be returned and logged back onto the system database for use.";
                            int targetID = ownerID;
                            int senderID = int.Parse(Session["UserID"].ToString());
                            string title = "Equipment Request";

                            message = message.Replace("'", "");
                            title = title.Replace("'", "");
                            string query = $"INSERT INTO [Notifications] (SenderID, TargetID, Info, Time, Title) VALUES ({senderID},{targetID},'{message}','{DateTime.Now}','{title}')";
                            database.logInfo(int.Parse(Session["UserID"].ToString()), $"Request for equipment | Equipment ID:[{eID}]");
                            if (database.insert(query))
                            {
                                string requestQuery = $"INSERT INTO [EquipmentRequest] (EquipmentID, UserID) VALUES ({eID},{senderID})";
                                if (database.insert(requestQuery))
                                {
                                    lblMessages.Text = "Request submitted";
                                    lblMessages.ForeColor = System.Drawing.Color.Green;
                                    database.logInfo(senderID, $"Sent notification to {targetID}");
                                }
                                else
                                {
                                    lblMessages.Text = "Error, request not sent, please try again";
                                }
                            }
                            else
                            {
                                lblMessages.Text = "Error, request not sent, please try again";
                                lblMessages.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    } else
                    {
                        lblMessages.Text = "Cannot request for equipment that is freely available for use";
                        lblMessages.ForeColor = System.Drawing.Color.Red;

                    }
                }
            }else
            {
                lblMessages.Text = "Invalid Equipment ID";
                lblMessages.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}