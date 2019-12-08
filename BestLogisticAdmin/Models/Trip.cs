using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class Trip
    {
        public byte Status { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime? DepTime { get; set; }
        public DateTime? ArrTime { get; set; }
        public string DepartureId { get; set; }
        public string ArrivalId { get; set; }

        //public Trip(byte status, string departure, string arrival, DateTime? depTime, DateTime? arrTime, string departureId, string arrivalId)
        //{
        //    Status = status;
        //    Departure = departure;
        //    Arrival = arrival;
        //    DepTime = depTime;
        //    ArrTime = arrTime;
        //    DepartureId = departureId;
        //    ArrivalId = arrivalId;
        //}
    }
}
