using System;

namespace SCR_Repair_Tracker
{
    public class OpenRepairRow
    {

        // These properties exactly match the output of the db stored procedure
        // Repairs_GetOpenRepairs for use with Dapper

        public int RepairID { get; set; }

        public int CustomerID { get; set; }

        public bool isLocked { get; set; }

        public short StatusKey { get; set; }

        public string CustomerName { get; set; }

        public string Manufacturer { get; set; }

        public string TypeOfDevice { get; set; }

        public string Status { get; set; }
        
        public DateTime OriginStamp { get; set; }
    }
}
