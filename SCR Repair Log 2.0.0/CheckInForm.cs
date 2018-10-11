using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;

namespace SCR_Repair_Tracker
{
    public partial class CheckInForm : Form
    {
        #region Fields and Properties

        private string formUser; // user of the form, used for note entry, uses the initals of the name
        private string userFull; // full tech name , used for printing on check in form
        private int noteCount; // a counter for the # of note entries
        private int repairCount; // counts # of repairs in check in
        private int partCount; // part orders counter
        private bool customerEdit; // bool to indicate if user has edit customer fields without saving
        private bool writeMFG; // bool to see if we have written a new mfg to db before saving
      

        private CustomerRow custRow; // customer information
        private FullRepairRow editRow; // current repair information 
        private List<NoteRow> repairNotes = new List<NoteRow>(); // repair notes for current repair
        private List<RepairAccRow> accessoriesList = new List<RepairAccRow>(); //accesories in current repair
        private List<FullRepairRow> repairsAdded = new List<FullRepairRow>(); // list of all repairs that have been added
        private List<PrintableRepair> repairsPrint = new List<PrintableRepair>(); // list of the repair details needed to print a check in sheet
        private List<PartOrderRow> partsAdded = new List<PartOrderRow>(); // part orders added
        private DataTable repairsDT = new DataTable(); // data table to show a dgv of repairs added
        private DataRow viewRow; // current row of DT
        
        private PartDetailsForm partInRepair;
        private CheckInPrint printForm;
        private string notePrintLong = string.Empty;

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


        public bool CustomerEdit
        {
            get { return customerEdit; }
            set { customerEdit = value; }
        }

        public CustomerRow CustRow
        {
            get { return custRow; }
            set { custRow = value; }
        }

        public FullRepairRow EditRow
        {
            get { return editRow; }
            set { editRow = value; }
        }

        public List<NoteRow> RepairNotes
        {
            get { return repairNotes; }
            set { repairNotes = value; }
        }

        public List<RepairAccRow> AccessoriesList
        {
            get { return accessoriesList; }
            set { accessoriesList = value; }
        }

        public List<FullRepairRow> RepairsAdded
        {
            get { return repairsAdded; }
            set { repairsAdded = value; }
        }
        #endregion

        #region Form Loading
        public CheckInForm()
        {
            InitializeComponent();

            
            writeMFG = false;
            repairCount = 0;
            partCount = 0;

            DataColumn Column = new DataColumn();  
            Column.DataType = System.Type.GetType("System.String");
            Column.ColumnName = "Manufacturer";
            repairsDT.Columns.Add(Column);

            Column = new DataColumn();  
            Column.DataType = System.Type.GetType("System.String");
            Column.ColumnName = "Device";
            repairsDT.Columns.Add(Column);

            Column = new DataColumn();
            Column.DataType = System.Type.GetType("System.String");
            Column.ColumnName = "Password";
            repairsDT.Columns.Add(Column);

            Column = new DataColumn();
            Column.DataType = System.Type.GetType("System.String");
            Column.ColumnName = "Accessories";
            repairsDT.Columns.Add(Column);

            Column = new DataColumn();
            Column.DataType = System.Type.GetType("System.String");
            Column.ColumnName = "Svc Approved";
            repairsDT.Columns.Add(Column);

            dgvCheckInItems.DataSource = repairsDT;

            




        }

