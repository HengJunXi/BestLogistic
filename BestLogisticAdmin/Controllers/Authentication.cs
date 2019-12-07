using BestLogisticAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Controllers
{
    public static class Authentication
    {
        public static Staff CurrentStaff { get; private set; }
        public static bool IsSignedIn()
        {
            return CurrentStaff != null;
        }

        //public static Staff getCurrentStaff()
        //{
        //    return currentStaff;
        //}

        //public static string GetUid()
        //{
        //    return currentStaff.Uid;
        //}

        //public static string GetStaffName()
        //{
        //    return currentStaff.Name;
        //}

        public static Staff SignInStaff(int staffId, string password)
        {
            Repository repository = new Repository();
            string hashSalt = repository.GetHashSalt(staffId);

            if (!hashSalt.Equals(string.Empty))
            {
                byte[] salt = Convert.FromBase64String(hashSalt);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                string passwordHash = Convert.ToBase64String(hash);

                try
                {
                    string[] result = repository.SignInStaff(staffId, passwordHash);
                    if (result == null)
                        return null;
                    CurrentStaff = new Staff(result[0], result[1], Convert.ToInt32(result[2]), result[3]);
                    return CurrentStaff;
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return null;
        }

        public static void SignOutStaff()
        {
            CurrentStaff = null;
        }
    }
}
