using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCR_Repair_Tracker
{
    public partial class RepairDetailsForm : Form
    {
        #region Fields and Properties

        private string formUser; // user of the form, used for note entry, uses the initals of the name
        private string userFull;
        private int noteCount; // a counter for the # of note entries
        private IdleTimeChecker idleTime = new IdleTimeChecker();
        private bool isAlreadyClosed;  // bool to set whether the repair is already closed
        private bool customerEdit; // bool to indicate if user has edit customer fields without saving
        private bool editStatic;  //bool to see if static details button has been pressed
        private bool writeMFG; // bool to see if we have written a new mfg to db before saving
        private FullRepairRow editRow;  // contains all the repair info, matches the repair table from sql
        private CustomerRow custRow; // contains all the customer information
        private List<NoteRow> origNotes= new List<NoteRow>(); // a copy of repair notes loaded at form load, used for comparison to see if notes have changed
        private List<NoteRow> repairNotes; // holds the list of notes.. each note  is a note row object
        private List<RepairAccRow> accessoriesList;
        private List<PartOrderRow> partOrders;
        private int partCount;       
        private PartDetailsForm partInRepair;
        private RepairDetailsPrint printForm;

        public delegate void PrintDelegate(); // used to invoke custom print method


        public string FormUser
        {
            get { return formUser; }
            set { formUser = value; }
        }

        public string UserFull
        {
            get { return userFull; }
            set { userFull = value; }
        }
        
        
        public bool IsAlreadyClosed
        {
            get { return isAlreadyClosed; }
            set { isAlreadyClosed = value; }
        }

        public bool EditStatic
        {
            get { return editStatic; }
            set { editStatic = value; }
        }

        public bool CustomerEdit
        {
            get { return customerEdit; }
            set { customerEdit = value; }
        }

        public FullRepairRow EditRow
        {
            get { return editRow; }
            set { editRow = value; }
        }

        public CustomerRow CustRow
        {
            get { return custRow; }
            set { custRow = value; }
        }

        public List<NoteRow> RepairNotes
        {
            get { return repairNotes; }
            set { repairNotes = value; }
        }

        public List<NoteRow> OrigNotes
        {
            get { return origNotes; }
            set { origNotes = value; }
        }

        public List<RepairAccRow> AccessoriesList
        {
            get { return accessoriesList; }
            set { accessoriesList = value; }
        }

        public List<PartOrderRow> PartOrders
        {
            get { return partOrders; }
            set { partOrders = value; }
        }

        public int PartCount
        {
            get { return partCount; }
            set { partCount = value; }
        }

        #endregion

        #region Form Loading 
        public RepairDetailsForm()
        {
            InitializeComponent();                     
            writeMFG = false;
            
        }

        private void RepairDetailsForm_Load(object sender, EventArgs e)
        {
            partInRepair = ((MainForm)MdiParent).SqlHelper.PartFromRepair(custRow, editRow.CustomerID, formUser, editRow.RepairID, false); // call bus class to prepare part form
            partInRepair.FormBus = ((MainForm)MdiParent).SqlHelper;
            partInRepair.FormUser = formUser;
        }
        #endregion

        #region Form Closing Events
        
        /// <summary>
        /// exit button (without saving)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {


            if (!CheckForEdit())  //checks for any user changes after form was loaded
            {

                ExitForm();
            }
            else
            {
                
                if (MessageBox.Show("Exit Without Saving?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExitForm();
                }

                
            }
        }
        
        /// <summary>
        /// Checkout/Print Button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrintCheckout_Click(object sender, EventArgs e)
        {
            DialogResult pass = MessageBox.Show("Print Password?", "", MessageBoxButtons.YesNo);


            DataSet1 printDS = new DataSet1();



            DataSet1.StaticInfoRow infoRow = (DataSet1.StaticInfoRow)printDS.Tables["StaticInfo"].NewRow();


            infoRow["StoreAddress"] = ConstantsLibrary.StoreAddress;
            infoRow["StoreAddress2"] = string.Concat(ConstantsLibrary.StoreCity, ", ", ConstantsLibrary.StoreState, " ", ConstantsLibrary.StoreZip);
            infoRow["StorePhone"] = ConstantsLibrary.StorePhone;
            infoRow["CustName"] = custRow.CustomerName;
            infoRow["CustTel1"] = Regex.Replace(custRow.Tel1, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

            if (!string.IsNullOrWhiteSpace(custRow.Tel2))
            {
                infoRow["CustTel2"] = Regex.Replace(custRow.Tel2, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            }
            else
            {
                infoRow["CustTel2"] = "none";
            }

            infoRow["EmployeeName"] = userFull;

            printDS.Tables["StaticInfo"].Rows.Add(infoRow);

            DataSet1.RepairInfoRow repairRow = (DataSet1.RepairInfoRow)printDS.Tables["RepairInfo"].NewRow();

            string accToPrint = string.Empty;

            if (LBaccEdit.CheckedItems.Count > 0)
            {
                CheckedItemsToList();

                foreach (AccTypeRow ci in LBaccEdit.CheckedItems)
                {
                    accToPrint += string.Concat(ci.AccType, ", ");
                }

                accToPrint = accToPrint.Remove((accToPrint.Length - 2), 2);

                foreach (int ind in LBaccEdit.CheckedIndices)
                {
                    LBaccEdit.SetItemCheckState(ind, CheckState.Unchecked);

                }


            }
            else
            {
                accToPrint = "None";
            }

            repairRow["DeviceType"] = cbxTypeDevice.Text;
            repairRow["Manufacturer"] = cbxMFGselect.Text;
            repairRow["Accessories"] = accToPrint;
            repairRow["SvcApproved"] = editRow.ServiceFee > 0 ? EditRow.ServiceFee.ToString("f2") : "0.00";
            repairRow["Password"] = pass == DialogResult.Yes ? txtPass.Text : "";
            repairRow["Notes"] = "";
            repairRow["PartCost"] = editRow.PartFee > 0 ? editRow.PartFee.ToString("f2") : "0.00";

            printDS.Tables["RepairInfo"].Rows.Add(repairRow);

            DataSet1.RepairNotesRow notesRow = (DataSet1.RepairNotesRow)printDS.Tables["RepairNotes"].NewRow();

            foreach (NoteRow nR in repairNotes)
            {
                notesRow["rNotes"] = nR.NoteText; 
                printDS.Tables["RepairNotes"].Rows.Add(notesRow);
                notesRow = (DataSet1.RepairNotesRow)printDS.Tables["RepairNotes"].NewRow();

            }


            printForm = new RepairDetailsPrint(printDS);
            PrintDelegate mymethod = new PrintDelegate(CustomPrintMethod);
            printForm.CustomPrintMethod = mymethod;
            printForm.ShowDialog();
        }

        /// <summary>
        /// Save button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (PreSaveCheck())
            {
                SaveRepair();
                ExitForm();
            }
            
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            var currentIdle = idleTime.GetInactiveTime();

            if (currentIdle.Value.Minutes > 10)
            {
                if (txtNoteAdd.Text.Length > 4)
                {
                    AddNote();
                }

                if (optPWYes.Checked && string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    optPWNo.Checked = true;
                }

                if (optAccYes.Checked && LBaccEdit.CheckedItems.Count == 0)
                {
                    optAccNo.Checked = true;
                }

                if (cbxMFGselect.Text != "Add New")
                {
                    SaveRepair();
                }
                
                ExitForm();

            }
        }

        private void ExitToOpenRepairs()
        {
            OpenRepairs BackToLog = new OpenRepairs();
            BackToLog.MdiParent = this.MdiParent;
            BackToLog.Dock = DockStyle.Fill;
            BackToLog.Show();
            Dispose();
            GC.Collect();
        }

        private void ExitToClosedRepairs()
        {
            CompletedRepairsForm compRepairs = new CompletedRepairsForm();
            compRepairs.MdiParent = this.MdiParent;
            compRepairs.Dock = DockStyle.Fill;
            compRepairs.Show();
            Dispose();
            GC.Collect();
        }

        private void ExitForm()
        {
            if (((MainForm)MdiParent).SqlHelper.SqlConn.CheckLocked(editRow.RepairID))
            {
                ((MainForm)MdiParent).SqlHelper.SqlConn.UnlockRecord(editRow.RepairID);
            }

            if (partInRepair != null)
            {
                partInRepair.Dispose();
            }

            if (isAlreadyClosed)
            {
                ExitToClosedRepairs();
            }
            else
            {
                ExitToOpenRepairs();
            }
        }

        private void RepairDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (((MainForm)MdiParent).SqlHelper.SqlConn.CheckLocked(editRow.RepairID))
            {
                ((MainForm)MdiParent).SqlHelper.SqlConn.UnlockRecord(editRow.RepairID);
            }

            if (partInRepair != null)
            {
                partInRepair.Dispose();
            }
        }

        #endregion


        #region Note Adding and Clearing

        /// <summary>
        /// Add Note Button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddNote_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        /// <summary>
        /// Another way to add note by pressing enter after typing a note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNoteAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // handles note add keypress, if the key is enter, it adds a note and supresses the keypress so no line return
            {
                e.Handled = true;
                AddNote();

            }
        }


        /// <summary>
        /// Clear Note button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClearNote_Click(object sender, EventArgs e)
        {
            ClearNote();
            
        }

        private void dgvNotesHistory_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClearNote();
        }

        private void ClearNote()
        {
            //make sure a row is selected
            if (dgvNotesHistory.SelectedRows.Count > 0)
            {

                if ( MessageBox.Show(string.Format("Delete the following note:\n {0} ?",repairNotes[dgvNotesHistory.SelectedRows[0].Index].NoteText),"Confirm Note Deletion",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    //remove from list @ selected row index
                    repairNotes.RemoveAt(dgvNotesHistory.SelectedRows[0].Index);
                    RefreshNotesDgv(); // refresh dgv
                    txtNoteAdd.Focus();
                }
                
            }
            else
            {
                MessageBox.Show("No notes to clear!");
            }
        }


        
        /// <summary>
        /// adds a note to the list and dgv, calls method to refresh dgv
        /// </summary>
        private void AddNote()
        {
            if (txtNoteAdd.Text.Length > 5)
            {

                noteCount++;


                repairNotes.Insert(0, new NoteRow
                {
                    NoteID = (noteCount),
                    NoteText = txtNoteAdd.Text,
                    UserName = formUser,
                    TimeStamp = String.Concat("   [", DateTime.Now.ToString("MM/dd hh:mm tt"), "]")
                });

                RefreshNotesDgv();



                txtNoteAdd.Clear();
                txtNoteAdd.Focus();



            }
            else
            {
                MessageBox.Show("Please enter a longer note!");
                txtNoteAdd.Focus();
            }
        }


        
        /// <summary>
        ///  resets the dgv source and repplies inital formatting
        /// </summary>
        private void RefreshNotesDgv()
        {
            dgvNotesHistory.DataSource = null;
            dgvNotesHistory.Rows.Clear();
            dgvNotesHistory.DataSource = repairNotes;
            dgvNotesHistory.Refresh();

            dgvNotesHistory.Columns[0].Visible = false;

            dgvNotesHistory.Columns[1].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
            dgvNotesHistory.Columns[1].Width = 30;

            dgvNotesHistory.Columns[2].DefaultCellStyle.ForeColor = System.Drawing.Color.RoyalBlue;
            dgvNotesHistory.Columns[2].Width = 225;


            dgvNotesHistory.Columns[3].DefaultCellStyle.ForeColor = System.Drawing.Color.OrangeRed;
            dgvNotesHistory.Columns[3].Width = 100;
            dgvNotesHistory.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Sans Serif", 7.5f, System.Drawing.FontStyle.Regular);

            dgvNotesHistory.ClearSelection();

            if (dgvNotesHistory.Rows.Count != 0)
            {
                dgvNotesHistory.Rows[0].Selected = true;
            }

        }

        /// <summary>
        /// converts full names from vb.net generated notes and converts to Initials
        /// </summary>
        /// <param name="nameIN"></param>
        /// <returns></returns>
        private string CheckUserName(string nameIN)
        {
            return string.Concat(nameIN.Where(c => c >= 'A' && c <= 'Z')); // goes thru a string and returns a concat of the uppercase letters
            // i.e - Jeff Maness => JM
            //
        }
        #endregion

        #region Customer Editing

        /// <summary>
        /// button to initiate editing customer fields, changes panel visibility and prepares textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCustEdit_Click(object sender, EventArgs e)
        {
            panEditCust.Visible = true;
            panViewCust.Visible = false;

            string[] namesplit = txtCustName.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (namesplit[0] != null)
            {
                txtCustEditFN.Text = namesplit[0];
            }

            if (namesplit[1] != null)
            {
                txtCustEditLN.Text = namesplit[1];
            }

            txtTel1Edit.Text = txtTel1.Text;
            txtTel2Edit.Text = txtTel2.Text;
            customerEdit = false;


        }

        /// <summary>
        /// Button to save a customer edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveCustEdit_Click(object sender, EventArgs e)
        {
            if (customerEdit == true)
            {
                if (ValidateCustomerEdit())
                {
                    if (txtTel2Edit.Text == "" && txtTel2.Text == "")
                    {
                        ((MainForm)MdiParent).SqlHelper.SqlConn.UpdateCustomer(editRow.CustomerID, txtCustEditFN.Text, txtCustEditLN.Text, txtTel1Edit.Text);
                    }
                    else
                    {
                        ((MainForm)MdiParent).SqlHelper.SqlConn.UpdateCustomer(editRow.CustomerID, txtCustEditFN.Text, txtCustEditLN.Text, txtTel1Edit.Text, txtTel2Edit.Text);
                    }

                    txtCustName.Text = string.Concat(txtCustEditFN.Text, " ", txtCustEditLN.Text);
                    txtTel1.Text = txtTel1Edit.Text;
                    txtTel2.Text = txtTel2Edit.Text;

                    custRow.CustomerName = txtCustName.Text;
                    custRow.FirstName = txtCustEditFN.Text;
                    custRow.LastName = txtCustEditLN.Text;
                    custRow.Tel1 = txtTel1.Text;
                    custRow.Tel2 = txtTel2.Text;
                }
            }

            panViewCust.Visible = true;
            panEditCust.Visible = false;
            customerEdit = false;


        }


        /// <summary>
        /// text changed event for customer info fields, sets a bool to inform user has edited cust info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerInfoChanged(object sender, EventArgs e)
        {
            customerEdit = true;
        }


        /// <summary>
        /// Customer Name Fields keypress event, rejets not alphanumeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerName_Keypress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }


        /// <summary>
        /// Customer Phone fields keypress event, rejects non numeric.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerPhone_Keypress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }



        /// <summary>
        /// validates customer edit fields (fn, ln, tel1, tel2) for saving to database
        /// </summary>
        /// <returns>bool true if good, false if any fields have a problem</returns>
        private bool ValidateCustomerEdit()
        {

            if (string.IsNullOrWhiteSpace(txtCustEditFN.Text) || string.IsNullOrWhiteSpace(txtCustEditLN.Text))
            {
                MessageBox.Show("First or Last Name is Blank!", "Error");
                return false;
            }
            else if (txtCustEditFN.Text == txtCustEditLN.Text)
            {
                MessageBox.Show("First and Last Name are the Same!", "Error");
                return false;
            }

            if (txtTel1Edit.Text.Length < 10)
            {
                MessageBox.Show("Not enough digits in Telephone1", "Error");
                return false;
            }


            txtTel1Edit.TextMaskFormat = MaskFormat.IncludeLiterals;
            string editConfirm = string.Format("Please confirm all entries are correct: \nFirst Name: {0}\nLast Name: {1}\nTelephone1: {2}", txtCustEditFN.Text, txtCustEditLN.Text, txtTel1Edit.Text);

            if (txtTel2Edit.Text != "")
            {
                if (txtTel2Edit.Text.Length < 10)
                {
                    MessageBox.Show("Not enough digits in Telephone2", "Error");
                    return false;
                }

                txtTel2Edit.TextMaskFormat = MaskFormat.IncludeLiterals;
                editConfirm = string.Concat(editConfirm, string.Format("\nTelephone2: {0}", txtTel2Edit.Text));
            }

            if (txtTel2.Text != "" && txtTel2Edit.Text == "")
            {
                editConfirm = string.Concat(editConfirm, "\nTelephone2: REMOVED");
            }


            txtTel1Edit.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtTel2Edit.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;



            if (MessageBox.Show(editConfirm, "Confirm Customer Edit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region Cost Textboxes


        /// <summary>
        /// keypress event for cost textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cost_Keypress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9\b\.]");  // 0-9, backspace, . are the only allow inputs

            // in this case the regex will match anything outside of the correct input and handle the event which will suppress
            // the incorrect keypress

            if (regex.IsMatch(e.KeyChar.ToString()))
            {

                e.Handled = true;
            }

            // make it so user can only enter one decimal 

            TextBox cost = (TextBox)sender;

            if (cost.Text.Contains(".") && e.KeyChar == '.')
            {
                e.Handled = true;
            }


            //doesnt let you add another decimal place after the 2nd.
            if (cost.Text.Contains(".") && cost.Text.Length > (cost.Text.IndexOf(".") + 2) && e.KeyChar != (char)Keys.Back)
            {
                if (!regex.IsMatch(e.KeyChar.ToString()))
                {
                    cost.Clear();
                }

                e.Handled = true;
            }

            if (!cost.Text.Contains(".") && cost.Text.Length > 3)
            {
                if (e.KeyChar != '.')
                {
                    if (!regex.IsMatch(e.KeyChar.ToString()))
                    {
                        cost.Clear();
                    }

                    e.Handled = true;
                }


            }
        }


        /// <summary>
        /// method to add part and service fee to total when text is changed n costi fields or check state is changed on tax 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal tempService = decimal.Parse(txtSvcFee.Text);
                decimal tempPart = decimal.Parse(txtPartCost.Text);
                decimal tempTax = 0m;

                if (chkTax.Checked)
                {
                    tempTax = tempPart * ConstantsLibrary.LocalTax;

                }

                txtTotalCost.Text = (tempService + tempPart + tempTax).ToString("f2");


            }
            catch (Exception)
            {
                txtTotalCost.Text = "";

            }
        }
        #endregion

        #region Static Repair Details
        // handles radio buttons for pw, acc,
        // edit static details button

        /// <summary>
        /// button event for edit static details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEditStaticDetails_Click(object sender, EventArgs e)
        {
            panAccRadio.Enabled = true;
            panPWradio.Enabled = true;
            cbxMFGselect.Enabled = true;
            cbxTypeDevice.Enabled = true;
            

            if (LBaccEdit.CheckedItems.Count > 0)
            {
                LBaccEdit.Enabled = true;
            }

            if (txtPass.Text != string.Empty)
            {
                txtPass.Enabled = true;
            }

            if (lbaccView.Visible)
            {
                lbaccView.Visible = false;
                LBaccEdit.Visible = true;
            }

            cmdEditStaticDetails.Visible = false;
            editStatic = true;

        }

        /// <summary>
        /// check changed events for pw radio boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptPwCheckChanged(object sender, EventArgs e)
        {
            RadioButton opt = (RadioButton)sender;

            if (optPWYes.Checked)
            {
                txtPass.Enabled = true;
            }
            else
            {

                if (txtPass.Text != string.Empty && opt.Name == "optPWYes")
                {
                    if (MessageBox.Show("Clear Password?", "Confirm Clear!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtPass.Clear();
                        
                    }
                    else
                    {
                        optPWYes.Checked = true;

                    }

                }

                txtPass.Enabled = false;
            }
        }

        /// <summary>
        ///  checked changed event for accesory radioboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptAccCheckChanged(object sender, EventArgs e)
        {
            RadioButton Opt = (RadioButton)sender;

            if (optAccYes.Checked)
            {
                LBaccEdit.Enabled = true;
            }
            else
            {
                if (LBaccEdit.CheckedItems.Count > 0 && Opt.Name == "optAccYes")
                {

                    if (MessageBox.Show("Clear Accessories From Repair?", "Confirm Clear!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (int ind in LBaccEdit.CheckedIndices)
                        {
                            LBaccEdit.SetItemCheckState(ind, CheckState.Unchecked);
                        }

                    }
                    else
                    {
                        optAccYes.Checked = true;
                    }

                }
                LBaccEdit.Enabled = false;
            }
        }


        /// <summary>
        /// selection change event for mfg combobox, enables the textbox to the right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMFGselect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxMFGselect.Text == "Add New")
            {

                txtAddMfg.Enabled = true;

            }
            else
            {
                txtAddMfg.Clear();
                txtAddMfg.Enabled = false;
            }
        }

        #endregion

        #region Saving and Validation

        /// <summary>
        /// method to check for any user edits that have occured since form load
        /// </summary>
        /// <returns></returns>
        private bool CheckForEdit()
        {
           
            
            // if there is note in the box but not added it will return true
            if (txtNoteAdd.Text.Length > 0)
            {
                return true;
            }
            
            // if the cust info has been changed, will return true
            if (customerEdit)
            {
                return true;
            }

            //checks status mfg, type to see if any changes
            if (Convert.ToInt16(cbxStatus.SelectedValue)!= editRow.StatusID || Convert.ToInt16(cbxMFGselect.SelectedValue) != editRow.MfgID || Convert.ToInt16(cbxTypeDevice.SelectedValue) != editRow.TypeID)
            {
                return true;
            }


            // check pw
            if (txtPass.Text != editRow.Password)
            {
                return true;
            }


            // check service and part costs
            if (Convert.ToDecimal(txtPartCost.Text) != editRow.PartFee || Convert.ToDecimal(txtSvcFee.Text) != editRow.ServiceFee)
            {
                return true;
            }
            
            // sets the original notes to be ordered by descending note id so we can compare each element with repair notes
            origNotes = origNotes.OrderByDescending(t => t.NoteID).ToList();


            //if the list counts are different , dont need to check the elements
            if (origNotes.Count != repairNotes.Count)
            {
                return true;
            }
            else
            {
                // check each note entry for differences
                for (int i=0; i < repairNotes.Count; i++)
                {
                    if ( origNotes[i].NoteText != repairNotes[i].NoteText)
                    {
                        return true;
                    }
                }
            }

            if (LBaccEdit.CheckedItems.Count > 0)
            {
                if (CheckForAccEdit())
                {
                    return true;
                }
            }
           
                 
            //if all the checks pass it will return false (to say the form has Not been edited)
            return false;
        }

        /// <summary>
        /// validates form entries before saving to datase, this method calls saverepair if validation passes
        /// </summary>
        private bool PreSaveCheck()
        {

            if (customerEdit)
            {
                MessageBox.Show("Please Save Customer Edit Before Saving Repair!", "Error");
                return false;
            }

            

            if (txtPass.Text != "" && optPWNo.Checked == true)
            {
                MessageBox.Show("Password is not selected but password exists. Please change selection or remove password!", "Error");
                return false;
            }

            if (txtPass.Text == "" && optPWYes.Checked)
            {
                MessageBox.Show("Password is blank but yes is selected. Please select No or enter a password!", "Error");
                return false;
            }

            if (LBaccEdit.CheckedItems.Count > 0 && optAccNo.Checked == true)
            {
                MessageBox.Show("Accesories are not selected but entries exists on the list. Please change selection or remove accesory entries", "Error");
                return false;
            }

            if (repairNotes.Count < 1)
            {
                MessageBox.Show("Please enter at least one note before saving!", "Error");
                return false;
            }


            if (txtNoteAdd.Text.Length > 4)
            {

                DialogResult saveNote = MessageBox.Show(String.Format("Add Note: \n{0}\nbefore saving?", txtNoteAdd.Text), "Add Note?", MessageBoxButtons.YesNoCancel);
                if (saveNote == DialogResult.Yes)
                {
                    // if they hit yes, add a note before saving
                    AddNote();
                }
                else if (saveNote == DialogResult.Cancel)
                {
                    // if they hit cancel, it cancels the save
                    return false;
                }

                //no saves without adding a note
            }


            if (cbxMFGselect.Text == "Add New" && txtAddMfg.Text.Length < 4)
            {
                MessageBox.Show("Please check Mfg. \nIf adding a new mfg. the name must be longer.");
                return false;
            }
            else if (cbxMFGselect.Text == "Add New" && txtAddMfg.Text.Length > 4)
            {

                if (((MainForm)MdiParent).SqlHelper.SqlConn.CheckMfgDuplicates(txtAddMfg.Text) == false)
                {

                    if (MessageBox.Show(string.Format("Add Manufacturer to database:\n{0}", txtAddMfg.Text), "Confirm Add Mfg.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        editRow.MfgID = ((MainForm)MdiParent).SqlHelper.SqlConn.AddMfg(txtAddMfg.Text);
                        writeMFG = true;

                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Please check Mfg. name, entry already exists in Database!");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtSvcFee.Text))
            {
                txtSvcFee.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtPartCost.Text))
            {
                txtPartCost.Text = "0";
            }

            if (cbxStatus.Text == "Closed" && editRow.CloseStamp == DateTime.MinValue)
            {
                if (MessageBox.Show(string.Format("Close the Repair with the following costs?\nService Fee: {0}\nPart Cost: {1}", txtSvcFee.Text, txtPartCost.Text), "Confirm Close", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
            
        }

        /// <summary>
        /// this method is called from the pre save check if the method passes
        /// </summary>
        private void SaveRepair()
        {

            editRow.TypeID = Convert.ToInt16(cbxTypeDevice.SelectedValue);

            if (writeMFG == false)
            {
                editRow.MfgID = Convert.ToInt16(cbxMFGselect.SelectedValue);
            }

            if (optPWYes.Checked)
            {
                editRow.Password = txtPass.Text;
            }
            else
            {
                editRow.Password = string.Empty;
            }

            if( OptSvcYes.Checked)
            {
                editRow.ServiceApproved = true;
            }
            else
            {
                editRow.ServiceApproved = false;
            }

            editRow.StatusID = Convert.ToInt16(cbxStatus.SelectedValue);

            editRow.Notes = NotesListToString();

           
            editRow.ServiceFee = Convert.ToDecimal(txtSvcFee.Text);                                              
            editRow.PartFee = Convert.ToDecimal(txtPartCost.Text);
                      


            // calls business class to save repair to databse

            if (CheckForAccEdit() && accessoriesList.Count > 0)  // case where we need to write accessories
            {
                ((MainForm)MdiParent).SqlHelper.SqlConn.DeleteAccRepair(EditRow.RepairID);
                ((MainForm)MdiParent).SqlHelper.SaveRepairAcc(CheckedItemsToList());
                ((MainForm)MdiParent).SqlHelper.SaveRepair(editRow);


            }
            else if (CheckForAccEdit()) // case where acceesories are removed, delete acc and save repair
            {
                ((MainForm)MdiParent).SqlHelper.SqlConn.DeleteAccRepair(EditRow.RepairID);
                ((MainForm)MdiParent).SqlHelper.SaveRepair(editRow);
            }
            else // no acc case, save only
            {
                ((MainForm)MdiParent).SqlHelper.SaveRepair(editRow);
            }

        }

        /// <summary>
        /// Checks for any edits to accesories list, returns true if edit has occured
        /// </summary>
        /// <returns></returns>
        private bool CheckForAccEdit()
        {
            List<RepairAccRow> checkAccessories = CheckedItemsToList();
            

            
            if (checkAccessories.Count != accessoriesList.Count)
            {
                return true;
            }
            else 
            {
                for (int i = 0; i < accessoriesList.Count; i++)
                {
                    if (checkAccessories[i].AccID != accessoriesList[i].AccID)
                    {
                        return true;
                    }
                }

                return false;
            }
           
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///  converts long db note string to a list of NoteRow
        /// </summary>
        /// <param name="LongNotesIN"></param>
        public void StringToNotesList(string LongNotesIN)
        {
            string[] tempNotes = LongNotesIN.Split(new string[] { "|<>|" }, StringSplitOptions.RemoveEmptyEntries); //splits the long database string into substrings
            string[] noteTemp; // a place to hold the components of each note entry           
            noteCount = 0;

            foreach (string note in tempNotes)
            {
                noteTemp = note.Split(new string[] { "//\\\\" }, StringSplitOptions.RemoveEmptyEntries); //split the note into smallest components                
                OrigNotes.Add(new NoteRow { NoteID = (noteCount + 1), UserName = CheckUserName(noteTemp[0]), NoteText = noteTemp[1], TimeStamp = noteTemp[2] });  // those components go to a new noterow, noterow is added to list
                Array.Clear(noteTemp, 0, noteTemp.Length); // clear the temp array in the loop
                noteCount++;

            }

            Array.Clear(tempNotes, 0, tempNotes.Length); // clear the larger array 

            OrigNotes = OrigNotes.OrderByDescending(t => t.NoteID).ToList(); // order the list of notes 
        }


        /// <summary>
        /// Converts list of notes for storage in the database
        /// </summary>
        /// <returns></returns>
        private string NotesListToString()
        {
            string notesOut = string.Empty;
            string delim = "//\\\\";

            foreach (NoteRow N in repairNotes.OrderBy(t => t.NoteID))
            {
                notesOut += string.Concat(N.UserName, delim, N.NoteText, delim, N.TimeStamp, "|<>|");
            }


            return notesOut;
        }


        /// <summary>
        /// converts the checked entries in the accesires checkedlistbox to a list of RepairAccRow
        /// </summary>
        /// <returns></returns>
        private List<RepairAccRow> CheckedItemsToList()
        {
            List<RepairAccRow> listOut = new List<RepairAccRow>();

            foreach (AccTypeRow ci in LBaccEdit.CheckedItems)
            {
                listOut.Add(new RepairAccRow { RepairID = editRow.RepairID, AccID = ci.AccID });
            }

            return listOut;
        }



        #endregion

        private void BtnViewPart_Click(object sender, EventArgs e)
        {
            if (partOrders.Count > 1)
            {
                OrderSelectForm partSelect = ((MainForm)MdiParent).SqlHelper.PartSelect(partOrders, txtCustName.Text);
                
                partSelect.ShowDialog();
                int tempID = partSelect.IdOut;
                partSelect.Dispose();

                partInRepair.LoadFromRepair(tempID, custRow);
                
                partInRepair.ShowDialog();
                




            }
            else
            {
                partInRepair.LoadFromRepair(PartOrders[0].OrderID, custRow);
                
                partInRepair.ShowDialog();
                
            }
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            AddPart();

            
        }

        private void AddPart()  // adds a part order associated with a repair
        {

            foreach (Control ctrl in partInRepair.PanStaticDetails.Controls)
            {
                if (ctrl.Enabled == false)
                {
                    ctrl.Enabled = true;
                }

            }

            partInRepair.BtnEditDetails.Visible = false;
            partInRepair.NewPart = true;
            partInRepair.EditRow = new PartOrderRow();
            partInRepair.EditRow.CustomerID = editRow.CustomerID;
            partInRepair.EditRow.RepairID = editRow.RepairID;

            partInRepair.ShowDialog(); // form is shown as dialog and then hidden when save or close is pressed


            if (partInRepair.SaveConfirm) // save confirm is true if user saves from part form
            {
                partCount++;
                            
                partOrders.Add(partInRepair.EditRow);
                

                if (BtnViewPart.Visible == false)
                {
                    BtnViewPart.Visible = true;
                }

                
            }




        }



        private void CustomPrintMethod()
        {


            


            printForm.Close();

        }
    }
}
