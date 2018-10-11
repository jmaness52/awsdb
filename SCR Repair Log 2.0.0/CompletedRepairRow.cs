using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class CompletedRepairRow
    {

        public int CustomerID { get; set; }

        public int RepairID { get; set; }

        public string CustomerName { get; set; }

        public string Tel1 { get; set; }

        public string TypeDevice { get; set; }

        public string MfgName{ get; set; }

        public DateTime CloseStamp { get; set; }

        public decimal TotalCost { get; set; }
    }
}
