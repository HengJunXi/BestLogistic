using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class PersonInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        //public PersonInfo(string name, string email, string phone, string address, string postCode, string location, string city, string state)
        //{
        //    Name = name;
        //    Email = email;
        //    Phone = phone;
        //    Address = address;
        //    PostCode = postCode;
        //    Location = location;
        //    City = city;
        //    State = state;
        //}
    }
}
