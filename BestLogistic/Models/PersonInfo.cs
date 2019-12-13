using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Models
{
    public class PersonInfo
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string PostCode { get; private set; }
        public string Location { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public PersonInfo(string name, string email, string phone, string address, string postCode, string location, string city, string state)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            PostCode = postCode;
            Location = location;
            City = city;
            State = state;
        }
    }
}