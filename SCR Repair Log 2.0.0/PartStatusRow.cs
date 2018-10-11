using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class PartStatusRow
    {
        public int PStatusID { get; set; }

        public string PartStatus { get; set; }

        public override string ToString()
        {
            return PartStatus.ToString();
        }
    }
}
