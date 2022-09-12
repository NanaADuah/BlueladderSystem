using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient ;
using System.Drawing;

namespace bcms
{
    public partial class Profile : System.Web.UI.Page
    {
        protected ViewUser profile;
        protected string role = "worker";
        protected bool isWorker = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();
            role = instance.getRole(int.Parse(Session["UserID"].ToString()));

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            int ID = 0;

            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    ID = int.Parse(Request.QueryString["ID"]);
                    SetProfile(ID);
                }
                else
                    Response.Redirect("ManageUsers.aspx");
            }
        }

        public void SetProfile(int ID)
        {
            User e = new User();
            if (e.getRole(ID).Equals("Worker", StringComparison.OrdinalIgnoreCase))
            {
                isWorker = true;

                Database database = new Database();
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
                        profile.BirthDate = reader.GetValue(6).ToString();
                        profile.Image = reader.GetValue(7).ToString();
                        profile.Email = reader.GetValue(7).ToString();

                        inputUserID.Text = profile.UserID;
                        inputLastName.Text = profile.Surname;
                        inputFirstName.Text = profile.Name;
                        inputGender.Text = profile.Gender;
                        inputBirthday.Text = profile.BirthDate;
                        inputEmailAddress.Text = profile.Email;
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

                        profile.Image = link + profile.Image;
                    }
                }
                else
                {

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

        public class ViewUser
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string UserID { get; set; }
            public string Gender { get; set; }
            public string BirthDate { get; set; }
            public string Image { get; set; }
            public string JobStatus { get; set; }
            public string EmployeeID { get; set; }
            public string Email { get; set; }
            public string Link { get; set; }
        }

    }
}