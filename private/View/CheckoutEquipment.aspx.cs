using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class CheckoutEquipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            int eID;
            bool attempt = int.TryParse(tbEquipmentID.Text, out eID);
            if (attempt)
            {
                if (database.getCount($"SELECT COUNT(*) AS Total FROM [Equipment] WHERE [EquipmentID] = {eID}") <= 0)
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
                        if (ownerID == int.Parse(Session["UserID"].ToString()))
                            lblMessages.Text = $"You have already checked out this equipment | ID[{eID}] ";
                        else
                            lblMessages.Text = $"Equipment with ID[{eID}] is unavailable, please request for it to be returned first";

                        lblMessages.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblMessages.Text = "";

                        string query = $"UPDATE [Equipment] SET Available = 0, [UserID] = {Session["UserID"].ToString()} WHERE EquipmentID = {eID}";
                        if (database.update(query))
                        {
                            lblMessages.Text = "Equipment checked out!";
                            database.logInfo(int.Parse(Session["UserID"].ToString()),$"Checked out equipment,ID:[{eID}]");
                        }
                        else
                        {
                            lblMessages.Text = Database.getError();
                        }
                    }


                }
            }
            else
            {
                lblMessages.Text = "Invalid Equipment ID";
            }
        }

        protected void btnCanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipment.aspx");
        }
    }
}