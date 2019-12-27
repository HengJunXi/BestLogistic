using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class ParcelStatus
    {
        public string date;
        public string time;
        public string status;

        public ParcelStatus(string date, string time, string status)
        {
            this.date = date;
            this.time = time;
            this.status = status;
        }
    }
}