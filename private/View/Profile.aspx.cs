using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;

namespace bcms
{
    public partial class Profile : System.Web.UI.Page
    {
        protected ViewUser profile;
        protected string role = "worker";
        protected bool isWorker = true;
        protected string imageLink;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            role = instance.getRole(int.Parse(Session["UserID"].ToString()));

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            int ID;

          
            if (Request.QueryString["id"] != null)
            {
                ID = int.Parse(Request.QueryString["id"]);
                SetProfile(ID);
            }
            else
                Response.Redirect("ViewEmployees.aspx");
        }

        public void SetProfile(int ID)
        {
            User e = new User();
            Database database = new Database();
            

            if(database.UserExists(ID))
            {
                if (e.getRole(ID).Equals("Worker", StringComparison.CurrentCultureIgnoreCase))
                {
                    isWorker = true;
                    profile = new ViewUser();
                    SqlDataReader reader = database.execReader($"SELECT * FROM [Employee] WHERE UserID = {ID}");
                    string defaultImage = "placeholder.png";
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            profile.EmployeeID = reader.GetValue(0).ToString();
                            profile.UserID = reader.GetValue(1).ToString();
                            profile.Name = reader.GetValue(2).ToString();
                            profile.Surname = reader.GetValue(3).ToString();
                            profile.JobStatus = reader.GetValue(4).ToString();
                            profile.Gender = reader.GetValue(5).ToString();
                            profile.BirthDate = Convert.ToDateTime(reader.GetValue(6).ToString());
                            profile.Image = reader.GetValue(7).ToString();
                            profile.Email = reader.GetValue(8).ToString();

                            inputUserID.Text = profile.UserID;
                            inputLastName.Text = profile.Surname;
                            inputFirstName.Text = profile.Name;
                            inputGender.Text = profile.Gender;
                            inputBirthday.Text = profile.BirthDate.ToString("dd MM yyyy");
                            inputEmailAddress.Text = profile.Email;
                            inputJobStatus.Text = profile.JobStatus;

                            string link = ".. / .. /public/includes/profile/";
                            if (profile.Image.Equals("") || profile.Image == null)
                            {
                                if (profile.Gender.Equals("female", StringComparison.OrdinalIgnoreCase))
                                    profile.Image = link + "female.jpg";
                                else
                                if (profile.Gender.Equals("male", StringComparison.OrdinalIgnoreCase))
                                    profile.Image = link + "male.jpg";
                                else
                                    profile.Image = link + defaultImage;
                                    
                            }
                            else
                            {
                                profile.Image = HttpContext.Current.Server.MapPath("~") + profile.Image;
                            }
                            
                            imgProfile.ImageUrl = profile.Image;

                        }
                    }
                }else
                {
                    Response.Redirect("ManageUsers.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int ID = int.Parse(Request.QueryString["ID"]);

                User user = new User();
                if (user.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin", StringComparison.CurrentCultureIgnoreCase))
                {
                    string updateName = inputFirstName.Text;
                    string updateSurname = inputLastName.Text;
                    string updatejobStatis = inputJobStatus.Text;
                    string query = $"UPDATE Employee SET FirstName = '{updateName}',LastName = '{updateSurname}', JobStatus='{updatejobStatis}' WHERE Employee.UserID = {ID}";
                    Database database = new Database();
                    database.update(query);
                }
            }
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageUsers.aspx");
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            if(profile != null)
            {
                if (FileUploader.PostedFile != null)
                {
                    Database database = new Database();
                    string folderPath = HttpContext.Current.Server.MapPath("~") + $"public\\includes\\profile\\{profile.UserID}\\";
                    string extension = Path.GetExtension(FileUploader.FileName);
                    try
                    {

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
                        {
                            Stream strm = FileUploader.PostedFile.InputStream;
                            using (var image = System.Drawing.Image.FromStream(strm))
                            {

                                int newWidth = 240; // New Width of Image in Pixel  
                                int newHeight = 240; // New Height of Image in Pixel  

                                var thumbImg = new Bitmap(newWidth, newHeight);
                                var thumbGraph = Graphics.FromImage(thumbImg);
                                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                                thumbGraph.DrawImage(image, imgRectangle);
                                string fileName = HttpContext.Current.Server.MapPath("~") + $"public\\includes\\profile\\{profile.UserID}\\{profile.UserID}{extension}";


                                string targetPath = fileName;
                                thumbImg.Save(targetPath, image.RawFormat);
                                string firstFileName = $"public\\includes\\profile\\{profile.UserID}\\{profile.UserID}{extension}";

                                string query = $"UPDATE [Employee] SET [Image] = '{firstFileName}' WHERE UserID = {profile.UserID}";
                                database.update(query);
                                imgProfile.ImageUrl = fileName;
                                lblMessages.Text = "Uploaded!";
                                database.logInfo(int.Parse(Session["UserID"].ToString()), "Uploaded new profile image");
                            }
                        }
                    }catch
                    {
                        lblMessages.Text = "Error uploading image, please try again!";
                    }
                }
            }
        }
    }
    public class ViewUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserID { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public string JobStatus { get; set; }
        public string EmployeeID { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
    }

}