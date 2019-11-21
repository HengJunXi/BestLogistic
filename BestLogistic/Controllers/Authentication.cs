﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BestLogistic.Controllers
{
    public static class Authentication
    {
        public static string SignInUser(string email, string password)
        {
            Repository repository = new Repository();
            string hashSalt = repository.GetHashSalt(email);

            if (!hashSalt.Equals(string.Empty))
            {
                byte[] salt = Convert.FromBase64String(hashSalt);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                string passwordHash = Convert.ToBase64String(hash);

                try
                {
                    string uid = repository.SignInUser(email, passwordHash);
                    HttpContext.Current.Session["uid"] = uid;
                    return uid;
                } 
                catch (SqlException e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return string.Empty;
        }

        public static bool RegisterUser(string email, string password, string fullName, 
            string idTypeStr, string idNumber, string dateOfBirth)
        {
            Repository repository = new Repository();

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            string passwordHash = Convert.ToBase64String(hash);
            string hashSalt = Convert.ToBase64String(salt);

            int idType = Int32.Parse(idTypeStr);

            // TODO: sanitize input
            try
            {
                repository.RegisterUser(
                    email, passwordHash, hashSalt, fullName, idType, idNumber, dateOfBirth);
                return true;
            } 
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        public static void SignOutUser()
        {
            HttpContext.Current.Session.Remove("uid");
        }
    }
}