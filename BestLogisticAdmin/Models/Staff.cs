﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class Staff
    {
        public readonly string Uid;
        public readonly string BranchId;
        public readonly int StaffId;
        public readonly string Name;
        public readonly string Branch;

        public Staff(string uid, string branchId, int staffId, string name, string branch)
        {
            Uid = uid;
            BranchId = branchId;
            StaffId = staffId;
            Name = name;
            Branch = branch;
        }
    }
}
