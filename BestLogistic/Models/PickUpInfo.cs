using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class PickUpInfo
    {
        public PickUpInfo(string trackingNumber, DateTime pickUpDate, DateTime pickUpTime, string remark, bool status)
        {
            TrackingNumber = trackingNumber;
            PickUpDate = pickUpDate;
            PickUpTime = pickUpTime;
            Remark = remark;
            Status = status;
        }

        public string TrackingNumber { get; private set; }
        public DateTime PickUpDate { get; private set; }
        public DateTime PickUpTime { get; private set; }
        public string Remark { get; private set; }
        public bool Status { get; private set; }

    }
}