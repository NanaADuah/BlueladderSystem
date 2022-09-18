using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;
using QRCoder;

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

            SqlDataReader reader = database.execReader($"SELECT EquipmentID, UserID, Category, EquipmentName, Manufacturer, SerialNumber, Available, Details, LocationID, Income, LastModified FROM [Equipment] WHERE EquipmentID = {id}");

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
                    currEquip.Income =double.Parse(reader.GetValue(9).ToString());
                    currEquip.LastModified = Convert.ToDateTime(reader.GetValue(10).ToString());
                    currEquip.StrTime = Database.TimeAgo(Convert.ToDateTime(reader.GetValue(10).ToString()));
                }
            }
            currEquip.Location = database.get($"SELECT [Name] FROM [Warehouse], [Equipment] WHERE [Equipment].LocationID = {currEquip.LocationID}");
                if(String.IsNullOrEmpty(currEquip.Detail))
                    tbDetails.Text = "No details to show";
                else
                    tbDetails.Text = currEquip.Detail;

                string qrText = $"Blueladder Construction Management System\nEquipment name: {currEquip.Name}\nID: {currEquip.EquipmentID}\nSerial: {currEquip.SerialNumber}\nDate captured: {DateTime.Now}";
                try
                {
                    
                    GenerateMyQCCode(qrText, currEquip.SerialNumber);

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
                lblMessages.Text = "An error occurred";
            }

        }

        private void GenerateMyQCCode(string QCText, string serial)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QCText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                //QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                imgBarCode.Height = 150;
                imgBarCode.Width = 150;
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();
                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                    plBarCode.Controls.Add(imgBarCode);
                    plBarCode.Visible = true;
                }

            }
            catch(Exception ex)
            {
                lblMessages.Text = ex.Message;
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
        public double Income { get; set; }
        public DateTime LastModified{ get; set; }
        public string StrTime{ get; set; }
    }
}