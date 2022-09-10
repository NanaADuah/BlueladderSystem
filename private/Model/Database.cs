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
        private static bool active = false;
        private static string error = "";

        static Database()
        {
            _instance = new Database();

        }

        public Database Instance
        {
            get { return _instance; }
        }

        private static string GetConnectionString()
        {

            string SQLConnection = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Nana Duah\source\Workspaces\Workspace\bcms\App_Data\source.mdf'; Integrated Security = True";
                //$@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bmcs.mdf; Integrated Security = True";
            return SQLConnection;
        }
        private void setError(String value)
        {
            error = value;
        }
        public bool connect()
        {
            connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                active = true;
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static string getError()
        {
            return error;
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
                    connection.Close();
                    result = command.ExecuteScalar().ToString();
               
                }
                catch
                {
                    setError(error);
                }
               
            }
            return result;
        }

        public bool UserExists(int ID)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            if(active)
            {
                try
                {
                    local.Open();
                    SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM [User] WHERE UserID = {ID}", local) ;
                    int value = (int)command.ExecuteScalar();
                    if (value == 0)
                        return true;
                    return false;
                }
                finally
                {
                    local.Close();
                }
            }
            return false;
        }

        public bool insert(string query)
        {
            SqlConnection local = new SqlConnection();
            if(active)
            {
                local.Open();
                SqlCommand command = new SqlCommand(query, local);
                command.ExecuteNonQuery();
                local.Close();
                return true;
            }
            return false;
        }
    }
}