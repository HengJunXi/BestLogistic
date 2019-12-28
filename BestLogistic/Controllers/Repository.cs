using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using BestLogistic.Models;

namespace BestLogistic.Controllers
{
    public class Repository
    {
        public static readonly string connectionString =
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

        public string[] SignInUser(string email, string password)
        {
            string query = "SELECT uid, name FROM [user] WHERE email=@EMAIL AND password_hash=@PASSWORD;";

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
                        return new string[] {
                            ds.Tables[0].Rows[0].Field<Guid>("uid").ToString(),
                            ds.Tables[0].Rows[0].Field<string>("name")
                        };
                }
            }
            return null;
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

        public User GetUser(string uid)
        {
            string query = "SELECT uid, email, phone_number, home_number, name, " +
                "id_type, id_number, date_of_birth, address, location, postcode, picture_url " +
                "FROM [user] WHERE uid=@UID;";

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
                        return new User(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        public static byte GetUserIDType(string uid)
        {
            string query = "SELECT id_type " +
                "FROM [user] WHERE uid=@UID;";
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
                        if ((ds.Tables[0].Rows[0].Field<byte>)("id_type") == 0)
                            return 0; 
                        else
                            return 1; 
                }
            }
            return 0;
        }

        public static string GetUserIDNumber(string uid)
        {
            string query = "SELECT id_number " +
                "FROM [user] WHERE uid=@UID;";

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
                        return (ds.Tables[0].Rows[0].Field<string>)("id_number");
                }
            }
            return null;
        }


        public static void UpdateUserAddress(string userId, string address, string postcode, string location)
        {
            string query = "update [user] set address=@ADDRESS, postcode=@POSTCODE, location=@LOCATION where uid=@UID;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ADDRESS", address);
                cmd.Parameters.AddWithValue("@POSTCODE", postcode);
                cmd.Parameters.AddWithValue("@LOCATION", location);
                cmd.Parameters.AddWithValue("@UID", userId);

                cmd.ExecuteNonQuery();
            }
        }

        public bool UpdateUserPassword(string userId, string userEmail, string oldPassword, string newPassword)
        {
            string hashSalt = this.GetHashSalt(userEmail);

            if (!hashSalt.Equals(string.Empty))
            {
                byte[] salt = Convert.FromBase64String(hashSalt);
                var pbkdf2 = new Rfc2898DeriveBytes(oldPassword, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                string passwordHash = Convert.ToBase64String(hash);

                try
                {
                    string[] result = this.SignInUser(userEmail, passwordHash);

                    if (result == null)
                        return false;

                    // create new salt
                    new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                    // hash new password with new salt
                    pbkdf2 = new Rfc2898DeriveBytes(newPassword, salt, 10000);
                    hash = pbkdf2.GetBytes(20);
                    // encode to base64
                    passwordHash = Convert.ToBase64String(hash);
                    hashSalt = Convert.ToBase64String(salt);

                    string query = "update [user] set password_hash=@PWDHASH, hash_salt=@SALT where uid=@UID;";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@PWDHASH", passwordHash);
                        cmd.Parameters.AddWithValue("@SALT", hashSalt);
                        cmd.Parameters.AddWithValue("@UID", userId);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static void UpdateUserMobileNumber(string userId, string mobileNumber)
        {
            string query = "update [user] set phone_number=@PN where uid=@UID;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@PN", mobileNumber);
                cmd.Parameters.AddWithValue("@UID", userId);

                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateUserHomeNumber(string userId, string homeNumber)
        {
            string query = "update [user] set home_number=@HN where uid=@UID;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@HN", homeNumber);
                cmd.Parameters.AddWithValue("@UID", userId);

                cmd.ExecuteNonQuery();
            }
        }

        public ArrayList GetAreaFromPostCode(string postcode)
        {
            string query = "SELECT area FROM [postcode] WHERE postcode=@PC;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@PC", postcode);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ArrayList arr = new ArrayList();
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            arr.Add(r.Field<string>("area"));
                        }
                        return arr;
                    }
                }
            }
            return null;
        }

        public string[] GetCityAndStateFromPostCodeAndLocation(string postcode, string location)
        {
            string query = "SELECT post_office, state_name " +
                "FROM [postcode] JOIN [state] " +
                "ON (postcode.state_code=state.state_code) " +
                "WHERE postcode=@PC AND area=@AREA;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@PC", postcode);
                cmd.Parameters.AddWithValue("@AREA", location);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return new string[] {
                            ds.Tables[0].Rows[0].Field<string>("post_office"),
                            ds.Tables[0].Rows[0].Field<string>("state_name")
                        };
                    }
                }
            }
            return null;
        }

        public List<ShipmentRecord> GetShipmentHistory (string userId)
        {
            string query = "select * from parcel where user_uid=@UID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UID", userId);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    List<ShipmentRecord> list = new List<ShipmentRecord>();
                    
                    for (int i = 0; i < list.Count; i++)
                    {
                        list.Add(new ShipmentRecord(
                            ds.Tables[0].Rows[i].Field<int>("tracking_number"),
                            ds.Tables[0].Rows[i].Field<string>("sender_name"),
                            ds.Tables[0].Rows[i].Field<string>("sender_address"),
                            ds.Tables[0].Rows[i].Field<string>("sender_location"),
                            ds.Tables[0].Rows[i].Field<string>("sender_postcode"),
                            ds.Tables[0].Rows[i].Field<string>("receiver_name"),
                            ds.Tables[0].Rows[i].Field<string>("receiver_address"),
                            ds.Tables[0].Rows[i].Field<string>("receiver_location"),
                            ds.Tables[0].Rows[i].Field<string>("receiver_postcode"),
                            ds.Tables[0].Rows[i].Field<DateTime?>("delivered_date")));
                    }   

                    return list;
                }
            }
        }
    }
}