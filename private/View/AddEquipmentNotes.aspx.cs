using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class AddEquipmentNotes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipment.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string data = tbDetails.Text;
            Database database = new Database();
            int eID;
            bool attempt = int.TryParse(tbEquipmentID.Text, out eID);
            if (attempt)
            {
                if (database.getCount($"SELECT COUNT(*) AS Total FROM [Equipment] WHERE [EquipmentID] = {eID}") <= 0)
                {
                    lblMessages.Text = "Equipment not found";
                }
                {
                    data = database.RemoveSpecialCharacters(data);
                    string query = $"UPDATE [Equipment] SET Detail = '{data}' WHERE EquipmentID = {eID}";
                    try
                    {
                        if(database.update(query))
                        {
                            database.logInfo(int.Parse(Session["UserID"].ToString()), $"Updated equipment notes, ID[{eID}]:");
                            lblMessages.Text = "Notes added!";
                        }
                    }
                    catch
                    {
                        lblMessages.Text = "An error occurred";
                    }

                }
            }

        }
    }
}