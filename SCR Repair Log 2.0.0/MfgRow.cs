using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class MfgRow 
    {
        public int MfgID { get; set; }

        public string MfgName { get; set; }

        public override string ToString()
        {
            return MfgName; 
        }
    }
}
