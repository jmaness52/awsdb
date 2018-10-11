using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class OpenPartRow
    {

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int RepairId { get; set; }

        public bool isLocked { get; set; }

        public string CustomerName { get; set; }

        public string VendorName { get; set; }

        public string PartDescription { get; set; }

        public string PartStatus { get; set; }

        public DateTime OriginStamp { get; set; }

        public int PStatusID { get; set; }

    }
}
