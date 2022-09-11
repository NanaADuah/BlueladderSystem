using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient ;

namespace bcms
{
    public partial class Profile : System.Web.UI.Page
    {
        protected ViewUser profile;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

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
                    profile.Surname= reader.GetValue(3).ToString();
                    profile.JobStatus = reader.GetValue(4).ToString();
                    profile.Gender = reader.GetValue(5).ToString();
                    profile.BirthDate = reader.GetValue(6).ToString();
                    profile.Image = reader.GetValue(7).ToString();

                    inputUserID.Text = profile.UserID;
                    inputLastName.Text = profile.Surname;
                    inputFirstName.Text = profile.Name;
                    inputGender.Text = profile.Gender;
                    inputBirthday.Text = profile.BirthDate;

                    if (profile.Image.Equals("") || profile.Image == null)
                    {
                        if (profile.Gender.Equals("female", StringComparison.OrdinalIgnoreCase))
                            profile.Image = "female.jpg";
                        else
                        if (profile.Gender.Equals("male", StringComparison.OrdinalIgnoreCase))
                            profile.Image = "male.jpg";
                        else
                            profile.Image = defaultImage;
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
        public string BirthDate { get; set; }
        public string Image { get; set; }
        public string JobStatus { get; set; }
        public string EmployeeID { get; set; }
    }

}