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
        private string IOutput = "";


        public bool add(User user, string password, string role, DateTime birthDate, string firstName, string lastName, string gender)
        {
            if (/*user.getRole().Equals("Admin") || */true) //TODO remove true
            {
                try
                {
                    Database database = new Database();
                    Random random = new Random();

                    int userID = random.Next(10000000, 99999999);

                    /*while(database.UserExists(userID))
                    {
                        userID += 1;
                    }/*/

                    password = EncryptPassword(password);
                    string query = $"INSERT INTO User (UserID, Password, BirthDate, Role, FirstName, LastName) VALUES ({userID},'{password}','{birthDate}','{role}','{lastName}')";
                    IOutput = query;

                    switch (role)
                    {
                        case ROLE_EMPLOYEE:

                            break;

                        default:
                            break;

                    }
                    if(database.insert(query))
                    {

                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
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

        public string getOutput()
        {
            return IOutput;
        }
        /*
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        */

    }
}