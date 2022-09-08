using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bcms
{
    public class User
    {
        private string name;

        private int userID ;

        public User()
        {
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