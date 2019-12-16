using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class TrackResult
    {
        public TrackResult(byte status, List<TrackRecord> records)
        {
            Status = status;
            Records = records;
        }

        // 0 pending lodge in, 1 pending pick up, 
        // 2 in branch, 3 pending transit, 4 in transit, 
        // 5 pending delivery, 6 delivering, 7 delivered
        public byte Status { get; private set; }
        public List<TrackRecord> Records { get; private set; }
    }
}