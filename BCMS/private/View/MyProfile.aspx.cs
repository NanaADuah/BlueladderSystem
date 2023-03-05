using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace bcms
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected UserProfile profile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");

            User user = new User();
            if (user.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin", StringComparison.CurrentCultureIgnoreCase))
            {
                Response.Redirect("Account.aspx");
            }

            displayProfile(int.Parse(Session["UserID"].ToString()));
        }

        public void displayProfile(int ID)
        {
            Database database = new Database();
            profile = new UserProfile();
            string query = $"SELECT FirstName, LastName, Email, Gender, Image, Birthdate FROM [Employee] WHERE UserID = {ID}";
            SqlDataReader reader = database.execReader(query);

            if (reader != null)
            {
                while (reader.Read())
                {
                    profile.FirstName = reader.GetString(0);
                    profile.LastName = reader.GetValue(1).ToString();
                    profile.Email = reader.GetValue(2).ToString();
                    profile.Gender = reader.GetValue(3).ToString();
                    profile.Image = reader.GetValue(4).ToString();
                    profile.Birthdate = Convert.ToDateTime(reader.GetValue(5).ToString());
                }
                string defaultImage = "placeholder.png";
                if (profile.Image.Equals("") || profile.Image == null)
                {
                    string link = "../../public/includes/profile/";
                    if (profile.Gender.Equals("female", StringComparison.OrdinalIgnoreCase))
                        profile.Image = link + "female.jpg";
                    else
                    if (profile.Gender.Equals("male", StringComparison.OrdinalIgnoreCase))
                        profile.Image = link + "male.jpg";
                    else
                        profile.Image = link + defaultImage;
                }

                tbFirstName.Text = profile.FirstName;
                tbGender.Text = profile.Gender;
                tbUserID.Text = Session["UserID"].ToString();
                tbLastName.Text = profile.LastName;
                tbEmail.Text = profile.Email;
                tbBirhDate.Text = profile.Birthdate.ToString("yyyy/MM/dd");
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            } 
        }
    }
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public DateTime Birthdate { get; set; }
    }
}