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
    public partial class CompletedPartsForm : Form
    {

        private List<CompletedPartRow> completedParts = new List<CompletedPartRow>();
        private IdleTimeChecker idleTime = new IdleTimeChecker();
        private int filterHeight;

        public CompletedPartsForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            completedParts = ((MainForm)MdiParent).SqlHelper.SqlConn.GetCompletedParts();

            RefreshDGV();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            var currentIdle = idleTime.GetInactiveTime();

            if (currentIdle.Value.TotalMinutes > 10) // logout after 10 min
            {

                ((MainForm)MdiParent).LogOut();
                Dispose();
                GC.Collect();

            }
        }

        private void CompletedPartsForm_Shown(object sender, EventArgs e)
        {
            completedParts = ((MainForm)MdiParent).SqlHelper.SqlConn.GetCompletedParts();

            RefreshDGV();

            dgvClosedParts.Columns[2].HeaderText = "Customer Name";
            dgvClosedParts.Columns[3].HeaderText = "Part Description";
            dgvClosedParts.Columns[4].HeaderText = "Vendor Name";
            dgvClosedParts.Columns[5].HeaderText = "Date Closed";
            dgvClosedParts.Columns[6].HeaderText = "Customer Price";
            

            dgvClosedParts.Columns[5].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvClosedParts.Columns[6].DefaultCellStyle.Format = "f2";
        }

        private void dgvClosedParts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // makes sure user is not clicking on the header
            {

                string[] formUser = new string[2];
                formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                if (string.IsNullOrWhiteSpace(formUser[0]))
                {
                    return;
                }


                int orderID = Convert.ToInt32(dgvClosedParts.SelectedCells[0].Value);

                bool isLocked = ((MainForm)MdiParent).SqlHelper.SqlConn.CheckPartLocked(orderID); // returns true or false value to see if record is locked by another user

                if (isLocked == false)
                {



                    PartDetailsForm EditForm;
                    EditForm = ((MainForm)MdiParent).SqlHelper.EditPartNoRepair(orderID); // calls the DV method to prepare an edit form

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
                    MessageBox.Show("Part Record is Locked.  Please wait for other user to finish or make sure record isn't open on another tech computer!");
                }
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
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


        private void RefreshDGV()
        {
            dgvClosedParts.DataSource = completedParts;

            dgvClosedParts.Columns[0].Visible = false;
            dgvClosedParts.Columns[1].Visible = false;

            filterHeight = dgvClosedParts.ColumnHeadersHeight + dgvClosedParts.Rows.Cast<DataGridViewRow>().Sum(r => r.Height); ;

            if (filterHeight <= dgvClosedParts.MaximumSize.Height)
            {
                dgvClosedParts.ScrollBars = ScrollBars.None;
                dgvClosedParts.Height = filterHeight;
            }
            else
            {
                dgvClosedParts.Height = dgvClosedParts.MaximumSize.Height;
                dgvClosedParts.ScrollBars = ScrollBars.Vertical;
            }

            foreach (DataGridViewRow row in dgvClosedParts.Rows)
            {
                if (Convert.ToDecimal(row.Cells[6].Value) > 0)
                    row.Cells[6].Style.BackColor = Color.LightGreen;
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

                completedParts = ((MainForm)MdiParent).SqlHelper.SqlConn.SearchCompletedParts(searchOut);
                RefreshDGV();
            }
            else
            {
                MessageBox.Show("Please enter at least 3 characters for the name!");
            }
        }
    }
}
