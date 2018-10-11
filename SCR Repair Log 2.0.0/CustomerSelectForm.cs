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
    public partial class CustomerSelectForm : Form
    {
        #region Fields and Properties

        private string outputType; //repair or part, will tell the form where to go once a customer is selected/created
        private DataTable customerSearchResults;
        

        public string OutputType
        {
            get { return outputType; }
            set { outputType = value; }
        }

        #endregion

        #region Loading Events
        public CustomerSelectForm()
        {
            InitializeComponent();
        }

        private void CustomerSelectForm_Load(object sender, EventArgs e)
        {
            LblSearchInstruction.Text = string.Format("After Searching, Double Click a Customer Name to Create a New {0}", outputType);
            cmdCreateNew.Text = string.Format("Create {0} with a New Customer", outputType);
            LblMain.Text = string.Format("New {0} Entry", outputType);

            
        }

        #endregion


        #region Textbox keypress events

        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void Search_KeyPress (object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s\b]");

            if (e.KeyChar == (char) Keys.Enter)
            {
                SearchEvent();
                e.Handled = true;
            }


            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
              
        }

        private void Telephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtTel1New_TextChanged(object sender, EventArgs e)
        {
            if (txtTel1New.Text.Length > 9)
            {
                txtTel2New.Visible = true;
                tel2.Visible = true;
            }
            else
            {
                txtTel2New.Visible = false;
                tel2.Visible = false;
            }
        }

        #endregion

        #region Customer Search
        private void RefreshCustDgv()
        {

            
            dgvCustSelect.DataSource = null;
            dgvCustSelect.Rows.Clear();
            dgvCustSelect.Columns.Clear();

            dgvCustSelect.DataSource = customerSearchResults;
            dgvCustSelect.Columns[0].Visible = false;

            int filterheight = dgvCustSelect.ColumnHeadersHeight + dgvCustSelect.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);

            if (filterheight < dgvCustSelect.MaximumSize.Height)
            {
                dgvCustSelect.ScrollBars = ScrollBars.None;
                dgvCustSelect.Height = filterheight;
                dgvCustSelect.Width = 322;
                   
            }
            else
            {
                dgvCustSelect.Height = dgvCustSelect.MaximumSize.Height;
                dgvCustSelect.ScrollBars = ScrollBars.Vertical;
                dgvCustSelect.Width = dgvCustSelect.MaximumSize.Width;
            }

            dgvCustSelect.Refresh();
            



        }

        private void cmdCustSearch_Click(object sender, EventArgs e)
        {

            SearchEvent();

        }


        private void SearchEvent()
        {
            if (txtCustSelect.Text.Length > 2)
            {
                string[] nameSplit = txtCustSelect.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string searchOut = string.Empty;

                if (nameSplit.Length > 2)
                {
                    return;
                }
                else if (nameSplit.Length == 2)
                {
                    searchOut = string.Concat("%", nameSplit[0], "%", " ", "%", nameSplit[1], "%");
                }
                else if (nameSplit.Length == 1)
                {
                    searchOut = string.Concat("%", nameSplit[0], "%");
                }

                customerSearchResults = ((MainForm)MdiParent).SqlHelper.CustSearch(searchOut); 


                RefreshCustDgv();  //refreshes the dgv and sets the height based on # of search results

                txtCustSelect.Clear(); // clears the search textbox



            }
            else
            {
                MessageBox.Show("Please enter at least 3 charachters when searching!", "Error");  // only search if 3 or more char
            }
        }

        #endregion

        #region Go To Other Forms

        private void dgvCustSelect_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && outputType == "Repair")
            {
                string[] formUser = new string[2];
                formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                if (string.IsNullOrWhiteSpace(formUser[0]))
                {
                    return;
                }

                

                CheckInForm existingCust;
                existingCust = ((MainForm)MdiParent).SqlHelper.PrepareCheckIn(Convert.ToInt32(dgvCustSelect.SelectedCells[0].Value));

                existingCust.FormUser = formUser[0];
                existingCust.UserFull = formUser[1];
                
                existingCust.MdiParent = this.MdiParent;
                existingCust.Dock = DockStyle.Fill;
                existingCust.Show();
                this.Dispose();
                GC.Collect();

            }

            if (e.RowIndex >=0 && outputType == "Part")
            {
                string[] formUser = new string[2];
                formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                if (string.IsNullOrWhiteSpace(formUser[0]))
                {
                    return;
                }

                PartDetailsForm existingCust;
                existingCust = ((MainForm)MdiParent).SqlHelper.NewPart(Convert.ToInt32(dgvCustSelect.SelectedCells[0].Value));
                existingCust.FormUser = formUser[0];
                existingCust.MdiParent = this.MdiParent;
                existingCust.Dock = DockStyle.Fill;
                existingCust.Show();
                this.Dispose();
                GC.Collect();

            }
        }

        private void cmdCreateNew_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNewFN.Text) || string.IsNullOrWhiteSpace(txtNewLN.Text) || string.IsNullOrWhiteSpace(txtTel1New.Text))
            {
                MessageBox.Show("Please check the entry. First Name, Last Name, and one Telephone number are required");
                return;
            }
            else if (txtNewFN.Text.Length < 2 || txtNewLN.Text.Length < 2)
            {
                MessageBox.Show("Please Check the entry.  First Name and Last Name must be at least two charachters");
                return;
            }
            else if (txtTel1New.Text.Length < 10)
            {
                MessageBox.Show("Please check the entry. Incorrect number of digits in Tel1");
                return;
            }
            

            if (txtTel2New.Visible)
            {

                if (!string.IsNullOrWhiteSpace(txtTel2New.Text))
                {
                    if (txtTel2New.Text.Length < 10)
                    {
                        MessageBox.Show("Please check the entry. Incorrect number of digits in Tel2");
                        return;
                    }
                }
               
            }


            
            
            //inserts the customer info to the db and returns the new customer ID so we can load the check in form

            int newID;

            if (string.IsNullOrWhiteSpace(txtTel2New.Text))
            {

                if (MessageBox.Show(string.Format("Please confirm all entries are correct\nFirst Name: {0}\nLast Name: {1}\n Telephone #: {2}", txtNewFN.Text, txtNewLN.Text, txtTel1New.Text), "Confirm Add Customer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    newID = ((MainForm)MdiParent).SqlHelper.CreateCustomer(txtNewFN.Text, txtNewLN.Text, txtTel1New.Text);
                    string[] formUser = new string[2];
                    formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                    if (string.IsNullOrWhiteSpace(formUser[0]))
                    {
                        MessageBox.Show("Customer Added but User Canceled. Please search database for existing customer if re-adding repair.");
                        return;
                    }


                    if (outputType == "Repair")
                    {

                        

                        CheckInForm newCust;
                        newCust = ((MainForm)MdiParent).SqlHelper.PrepareCheckIn(newID);

                        newCust.FormUser = formUser[0];
                        newCust.UserFull = formUser[1];
                        newCust.MdiParent = this.MdiParent;
                        newCust.Dock = DockStyle.Fill;
                        newCust.Show();
                        this.Dispose();
                        GC.Collect();

                    }
                    else
                    {

                        PartDetailsForm newCust;
                        newCust = ((MainForm)MdiParent).SqlHelper.NewPart(newID);

                        newCust.FormUser = formUser[0];
                        
                        newCust.MdiParent = this.MdiParent;
                        newCust.Dock = DockStyle.Fill;
                        newCust.Show();
                        this.Dispose();
                        GC.Collect();
                    }
                    
                }
                else
                {
                    return;
                }
                               
            }
            else
            {

                if (MessageBox.Show(string.Format("Please confirm all entries are correct\nFirst Name: {0}\nLast Name: {1}\n Telephone #: {2}\n Alt Telephone: {3}", txtNewFN.Text, txtNewLN.Text, txtTel1New.Text, txtTel2New.Text), "Confirm Add Customer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    newID = ((MainForm)MdiParent).SqlHelper.CreateCustomer(txtNewFN.Text, txtNewLN.Text, txtTel1New.Text, txtTel2New.Text);

                    string[] formUser = new string[2];
                    formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                    if (string.IsNullOrWhiteSpace(formUser[0]))
                    {
                        MessageBox.Show("Customer Added but User Canceled. Please search database for existing customer if re-adding repair.");
                        return;
                    }

                    if (outputType == "Repair")
                    {

                        CheckInForm newCust;
                        newCust = ((MainForm)MdiParent).SqlHelper.PrepareCheckIn(newID);

                        newCust.FormUser = formUser[0];
                        newCust.UserFull = formUser[1];

                        newCust.MdiParent = this.MdiParent;
                        newCust.Dock = DockStyle.Fill;
                        newCust.Show();
                        this.Dispose();
                        GC.Collect();


                    }
                    else
                    {
                        PartDetailsForm newCust;
                        newCust = ((MainForm)MdiParent).SqlHelper.NewPart(newID);

                        newCust.FormUser = formUser[0];
                        

                        newCust.MdiParent = this.MdiParent;
                        newCust.Dock = DockStyle.Fill;
                        newCust.Show();
                        this.Dispose();
                        GC.Collect();
                    }
                    
                }
                else
                {
                    return;
                }
                    
            }


            
        }

        #endregion

        
    }
}
