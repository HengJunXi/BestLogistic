using BestLogisticAdmin.Models;
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
        public static List<Branch> GetRoutesForBranch(string branchId)
        {
            string query = "select R.arrival_point, P.name, from route R inner join point P on R.arrival_point=P.place_id where R.departure_point=@BID;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    List<Branch> list = new List<Branch>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        list.Add(new Branch(ds.Tables[0].Rows[i].Field<string>("arrival_point"), ds.Tables[0].Rows[i].Field<string>("name"));
                    return list;
                }
            }
        }
    }
}
