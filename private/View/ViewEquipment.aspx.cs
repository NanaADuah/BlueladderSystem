using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using System.Data.SqlClient;

namespace bcms
{
    public partial class ViewEquipment : System.Web.UI.Page
    {
        protected Equip currEquip;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            getEquip();
        }

        public void getEquip()
        {
            currEquip = new Equip();
            Database database = new Database();
            try
            {

            int id = int.Parse(Request.QueryString["id"].ToString());

            SqlDataReader reader = database.execReader($"SELECT TOP 1 * FROM [Equipment] WHERE EquipmentID = {id}");

            if (reader != null) { 
                while (reader.Read())
                {
                    currEquip.EquipmentID = int.Parse(reader.GetValue(0).ToString());
                    currEquip.UserID = int.Parse(reader.GetValue(1).ToString());
                    currEquip.Category= reader.GetValue(2).ToString();
                    currEquip.Name= reader.GetValue(3).ToString();
                    currEquip.Manufacturer= reader.GetValue(4).ToString();
                    currEquip.SerialNumber= reader.GetValue(5).ToString();
                    currEquip.Available = Convert.ToBoolean(reader.GetValue(6).ToString());
                    currEquip.Detail= reader.GetValue(7).ToString();
                    currEquip.LocationID =int.Parse(reader.GetValue(8).ToString());
                }
            }
            currEquip.Location = database.get($"SELECT [Name] FROM [Warehouse], [Equipment] WHERE [Equipment].LocationID = {currEquip.LocationID}");
                if(String.IsNullOrEmpty(currEquip.Detail))
                    tbDetails.Text = "No details to show";
                else
                    tbDetails.Text = currEquip.Detail;

                string qrText = $"Blueladder Construction Management System\nEquipment name: {currEquip.Name}\nID: {currEquip.Name}\nSerial: {currEquip.SerialNumber}\nDate captured: {DateTime.Now}";
                try
                {
                    
                GenerateMyQCCode(qrText, currEquip.SerialNumber);
                ReadQRCode(currEquip.SerialNumber);
                }
                catch(Exception ex)
                {
                    lblMessages.Text = ex.Message;
                }
                lblQRCode.Text = currEquip.SerialNumber;
                tbManufacturer.Text = currEquip.Manufacturer;
                tbEquipmentName.Text = currEquip.Name;
                tbLocation.Text = currEquip.Location;
                tbModified.Text = currEquip.UserID.ToString();
            }
            catch
            {
                //   Response.Redirect("Equipment.aspx");
                lblMessages.Text = "An error occurred";
            }

        }

        private void GenerateMyQCCode(string QCText, string serial)
        {
            try
            {

            var QCwriter = new BarcodeWriter();

            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(QCText);
            string path = Server.MapPath($"~/public/qr/{serial}.jpg");
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path,
                   FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            imgageQRCode.Visible = true;
            imgageQRCode.ImageUrl = $"~/public/qr/{serial}.jpg";
            }
            catch(Exception ex)
            {
                lblMessages.Text = ex.Message;
            }

        }

        private void ReadQRCode(string serial)
        {
            var QCreader = new BarcodeReader();
            string QCfilename = HttpContext.Current.Server.MapPath("~") +$"public\\qr\\{serial}.jpg";
            var QCresult = QCreader.Decode(new Bitmap(QCfilename));
            if (QCresult != null)
            {
                throw new Exception("Error reading equipment QR Code");
            }
        }

        public void view()
        {
            Database database = new Database();
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    string serial = database.get($"SELECT TOP 1 SerialNumber FROM [Equipment] WHERE EquipmentID = {id}");
                    
                }
                catch
                {
                    lblMessages.Text = "An error occcurred, please try again";
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            
        }
    }

    public class Equip
    {
        public int EquipmentID { get; set; }
        public int UserID { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Available { get; set; }
        public string Location{ get; set; }
        public int LocationID{ get; set; }
        public string Manufacturer{ get; set; }
        public string Detail { get; set; }
    }
}