using System.Collections.Generic;
using System.Drawing;

namespace SCR_Repair_Tracker
{
    public static class ConstantsLibrary
    {

        private static string storeName; // these fields are obtained from the app.config
        private static string storeAddress;
        private static string storeCity;
        private static string storeState;
        private static string storeZip;
        private static string storePhone;
        private static decimal localTax; 
        

        private static List<DeviceTypeRow> deviceTypes; //these list fields are obtained from the Database
        private static List<StatusTypeRow> statusTypes;
        private static List<AccTypeRow> accTypes;
        private static List<EmployeeRow> employeeList;
        private static List<PartStatusRow> partStatusTypes;
        

       

        public static string StoreName
        {
            get { return storeName; }
            set { storeName= value; }
        }

        public static string StoreAddress
        {
            get { return storeAddress; }
            set { storeAddress = value; }
        }

        public static string StoreCity
        {
            get { return storeCity; }
            set { storeCity = value; }
        }

        public static string StoreState
        {
            get { return storeState; }
            set { storeState = value; }
        }

        public static string StoreZip
        {
            get { return storeZip; }
            set { storeZip = value; }
        }

        public static string StorePhone
        {
            get { return storePhone; }
            set { storePhone = value; }
        }

        public static decimal LocalTax
        {
            get { return localTax; }
            set { localTax = value; }
        }



        public static List<DeviceTypeRow> DeviceTypes
        {
            get
            {
                return deviceTypes;
            }
            set
            {
                deviceTypes = value;
            }

        }

        public static List<StatusTypeRow> StatusTypes
        {
            get
            {
                return statusTypes;
            }
            set
            {
                statusTypes = value;
            }

        }

        public static List<AccTypeRow> AccTypes
        {
            get { return accTypes; }
            set { accTypes = value; }
        }

        public static List<EmployeeRow> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
            }

        }

        public static List<PartStatusRow> PartStatusTypes
        {
            get { return partStatusTypes; }
            set { partStatusTypes = value; }
        }

       




        // color coding of the status, backcolor is changed based on repair status
        public static Dictionary<string, Color> RepairBackColor = new Dictionary<string, Color>() 
        {
            { "1", Color.White},  // 1 = Closed   
            { "2", Color.DarkBlue}, // 2 = New
            { "3", Color.BlueViolet},  //diagx
            { "4", Color.OliveDrab},  //mobile
            { "5", Color.CornflowerBlue}, //hardware
            { "6", Color.Tomato}, //s/t or backup
            { "7", Color.MediumSeaGreen}, //software
            { "8", Color.Goldenrod}, //pc check
            { "9", Color.Plum}, // awaiting cust
            { "10", Color.Peru}, //part ordered
            { "11", Color.LightBlue} //awaiting pickup
        };


        // color coding of the status, forecolor changed based on status
        public static Dictionary<string, Color> RepairForeColor = new Dictionary<string, Color>() 
        { 
            { "1", Color.Black},  //these are the same as the backcolor statuses
            { "2", Color.White},
            { "3", Color.White},
            { "4", Color.White},
            { "5", Color.White},
            { "6", Color.White},
            { "7", Color.White},
            { "8", Color.White},
            { "9", Color.Black},
            { "10", Color.Black},
            { "11", Color.Black}
        };

        public static Dictionary<string, Color> PartBackColor = new Dictionary<string, Color>()
        {
            { "1", Color.RoyalBlue},  // 1 = Need to quote   
            { "2", Color.DarkSeaGreen}, // 2 = Need to order
            { "3", Color.Goldenrod},  //price quoted 
            { "4", Color.Aquamarine},  // order placed
            { "5", Color.Fuchsia}, //need to return
            { "6", Color.Tomato}, //return pending
            { "7", Color.Black} //closed
            
        };

        public static Dictionary<string, Color> PartForeColor = new Dictionary<string, Color>()
        {
            { "1", Color.White},  //these are the same as the backcolor statuses
            { "2", Color.White},
            { "3", Color.White},
            { "4", Color.Black},
            { "5", Color.White},
            { "6", Color.Black},
            { "7", Color.White}
            
        };



    }
}
