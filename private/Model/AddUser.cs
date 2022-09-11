using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace bcms
{
    public class AddUser
    {
        const string ROLE_ADMIN = "admin";
        const string ROLE_OWNER = "owner";
        const string ROLE_EMPLOYEE = "employee";


        public string EmployeeAdd(int SessionID, int UserID, string JobStatus, DateTime birthDate, string firstName, string lastName, string gender, string email)
        {
            User user = new User();
            if (int.Parse(user.getRole(SessionID)).Equals("Admin")) 
            {
                try
                {
                    Database database = new Database();
                    
                    string query = $"INSERT INTO employee (UserID, BirthDate, JobStatus, FirstName, LastName, Email, Gender) VALUES ({UserID},'{birthDate}','{JobStatus}','{firstName}','{lastName}','{email}','{gender}')";

                    if(database.insert(query))
                        return "Success";
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
            return Database.getError();
        }

        public int UserAdd(string Role, string Password)
        {
            Database database = new Database();
            Random random = new Random();
            Password = EncryptPassword(Password);

            var mystring = DateTime.Now.ToString("HH:mm:ss:ff") + random.Next(1, 9999); ;
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(mystring));
            int UserID = BitConverter.ToInt32(hashed, 0);


            if ( database.insert($"INSERT INTO [User] (UserID, Role) VALUES({UserID}, '{Password}', '{Role}')"))
            {
                return UserID;
            }
            return -1;
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