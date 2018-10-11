using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class DeviceTypeRow
    {
        public int TypeID { get; set; }

        public string TypeDevice { get; set; }


        // needed for list lookup 
        public override string ToString()
        {
            return TypeDevice.ToString();
        }
    }
}
