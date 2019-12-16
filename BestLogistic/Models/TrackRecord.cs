using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class TrackRecord
    {
        public string Departure { get; private set; }
        public string DeparturePoint { get; private set; }

        public string Arrival { get; private set; }
        public string ArrivalPoint { get; private set; }

        public DateTime? DepartureDateTime { get; private set; }
        public DateTime? ArrivalDateTime { get; private set; }

        public TrackRecord(string departure, string departurePoint, string arrival, string arrivalPoint, DateTime? departureDateTime, DateTime? arrivalDateTime)
        {
            Departure = departure;
            DeparturePoint = departurePoint;
            Arrival = arrival;
            ArrivalPoint = arrivalPoint;
            DepartureDateTime = departureDateTime;
            ArrivalDateTime = arrivalDateTime;
        }
    }
}