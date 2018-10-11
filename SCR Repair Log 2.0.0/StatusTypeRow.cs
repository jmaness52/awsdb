using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class StatusTypeRow
    {
        public int StatusID { get; set; }

        public string StatusName { get; set; }

        public override string ToString()
        {
            return StatusName.ToString();
        }
    }
}
