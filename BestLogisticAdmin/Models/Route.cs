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
    public class Route
    {
        public string DeparturePoint;
        public string ArrivalPoint;
        public string Departure;
        public string Arrival;

        //public Route(string departurePoint, string arrivalPoint, string departure, string arrival)
        //{
        //    DeparturePoint = departurePoint;
        //    ArrivalPoint = arrivalPoint;
        //    Departure = departure;
        //    Arrival = arrival;
        //}

        public Route(DataRow dataRow)
        {
            DeparturePoint = dataRow.Field<string>("departure_point");
            ArrivalPoint = dataRow.Field<string>("arrival_point");
            Departure = dataRow.Field<string>("departure");
            Arrival = dataRow.Field<string>("arrival");
        }

        public static List<Route> GetRoutes()
        {
            List<Route> list = new List<Route>();
            
            string query = "SELECT departure_point, arrival_point, P1.name AS departure, P2.name AS arrival FROM route R INNER JOIN point P1 ON R.departure_point=P1.place_id INNER JOIN point P2 ON R.arrival_point=P2.place_id WHERE departure_point=@BID;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        list.Add(new Route(ds.Tables[0].Rows[i]));
                }
            }

            return list;
        }
    }
}
