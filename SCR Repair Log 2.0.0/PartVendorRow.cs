﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class PartVendorRow
    {
        public int VendorID { get; set; }

        public string VendorName { get; set; }

        public override string ToString()
        {
            return VendorName.ToString();
        }

    }
}
