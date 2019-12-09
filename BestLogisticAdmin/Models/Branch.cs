using BestLogisticAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class Branch
    {
        public string Name;
        public string Point;

        //public static Branch GetBranch(string point)
        //{
        //    string query = "SELECT ;";
        //    using (SqlConnection conn = new SqlConnection(Repository.connectionString))
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        conn.Open();

        //        using (DataSet ds = new DataSet())
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //        {
        //            adapter.Fill(ds);

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //                list.Add(new Route(ds.Tables[0].Rows[i]));
        //        }
        //    }
        //}
    }
}
