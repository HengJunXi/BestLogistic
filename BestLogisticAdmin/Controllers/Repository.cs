using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Controllers
{
    public class Repository
    {
        public static readonly string connectionString =
                "server=" + Credential.SERVER + "; " +
                "database=" + Credential.DATABASE + "; " +
                "uid=" + Credential.UID + "; " +
                "password=" + Credential.PASSWORD + ";";

        public string GetHashSalt(int staffId)
        {
            string query = "SELECT hash_salt FROM [staff] WHERE staff_id=@ID;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", staffId);

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

        public string[] SignInStaff(int staffId, string password)
        {
            string query = "SELECT uid, branch_id, name FROM [staff] WHERE staff_id=@ID AND password_hash=@PASSWORD;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", staffId);
                cmd.Parameters.AddWithValue("@PASSWORD", password);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                        return new string[] {
                            ds.Tables[0].Rows[0].Field<Guid>("uid").ToString(),
                            ds.Tables[0].Rows[0].Field<string>("branch_id"),
                            staffId.ToString(),
                            ds.Tables[0].Rows[0].Field<string>("name")
                        };
                }
            }
            return null;
        }
    }
}
