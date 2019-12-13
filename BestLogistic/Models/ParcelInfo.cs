using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class ParcelInfo
    {
        public ParcelInfo(bool service, bool type, byte pieces, string content, decimal value, float weight, decimal deliveryFee, decimal pickUpFee)
        {
            Service = service;
            Type = type;
            Pieces = pieces;
            Content = content;
            Value = value;
            Weight = weight;
            DeliveryFee = deliveryFee;
            PickUpFee = pickUpFee;
        }

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