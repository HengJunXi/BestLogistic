using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class ParcelInfo
    {
        public string TrackingNumber { get; private set; }
        public bool Service { get; private set; }
        public bool Type { get; private set; }
        public byte Pieces { get; private set; }
        public string Content { get; private set; }
        public Decimal Value { get; private set; }
        public float Weight { get; private set; }
        public Decimal DeliveryFee { get; private set; }
        public Decimal PickUpFee { get; private set; }

    }
}
