using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace bcms
{
    public partial class Backup : System.Web.UI.Page
    {
        int countSaves = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            countSaves = countSaves + 1;
            lblNum.Text = countSaves.ToString();


            DateTime currentDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            lblDate.Text = currentDate.ToString();

            string folder = Server.MapPath("~/Scripts/");
            string fileName = "";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            Database database = new Database();


            if (database != null)
            {
                string dbName = "";
                fileName = $"{dbName}.sql";
                StreamWriter fs = File.CreateText(fileName);
                fs.Write(fs);
                fs.Close();
                InfoDisplay.Text = "Backup created.";
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string folder = Server.MapPath("~/Scripts/");
            string fileName = "";
            if (!Directory.Exists(folder))
            {
                Directory.Delete(folder);
                InfoDisplay.Text = "Backup Deleted";
            }
        }
  
    }
}