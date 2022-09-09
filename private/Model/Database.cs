using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace bcms
{
    public class Database
    {
        private static Database _instance;
        private SqlConnection connection;

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
            string SQLConnection = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bcms.mdf; Integrated Security = True";
            return SQLConnection;
        }

        public bool connect()
        {
            this.connection = new SqlConnection(GetConnectionString());
            try
            {

                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}