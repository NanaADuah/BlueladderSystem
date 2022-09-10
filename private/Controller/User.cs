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
    public class User
    {
        private User user;
        private string name;
        private string role;

        private int userID ;

        public User()
        {
            Database database = new Database(); 
            user = new User();
            if(database.connect())
            {
                database.get("");
                role = "";
            }
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

        public bool checkLoginDetails(string iD, string password)
        {

            string query = $"SELECT UserID, Password FROM Users WHERE ID = '{ID}'";
            Database database = new Database();
            string value = database.get(query);
            return true;

            /*while (reader.Read())
            {
                if (reader.GetValue(1).Equals(email))
                {
                    string matchPassword = reader.GetValue(2).ToString();
                    Session["WorkerID"] = reader.GetValue(0);

                    if (matchPassword.Equals(password))
                    {
                        reader.Close();
                        reader.Dispose();
                        connection.Close();
                        return true;
                    }
                }
            }

            reader.Close();
            reader.Dispose();
            connection.Close();
            return false;*/
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

        public int ID
        {
            get { return userID; }
            set { this.userID = value; }
        }

        public int getUserID()
        {
            return userID;
        }

    }
}