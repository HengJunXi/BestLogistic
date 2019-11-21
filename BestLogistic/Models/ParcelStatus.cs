using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class ParcelStatus
    {
        public DateTime date;
        public DateTime time;
        public string status;

        public ParcelStatus(DateTime date, DateTime time, string status)
        {
            this.date = date;
            this.time = time;
            this.status = status;
        }
    }
}