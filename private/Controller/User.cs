using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace bcms
{
    public class User : Page
    {
        private static User _instance;
        private string name;
        private string role;
        private int userID;

        static User()
        {
             _instance = new User();
        }
        public User()
        {

        }

        public string getUser(int id)
        {
            string value = "";
            return value;
        }

        public bool logged()
        {
            bool logged = false;
            if(HttpContext.Current != null)
            { 
                var request = HttpContext.Current.Request;
                HttpCookie details = request.Cookies["BlueLadder"];
                if (details == null)
                    return false;
                return true;
            }
            return logged;
        }

        public void login()
        {
            Database database = new Database();
            Session["UserID"] =  userID;
            HttpContext.Current.Response.Redirect("dashboard.aspx");

            string devType = "Null";
            string devName = Environment.MachineName;
           // database.logDevice(devType,devName);
        }

        public void Logout()
        {
            Session.Remove("UserID");
            Response.Redirect("dashboard.aspx");

        }
        public string randomString(int length)
        {
            var array = new char[36];
                //array =  (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' );
            string text = "";

            for (int x = 0; x < length; x++)
            {
                Random rand = new Random();
                int random = rand.Next(0, 36);
                text += array[random];
            }

            return text;
         }
        public string getRole()
        {
            return role;
        }
        public User(int id, String name)
        {
            Name = name;
            userID = id;
        }
        public string getName()
        {
            return name;
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public int getUserID()
        {
            return userID;
        }

    }
}