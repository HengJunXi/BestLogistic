using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class ShipmentRecord
    {
        public readonly int TrackingNumber;

        public ShipmentRecord(int trackingNumber, string senderName, string senderAddress, string senderLocation, string senderPostcode, string receiverName, string receiverAddress, string receiverLocation, string receiverPostcode, DateTime? deliveredDate)
        {
            TrackingNumber = trackingNumber;
            SenderName = senderName;
            SenderAddress = senderAddress;
            SenderLocation = senderLocation;
            SenderPostcode = senderPostcode;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            ReceiverLocation = receiverLocation;
            ReceiverPostcode = receiverPostcode;
            DeliveredDate = deliveredDate;
        }

        public string SenderName { get; private set; }
        public string SenderAddress { get; private set; }
        public string SenderLocation { get; private set; }
        public string SenderPostcode { get; private set; }
        public string ReceiverName { get; private set; }
        public string ReceiverAddress { get; private set; }
        public string ReceiverLocation { get; private set; }
        public string ReceiverPostcode { get; private set; }
        public DateTime? DeliveredDate { get; private set; }
    }
}