        private void CheckInForm_Load(object sender, EventArgs e)
        {
            partInRepair = ((MainForm)MdiParent).SqlHelper.PartFromRepair(custRow, editRow.CustomerID, formUser, repairCount, true); // call bus class to prepare part form
            partInRepair.FormBus = ((MainForm)MdiParent).SqlHelper;
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

                if (MessageBox.Show(string.Format("Delete the following note:\n {0} ?", repairNotes[dgvNotesHistory.SelectedRows[0].Index].NoteText), "Confirm Note Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
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


        #endregion

        #region Repair Adding and Clearing

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            string precheck = PreAddCheck();

            if (precheck == string.Empty)
            {
                AddRepair();

                if (Convert.ToDecimal(txtPartCost.Text) > 0)
                {
                    if (MessageBox.Show("A non zero part cost was entered. Would you like to add a part order at this time?", "Add Part Order?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AddPart();
                    }
                }

                ClearForm();

                MessageBox.Show("Repair Added! Press Check in to finish or keep adding repairs using the fields"); 
            }
            else if (precheck == "user cancel")
            {

            }
            else if (precheck.Length > 11)
            {
                MessageBox.Show(precheck, "Add Error");
            }

            
        }

        private void BtnClearItem_Click(object sender, EventArgs e)
        {
            if (repairsAdded.Count > 0 && MessageBox.Show("Delete the Last Repair Added?","Confirm Delete",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                repairsAdded.RemoveAt((repairCount - 1));
                repairsDT.Rows.RemoveAt((repairCount - 1));
                repairsPrint.RemoveAt((repairCount - 1));
                repairCount--;

                if (repairCount == 0)
                {
                    BtnClearItem.Visible = false;
                    cmdSave.Enabled = false;
                }
            }
        }

        private string PreAddCheck()
        {
            if (customerEdit)
            {
                return "Please Save Customer Edit Before Saving Repair!";
                
            }

            if (txtPass.Text != "" && optPWNo.Checked == true)
            {
                return "Password is not selected but password exists. Please change selection or remove password!";
                
            }

            if (txtPass.Text == "" && optPWYes.Checked)
            {
                return "Password is blank but yes is selected. Please select No or enter a password!";
                
            }

            if (LBaccEdit.CheckedItems.Count > 0 && optAccNo.Checked == true)
            {
                return "Accesories are not selected but entries exists on the list. Please change selection or remove accesory entries";
                
            }

            if (optAccYes.Checked && LBaccEdit.CheckedItems.Count == 0)
            {
                return "No Accesories selected. Please select the accessories or choose No accessories.";
                
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
                    return "user cancel";
                }

                //no saves without adding a note
            }


            if (noteCount < 1)
            {
                return "Please enter at least one note before saving!";
                
            }



            if (OptSvcNo.Checked == false && OptSvcYes.Checked == false)
            {
                return "Please specify whether service is preapproved or specify NO to signify Call with Diagnosis.";
                
            }

            

            if (OptSvcYes.Checked && string.IsNullOrWhiteSpace(txtSvcFee.Text))
            {
                return "If Service has been approved, please enter the service cost. Otherwise change the selection to No";
                
            }

            if (string.IsNullOrWhiteSpace(txtSvcFee.Text))
            {
                txtSvcFee.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtPartCost.Text))
            {
                txtPartCost.Text = "0";
            }


            if (cbxTypeDevice.Text == "")
            {
                return "Please specify Type of Device to Check In";
                
            }

            if (cbxMFGselect.Text == "")
            {
                return "Please specify Device Manufacturer";
                
            }


            if (cbxMFGselect.Text == "Add New" && txtAddMfg.Text.Length < 4)
            {
                return "Please check Mfg. \nIf adding a new mfg. the name must be longer";
                
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
                        return "user cancel";
                    }

                }
                else
                {
                    return "Please check Mfg. name, entry already exists in Database!";
                   
                }
            }



            return string.Empty;

            
        }

