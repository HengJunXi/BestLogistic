using BestLogistic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class ShipmentRecord
    {
        public readonly int TrackingNumber;

        public ShipmentRecord(int trackingNumber, string senderName, string senderAddress, string senderLocation, string senderPostcode, string senderCity, string senderState, string receiverName, string receiverAddress, string receiverLocation, string receiverPostcode, string receiverCity, string receiverState, DateTime? deliveredDate)
        {
            TrackingNumber = trackingNumber;
            SenderName = senderName;
            SenderAddress = senderAddress;
            SenderLocation = senderLocation;
            SenderPostcode = senderPostcode;
            SenderCity = senderCity;
            SenderState = senderState;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress + ", " + receiverLocation + ", " + receiverPostcode + " " + receiverCity
                                + ", " + Utility.StateCodeMap[receiverState];
            ReceiverLocation = receiverLocation;
            ReceiverPostcode = receiverPostcode;
            ReceiverCity = receiverCity;
            ReceiverState = receiverState;
            DeliveredDate = deliveredDate;
        }

        public string SenderName { get; private set; }
        public string SenderAddress { get; private set; }
        public string SenderLocation { get; private set; }
        public string SenderPostcode { get; private set; }
        public string SenderCity { get; private set; }
        public string SenderState { get; private set; }
        public string ReceiverName { get; private set; }
        public string ReceiverAddress { get; private set; }
        public string ReceiverLocation { get; private set; }
        public string ReceiverPostcode { get; private set; }
        public string ReceiverCity { get; private set; }
        public string ReceiverState { get; private set; }
        public DateTime? DeliveredDate { get; private set; }
    }
}