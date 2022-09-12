using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Data;

namespace bcms
{
    public class Database
    {
        private static Database _instance;
        private SqlConnection connection;
        private static bool active = false;
        private static string error = "";
        private static int userCount;
        static Database()
        {
            _instance = new Database();
        }
        public int getDevices()
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            try
            {

                string query = $"SELECT COUNT(*) AS Total FROM Device";
                SqlCommand command = new SqlCommand(query, local);
                int value =  int.Parse(command.ExecuteScalar().ToString());
                return value;
            }
            catch (Exception ex)
            {
                setError(ex.Message);
                return -1;
            }
            finally
            {
                local.Close();
            }
        }
        
        public int getDevicesTypes()
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            try
            {

                string query = "“SELECT COUNT(*) AS Types FROM Device GROUP BY Device.DeviceType";
                SqlCommand command = new SqlCommand(query, local);
                int value =  int.Parse(command.ExecuteScalar().ToString());
                    return value;
            }
            catch (Exception ex)
            {
                setError(ex.Message);
                return -1;
            }
            finally
            {
                local.Close();
            }
        }
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool removeUser(int UserID, string role)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            try
            {

                string query = $"DELETE FROM [User] WHERE UserID = {UserID}";
    
                if(role.Equals("Worker"))
                {
                    query = $"DELETE FROM [User], [Employee] LEFT JOIN [Employee] ON [User].UserID = [Employee].UserID WHERE [User].UserID = {UserID}";
                    SqlCommand command = new SqlCommand(query, local);

                    query = $"DELETE FROM [User], [Device] LEFT JOIN [Device] ON [User].UserID = [DeviceID].UserID WHERE [User].UserID = {UserID}";
                    command = new SqlCommand(query, local);
                    return true;
                }
            }
            catch (Exception ex)
            {
                setError(ex.Message);
                return false;
            }
            finally
            {
                local.Close();
            }
            return false;
        }

        public bool removeDevice(int DeviceID)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            try
            {
                local.Open();
                string query = $"DELETE FROM [Device] WHERE DeviceID = {DeviceID}";
                SqlCommand command = new SqlCommand(query, local);
                command.ExecuteNonQuery();
                setError("");
                return true;
            }
            catch(Exception ex)
            {
                setError(ex.Message);
            }
            finally
            {
                local.Close();
            }
            return false;
        }
        
        public bool removeBackup(int BackUpID)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            try
            {
                local.Open();
                SqlCommand comName = new SqlCommand($"SELECT FileName FROM [Backup] WHERE BackupID = {BackUpID}",local);
                string filename = comName.ExecuteScalar().ToString();
                setError(filename);
                string query = $"DELETE FROM [Backup] WHERE BackupID = {BackUpID}";
                SqlCommand command = new SqlCommand(query, local);
                //command.ExecuteNonQuery();
                //setError("");
                return true;
            }
            catch(Exception ex)
            {
                setError(ex.Message);
            }
            finally
            {
                local.Close();
            }
            return false;
        }
        public bool removeEquipment(int eID)
        {
            string[] list = new string[500];
            SqlConnection local = new SqlConnection(GetConnectionString());
            if (isActive())
            {
                try
                {
                    local.Open();
                    SqlCommand command = new SqlCommand($"DELETE [Equipment],[EquipmentRequest] FROM [Equipment] LEFT JOIN  [EquipmentRequest] ON [Equipment].UserID = [EquipmentRequest].UserID WHERE [Equipment].UserID = {eID}", local);
                    command.ExecuteReader();
                    setError("");
                    return true;
                }
                catch (Exception ex)
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

        public string[] getlist(string query)
        {
            string[] list = new string[500];
            SqlConnection local = new SqlConnection(GetConnectionString());
            if (isActive())
            {
                try
                {
                    local.Open();
                    SqlCommand command = new SqlCommand(query, local);
                    SqlDataReader read = command.ExecuteReader();
                    int index = 0;
                    while(read.Read())
                    {
                        list[index] = read.GetValue(0).ToString();
                        index++;
                    }
                    setUserCount(index);
                }
                catch (Exception ex)
                {

                    setError(ex.Message);
                }
                finally
                {
                    local.Close();
                }

            }

            return list;
        }

        public void setUserCount(int count)
        {
            userCount = count;
        }

        public void setNullBackup()
        {
            string query = "UPDATE Backup SET UserID = null WHERE [User].UserID = {ID}";
            update(query);
        }
        public bool generateEquipment(int count)
        {

            SqlConnection local = new SqlConnection(GetConnectionString());

            string[] _manufacturers = new string[] {"Zoomilion","Doosan","Liebherr","Htachi","Volve CE","XCMG","John Deere","Komatsu", "Catepillar","Sandvik","Sortimo","TTI","OLFA","Mafell","lee Valley Tools"};

            string[] _equipmentName = new string[] {"Bolster","Boning rod","Brick hammer","Bump cutter/screed","Chisel","Circular saw","Concrete mixer","Cordless drill","Crowbar","Digging bar","End frames","Float","Gloves","Hand saw","Helmet","Hoe","Iron pan","Jack plane","Ladder","Line and pins","Mason’s square","Measuring box","Measuring tape","Measuring wheel","Pick axe","Plumb bob","Plumb rule","Polishers","Putty knife","Rammer","Rubber Boots","Safety glasses","Safety helmet","Sand screen machine","Scratchers","Sledge hammer","Spade","Spirit level","Straight edge brushes","Tile cutter","Trowel","Vibrator","Wedge","Wheel barrow"};

            string[] _category = new string[] { "Cold Planers","Drills","Drum Rollers","Shovels","Forklift","Motor Graders","Telehandler","Buckets","Buggies","Hoist","Screens","Ball Mills","Surface Vibrator"};



            if (isActive())
            {
                try
                {
                    string[] _userIDs = getlist("SELECT UserID FROM Employee");
                    SqlCommand command;
                    Random rand = new Random();

                    local.Open();
                    for (int i = 0; i < count; i++)
                    {
                        string manufacturer = _manufacturers[rand.Next(0, _manufacturers.Length)];
                        string eName = _equipmentName[rand.Next(0, _equipmentName.Length)];
                        string category = _category[rand.Next(0, _category.Length)];
                        DateTime date = DateTime.Now;
                        string serial = eName.Substring(0, 3) + EncryptPassword(date.ToString("HH:mm:ss:f"));
                        serial = serial.Length <= 20 ? serial : serial.Substring(0, 20);
                        Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                        serial = rgx.Replace(serial, "");
                        string avail = rand.Next(0, 100) % 2 == 0?"True":"False";
                        string query = $"INSERT INTO Equipment(UserID,Category,EquipmentName, Manufacturer, SerialNumber, Available) VALUES ({int.Parse(_userIDs[rand.Next(0, userCount)])},'{category}','{eName}','{manufacturer}','{serial}',{avail})";
                        command = new SqlCommand(query, local);
                        command.ExecuteNonQuery();
                    }

                    local.Close();
                    setError("");

                }
                catch (Exception ex)
                {
                    setError(ex.Message);
                    return false;
                }
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

        public string writeCSV(string tableName, int UserID)
        {
            DataTable table = new DataTable();
            SqlConnection local = new SqlConnection(GetConnectionString());
            if(isActive())
            { 
                try
                {
                    local.Open();
                    string query = $"SELECT  * FROM [{tableName}]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, local);
                    adapter.Fill(table);
                    string saveName = RandomString(15);
                    string storeDataBaseFilename = HttpContext.Current.Server.MapPath("~") + $"public\\backup\\{saveName}.csv";
                    string userStore = GetDownloadFolderPath() + $"\\{saveName}.csv";
                    CSVUtility.ToCSV(table, storeDataBaseFilename);
                    CSVUtility.ToCSV(table, userStore);
                    string insData = $"INSERT INTO [Backup] (Filename, Time, UserID, Type) VALUES ('public\\backup\\{saveName}.csv','{DateTime.Now}',{UserID},'Normal')";
                    SqlCommand command = new SqlCommand(insData, local);
                    command.ExecuteNonQuery();
                    setError("");
                    return userStore;
                }
                catch (Exception ex)
                {
                    setError(ex.Message);
                }
                finally
                {
                    local.Close();
                } 
            }
            return "-1";
        }

        public static string GetHomePath()
        {
            // Not in .NET 2.0
            // System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                return System.Environment.GetEnvironmentVariable("HOME");

            return System.Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
        }


        public static string GetDownloadFolderPath()
        {
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
            {
                string pathDownload = System.IO.Path.Combine(GetHomePath(), "Downloads");
                return pathDownload;
            }

            return System.Convert.ToString(
                Microsoft.Win32.Registry.GetValue(
                     @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"
                    , "{374DE290-123F-4565-9164-39C4925E467B}"
                    , String.Empty
                )
            );
        }

        public int getCount(string query)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            int count = 0;
            if(isActive())
            try
            {
                    local.Open();
                    SqlCommand command = new SqlCommand(query, local);
                    count = int.Parse(command.ExecuteScalar().ToString());
                    setError("");
                    local.Close();
                    return count;
            }
                catch(Exception ex)
                {
                    setError(ex.Message);
                    return -1;
                }
            return -1;
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

        public bool updatePassword(int userID, string newPass)
        {
            string hPassword = EncryptPassword(newPass);
            if (active)
            {
            SqlConnection local = new SqlConnection();

            try
            {
                local.Open();
                SqlCommand command = new SqlCommand($"UPDATE [User] SET Password = '{hPassword}'", local);
                command.ExecuteNonQuery();
                local.Close();
                return true;
            }catch(Exception ex)
                {
                    setError(ex.Message);
                }
            }
            return false;

        }

        public bool removEmployee(int ID)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());

            try
            {
                local.Open();
                string query = $"DELETE [User], [Employee] FROM [User] LEFT JOIN [Employee] ON [User].key = [Employee].key WHERE UserID = {ID}";
                SqlCommand command = new SqlCommand(query, local);
                command.ExecuteNonQuery();
                local.Close();
                setError("");
            }
            catch (SqlException ex)
            {
               setError(ex.Message);
            }
            local.Close();
            return false;
        }
        public bool check(int ID, string password)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            password = Database.EncryptPassword(password);

            try
            {
                local.Open();
                string query = $"SELECT Password FROM [User] WHERE UserID = {ID}";
                SqlCommand command = new SqlCommand(query, local);
                Object result = command.ExecuteScalar();
                string matchPassword = result.ToString();
                local.Close();
                setError("");
                if (matchPassword.Equals(password))
                    return true;
                return false;
            }
              catch (SqlException ex)
            {
                setError(ex.Message);
            }
            local.Close();
            return false;
        }
        public bool update(string query)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            try
            {
                local.Open();
                SqlCommand command = new SqlCommand(query, local);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                local.Close();
                return true;
            }
            catch(Exception ex)
            {
                setError(ex.Message);
                return false;
            }
        }
        public void logDevice(string IP, string type, string name, int UserID)
        {
            SqlConnection local = new SqlConnection(GetConnectionString());
            DateTime time = DateTime.Now;
            string query = $"INSERT INTO Devices (DeviceID,DeviceName, DeviceType, Time, UserID) VALUES ('{IP}','{name}','{type}',{time},{UserID})";
            bool result = insert(query);
            if (result)
                setError("");
            else
                setError("Logging device error B100");
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
        }

        public int UserAdd(string Role, string Password)
        {
            Database database = new Database();
            Random random = new Random();
            AddUser e = new AddUser();
            Password = EncryptPassword(Password);

            var mystring = DateTime.Now.ToString("HH:mm:ss:ff") + random.Next(1, 9999); ;
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(mystring));
            int UserID = BitConverter.ToInt32(hashed, 0);

            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                string q = $"SET IDENTITY_INSERT [User] ON INSERT INTO [User] (UserID, Password, Role) VALUES ({UserID}, '{Password}', '{Role}') SET IDENTITY_INSERT [User] OFF";
                SqlCommand command = new SqlCommand(q, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return UserID;
            }
            catch (Exception ex)
            {
                setError(ex.Message);
                return -1;
            }
        }
        public string EmployeeAdd(int SessionID, int UserID, string JobStatus, DateTime birthDate, string firstName, string lastName, string gender, string email)
        {
            User user = new User();
            SqlConnection local = new SqlConnection(GetConnectionString());
            if(isActive())
            {

                if (int.Parse(user.getRole(SessionID)).Equals("Admin"))
                {
                    try
                    {
                        local.Open();
                        string query = $"SET IDENTITY_INSERT Employee ON INSERT INTO Employee (UserID, BirthDate, JobStatus, FirstName, LastName, Email, Gender) VALUES ({UserID},'{birthDate}','{JobStatus}','{firstName}','{lastName}','{email}','{gender}') SET IDENTITY_INSERT Employee OFF";
                        SqlCommand command = new SqlCommand(query, local);
                        command.ExecuteNonQuery();
                        return "Success";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    finally
                    {
                        local.Close();
                    }
                }
                return getError();
            }
            return "Database access not available at the momment...";
        }

        public static string EncryptPassword(string Password)
        {
            string result = "default";
            try
            {
                SHA256Managed hasher = new SHA256Managed();

                byte[] passBytes = new UTF8Encoding().GetBytes(Password);
                byte[] keyBytes = hasher.ComputeHash(passBytes);

                hasher.Dispose();
                result = Convert.ToBase64String(keyBytes);
            }
            catch (Exception ex)
            {
                UI instace = new UI();
                instace.displayMessage(ex.Message);
            }

            return result;

        }
    }
}