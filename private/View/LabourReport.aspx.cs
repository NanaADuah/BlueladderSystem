using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace bcms
{


    public partial class LabourReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            Database database = new Database();
            database.connect();
            if (!database.isActive())
            {
                string error = Database.getError();
                InfoDisplay.Text = $"Error connecting to system database|{error}";
            }
            else
            {LabReport.Items.Add("Equipment Count" + "\t" + "Employee ID" + "\t" + "Equipment ID" + "\t\t" + "Equipment Type" + "\t\t" + "Equipment Location");
                for (int count = 0; count <= 250; count++)
                {
                 LabReport.Items.Add((count + 1) + "\t" + database.GetType(userID).ToString() + "\t" + database.GetType(equipID).ToString() + "\t\t" + database.GetType(equipType).ToString() + "\t\t" + database.GetType(storageArea).ToString());
                }


            }
            */
        }

        public class LReport
        {
            public int ID { get; set; }
        }
    }
}