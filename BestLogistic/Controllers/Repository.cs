using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BestLogistic.Controllers
{
    public class Repository
    {
        private readonly string connectionString =
                "server=" + Credential.SERVER + "; " +
                "database=" + Credential.DATABASE + "; " +
                "uid=" + Credential.UID + "; " +
                "password=" + Credential.PASSWORD + ";";
        
        public string GetHashSalt(string email)
        {
            string query = "SELECT hash_salt FROM [user] WHERE email=@EMAIL;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@EMAIL", email);

                string hashSalt = string.Empty;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                using (DataSet ds = new DataSet())
                {
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        hashSalt = ds.Tables[0].Rows[0].Field<string>("hash_salt");
                        return hashSalt;
                    }   
                }
            }
            return string.Empty;
        }

        public string SignInUser(string email, string password)
        {
            string query = "SELECT uid FROM [user] WHERE email=@EMAIL AND password_hash=@PASSWORD;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@EMAIL", email);
                cmd.Parameters.AddWithValue("@PASSWORD", password);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                        return ds.Tables[0].Rows[0].Field<Guid>("uid").ToString();
                }
            }
            return string.Empty;
        }

        public void RegisterUser(string email, string passwordHash, string hashSalt,
            string fullName, int idType, string idNumber, string dateOfBirth)
        {
            string query = "INSERT INTO [user] (email, password_hash, hash_salt, " +
                "name, id_type, id_number, date_of_birth) " +
                "VALUES (@EMAIL, @PASSWORD, @SALT, @NAME, @TYPE, @NUM, @DATE);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@EMAIL", email);
                cmd.Parameters.AddWithValue("@PASSWORD", passwordHash);
                cmd.Parameters.AddWithValue("@SALT", hashSalt);
                cmd.Parameters.AddWithValue("@NAME", fullName);
                cmd.Parameters.AddWithValue("@TYPE", idType);
                cmd.Parameters.AddWithValue("@NUM", idNumber);
                cmd.Parameters.AddWithValue("@DATE", dateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public string GetUser(string uid)
        {
            //string query = "SELECT uid, email, phone_number, home_number, name," +
            //    "id_type, id_number, date_of_birth, address, location, postcode " +
            //    "FROM [user] WHERE uid=@UID;";
            string query = "SELECT name FROM [user] WHERE uid=@UID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UID", uid);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                        return ds.Tables[0].Rows[0].Field<string>("name");
                }
            }
            return string.Empty;
        }
    }
}