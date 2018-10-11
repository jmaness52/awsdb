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

namespace SCR_Repair_Tracker
{
    public partial class PartDetailsForm : Form
    {
        #region Fields and Properties

        private CustomerRow custRow;
        private bool customerEdit; // bool to indicate if user has edit customer fields without saving
        private bool saveConfirm; // bool to indicate save event
        private bool newPart; // indicates new or edit
        private bool fromRepair; // bool to indicate form has been opened from repair form
        private bool fromCheckIn;  // if coming from check in form, saving will be handled differently
        private bool isAlreadyClosed; // indicates if the part order has already been closed out (has a closed stamp)
        private bool writeVen = false; // indicates if a new part vendor has been added, used when saving
        private string formUser; // 3 digit initials of tech (used in notes)
        private string userFull;
        private int noteCount; // # of note entries 
        private int repairId; 
        private PartOrderRow editRow; // save row for part order
        private List<NoteRow> partNotes = new List<NoteRow>(); // list of note entries for the part order
        private List<NoteRow> origNotes = new List<NoteRow>(); // a copy of repair notes loaded at form load, used for comparison to see if notes have changed        
        private List<OpenRepairRow> possibleRepairs = new List<OpenRepairRow>(); //queries the database for open repairs with the same customer ID as the part order (used for linking part to repair)
        private DataValidation formBus = new DataValidation(); // call to business class
        


        public CustomerRow CustRow
        {
            get { return custRow; }
            set { custRow = value; }
        }

        public PartOrderRow EditRow
        {
            get { return editRow; }
            set { editRow = value; }
        }

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


        public bool SaveConfirm
        {
            get { return saveConfirm; }
            set { saveConfirm = value; }
        }

        public bool NewPart
        {
            get { return newPart; }
            set { newPart = value; }
        }

        public bool FromRepair
        {
            get { return fromRepair; }
            set { fromRepair = value; }
        }

        public bool FromCheckIn
        {
            get { return fromCheckIn; }
            set { fromCheckIn = value; }
        }

        public int RepairID
        {
            get { return repairId; }
            set { repairId = value; }
        }


        public bool IsAlreadyClosed
        {
            get { return isAlreadyClosed; }
            set { isAlreadyClosed = value; }
        }

        public List<NoteRow> PartNotes
        {
            get { return partNotes; }
            set { partNotes = value; }

        }

        public List<NoteRow> OrigNotes
        {
            get { return origNotes; }
            set { origNotes = value; }
        }

        public List<OpenRepairRow> PossibleRepairs
        {
            get { return possibleRepairs; }
            set { possibleRepairs = value; }
        }

        public DataValidation FormBus
        {
            get { return formBus; }
            set { formBus = value; }
        }

        #endregion

        #region Form Loading

