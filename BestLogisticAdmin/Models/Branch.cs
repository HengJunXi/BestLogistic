using BestLogisticAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class Branch
    {
        public string Id;
        public string Name;

        public Branch(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
