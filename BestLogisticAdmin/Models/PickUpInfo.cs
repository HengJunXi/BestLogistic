using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class PickUpInfo
    {
        public PickUpInfo(DateTime pickUpDate, DateTime pickUpTime, string remark, bool status)
        {
            PickUpDate = pickUpDate;
            PickUpTime = pickUpTime;
            Remark = remark;
            Status = status;
        }
        public DateTime PickUpDate { get; private set; }
        public DateTime PickUpTime { get; private set; }
        public string Remark { get; private set; }
        public bool Status { get; private set; }            // 0 pending, 1 picked up
    }
}
