using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class User
    {
        public readonly string Uid;
        public readonly string Name;
        public readonly string Email;
        public readonly int IdType;
        public readonly string IdNumber;
        public readonly DateTime DateOfBirth;
        public string Address { get; private set; }
        public string Location { get; private set; }
        public string Postcode { get; private set; }
        public string PhoneNumber { get; private set; }
        public string HomeNumber { get; private set; }

        public string PictureUrl { get; private set; }

        public User(DataRow data)
        {
            Uid = data.Field<Guid>("uid").ToString();
            Name = data.Field<string>("name");
            Email = data.Field<string>("email");
            IdType = data.Field<byte>("id_type");
            IdNumber = data.Field<string>("id_number");
            DateOfBirth = data.Field<DateTime>("date_of_birth");
            Address = data.Field<string>("address");
            Location = data.Field<string>("location");
            Postcode = data.Field<string>("postcode");
            PhoneNumber = data.Field<string>("phone_number");
            HomeNumber = data.Field<string>("home_number");
            PictureUrl = data.Field<string>("picture_url");
        }
    }
}