        private void AddRepair()
        {

            repairCount++; 

            if ( repairCount == 1)
            {
                BtnClearItem.Visible = true;
                cmdSave.Enabled = true;
            }


            //adding repair row (for saving to the database)

            repairsAdded.Add(new FullRepairRow {
                RepairID = repairCount,
                CustomerID = editRow.CustomerID,
                StatusID = 1,
                TypeID = Convert.ToInt16(cbxTypeDevice.SelectedValue),
                MfgID = writeMFG == true ? editRow.MfgID : Convert.ToInt16(cbxMFGselect.SelectedValue),
                ServiceFee = Convert.ToDecimal(txtSvcFee.Text),
                PartFee = Convert.ToDecimal(txtPartCost.Text),
                Password = optPWYes.Checked ? txtPass.Text : "",
                Notes = NotesListToString(),
                ServiceApproved = OptSvcYes.Checked ?  true : false,
                isLocked = false
            });

            // checks for acc and adds them to a running list with a temporary repair id of (repairCount)

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
           
            // adds view row to datatable/ datagrid view
            viewRow = repairsDT.NewRow();
            viewRow["Manufacturer"] = writeMFG == true ? txtAddMfg.Text : cbxMFGselect.Text;
            viewRow["Device"] = cbxTypeDevice.Text;
            viewRow["Password"] = optPWYes.Checked ? "Yes" : "No";
            viewRow["Accessories"] = optAccYes.Checked ? "Yes" : "No";
            viewRow["Svc Approved"] = OptSvcYes.Checked ? "Yes" : "No";
            repairsDT.Rows.Add(viewRow);


            

            foreach (NoteRow nr in repairNotes)
            {
                notePrintLong += string.Concat(nr.NoteText, "   "); //adds the note text into a single string seperated by some white space
            }

            repairsPrint.Add(new PrintableRepair // repair info to print on check in sheet
            {
                DeviceType = cbxTypeDevice.Text,
                Manufacturer = viewRow["Manufacturer"].ToString(),
                Password = optPWYes.Checked ? txtPass.Text : "None",
                Accessories = accToPrint,
                SvcApproved = OptSvcYes.Checked ? repairsAdded[(repairCount-1)].ServiceFee.ToString("f2") : "No",
                Notes = notePrintLong
                
            });

            notePrintLong = string.Empty;

            
        }


        private void AddPart()  // adds a part order associated with a repair
        {

            
            partInRepair.ShowDialog(); // form is shown as dialog and then hidden when save or close is pressed


            if (partInRepair.SaveConfirm) // save confirm is true if user saves from part form
            {
                partCount++;

                partsAdded.Add(new PartOrderRow
                {
                    OrderID = partCount,
                    CustomerID = editRow.CustomerID,
                    RepairID = repairCount, // temporary repair id, needs to be change once repair is inserted
                    PStatusID = partInRepair.EditRow.PStatusID,
                    VendorID = partInRepair.EditRow.VendorID,
                    PartDescription = partInRepair.EditRow.PartDescription,
                    PartLink = partInRepair.EditRow.PartLink,
                    Notes = partInRepair.EditRow.Notes,
                    PriceBefore = partInRepair.EditRow.PriceBefore,
                    PriceAfterMarkup = partInRepair.EditRow.PriceAfterMarkup

                });
            }

            

 
        }

