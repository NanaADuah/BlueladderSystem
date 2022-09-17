using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net;

namespace bcms
{
    public class User : Page
    {
        private static User _instance;
        private string name;
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

        public void login(int ID)
        {
            Database database = new Database();
            Session["UserID"] =  ID;

            var HostIP = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "";
            string host = Dns.GetHostName();
            Random rand = new Random();
            // Getting ip address using host name
            IPHostEntry ip = Dns.GetHostEntry(host);
            Console.WriteLine();

            string devType = "Desktop";
            string devName = Environment.MachineName;
            string deviceIP = rand.Next(5000, 100000).ToString();

            database.logDevice(deviceIP, devType,devName, ID);
            database.logInfo(ID,"login");
            HttpContext.Current.Response.Redirect("dashboard.aspx");
        }

        public void Logout()
        {
            Database database = new Database();
            database.logInfo(int.Parse(Session["UserID"].ToString()), "logout");
            Session.Remove("UserID");
            HttpContext.Current.Response.Redirect("dashboard.aspx");
        }
        public string randomString(int length)
        {
            char[] array = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string text = "";

            for (int x = 0; x < length; x++)
            {
                Random rand = new Random();
                int random = rand.Next(0, 36);
                text += array[random];
            }

            return text;
         }

        public string getRole(int ID)
        {
            Database database = new Database();
            string result = database.get($"SELECT TOP 1 Role FROM [User] WHERE UserID = {ID}");
            return result;
        }
        public User(int id, String name)
        {
            Name = name;
            userID = id;
        }
        public string getName(int ID)
        {
            Database database = new Database();
            string result = database.get($"SELECT TOP 1 Name FROM [Employee] WHERE UserID = {ID}");
            return result;
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