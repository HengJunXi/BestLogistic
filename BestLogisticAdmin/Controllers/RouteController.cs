using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Controllers
{
    public static class RouteController
    {
        public static List<string> GetRoutesForBranch(string branchId)
        {
            string query = "select arrival_point from route where departure_point=@BID;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    List<string> list = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        list.Add(ds.Tables[0].Rows[i].Field<string>("arrival_point"));
                    return list;
                }
            }
        }
    }
}