        private void ClearForm()
        {
            //clears everything out on the form, preparing to accept a new repair
            cbxMFGselect.SelectedIndex = -1;
            cbxTypeDevice.SelectedIndex = -1;
            txtPass.Clear();
            repairNotes.Clear();
            noteCount = 0;
            RefreshNotesDgv();
            txtSvcFee.Clear();
            txtPartCost.Clear();
            optPWNo.Checked = true;
            LBaccEdit.ClearSelected();
            optAccNo.Checked = true;
            OptSvcNo.Checked = false;
            OptSvcYes.Checked = false;
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

        #region Radio Btns and MFG

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

        #region Form Closing Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (repairsAdded.Count > 0)
            {
               if (MessageBox.Show("One or more repairs has been added. Exit without saving?", "Exit Without Save?", MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    GotoOpenRepairs();
                }
            }
            else
            {
                GotoOpenRepairs();
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string precheck = PreAddCheck();

            if (precheck == string.Empty) // if the precheck passes, add a repair to the sheet
            {
                AddRepair();
                ClearForm();

            }
            
            if (repairCount > 0)
            {
                if (MessageBox.Show("Print check in paper?" , "Confirm Print",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Prepare the information for printing
                    //set up instances of data tables and dataset

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

                    foreach (PrintableRepair pr in repairsPrint)
                    {
                        DataSet1.RepairInfoRow repairRow = (DataSet1.RepairInfoRow)printDS.Tables["RepairInfo"].NewRow();

                        repairRow["DeviceType"] = pr.DeviceType;
                        repairRow["Manufacturer"] = pr.Manufacturer;
                        repairRow["Accessories"] = pr.Accessories;
                        repairRow["SvcApproved"] = pr.SvcApproved;
                        repairRow["Password"] = pr.Password;
                        repairRow["Notes"] = pr.Notes;

                        printDS.Tables["RepairInfo"].Rows.Add(repairRow);

                    }

                    printForm = new CheckInPrint(printDS);

                    PrintDelegate mymethod = new PrintDelegate(CustomPrintMethod);
                    printForm.CustomPrintMethod = mymethod;
                    printForm.ShowDialog();

                    this.Focus();

                }
                else
                {
                    InsertRepairID();
                    InsertAccParts();
                    GotoOpenRepairs();
                }
                        
                 
            }
            else
            {
                MessageBox.Show(precheck, "Check in Error");

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
                RepairNotes.Add(new NoteRow { NoteID = (noteCount + 1), UserName = noteTemp[0], NoteText = noteTemp[1], TimeStamp = noteTemp[2] });  // those components go to a new noterow, noterow is added to list
                Array.Clear(noteTemp, 0, noteTemp.Length); // clear the temp array in the loop
                noteCount++;

            }

            Array.Clear(tempNotes, 0, tempNotes.Length); // clear the larger array 

            RepairNotes = RepairNotes.OrderByDescending(t => t.NoteID).ToList(); // order the list of notes 
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
        private void CheckedItemsToList() //creates a running list of accessories and assoicated temporary repair ID's
        {
            

            foreach (AccTypeRow ci in LBaccEdit.CheckedItems)
            {
                accessoriesList.Add(new RepairAccRow { RepairID = repairCount, AccID = ci.AccID });
            }

            
        }



        #endregion

        private void CheckInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (partInRepair != null)
            {
                partInRepair.Dispose();
            }
        }

        private void CustomPrintMethod()
        {
            

            if (MessageBox.Show("Check In sheet printed.  Please confirm entries are correct and press Yes to add repair(s) to Database","Confirm Repairs",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                InsertRepairID();
                InsertAccParts();
                GotoOpenRepairs();
            }


            printForm.Close();
            
        }


        private void InsertRepairID()
        {
            int[] newRepairId = RepairsToDatabase(); //adds the repair rows to the db, returns the repair ids generated by sql

            for (int j = 0; j < newRepairId.Length; j++)
            {
                if (partsAdded.ElementAtOrDefault(j) != null)
                {
                    partsAdded[j].RepairID = newRepairId[j]; 
                }

                for (int k = 0; k < accessoriesList.Count; k++)
                {
                    if (accessoriesList[k].RepairID == (j+1))
                    {
                        accessoriesList[k].RepairID = newRepairId[j];
                    }
                }


            }
            
            
                

            
        }


        private int[] RepairsToDatabase()
        {
            int[] newRepairId = new int[repairsAdded.Count];
            int j = 0;

            foreach (FullRepairRow rep in repairsAdded)
            {
                newRepairId[j] = ((MainForm)MdiParent).SqlHelper.SqlConn.InsertRepair(rep.CustomerID,rep.TypeID,rep.MfgID,rep.ServiceFee, rep.PartFee, rep.Password, rep.Notes, rep.ServiceApproved);
                j++;
            }

            return newRepairId;
        }

        private void InsertAccParts()
        {
            if (accessoriesList.Count > 0)
            {
                foreach (RepairAccRow acc in accessoriesList)
                {
                    ((MainForm)MdiParent).SqlHelper.SqlConn.InsertRepairAcc(acc.RepairID, acc.AccID);
                }
            }

            if (partsAdded.Count > 0)
            {
                foreach (PartOrderRow po in partsAdded)
                {
                    ((MainForm)MdiParent).SqlHelper.SqlConn.InsertPartOrder_WithRepair(po.CustomerID, po.RepairID, po.PStatusID, po.VendorID, po.PartDescription, po.PartLink, po.Notes, po.PriceBefore, po.PriceAfterMarkup);
                }
            }
        }

        private void GotoOpenRepairs()
        {
            OpenRepairs BackToLog = new OpenRepairs();
            BackToLog.MdiParent = this.MdiParent;
            BackToLog.Show();
            Dispose();
            GC.Collect();
        }

        
    }

}
