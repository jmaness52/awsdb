using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class PartOrderRow
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public int RepairID { get; set; }

        public int PStatusID { get; set; }

        public int VendorID { get; set; }

        public DateTime OriginStamp { get; set; }

        public DateTime CloseStamp { get; set; }

        public string PartDescription { get; set; }

        public string PartLink { get; set; }

        public string Notes { get; set; }

        public decimal PriceBefore { get; set; }

        public decimal PriceAfterMarkup { get; set; }

        public bool IsLocked { get; set; }

    }
}
