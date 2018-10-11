using System;

namespace SCR_Repair_Tracker
{
    public class FullRepairRow
    {
        public int RepairID { get; set; }

        public int CustomerID { get; set; }

        public DateTime OriginStamp { get; set; }

        public short StatusID { get; set; }

        public DateTime CloseStamp { get; set; }

        public short TypeID { get; set; }

        public short MfgID { get; set; }

        public decimal ServiceFee { get; set; }

        public decimal PartFee { get; set; }

        public decimal TotalCost { get; set; }

        public string Password { get; set; }

        public string Notes { get; set; }

        public bool isLocked { get; set; }

        public bool ServiceApproved { get; set; }




    }
}
