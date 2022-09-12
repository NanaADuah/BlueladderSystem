using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{
    public partial class BackupInfo : System.Web.UI.Page
    {
        protected IList<String> dbNames;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");
            ViewState["databaseName"] = "User";
            if (!IsPostBack)
                lblMessages.Text = "";
        }

        protected void btnRemoveBackup_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            int bID ;
            lblDelMessage.ForeColor = System.Drawing.Color.Red;
            bool valid = int.TryParse(tbDeleteBackup.Text, out bID);
            if (!valid)
                lblDelMessage.Text = "Invalid backup ID";

            string query = $"SELECT COUNT(*) AS IExist FROM [Backup] WHERE BackupID = {bID}";
            int output = database.getCount(query);

            if(output == -1)
                lblDelMessage.Text = Database.getError();
            else
            if(output == 0)
                lblDelMessage.Text = $"No backups exist with ID '{bID}'";
            else
            if(database.removeBackup(bID))
                lblDelMessage.Text = "Database backup successfully deleted";
            else
                lblDelMessage.Text = "An error occured. Backup not deleted!";

        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            if (ViewState["databaseName"] != null && !ViewState["databaseName"].Equals("-1"))
            {
                string tName = ViewState["databaseName"] as string;
                Database database = new Database();
                string result = database.writeCSV(tName, int.Parse(Session["UserID"].ToString()));
                if (result.Equals("-1"))
                    lblMessages.Text = Database.getError();
                else
                    lblMessages.Text = $"Backup files made! Additional file stored at {result}";
            }else
            {
                lblMessages.Text = "Please select a database to save";
                lblMessages.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void rbEqipment_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["databaseName"] = "Equipment";
        }

        protected void rbEmployee_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["databaseName"] = "Employee";
        }

        protected void rbDevice_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["databaseName"] = "Devices";
        }

        protected void rbRequest_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["databaseName"] = "EquipmentRequest";
        }

        protected void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["databaseName"] = "User";
        }
    }
}