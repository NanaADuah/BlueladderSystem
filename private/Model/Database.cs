using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

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

        public bool generateEquipment(int count, int UserID)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());

            string[] _manufacturers = new string[] {"Zoomilion","Doosan","Liebherr","Htachi","Volve CE","XCMG","John Deere","Komatsu", "Catepillar","Sandvik","Sortimo","TTI","OLFA","Mafell","lee Valley Tools"};

            string[] _equipmentName = new string[] {"Bolster","Boning rod","Brick hammer","Bump cutter/screed","Chisel","Circular saw","Concrete mixer","Cordless drill","Crowbar","Digging bar","End frames","Float","Gloves","Hand saw","Helmet","Hoe","Iron pan","Jack plane","Ladder","Line and pins","Mason’s square","Measuring box","Measuring tape","Measuring wheel","Pick axe","Plumb bob","Plumb rule","Polishers","Putty knife","Rammer","Rubber Boots","Safety glasses","Safety helmet","Sand screen machine","Scratchers","Sledge hammer","Spade","Spirit level","Straight edge brushes","Tile cutter","Trowel","Vibrator","Wedge","Wheel barrow"};

            string[] _category = new string[] { "Cold Planers","Drills","Drum Rollers","Shovels","Forklift","Motor Graders","Telehandler","Buckets","Buggies","Hoist","Screens","Ball Mills","Surface Vibrator"};


            if (isActive())
            try
            {
                    SqlCommand command;
                    Random rand = new Random();

                    local.Open();
                    for(int i = 0; i < count; i++)
                    {
                        string manufacturer = _manufacturers[rand.Next(0, _manufacturers.Length)];
                        string eName = _equipmentName[rand.Next(0,_equipmentName.Length)];
                        string category = _category[rand.Next(0, _category.Length)];
                        DateTime date = DateTime.Now;
                        string serial = eName.Substring(0,3) + AddUser.EncryptPassword(date.ToString("HH:mm:ss:f"));
                        serial = serial.Length <= 20 ? serial : serial.Substring(0, 20);
                        Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                        serial = rgx.Replace(serial, "");
                        string query = $"INSERT INTO Equipment(UserID,Category,EquipmentName, Manufacturer, SerialNumber) VALUES ({UserID},'{category}','{eName}','{manufacturer}','{serial}')";
                        command = new SqlCommand(query, local ) ;
                        command.ExecuteNonQuery();
                    }

                    local.Close();
                    setError("");

                }
                catch(Exception ex)
            {
                    setError(ex.Message);
                    return false;
            }
            return true;
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
            SqlConnection local = new SqlConnection(GetConnectionString());
            string result = "";
            if(isActive())
            {
                try
                {
                    local.Open();
                    SqlCommand command = new SqlCommand(query, local);
                    result = command.ExecuteScalar().ToString();
                    setError("");
                    local.Close();
                }
                catch(Exception ex)
                {
                    setError(ex.Message);
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
                    setError("");
                    if (value == 0)
                        return true;
                    return false;
                }
                catch(Exception ex)
                {
                    setError(ex.Message);
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
                setError("");
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