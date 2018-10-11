using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SCR_Repair_Tracker
{
    public partial class OpenRepairs : Form
    {


        #region Fields and Properties
        List<OpenRepairRow> OpenRepairList = new List<OpenRepairRow>(); // holds a list of the open repairs
        IdleTimeChecker IdleTime = new IdleTimeChecker(); //instace of the class that can track idle/inactive time
        
        private int saveScroll; // when the grid is refreshed, this int saves scrolling index
        private int saveRow; // saves selected rowv if number o
        private int filterHeight; // height of all the rows of data,  we use this value to decrease the height of the dgv if there are few entries (no scrolling is needed)


        #endregion

        #region Loading Events
        public OpenRepairs()
        {
            InitializeComponent();
        }

        private void OpenRepairs_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

        }

        private void OpenRepairs_Shown(object sender, EventArgs e)
        {

            // sets the inital state of the dgv by loading the repairs, and changing column headings
            RefreshRepairs();

            dgvOpenRepairs.Columns[4].HeaderText = "Customer";  // sets th headers of the dgv columns where necessary to deviate from the sql names
            dgvOpenRepairs.Columns[6].HeaderText = "Type";
            dgvOpenRepairs.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvOpenRepairs.Columns[8].HeaderText = "Date Created";

        }
        #endregion

        #region Refresh Repairs and Timers
        private void RefreshRepairs() //loads the dgv from database, hides the key columns, filters the colors based on status
        {

            OpenRepairList = ((MainForm)MdiParent).SqlHelper.SqlConn.GetOpenRepairs(); //loads the list using sql db 


            // the list is loaded, but before we touch the dgv, capture scroll position and selected row


            if (dgvOpenRepairs.Rows.Count > 0) // save the non-zero row index of the dgv so we can go back to the same postion after refresh
            {

                saveScroll = dgvOpenRepairs.FirstDisplayedCell.RowIndex;


                if (dgvOpenRepairs.SelectedCells.Count > 0)
                {
                    saveRow = dgvOpenRepairs.SelectedRows[0].Index; //saves the user selected row so we can go back to same row after refresh

                }
            }
            dgvOpenRepairs.DataSource = OpenRepairList; // loads dgv with the list

            dgvOpenRepairs.Columns[0].Visible = false;
            dgvOpenRepairs.Columns[1].Visible = false;
            dgvOpenRepairs.Columns[2].Visible = false;
            dgvOpenRepairs.Columns[3].Visible = false;
            dgvOpenRepairs.ClearSelection();





            if (saveScroll != 0 & saveScroll < dgvOpenRepairs.Rows.Count) // if scroll was non zero, change the scrolling index to where it was before refresh
            {
                dgvOpenRepairs.FirstDisplayedScrollingRowIndex = saveScroll;

            }

            dgvOpenRepairs.Rows[saveRow].Selected = true;  // set the selected row back to what it was before refresh

            foreach (DataGridViewRow row in dgvOpenRepairs.Rows) //sets the color coding of the status based on the color coding
            {

                row.Cells[7].Style.ForeColor = ConstantsLibrary.RepairForeColor[row.Cells[3].Value.ToString()];
                row.Cells[7].Style.BackColor = ConstantsLibrary.RepairBackColor[row.Cells[3].Value.ToString()];
            }


            // grabs the height of the rows plus header, if this is smaller than the max height of the dgv, we redraw the control
            filterHeight = dgvOpenRepairs.ColumnHeadersHeight + dgvOpenRepairs.Rows.Cast<DataGridViewRow>().Sum(r => r.Height); ;

            if (filterHeight <= dgvOpenRepairs.MaximumSize.Height)
            {
                dgvOpenRepairs.ScrollBars = ScrollBars.None;
                dgvOpenRepairs.Height = filterHeight;
            }
            else
            {
                dgvOpenRepairs.Height = dgvOpenRepairs.MaximumSize.Height;
                dgvOpenRepairs.ScrollBars = ScrollBars.Vertical;
            }

        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {

            var currentIdle = IdleTime.GetInactiveTime();

            if (currentIdle.Value.TotalMinutes < 10) // only query db if user is idle less than 10 min, prevent issues with sleep and not reaching db
            {

                RefreshRepairs();

            }
            else
            {

                ((MainForm)MdiParent).LogOut();
                Dispose();
                GC.Collect();


            }

        }
        #endregion

        #region Go to other Forms
        //Event to open a Repair Details form from the view
        private void dgvOpenRepairs_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // makes sure user is not clicking on the header
            {

                string[] formUser = new string[2];
                formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                if (string.IsNullOrWhiteSpace(formUser[0]))
                {
                    return;
                }

                int repairID = Convert.ToInt32(dgvOpenRepairs.SelectedCells[0].Value);


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

        #endregion

        private void OpenRepairs_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void cmdNewRepair_Click(object sender, EventArgs e)
        {
            CustomerSelectForm CustSelect = new CustomerSelectForm();
            CustSelect.OutputType = "Repair";
            CustSelect.MdiParent = this.MdiParent;
            CustSelect.Dock = DockStyle.Fill;
            CustSelect.Show();           
            Dispose();
            GC.Collect();
        }
    }
}
