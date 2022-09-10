using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

namespace bcms
{
    public class Database
    {
        private static Database _instance;
        private SqlConnection connection;
        private bool active = false;

        static Database()
        {
            _instance = new Database();

        }

        public Database Instance
        {
            get { return _instance; }
        }

        private string GetConnectionString()
        {
            string directory = System.IO.Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(directory).Parent.FullName;
            string SQLConnection = $@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BLCMS.mdf; Integrated Security = True";
            return SQLConnection;
        }

        public bool connect()
        {
            this.connection = new SqlConnection(GetConnectionString());
            try
            {

                connection.Open();
                active = true;
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string get(string query)
        {
            string result = "";
            if(active)
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    result = command.ExecuteScalar().ToString();
               
                }
                finally
                {
                    connection.Close();
                }
               
            }
            return result;
        }

        public bool UserExists(int ID)
        {
            if(active)
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM [User] WHERE UserID = {ID}", connection) ;
                    int value = (int)command.ExecuteScalar();
                    if (value == 0)
                        return true;
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return false;
        }

        public bool insert(string query)
        {
            if(active)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }
    }
}