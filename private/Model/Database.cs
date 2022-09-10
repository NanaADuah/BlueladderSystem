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

        public bool isActive()
        {
            return active;
        }
        private static string GetConnectionString()
        {
            string SQLConnection = $@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bcms.mdf; Integrated Security = True";
            return SQLConnection;
        }
        private void setError(String value)
        {
            error = value;
        }
        public void connect()
        {
            connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                active = true;
                connection.Close();
            }
            catch(Exception ex)
            {
                error = ex.Message;
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
        public bool check(int ID, string password)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            password = AddUser.EncryptPassword(password);

            try
            {
                local.Open();
                string query = $"SELECT Password FROM [User] WHERE UserID = {ID}";
                SqlCommand command = new SqlCommand(query, local);
                Object result = command.ExecuteScalar();
                string matchPassword = result.ToString();
                local.Close();

                if (matchPassword.Equals(password))
                    return true;
                return false;
            }
              catch (SqlException ex)
            {
                error = ex.Message;
            }
            local.Close();
            return false;
        }

        public void logDevice(string type, string name)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            DateTime time = DateTime.Now;
            string query = $"INSERT INTO Devices (DeviceName, DeviceType, Date) VALUES ('{name}','{type}',{time})";
            bool result = insert(query);
        }

        public SqlDataReader execReader(string query)
        {
            SqlDataReader reader = null;
            SqlConnection local = new SqlConnection(GetConnectionString());

            try
            {
                local.Open();
                SqlCommand command = new SqlCommand(query, local);
                reader = command.ExecuteReader();
                return reader;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            return reader;
           // local.Close();
        }
    }
}