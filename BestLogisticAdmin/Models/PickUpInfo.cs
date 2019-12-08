using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class PickUpInfo
    {
        public DateTime? PickUpDate { get; set; }
        public DateTime? PickUpTime { get; set; }
        public string PickUpRemark { get; set; }

        //public PickUpInfo(DateTime? pickUpDate, DateTime? pickUpTime, string pickUpRemark)
        //{
        //    PickUpDate = pickUpDate;
        //    PickUpTime = pickUpTime;
        //    PickUpRemark = pickUpRemark;
        //}
    }
}
