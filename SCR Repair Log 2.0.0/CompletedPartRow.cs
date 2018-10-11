using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Repair_Tracker
{
    public class CompletedPartRow
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string PartDescription { get; set; }

        public string VendorName { get; set; }

        public DateTime CloseStamp { get; set; }

        public decimal PriceAfterMarkup { get; set; }


    }
}
