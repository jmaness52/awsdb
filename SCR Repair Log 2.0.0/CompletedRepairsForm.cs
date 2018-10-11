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
    public partial class CompletedRepairsForm : Form
    {

        private List<CompletedRepairRow> completedRepairs = new List<CompletedRepairRow>();
        private IdleTimeChecker IdleTime = new IdleTimeChecker();
        private int filterHeight;

        public CompletedRepairsForm()
        {
            InitializeComponent();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            var currentIdle = IdleTime.GetInactiveTime();

            if (currentIdle.Value.TotalMinutes > 10) // logout after 10 min
            {

                ((MainForm)MdiParent).LogOut();
                Dispose();
                GC.Collect();

            }          
        }

        private void CompletedRepairsForm_Shown(object sender, EventArgs e)
        {
            completedRepairs = ((MainForm)MdiParent).SqlHelper.SqlConn.GetCompletedRepairs();

            RefreshDGV();

            dgvClosedRepairs.Columns[2].HeaderText = "Customer Name";
            dgvClosedRepairs.Columns[3].HeaderText = "Telephone";
            dgvClosedRepairs.Columns[4].HeaderText = "Device";
            dgvClosedRepairs.Columns[5].HeaderText = "Manufacturer";
            dgvClosedRepairs.Columns[6].HeaderText = "Date Closed";
            dgvClosedRepairs.Columns[7].HeaderText = "Total Cost";

            dgvClosedRepairs.Columns[6].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvClosedRepairs.Columns[7].DefaultCellStyle.Format = "f2";

        }


        private void RefreshDGV()
        {
            dgvClosedRepairs.DataSource = completedRepairs;

            dgvClosedRepairs.Columns[0].Visible = false;
            dgvClosedRepairs.Columns[1].Visible = false;

            filterHeight = dgvClosedRepairs.ColumnHeadersHeight + dgvClosedRepairs.Rows.Cast<DataGridViewRow>().Sum(r => r.Height); ;

            if (filterHeight <= dgvClosedRepairs.MaximumSize.Height)
            {
                dgvClosedRepairs.ScrollBars = ScrollBars.None;
                dgvClosedRepairs.Height = filterHeight;
            }
            else
            {
                dgvClosedRepairs.Height = dgvClosedRepairs.MaximumSize.Height;
                dgvClosedRepairs.ScrollBars = ScrollBars.Vertical;
            }

            foreach (DataGridViewRow row in dgvClosedRepairs.Rows)
            {
                if (Convert.ToDecimal(row.Cells[7].Value) > 0)
                row.Cells[7].Style.BackColor = Color.LightGreen;
            }
        }

        private void dgvClosedRepairs_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // makes sure user is not clicking on the header
            {

                string[] formUser = new string[2];
                formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                if (string.IsNullOrWhiteSpace(formUser[0]))
                {
                    return;
                }


                int repairID = Convert.ToInt32(dgvClosedRepairs.SelectedCells[1].Value);

                bool isLocked = ((MainForm)MdiParent).SqlHelper.SqlConn.CheckLocked(repairID); // returns true or false value to see if record is locked by another user

                if (isLocked == false)
                {



                    RepairDetailsForm EditForm;
                    EditForm = ((MainForm)MdiParent).SqlHelper.PrepareEditForm(repairID); // calls the DV method to prepare an edit form

                    EditForm.FormUser = formUser[0];
                    EditForm.UserFull = formUser[1];

                    EditForm.MdiParent = this.MdiParent;
                    EditForm.Dock = DockStyle.Fill;
                    EditForm.Show();
                    Dispose();
                    GC.Collect();

                }
                else
                {
                    MessageBox.Show("Repair Record is Locked.  Please wait for other user to finish or make sure record isn't open on another tech computer!");
                }
            }

        }

        private void searchEvent()
        {

            if (txtName.Text.Length > 2)
            {
                string[] nameSplit = txtName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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

                completedRepairs = ((MainForm)MdiParent).SqlHelper.SqlConn.SearchCompletedRepairs(searchOut);
                RefreshDGV();
            }
            else
            {
                MessageBox.Show("Please enter at least 3 characters for the name!");
            }           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            completedRepairs = ((MainForm)MdiParent).SqlHelper.SqlConn.GetCompletedRepairs();

            RefreshDGV();
        }

        private void txtFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s\b]");

            if (e.KeyChar == (char)Keys.Enter)
            {
                searchEvent();
                e.Handled = true;
            }


            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }

            
        }
    }
}