        public PartDetailsForm()
        {
            InitializeComponent();
            noteCount = 0; // set initial notecount
            



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
                        formBus.SqlConn.UpdateCustomer(editRow.CustomerID, txtCustEditFN.Text, txtCustEditLN.Text, txtTel1Edit.Text);
                    }
                    else
                    {
                        formBus.SqlConn.UpdateCustomer(editRow.CustomerID, txtCustEditFN.Text, txtCustEditLN.Text, txtTel1Edit.Text, txtTel2Edit.Text);
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

                if (MessageBox.Show(string.Format("Delete the following note:\n {0} ?", partNotes[dgvNotesHistory.SelectedRows[0].Index].NoteText), "Confirm Note Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //remove from list @ selected row index
                    partNotes.RemoveAt(dgvNotesHistory.SelectedRows[0].Index);
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


                partNotes.Insert(0, new NoteRow
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
            dgvNotesHistory.DataSource = partNotes;
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

        #region Saving and Closing

        private bool PreSaveCheck() //checks for any invalid user input and returns false if a problem occurs
        {

            if (customerEdit)
            {
                MessageBox.Show("Please save customer information before saving part entry!", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CbxVendorSelect.Text))
            {
                MessageBox.Show("Please Select a Vendor!", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CbxPartStatus.Text))
            {
                MessageBox.Show("Please choose the status!", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtPartDesc.Text))
            {
                MessageBox.Show("Please Enter a Description for the Part", "Error");
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

            if (noteCount < 1)
            {

                MessageBox.Show("Please Enter at least one note!", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtPriceBefore.Text))
            {
                TxtPriceBefore.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(TxtPriceAfter.Text))
            {
                TxtPriceAfter.Text = "0";
            }



            if (CbxPartStatus.Text == "Closed")
            {
                if (TxtPriceBefore.Text == "0" || TxtPriceAfter.Text == "0")
                {
                    MessageBox.Show("Please enter values for Price before and price after markup", "Error");
                    return false;
                }

                if (editRow.OriginStamp == DateTime.MinValue)
                {
                    MessageBox.Show("Can't close a new part order. Please choose a different status", "Error");
                    return false;
                }
            }

            if (CbxVendorSelect.Text == "Add New" && TxtAddVendor.Text.Length < 4)
            {
                MessageBox.Show("Please check Vendor. \nIf adding a new vendor, the name must be longer.");
                return false;
            }
            else if (CbxVendorSelect.Text == "Add New" && TxtAddVendor.Text.Length > 4)
            {

                if (formBus.SqlConn.CheckVendorDuplicates(TxtAddVendor.Text) == false)
                {

                    if (MessageBox.Show(string.Format("Add Vendor to database:\n{0}", TxtAddVendor.Text), "Confirm Add Vendor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        editRow.VendorID = formBus.SqlConn.AddVendor(TxtAddVendor.Text);
                        writeVen = true;

                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Please check Vendor name, entry already exists in Database!");
                    return false;
                }
            }

            return true;
        }


      

      

        private void ClearForm()
        {
            CbxPartStatus.SelectedIndex = -1;
            CbxVendorSelect.SelectedIndex = -1;
            partNotes.Clear();
            origNotes.Clear();
            RefreshNotesDgv();
            TxtPartDesc.Clear();
            TxtPartLink.Clear();
            TxtPriceAfter.Clear();
            TxtPriceBefore.Clear();
            TxtAddVendor.Clear();
            
        }

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

            if (TxtPartDesc.Text != editRow.PartDescription || TxtPartLink.Text != editRow.PartLink)
            {
                return true;
            }

            if (Convert.ToInt32(CbxPartStatus.SelectedValue) != editRow.PStatusID || Convert.ToInt32(CbxVendorSelect.SelectedValue) != editRow.VendorID)
            {
                return true;
            }


            // check service and part costs
            if (Convert.ToDecimal(TxtPriceBefore.Text) != editRow.PriceBefore || Convert.ToDecimal(TxtPriceAfter.Text) != editRow.PriceAfterMarkup)
            {
                return true;
            }

            // sets the original notes to be ordered by descending note id so we can compare each element with repair notes
            origNotes = origNotes.OrderByDescending(t => t.NoteID).ToList();


            //if the list counts are different , dont need to check the elements
            if (origNotes.Count != partNotes.Count)
            {
                return true;
            }
            else
            {
                // check each note entry for differences
                for (int i = 0; i < partNotes.Count; i++)
                {
                    if (origNotes[i].NoteText != partNotes[i].NoteText)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void cmdSavePart_Click(object sender, EventArgs e)
        {
         
            if (PreSaveCheck())
            {
                
                
                if (writeVen == false)
                {
                    editRow.VendorID = Convert.ToInt32(CbxVendorSelect.SelectedValue);
                }

                //populate edit row
                editRow.PStatusID = Convert.ToInt32(CbxPartStatus.SelectedValue);
                editRow.PartLink = TxtPartLink.Text;
                editRow.PartDescription = TxtPartDesc.Text;
                editRow.Notes = NotesListToString();
                editRow.PriceBefore = Convert.ToDecimal(TxtPriceBefore.Text);
                editRow.PriceAfterMarkup = Convert.ToDecimal(TxtPriceAfter.Text);

                
                if (newPart)
                {

                    if (fromCheckIn)
                    {
                        ClearForm();
                        saveConfirm = true;
                        Hide();
                        return;
                    }


                    if (fromRepair)
                    {
                        
                        editRow.OrderID = formBus.InsertPartOrder(editRow);
                        ClearForm();
                        saveConfirm = true;
                        Hide();
                    }
                    else
                    {
                        editRow.OrderID = formBus.InsertPartOrder(editRow);
                        ExitForm();
                    }


                    
                }
                else
                {

                    formBus.UpdatePartOrder(editRow);

                    if (fromRepair)
                    {
                        ClearForm();
                        saveConfirm = true;
                        Hide();
                    }
                    else
                    {
                        ExitForm();
                    }                  
                }
                             
            }

        }

        private void cmdClosePart_Click(object sender, EventArgs e)
        {

            if (newPart)
            {
                if (fromRepair == false)
                {
                    ExitForm();

                }
                else
                {
                    saveConfirm = false;
                    ClearForm();
                    Hide();
                }
                
            }
            else if (!CheckForEdit() || MessageBox.Show("Exit without saving?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (fromRepair == false)
                {
                    ExitForm();
                }
                else
                {
                    saveConfirm = false;
                    ClearForm();
                    Hide();
                }               
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

        private void ExitToOpenParts()
        {
            OpenParts backToParts = new OpenParts();
            backToParts.MdiParent = this.MdiParent;
            backToParts.Dock = DockStyle.Fill;
            backToParts.Show();
            Dispose();
            GC.Collect();
        }

        private void ExitToClosedRepairs()
        {
            CompletedPartsForm closedParts = new CompletedPartsForm();
            closedParts.MdiParent = this.MdiParent;
            closedParts.Dock = DockStyle.Fill;
            closedParts.Show();
            Dispose();
            GC.Collect();
        }

        private void GoToRepair(int repairIN)
        {
            if (newPart == false && formBus.SqlConn.CheckPartLocked(editRow.OrderID))
            {
                formBus.SqlConn.UnlockPart(editRow.OrderID);
            }

            
            RepairDetailsForm repairFromPart = formBus.PrepareEditForm(repairIN);

            repairFromPart.FormUser = formUser;
            repairFromPart.UserFull = userFull;
            repairFromPart.MdiParent = this.MdiParent;
            repairFromPart.Dock = DockStyle.Fill;
            repairFromPart.Show();
            Dispose();
            GC.Collect();
        }

        private void ExitForm()
        {
            if (newPart == false && formBus.SqlConn.CheckPartLocked(editRow.OrderID))
            {
                formBus.SqlConn.UnlockPart(editRow.OrderID);
            }

            if (isAlreadyClosed)
            {
                ExitToClosedRepairs();
            }
            else if (newPart)
            {
                ExitToOpenRepairs();
            }
            else
            {
                ExitToOpenParts();
            }


        }

        #endregion

        #region Conversion Methods

        /// <summary>
        /// Converts list of notes for storage in the database
        /// </summary>
        /// <returns></returns>
        private string NotesListToString()
        {
            string notesOut = string.Empty;
            string delim = "//\\\\";

            foreach (NoteRow N in partNotes.OrderBy(t => t.NoteID))
            {
                notesOut += string.Concat(N.UserName, delim, N.NoteText, delim, N.TimeStamp, "|<>|");
            }


            return notesOut;
        }


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

        #endregion

        private void cbxVendorSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbxVendorSelect.Text == "Add New")
            {

                TxtAddVendor.Enabled = true;

            }
            else
            {
                TxtAddVendor.Clear();
                TxtAddVendor.Enabled = false;
            }
        }

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
                OrigNotes.Add(new NoteRow { NoteID = (noteCount + 1), UserName = noteTemp[0], NoteText = noteTemp[1], TimeStamp = noteTemp[2] });  // those components go to a new noterow, noterow is added to list
                Array.Clear(noteTemp, 0, noteTemp.Length); // clear the temp array in the loop
                noteCount++;

            }

            Array.Clear(tempNotes, 0, tempNotes.Length); // clear the larger array 

            OrigNotes = OrigNotes.OrderByDescending(t => t.NoteID).ToList(); // order the list of notes 
        }

        private void PartDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!newPart && formBus.SqlConn.CheckPartLocked(editRow.OrderID))
            {
                formBus.SqlConn.UnlockPart(editRow.OrderID);
            }
        }

        private void BtnEditDetails_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in PanStaticDetails.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = true;
                }
            }

            BtnEditDetails.Visible = false;
            TxtAddVendor.Enabled = false;
        }

        private void BtnLinkRepair_Click(object sender, EventArgs e)
        {
            if (possibleRepairs.Count > 1)
            {
                foreach (OpenRepairRow r in possibleRepairs)
                {
                    r.CustomerName = txtCustName.Text;
                }

                OrderSelectForm repairSelect = formBus.RepairSelect(possibleRepairs);
                repairSelect.ShowDialog();
                editRow.RepairID = repairSelect.IdOut;
                repairSelect.Dispose();
            }
            else
            {
                editRow.RepairID = possibleRepairs[0].RepairID;
            }

            MessageBox.Show("Link Successful!");
            BtnLinkRepair.Hide();
            

        }

        private void BtnGotoRepair_Click(object sender, EventArgs e)
        {
            if (!CheckForEdit() || MessageBox.Show("Press Yes to exit to repair details without saving changes.","Confirm Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GoToRepair(editRow.RepairID);
            }
            
        }

        public void LoadFromRepair(int partIn, CustomerRow custIn)
        {
            ClearForm();            
            saveConfirm = false;
            writeVen = false;
            custRow = custIn;
            newPart = false;

            txtCustName.Text = custIn.CustomerName;
            txtTel1.Text = custIn.Tel1;

            if (!string.IsNullOrWhiteSpace(custIn.Tel2))
            {
                txtTel2.Text = custIn.Tel2;
            }

            editRow = formBus.SqlConn.GetSinglePart(partIn);
            editRow.OrderID = partIn;

            CbxPartStatus.SelectedIndex = CbxPartStatus.FindString(ConstantsLibrary.PartStatusTypes.Find(t => t.PStatusID == editRow.PStatusID).ToString());


            formBus.SqlConn.PopulatePartVendors(CbxVendorSelect, editRow.VendorID);

            StringToNotesList(editRow.Notes);
            partNotes = new List<NoteRow>(origNotes);
            

            dgvNotesHistory.DataSource = partNotes; // set the source of the dgv 
            //dgvNotesHistory.Columns[0].Visible = false;

            //dgvNotesHistory.Columns[1].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
            //dgvNotesHistory.Columns[1].Width = 30;

            //dgvNotesHistory.Columns[2].DefaultCellStyle.ForeColor = System.Drawing.Color.RoyalBlue;
            //dgvNotesHistory.Columns[2].Width = 225;


            //dgvNotesHistory.Columns[3].DefaultCellStyle.ForeColor = System.Drawing.Color.OrangeRed;
            //dgvNotesHistory.Columns[3].Width = 100;
            //dgvNotesHistory.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Sans Serif", 7.5f, System.Drawing.FontStyle.Regular);

            TxtPriceBefore.Text = editRow.PriceBefore.ToString("f2");
            TxtPriceAfter.Text = editRow.PriceAfterMarkup.ToString("f2");

            TxtPartDesc.Text = editRow.PartDescription;
            TxtPartLink.Text = editRow.PartLink;
        }
    }
}


