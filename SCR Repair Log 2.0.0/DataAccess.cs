using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using System;
using System.Windows.Forms;


namespace SCR_Repair_Tracker
{
    public class DataAccess  
    {
        // This class will contain methods to query, insert, update records 
        // String is stored in connstringbuilder.connectionstring
        // can copy and paste using statement to make new connection to DB
        // connection.Query to return data from database, generally saved to a list
        // connection.Execute to INSERT or UPDATE tables (no data received)


        #region Get Lists

        // Gets lists of information from the database including comboboxes, open repairs, open parts


        /// <summary>
        /// retreives open repairs list
        /// </summary>
        /// <returns></returns>
        public List<OpenRepairRow> GetOpenRepairs()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                // execs a DB stored procedure to pull up all the open repairs and sort by status, date
                return connection.Query<OpenRepairRow>("[SCR_USER].[Repairs_GetOpenRepairs]").ToList();
            }

        }

        public List<OpenPartRow> GetOpenPartOrders()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                // execs a DB stored procedure to pull up all the open repairs and sort by status, date
                return connection.Query<OpenPartRow>("[SCR_USER].[GetOpenPartOrders]").ToList();
            }

        }

        public List<PartOrderRow> GetPartsInRepair(int repairIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<PartOrderRow>("[SCR_USER].GetPartsInRepair @Repair", new { Repair = repairIN } ).ToList();
            }
        }


        public void PopulateMfgControl(ComboBox mfgIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {


                //mfgrow is class with two properties MfgID, MfgName - this matches sql output
                // the list is loaded from db, sorted alphabetically,
                // and then an entry is added to reserve a space in the combobox to add a new manufacturer
                List<MfgRow> ControlsItems = connection.Query<MfgRow>("[SCR_USER].GetCbxList @Control", new { Control = "MfgTypes" }).Select(item => new MfgRow
                {
                    MfgID = item.MfgID,
                    MfgName = item.MfgName.ToString()
                }).ToList();


                //alphabetic sorting of manufacturer name
                ControlsItems.Sort(delegate (MfgRow x, MfgRow y)
                {
                    return x.MfgName.CompareTo(y.MfgName);
                });



                //add an extry entry to the list to allow user to add a new manufacturer,  the mfg id is set to the max value + 1  but this value
                // is not used when inserting to mfg table in sql

                ControlsItems.Add(new MfgRow() { MfgName = "Add New", MfgID = (ControlsItems.Max(x => x.MfgID) + 1) });

                mfgIN.DataSource = ControlsItems;
                mfgIN.ValueMember = "MfgID";
                mfgIN.DisplayMember = "MfgName";

            }
        }


        /// <summary>
        /// populates MFG combobox and Acc listbox
        /// </summary>
        /// <param name="mfgIN"></param>
        /// <param name="mfgID"></param>          
        public void PopulateMfgControl(ComboBox mfgIN, int mfgIDin)
        {




            // query to manufacturer table - 'MfgTypes'
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {


                //mfgrow is class with two properties MfgID, MfgName - this matches sql output
                // the list is loaded from db, sorted alphabetically,
                // and then an entry is added to reserve a space in the combobox to add a new manufacturer
                List<MfgRow> ControlsItems = connection.Query<MfgRow>("[SCR_USER].GetCbxList @Control", new { Control = "MfgTypes" }).Select(item => new MfgRow
                {
                    MfgID = item.MfgID,
                    MfgName = item.MfgName.ToString()
                }).ToList();


                //alphabetic sorting of manufacturer name
                ControlsItems.Sort(delegate (MfgRow x, MfgRow y)
                {
                    return x.MfgName.CompareTo(y.MfgName);
                });



                //add an extry entry to the list to allow user to add a new manufacturer,  the mfg id is set to the max value + 1  but this value
                // is not used when inserting to mfg table in sql

                ControlsItems.Add(new MfgRow() { MfgName = "Add New", MfgID = (ControlsItems.Max(x => x.MfgID) + 1) });

                mfgIN.DataSource = ControlsItems;
                mfgIN.ValueMember = "MfgID";
                mfgIN.DisplayMember = "MfgName";

                //sets the selected value of the cbx by looking up from controls items list<MfgRow> , the mfgID is input from the EditRow
                // variable in the data validation class
                mfgIN.SelectedIndex = mfgIN.FindString(ControlsItems.Find(t => t.MfgID == mfgIDin).ToString());


            }

            
        }

        public void PopulatePartVendors(ComboBox vendorsIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {


                //mfgrow is class with two properties MfgID, MfgName - this matches sql output
                // the list is loaded from db, sorted alphabetically,
                // and then an entry is added to reserve a space in the combobox to add a new manufacturer
                List<PartVendorRow> ControlsItems = connection.Query<PartVendorRow>("[SCR_USER].GetCbxList @Control", new { Control = "PartVendors" }).Select(item => new PartVendorRow
                {
                    VendorID = item.VendorID,
                    VendorName = item.VendorName.ToString()
                }).ToList();


                //alphabetic sorting of manufacturer name
                ControlsItems.Sort(delegate (PartVendorRow x, PartVendorRow y)
                {
                    return x.VendorName.CompareTo(y.VendorName);
                });



                //add an extry entry to the list to allow user to add a new manufacturer,  the mfg id is set to the max value + 1  but this value
                // is not used when inserting to mfg table in sql

                ControlsItems.Add(new PartVendorRow() { VendorName = "Add New", VendorID = (ControlsItems.Max(x => x.VendorID) + 1) });

                vendorsIn.DataSource = ControlsItems;
                vendorsIn.ValueMember = "VendorID";
                vendorsIn.DisplayMember = "VendorName";

                

            }
        }

        public void PopulatePartVendors(ComboBox vendorsIn, int vendorID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {


                //mfgrow is class with two properties MfgID, MfgName - this matches sql output
                // the list is loaded from db, sorted alphabetically,
                // and then an entry is added to reserve a space in the combobox to add a new manufacturer
                List<PartVendorRow> ControlsItems = connection.Query<PartVendorRow>("[SCR_USER].GetCbxList @Control", new { Control = "PartVendors" }).Select(item => new PartVendorRow
                {
                    VendorID = item.VendorID,
                    VendorName = item.VendorName.ToString()
                }).ToList();


                //alphabetic sorting of manufacturer name
                ControlsItems.Sort(delegate (PartVendorRow x, PartVendorRow y)
                {
                    return x.VendorName.CompareTo(y.VendorName);
                });



                //add an extry entry to the list to allow user to add a new manufacturer,  the mfg id is set to the max value + 1  but this value
                // is not used when inserting to mfg table in sql

                ControlsItems.Add(new PartVendorRow() { VendorName = "Add New", VendorID = (ControlsItems.Max(x => x.VendorID) + 1) });

                vendorsIn.DataSource = ControlsItems;
                vendorsIn.ValueMember = "VendorID";
                vendorsIn.DisplayMember = "VendorName";

                vendorsIn.SelectedIndex = vendorsIn.FindStringExact(ControlsItems.Find(t => t.VendorID == vendorID).ToString());
            }
        }

        /// <summary>
        /// stores a list of devices types and status types to constants library
        /// </summary>

        public void StoreStaticTables()
        {

            // method to store the Status and DeviceType Values (and corresponding keys) in the constants library class
            // the Manufacturer, and accessory tables are loaded each time the form is loaded (these can change, therefore they are dynamic), done in dynamic method
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                List<DeviceTypeRow> ControlsItems = connection.Query<DeviceTypeRow>("[SCR_USER].GetCbxList @Control", new { Control = "DeviceTypes" }).Select(item => new DeviceTypeRow
                {
                    TypeID = item.TypeID,
                    TypeDevice = item.TypeDevice.ToString()
                }).ToList();

                ConstantsLibrary.DeviceTypes = ControlsItems;
            }

            // the Manufacturer, and accessory tables are loaded each time the form is loaded (these can change, therefore they are dynamic), done in dynamic method
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                List<StatusTypeRow> ControlsItems = connection.Query<StatusTypeRow>("[SCR_USER].GetCbxList @Control", new { Control = "StatusTypes" }).Select(item => new StatusTypeRow
                {
                    StatusID = item.StatusID,
                    StatusName = item.StatusName.ToString()
                }).ToList();

                ConstantsLibrary.StatusTypes = ControlsItems;
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {

                List<AccTypeRow> ControlsItems = connection.Query<AccTypeRow>("[SCR_USER].GetCbxList @Control", new { Control = "AccessoryTypes" }).Select(item => new AccTypeRow
                {
                    AccID = item.AccID,
                    AccType = item.AccType.ToString()
                }).ToList();

                ConstantsLibrary.AccTypes = ControlsItems;



            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                List<EmployeeRow> ControlsItems = connection.Query<EmployeeRow>("[SCR_USER].GetEmployees").Select(item => new EmployeeRow
                {
                    EmployeeName = item.EmployeeName,
                    Tel1 = item.Tel1,
                    Initials = item.Initials
                }).ToList();

                ConstantsLibrary.EmployeeList = ControlsItems;
            }


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                List<PartStatusRow> ControlsItems = connection.Query<PartStatusRow>("[SCR_USER].GetCbxList @Control", new { Control = "PartStatus" }).Select(item => new PartStatusRow
                {
                    PStatusID = item.PStatusID,
                    PartStatus = item.PartStatus.ToString()
                }).ToList();

                ConstantsLibrary.PartStatusTypes = ControlsItems;
            }

            
        }

        /// <summary>
        /// gets a list of accessories belonging to a repair
        /// </summary>
        /// <param name="RepairIN"></param>
        /// <returns></returns>

        public List<RepairAccRow> GetAccessoriesForRepair(int RepairIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<RepairAccRow>("[SCR_USER].GetRepairAcc @RepairID", new { RepairID = RepairIN }).Select(item => new RepairAccRow
                {
                    RepairID = item.RepairID,
                    AccID = item.AccID
                }).ToList();

            }
        }


        public List<CustomerRow> SearchCustomers(string searchIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<CustomerRow>("[SCR_USER].SearchCustomers @CustID", new { CustID = searchIN }).Select(item => new CustomerRow
                {
                    CustomerID = item.CustomerID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,                    
                    Tel1 = item.Tel1,
                    Tel2 = item.Tel2,
                    CustomerName = item.CustomerName
                }).ToList();
            }
        }

        public List<CompletedRepairRow> GetCompletedRepairs()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<CompletedRepairRow>("[SCR_USER].Repairs_GetCompletedRepairs").ToList();
            }
        }

        public List<CompletedRepairRow> SearchCompletedRepairs(string searchIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<CompletedRepairRow>("[SCR_USER].SearchCompletedRepairs @CustName", new { CustName = searchIN }).Select(item => new CompletedRepairRow
                {
                    CustomerID = item.CustomerID,
                    RepairID = item.RepairID,
                    CustomerName = item.CustomerName,
                    Tel1 = item.Tel1,
                    TypeDevice = item.TypeDevice,
                    MfgName = item.MfgName,
                    CloseStamp = item.CloseStamp,
                    TotalCost = item.TotalCost
                    
                }).ToList();
            }
        }

        public List<CompletedPartRow> GetCompletedParts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<CompletedPartRow>("[SCR_USER].GetCompletedPartOrders").ToList();
            }
        }

        public List<CompletedPartRow> SearchCompletedParts(string searchIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<CompletedPartRow>("[SCR_USER].SearchCompletedPartOrders @CustName", new { CustName = searchIN }).Select(item => new CompletedPartRow
                {
                    OrderID = item.OrderID,
                    CustomerID = item.CustomerID,                   
                    CustomerName = item.CustomerName,
                    PartDescription = item.PartDescription,
                    VendorName = item.VendorName,
                    CloseStamp = item.CloseStamp,
                    PriceAfterMarkup = item.PriceAfterMarkup

                }).ToList();
            }
        }



        #endregion

        #region Record Locking

        /// <summary>
        /// check if record is locked, return true if locked
        /// </summary>
        /// <param name="repairIn"></param>
        /// <returns></returns>

        public bool CheckLocked(int repairIn)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {

                var testValue = connection.ExecuteScalar("[SCR_USER].Get_isRecordLocked @RepairID", new { RepairID = repairIn }); // store result of query in an object


                // the value can be null true or false,   need the if statement to prevent
                // errors in case of null.. null should be the same as false to the programs perspective

                if (testValue != null)
                {
                    return (bool)testValue;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool CheckPartLocked(int orderIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                var testValue = connection.ExecuteScalar("[SCR_USER].Get_isPartLocked @OrderID", new { OrderID = orderIN });

                if (testValue != null)
                {
                    return (bool)testValue;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// lock a record for edit
        /// </summary>
        /// <param name="repairIn"></param>
        public void LockRecord(int repairIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].LockRecord @RepairID", new { RepairID = repairIn });
            }
        }

        public void LockPart (int orderIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].LockPart @OrderID", new { OrderID = orderIn });
            }
        }


        public void UnlockRecord(int repairIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].unLockRecord @RepairID", new { RepairID = repairIn });
            }
        }

        public void UnlockPart(int orderIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].unLockPart @OrderID", new { OrderID = orderIn });
            }
        }

        #endregion

        #region Get Single Records

        /// <summary>
        /// gets a single repair record
        /// </summary>
        /// <param name="repairIn"></param>
        /// <returns></returns>
        public FullRepairRow FetchRepair(int repairIn)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<FullRepairRow>("[SCR_USER].GetSingleRepair @RepairID", new { RepairID = repairIn });
            }
        }

        public PartOrderRow GetSinglePart(int orderIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<PartOrderRow>("[SCR_USER].GetSinglePart @OrderID", new { OrderID = orderIn });
            }
        }


        /// <summary>
        /// gets a single customer record
        /// </summary>
        /// <param name="custIn"></param>
        /// <returns></returns>

        public CustomerRow FetchCustomer(int custIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<CustomerRow>("[SCR_USER].GetCustomer @CustID", new { CustID = custIn });
            }

        }

        public string GetVendor(int vendorIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<string>("[SCR_USER].GetSingleVendor @VendorID", new { VendorID = vendorIn });
            }
        }

        #endregion

        #region Add Records

        /// <summary>
        /// add a mfg to databse
        /// </summary>
        /// <param name="mfgNameIn"></param>
        /// <returns></returns>

        public short AddMfg(string mfgNameIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                int newMfg = connection.QuerySingle<int>("[SCR_USER].AddMFG @MfgName", new { MfgName = mfgNameIn });
                return (short)newMfg;
            }
        }

        public short AddVendor(string vendorIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                int newVendor = connection.QuerySingle<int>("[SCR_USER].AddVendor @VendorName", new { VendorName = vendorIn });

                return (short)newVendor;
            }
        }


        /// <summary>
        /// insert a single acc row into repair acc table
        /// </summary>
        /// <param name="repairIN"></param>
        /// <param name="accIN"></param>
        public void InsertRepairAcc(int repairIN, int accIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].InsertRepairAcc @RepairID, @AccID", new { RepairID = repairIN, AccID = accIN });
            }
        }

        public int InsertCustomer(string FnIN, string LnIn, string TelIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<int>("[SCR_USER].InsertCust1 @FirstName, @LastName, @Tel1", new { FirstName = FnIN, LastName = LnIn, Tel1 = TelIN });
            }
        }

        public int InsertCustomer(string FnIN, string LnIn, string TelIN, string Tel2IN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<int>("[SCR_USER].InsertCust2 @FirstName, @LastName, @Tel1, @Tel2", new { FirstName = FnIN, LastName = LnIn, Tel1 = TelIN, Tel2 = Tel2IN });
            }
        }

        public int InsertRepair(int CustIn, int TypeIn, int MfgIn, decimal SvcFeeIn, decimal PartFeeIn, string PassIn, string NotesIn, bool SvcFlagIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<int>("[SCR_USER].InsertRepair @CustID, @TypeID, @MfgID, @ServiceFee, @PartFee, @Password, @Notes, @SvcApproved", new {
                    CustID = CustIn,
                    TypeID = TypeIn,
                    MfgID = MfgIn,
                    ServiceFee = SvcFeeIn,
                    PartFee = PartFeeIn,
                    Password = PassIn,
                    Notes = NotesIn,
                    SvcApproved = SvcFlagIn});
            }
        }

        public int InsertPartOrder_WithRepair(int CustIN, int RepairIn, int StatusIn, int VendorIn, string PartDescIn, string PartLinkIn, string NotesIn, decimal pBefore, decimal pAfter)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<int>("[SCR_USER].InsertPartOrder_WithRepair @CustID, @RepairID, @PStatusID, @VendorID, @PartDescription, @PartLink, @Notes, @PriceBefore, @PriceAfter", new {
                    CustID = CustIN,
                    RepairID = RepairIn,
                    PStatusID = StatusIn,
                    VendorID = VendorIn,
                    PartDescription = PartDescIn,
                    PartLink = PartLinkIn,
                    Notes = NotesIn,
                    PriceBefore = pBefore,
                    PriceAfter = pAfter });
            }
        }

        public int InsertPartOrder_NoRepair(int CustIN, int StatusIn, int VendorIn, string partDescIn, string PartLinkIn, string NotesIn, decimal pBefore, decimal pAfter)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.QuerySingle<int>("[SCR_USER].InsertPartOrder_NoRepair @CustID, @PStatusID, @VendorID, @PartDescription, @PartLink, @Notes, @PriceBefore, @PriceAfter", new
                {
                    CustID = CustIN,
                    PStatusID = StatusIn,
                    VendorID = VendorIn,
                    PartDescription = partDescIn,
                    PartLink = PartLinkIn,
                    Notes = NotesIn,
                    PriceBefore = pBefore,
                    PriceAfter = pAfter
                });
            }
        }


        #endregion

        #region Update Records

        /// <summary>
        /// update a customer record with 1 tel #
        /// </summary>
        /// <param name="custID"></param>
        /// <param name="fnIN"></param>
        /// <param name="lnIN"></param>
        /// <param name="tel1in"></param>
        public void UpdateCustomer(int custID, string fnIN, string lnIN, string tel1in)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].UpdateCust1 @CustID, @FirstName, @LastName, @Tel1", new { CustID = custID, FirstName = fnIN, LastName = lnIN, Tel1 = tel1in });
            }
        }

        

        /// <summary>
        /// update a customer record with 2 tel #
        /// </summary>
        /// <param name="custID"></param>
        /// <param name="fnIN"></param>
        /// <param name="lnIN"></param>
        /// <param name="tel1in"></param>
        /// <param name="tel2in"></param>
        public void UpdateCustomer(int custID, string fnIN, string lnIN, string tel1in, string tel2in)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].UpdateCust2 @CustID, @FirstName, @LastName, @Tel1, @Tel2", new { CustID = custID, FirstName = fnIN, LastName = lnIN, Tel1 = tel1in, Tel2 = tel2in });
            }
        }

        /// <summary>
        /// close out a repair (sets time stamp)
        /// </summary>
        /// <param name="repairIN"></param>
        public void CloseRepair(FullRepairRow repairIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].CloseRepair @StatusID , @TypeID , @MfgID , @ServiceFee , @PartFee , @Password , @Notes, @SvcApproved , @RepairID ", new
                {
                    StatusID = repairIN.StatusID,
                    TypeID = repairIN.TypeID,
                    MfgID = repairIN.MfgID,
                    ServiceFee = repairIN.ServiceFee,
                    PartFee = repairIN.PartFee,
                    Password = repairIN.Password,
                    Notes = repairIN.Notes,
                    SvcApproved = repairIN.ServiceApproved,
                    RepairID = repairIN.RepairID
                });
            }
        }

        /// <summary>
        /// edits a repair
        /// </summary>
        /// <param name="repairIN"></param>
        public void UpdateRepair(FullRepairRow repairIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].UpdateRepair @StatusID , @TypeID , @MfgID , @ServiceFee , @PartFee , @Password , @Notes , @SvcApproved , @RepairID ", new
                {
                    StatusID = repairIN.StatusID,
                    TypeID = repairIN.TypeID,
                    MfgID = repairIN.MfgID,
                    ServiceFee = repairIN.ServiceFee,
                    PartFee = repairIN.PartFee,
                    Password = repairIN.Password,
                    Notes = repairIN.Notes,
                    SvcApproved = repairIN.ServiceApproved,
                    RepairID = repairIN.RepairID
                });
            }
        }

        public void UpdatePartOrderWithRepair(PartOrderRow partIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].UpdatePartOrderWithRepair @OrderID , @RepairID , @PStatusID , @VendorID , @PartDescription , @PartLink , @Notes , @PriceBefore , @PriceAfter ", new
                {
                    OrderID = partIN.OrderID,
                    RepairID = partIN.RepairID,
                    PStatusID = partIN.PStatusID,
                    VendorID = partIN.VendorID,
                    PartDescription = partIN.PartDescription,
                    PartLink = partIN.PartLink,
                    Notes = partIN.Notes,
                    PriceBefore = partIN.PriceBefore,
                    PriceAfter = partIN.PriceAfterMarkup
                });

            }
        }

        public void ClosePartOrderWithRepair(PartOrderRow partIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].ClosePartOrderWithRepair @OrderID , @RepairID , @PStatusID , @VendorID , @PartDescription , @PartLink , @Notes , @PriceBefore , @PriceAfter ", new
                {
                    OrderID = partIN.OrderID,
                    RepairID = partIN.RepairID,
                    PStatusID = partIN.PStatusID,
                    VendorID = partIN.VendorID,
                    PartDescription = partIN.PartDescription,
                    PartLink = partIN.PartLink,
                    Notes = partIN.Notes,
                    PriceBefore = partIN.PriceBefore,
                    PriceAfter = partIN.PriceAfterMarkup
                });

            }
        }

        public void UpdatePartOrderNoRepair(PartOrderRow partIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].UpdatePartOrderNoRepair @OrderID , @PStatusID , @VendorID , @PartDescription , @PartLink , @Notes , @PriceBefore , @PriceAfter ", new
                {
                    OrderID = partIN.OrderID,
                    PStatusID = partIN.PStatusID,
                    VendorID = partIN.VendorID,
                    PartDescription = partIN.PartDescription,
                    PartLink = partIN.PartLink,
                    Notes = partIN.Notes,
                    PriceBefore = partIN.PriceBefore,
                    PriceAfter = partIN.PriceAfterMarkup
                });

            }
        }

        public void ClosePartOrderNoRepair(PartOrderRow partIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].ClosePartOrderNoRepair @OrderID , @PStatusID , @VendorID , @PartDescription , @PartLink , @Notes , @PriceBefore , @PriceAfter ", new
                {
                    OrderID = partIN.OrderID,
                    PStatusID = partIN.PStatusID,
                    VendorID = partIN.VendorID,
                    PartDescription = partIN.PartDescription,
                    PartLink = partIN.PartLink,
                    Notes = partIN.Notes,
                    PriceBefore = partIN.PriceBefore,
                    PriceAfter = partIN.PriceAfterMarkup
                });

            }
        }



        #endregion

        #region Delete Records

        /// <summary>
        /// deletes accesories for a given repair
        /// </summary>
        /// <param name="RepairIN"></param>
        public void DeleteAccRepair(int RepairIN)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                connection.Execute("[SCR_USER].DeleteAcc @RepairID", new { RepairID = RepairIN });
            }
        }
        #endregion

        #region Duplicate Checking
        public bool CheckMfgDuplicates(string mfgNameIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {

                List<MfgRow> MfgCheck = connection.Query<MfgRow>("[SCR_USER].MfgDupCheck @MfgName", new { MfgName = mfgNameIn }).Select(item => new MfgRow
                {
                    MfgID = item.MfgID,
                    MfgName = item.MfgName.ToString()
                }).ToList();

                if (MfgCheck.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckVendorDuplicates(string vendorIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {

                List<PartVendorRow> VendorCheck = connection.Query<PartVendorRow>("[SCR_USER].VendorDupCheck @VendorName", new { VendorName = vendorIn }).Select(item => new PartVendorRow
                {
                    VendorID = item.VendorID,
                    VendorName = item.VendorName.ToString()
                }).ToList();

                if (VendorCheck.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<OpenRepairRow> GetOpenRepairsByCust(int custIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnStringBuilder.ConnectionString))
            {
                return connection.Query<OpenRepairRow>("[SCR_USER].GetOpenRepairsByCust @CustID", new { CustID = custIn }).Select(item => new OpenRepairRow {
                    RepairID = item.RepairID,
                    Manufacturer = item.Manufacturer.ToString(),
                    TypeOfDevice = item.TypeOfDevice.ToString(),
                    Status = item.Status.ToString(),                    
                    OriginStamp = item.OriginStamp
                }).ToList();
            }
        }

        #endregion
















    }
}
