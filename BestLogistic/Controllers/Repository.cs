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
                "id_type, id_number, date_of_birth, address, location, postcode " +
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
    }
}