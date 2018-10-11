using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace SCR_Repair_Tracker
{
    public class DataValidation
    {

        
        private DataAccess sqlConn = new DataAccess();


        public DataAccess SqlConn
        {
            get { return sqlConn; }
            set { sqlConn = value; }
        }

        #region Prepare Forms


        public string[] SelectFormUser()
        {
            UserSelectForm selUser = new UserSelectForm();
            selUser.ShowDialog();

            if (string.IsNullOrWhiteSpace(selUser.User))
            {
                return new string[2];
            }

            string[] user = new string[2];
            user[0] = selUser.User;
            user[1] = selUser.UserFull;

            return user;

            
        }




        /// <summary>
        /// Prepares Repair Details Form for Editing a Repair
        /// </summary>
        /// <param name="repairIn"></param>
        /// <param name="SqlIn"></param>
        /// <returns></returns>
        public RepairDetailsForm PrepareEditForm(int repairIn)
        {




            RepairDetailsForm FormOut = new RepairDetailsForm();

            FormOut.EditRow = sqlConn.FetchRepair(Convert.ToInt32(repairIn));  // gives all the details needed to load a repair into the form
            FormOut.CustRow = sqlConn.FetchCustomer(FormOut.EditRow.CustomerID);

            sqlConn.LockRecord(repairIn); //Locks the record for edit

            // prepares a new blank form so we can populate controls and set the values

            FormOut.PartOrders = sqlConn.GetPartsInRepair(FormOut.EditRow.RepairID);

            if (FormOut.PartOrders.Count != 0)
            {
                FormOut.BtnViewPart.Visible = true;
                FormOut.PartCount = FormOut.PartOrders.Count;

            }
            else
            {
                FormOut.PartCount = 0;
            }

           
            FormOut.EditStatic = false;
            FormOut.CustomerEdit = false;
            FormOut.cmdPrintOrCheckOut.Text = "Print"; //removing the checkout feature..we will still need to use the POS to check out,  this will just be a print button


            // sets a flag indicating this form is open or closed repair
            if (FormOut.EditRow.CloseStamp != DateTime.MinValue && FormOut.EditRow.StatusID == 10) //the null value converts to datetime.minvalue
            {
                FormOut.IsAlreadyClosed = true;

            }
            else
            {
                FormOut.IsAlreadyClosed = false;
            }


           
            FormOut.txtCustName.Text = FormOut.CustRow.CustomerName;  // loads the full customer name into field
            FormOut.txtTel1.Text = FormOut.CustRow.Tel1;  // loads the first contact phone # into its textbox


            if (FormOut.CustRow.Tel2 != null) // 2nd phone number is optional, only load if not null.
            {
                FormOut.txtTel2.Text = FormOut.CustRow.Tel2;
            }


            //set the Type of Device cbx based on a list in constansts library
            FormOut.cbxTypeDevice.DataSource = ConstantsLibrary.DeviceTypes;
            FormOut.cbxTypeDevice.ValueMember = "TypeID";
            FormOut.cbxTypeDevice.DisplayMember = "TypeDevice";

            //sets the selected value for device type , uses a lookup from the devicetypes list
            FormOut.cbxTypeDevice.SelectedIndex = FormOut.cbxTypeDevice.FindString(ConstantsLibrary.DeviceTypes.Find(t => t.TypeID == FormOut.EditRow.TypeID).ToString());



            //same procedure for status 
            FormOut.cbxStatus.DataSource = ConstantsLibrary.StatusTypes;
            FormOut.cbxStatus.ValueMember = "StatusID";
            FormOut.cbxStatus.DisplayMember = "StatusName";

            FormOut.cbxStatus.SelectedIndex = FormOut.cbxStatus.FindString(ConstantsLibrary.StatusTypes.Find(t => t.StatusID == FormOut.EditRow.StatusID).ToString());



            // the manufacturer cbx need to be re-queried each time the form is open
            // this method will populate these controls directly.  the 2nd input is used to select the manufactuer from the list of mfg.
            // in this case it is done in the data access class because the list needed to do a lookup is in the temporary ControlsItems variable
            sqlConn.PopulateMfgControl(FormOut.cbxMFGselect, FormOut.EditRow.MfgID);


            //sets the list of available accessories
            FormOut.LBaccEdit.DataSource = ConstantsLibrary.AccTypes;
            FormOut.LBaccEdit.DisplayMember = "AccType";
            FormOut.LBaccEdit.ValueMember = "AccID";


            // checks for accessories in the repair by quering RepairAcc table in db
            // need to toggle visiblity of listboxes (lbaccview, lbaccedit), set radio buttons
            // based on whether on not accessories exist
            FormOut.AccessoriesList = sqlConn.GetAccessoriesForRepair(FormOut.EditRow.RepairID);


            if (FormOut.AccessoriesList.Count > 0) // code to execute if the repair contains accessories
            {

                // check the radio box for accesories
                FormOut.optAccYes.Checked = true;


                // check the boxes in the edit list box

                foreach (RepairAccRow r in FormOut.AccessoriesList)
                {
                    FormOut.LBaccEdit.SetItemChecked((r.AccID - 1), true);
                }


                // adds the text of the Accesory type to the view listbox for each checked item in the edit listbox
                // the listboxes are on top of one each other, one is for editing (checkedlistbox) the other is just for viewing
                foreach (AccTypeRow ci in FormOut.LBaccEdit.CheckedItems)
                {
                    FormOut.lbaccView.Items.Add(ci.AccType);
                }

                // hides the edit list box and show the view listbox

                FormOut.LBaccEdit.Hide();
                FormOut.lbaccView.Show();
            }
            else // code to run if the repair has NO accessories
            {
                FormOut.optAccNo.Checked = true;
                FormOut.lbaccView.Hide();
                FormOut.LBaccEdit.Show();
            }

            // check for a password and set radio buttons/ textbox

            if (!string.IsNullOrWhiteSpace(FormOut.EditRow.Password))
            {
                FormOut.optPWYes.Checked = true;
                FormOut.txtPass.Text = FormOut.EditRow.Password;
            }
            else
            {
                FormOut.optPWNo.Checked = true;
                FormOut.EditRow.Password = string.Empty;
            }

            // check for part and service fees and write to textboxes.. if no costs, write 0's

            if (FormOut.EditRow.PartFee != 0)
            {
                FormOut.txtPartCost.Text = FormOut.EditRow.PartFee.ToString("f2");
                FormOut.EditRow.PartFee = Convert.ToDecimal(FormOut.txtPartCost.Text);
            }
            else
            {
                FormOut.txtPartCost.Text = "0";
            }

            if (FormOut.EditRow.ServiceFee != 0)
            {
                FormOut.txtSvcFee.Text = FormOut.EditRow.ServiceFee.ToString("f2");
                FormOut.EditRow.ServiceFee = Convert.ToDecimal(FormOut.txtSvcFee.Text);
            }
            else
            {
                FormOut.txtSvcFee.Text = "0";
            }

            if (FormOut.EditRow.TotalCost != 0)
            {
                FormOut.txtTotalCost.Text = FormOut.EditRow.TotalCost.ToString("f2");
                FormOut.EditRow.TotalCost = Convert.ToDecimal(FormOut.txtTotalCost.Text);
            }
            else
            {
                FormOut.txtTotalCost.Text = "0";
                FormOut.EditRow.TotalCost = Convert.ToDecimal(FormOut.txtTotalCost.Text);
            }


            if (FormOut.EditRow.ServiceApproved == false)
            {
                FormOut.OptSvcNo.Checked = true;
            }
            else
            {
                FormOut.OptSvcYes.Checked = true;
            }

            //Populate Notes Section

            FormOut.StringToNotesList(FormOut.EditRow.Notes);
            FormOut.RepairNotes = new List<NoteRow>(FormOut.OrigNotes);


            FormOut.dgvNotesHistory.DataSource = FormOut.RepairNotes; // set the source of the dgv 
            FormOut.dgvNotesHistory.Columns[0].Visible = false;

            FormOut.dgvNotesHistory.Columns[1].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
            FormOut.dgvNotesHistory.Columns[1].Width = 30;

            FormOut.dgvNotesHistory.Columns[2].DefaultCellStyle.ForeColor = System.Drawing.Color.RoyalBlue;
            FormOut.dgvNotesHistory.Columns[2].Width = 225;


            FormOut.dgvNotesHistory.Columns[3].DefaultCellStyle.ForeColor = System.Drawing.Color.OrangeRed;
            FormOut.dgvNotesHistory.Columns[3].Width = 100;
            FormOut.dgvNotesHistory.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Sans Serif", 7.5f, System.Drawing.FontStyle.Regular);


            foreach (Control cn in FormOut.panStaticRepairDetails.Controls)
            {
                if (cn is ComboBox || cn is CheckedListBox || cn is TextBox || cn is Panel)
                {
                    cn.Enabled = false;
                }
            }

            FormOut.cmdEditStaticDetails.Visible = true;




            return FormOut;




        }

        public PartDetailsForm EditPartNoRepair(int orderIn)
        {

            
            PartDetailsForm FormOut = new PartDetailsForm();


            FormOut.EditRow = sqlConn.GetSinglePart(orderIn);
            FormOut.CustRow = sqlConn.FetchCustomer(FormOut.EditRow.CustomerID);

            sqlConn.LockPart(orderIn);


            FormOut.NewPart = false;
            FormOut.FromRepair = false;

            if( FormOut.EditRow.CloseStamp != DateTime.MinValue && FormOut.EditRow.PStatusID == 7)
            {
                FormOut.IsAlreadyClosed = true;
            }
            else
            {
                FormOut.IsAlreadyClosed = false;
            }

            FormOut.txtCustName.Text = FormOut.CustRow.CustomerName;  // loads the full customer name into field
            FormOut.txtTel1.Text = FormOut.CustRow.Tel1;  // loads the first contact phone # into its textbox


            if (FormOut.CustRow.Tel2 != null) // 2nd phone number is optional, only load if not null.
            {
                FormOut.txtTel2.Text = FormOut.CustRow.Tel2;
            }

            FormOut.CbxPartStatus.DataSource = ConstantsLibrary.PartStatusTypes;
            FormOut.CbxPartStatus.DisplayMember = "PartStatus";
            FormOut.CbxPartStatus.ValueMember = "PStatusID";
            FormOut.CbxPartStatus.SelectedIndex = FormOut.CbxPartStatus.FindString(ConstantsLibrary.PartStatusTypes.Find(t => t.PStatusID == FormOut.EditRow.PStatusID).ToString());

            FormOut.PanRepairConnection.Visible = true;
            FormOut.BtnGotoRepair.Visible = false;
            FormOut.BtnLinkRepair.Visible = false;

            FormOut.PossibleRepairs = sqlConn.GetOpenRepairsByCust(FormOut.EditRow.CustomerID); // compares cust id on part entry to see if any open repairs belong to same customer (used for attaching part to repair)

            if (FormOut.EditRow.RepairID == 0 && FormOut.PossibleRepairs.Count > 0)
            {
                FormOut.BtnLinkRepair.Visible = true;
            }

            if (FormOut.EditRow.RepairID != 0)
            {
                FormOut.BtnGotoRepair.Visible = true;
            }

            sqlConn.PopulatePartVendors(FormOut.CbxVendorSelect, FormOut.EditRow.VendorID);

            FormOut.StringToNotesList(FormOut.EditRow.Notes);
            FormOut.PartNotes = new List<NoteRow>(FormOut.OrigNotes);

            FormOut.dgvNotesHistory.DataSource = FormOut.PartNotes; // set the source of the dgv 
            FormOut.dgvNotesHistory.Columns[0].Visible = false;

            FormOut.dgvNotesHistory.Columns[1].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
            FormOut.dgvNotesHistory.Columns[1].Width = 30;

            FormOut.dgvNotesHistory.Columns[2].DefaultCellStyle.ForeColor = System.Drawing.Color.RoyalBlue;
            FormOut.dgvNotesHistory.Columns[2].Width = 225;


            FormOut.dgvNotesHistory.Columns[3].DefaultCellStyle.ForeColor = System.Drawing.Color.OrangeRed;
            FormOut.dgvNotesHistory.Columns[3].Width = 100;
            FormOut.dgvNotesHistory.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Sans Serif", 7.5f, System.Drawing.FontStyle.Regular);

            FormOut.TxtPriceBefore.Text = FormOut.EditRow.PriceBefore.ToString("f2");
            FormOut.TxtPriceAfter.Text = FormOut.EditRow.PriceAfterMarkup.ToString("f2");

            FormOut.TxtPartDesc.Text = FormOut.EditRow.PartDescription;
            FormOut.TxtPartLink.Text = FormOut.EditRow.PartLink;

            foreach(Control ctrl in FormOut.PanStaticDetails.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = false;
                }
            }


            return FormOut;
        }

       

        /// <summary>
        /// Prepares Repair Details Form for a New Repair
        /// </summary>
        /// <param name="CustIn"></param>
        /// <param name="SqlIn"></param>
        /// <returns></returns>
        public CheckInForm PrepareCheckIn(int CustIn)
        {

            
            
            CheckInForm FormOut = new CheckInForm();

            
        
            

            // retreive customer information
            FormOut.CustRow = sqlConn.FetchCustomer(CustIn);

            FormOut.EditRow = new FullRepairRow();
            FormOut.EditRow.CustomerID = CustIn;
            FormOut.txtCustName.Text = FormOut.CustRow.CustomerName;
            FormOut.txtTel1.Text = FormOut.CustRow.Tel1;  // loads the first contact phone # into its textbox

            if (FormOut.CustRow.Tel2 != null) // 2nd phone number is optional, only load if not null.
            {
                FormOut.txtTel2.Text = FormOut.CustRow.Tel2;
            }

            FormOut.cbxTypeDevice.DataSource = ConstantsLibrary.DeviceTypes;
            FormOut.cbxTypeDevice.DisplayMember = "TypeDevice";
            FormOut.cbxTypeDevice.ValueMember = "TypeID";
            FormOut.cbxTypeDevice.SelectedIndex = -1;

            FormOut.LBaccEdit.DataSource = ConstantsLibrary.AccTypes;
            FormOut.LBaccEdit.DisplayMember = "AccType";
            FormOut.LBaccEdit.ValueMember = "AccID";

            sqlConn.PopulateMfgControl(FormOut.cbxMFGselect);
            FormOut.cbxMFGselect.SelectedIndex = -1;

            

            



            return FormOut;
        }

      

        public PartDetailsForm PartFromRepair(CustomerRow custIn, int custID, string userIn, int repairIn, bool checkIn)
        {
            PartDetailsForm FormOut = new PartDetailsForm();
            

            FormOut.EditRow = new PartOrderRow();
            FormOut.CustRow = custIn;
            FormOut.BtnEditDetails.Visible = false;
            
            FormOut.FormUser = userIn;
            FormOut.EditRow.CustomerID = custID;
            FormOut.EditRow.RepairID = repairIn;
            FormOut.NewPart = true;
            FormOut.FromRepair = true;
            FormOut.FromCheckIn = checkIn;
            FormOut.RepairID = repairIn;
            FormOut.IsAlreadyClosed = false;
            
            FormOut.FormBorderStyle = FormBorderStyle.FixedSingle;

            FormOut.txtCustName.Text = custIn.CustomerName;
            FormOut.txtTel1.Text = FormOut.CustRow.Tel1;
            
            if (!string.IsNullOrWhiteSpace(custIn.Tel2))
            {
                FormOut.txtTel2.Text = FormOut.CustRow.Tel2;
            }

            FormOut.CbxPartStatus.DataSource = ConstantsLibrary.PartStatusTypes;
            FormOut.CbxPartStatus.DisplayMember = "PartStatus";
            FormOut.CbxPartStatus.ValueMember = "PStatusID";
            FormOut.CbxPartStatus.SelectedIndex = -1;


            sqlConn.PopulatePartVendors(FormOut.CbxVendorSelect);
            FormOut.CbxVendorSelect.SelectedIndex = -1;

            return FormOut;
        }

        public PartDetailsForm NewPart(int CustIn)
        {
            
            
            PartDetailsForm FormOut = new PartDetailsForm();

                        
            // retreive customer information
            FormOut.CustRow = sqlConn.FetchCustomer(CustIn);

            FormOut.EditRow = new PartOrderRow();
            FormOut.EditRow.CustomerID = CustIn;
            FormOut.NewPart = true;
            FormOut.FromRepair = false;
            FormOut.IsAlreadyClosed = false;
            FormOut.txtCustName.Text = FormOut.CustRow.CustomerName;
            FormOut.txtTel1.Text = FormOut.CustRow.Tel1;  // loads the first contact phone # into its textbox

            if (FormOut.CustRow.Tel2 != null) // 2nd phone number is optional, only load if not null.
            {
                FormOut.txtTel2.Text = FormOut.CustRow.Tel2;
            }

            FormOut.BtnEditDetails.Visible = false;
           
            FormOut.PanRepairConnection.Visible = true;
            FormOut.BtnGotoRepair.Visible = false;
            FormOut.BtnLinkRepair.Visible = false;

            FormOut.PossibleRepairs = sqlConn.GetOpenRepairsByCust(FormOut.EditRow.CustomerID);

            if (FormOut.PossibleRepairs.Count > 0)
            {
                FormOut.BtnLinkRepair.Visible = true;
            }

            FormOut.CbxPartStatus.DataSource = ConstantsLibrary.PartStatusTypes;
            FormOut.CbxPartStatus.DisplayMember = "PartStatus";
            FormOut.CbxPartStatus.ValueMember = "PStatusID";
            FormOut.CbxPartStatus.SelectedIndex = -1;


            sqlConn.PopulatePartVendors(FormOut.CbxVendorSelect);
            FormOut.CbxVendorSelect.SelectedIndex = -1;

            return FormOut;
        }


        public OrderSelectForm PartSelect(List<PartOrderRow> partsIn, string custIn)
        {
            OrderSelectForm FormOut = new OrderSelectForm();
            

            FormOut.Text = "Select Part Order";
            FormOut.LblInstruct.Text = "Double click to select a part for view/edit.";
            FormOut.FormType = "Part";

            DataTable dtOut = new DataTable();
            string venName;

            dtOut.Columns.Add("OrderID");
            dtOut.Columns.Add("Customer Name");
            dtOut.Columns.Add("Vendor");
            dtOut.Columns.Add("Part Description");

            foreach (PartOrderRow part in partsIn)
            {

                venName = sqlConn.GetVendor(part.VendorID);
                dtOut.Rows.Add(part.OrderID,custIn,venName,part.PartDescription);
            }

            FormOut.dgvOrderSelect.DataSource = dtOut;

            FormOut.dgvOrderSelect.Columns[0].Visible = false;

            int filterHeight = FormOut.dgvOrderSelect.ColumnHeadersHeight + FormOut.dgvOrderSelect.Rows.Cast<DataGridViewRow>().Sum(r => r.Height); ;

            if (filterHeight <= FormOut.dgvOrderSelect.MaximumSize.Height)
            {
                FormOut.dgvOrderSelect.ScrollBars = ScrollBars.None;
                FormOut.dgvOrderSelect.Height = filterHeight;
            }
            else
            {
                FormOut.dgvOrderSelect.Height = FormOut.dgvOrderSelect.MaximumSize.Height;
                FormOut.dgvOrderSelect.ScrollBars = ScrollBars.Vertical;
            }

            return FormOut;
        }

        public OrderSelectForm RepairSelect(List<OpenRepairRow> repairsIn)
        {
            OrderSelectForm FormOut = new OrderSelectForm();

            FormOut.Text = "Select A Repair";
            FormOut.LblInstruct.Text = "Double click an open repair to attach the part order.";
            FormOut.FormType = "Repair";
            FormOut.dgvOrderSelect.DataSource = repairsIn;

            FormOut.dgvOrderSelect.Columns[0].Visible = false;
            FormOut.dgvOrderSelect.Columns[1].Visible = false;
            FormOut.dgvOrderSelect.Columns[2].Visible = false;
            FormOut.dgvOrderSelect.Columns[3].Visible = false;

            FormOut.dgvOrderSelect.Columns[4].HeaderText = "Customer";  // sets th headers of the dgv columns where necessary to deviate from the sql names
            FormOut.dgvOrderSelect.Columns[6].HeaderText = "Type";
            FormOut.dgvOrderSelect.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy";
            FormOut.dgvOrderSelect.Columns[8].HeaderText = "Date Created";

            int filterHeight = FormOut.dgvOrderSelect.ColumnHeadersHeight + FormOut.dgvOrderSelect.Rows.Cast<DataGridViewRow>().Sum(r => r.Height); ;

            if (filterHeight <= FormOut.dgvOrderSelect.MaximumSize.Height)
            {
                FormOut.dgvOrderSelect.ScrollBars = ScrollBars.None;
                FormOut.dgvOrderSelect.Height = filterHeight;
            }
            else
            {
                FormOut.dgvOrderSelect.Height = FormOut.dgvOrderSelect.MaximumSize.Height;
                FormOut.dgvOrderSelect.ScrollBars = ScrollBars.Vertical;
            }


            return FormOut;
        }
        #endregion

        #region Saving Records

        public void SaveRepair(FullRepairRow dataIn)
        {
            

            if (dataIn.CloseStamp == DateTime.MinValue && dataIn.StatusID == 10)
            {
                sqlConn.CloseRepair(dataIn);
            }
            else
            {
                sqlConn.UpdateRepair(dataIn);
            }
        }

        public void UpdatePartOrder(PartOrderRow editRowIn)
        {
            

            if (editRowIn.CloseStamp == DateTime.MinValue && editRowIn.PStatusID ==7)
            {
                
                if (editRowIn.RepairID == 0)
                {
                    sqlConn.ClosePartOrderNoRepair(editRowIn);
                }
                else
                {
                    sqlConn.ClosePartOrderWithRepair(editRowIn);
                }

            }
            else
            {

                if (editRowIn.RepairID == 0)
                {
                    sqlConn.UpdatePartOrderNoRepair(editRowIn);
                }
                else
                {
                    sqlConn.UpdatePartOrderWithRepair(editRowIn);
                }

                
            }

        }

        public int InsertPartOrder(PartOrderRow editRow)
        {
            
            int idOut;

            if (editRow.RepairID == 0)
            {
                idOut = sqlConn.InsertPartOrder_NoRepair(editRow.CustomerID, editRow.PStatusID, editRow.VendorID, editRow.PartDescription, editRow.PartLink, editRow.Notes, editRow.PriceBefore, editRow.PriceAfterMarkup);
            }
            else
            {
                idOut = sqlConn.InsertPartOrder_WithRepair(editRow.CustomerID, editRow.RepairID, editRow.PStatusID, editRow.VendorID, editRow.PartDescription, editRow.PartLink, editRow.Notes, editRow.PriceBefore, editRow.PriceAfterMarkup);
            }

            return idOut;
        }

        public void SaveRepairAcc(List<RepairAccRow> accIN)
        {
            

            foreach (RepairAccRow acc in accIN)
            {
                sqlConn.InsertRepairAcc(acc.RepairID, acc.AccID);
            }
            
        }

        

        public int CreateCustomer(string FnIN, string LnIN, string TelIN)
        {
            
            return sqlConn.InsertCustomer(FnIN, LnIN, TelIN);
        }

        public int CreateCustomer(string FnIN, string LnIN, string TelIN, string Tel2IN)
        {
            
            return sqlConn.InsertCustomer(FnIN, LnIN, TelIN, Tel2IN);
        }

        #endregion

        public DataTable CustSearch(string searchIN)
        {
            List<CustomerRow> searchResult = sqlConn.SearchCustomers(searchIN);
            DataTable dtOut = new DataTable();
            dtOut.Columns.Add("CustomerID");
            dtOut.Columns.Add("Customer Name");
            dtOut.Columns.Add("Telephone Number");
            dtOut.Columns.Add("Alt Telephone");

            foreach (CustomerRow result in searchResult)
            {
                dtOut.Rows.Add(result.CustomerID,result.CustomerName, result.Tel1, result.Tel2);
            }

            
            return dtOut;


        }

        
    }
}
