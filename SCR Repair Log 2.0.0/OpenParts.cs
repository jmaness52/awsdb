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
    public partial class OpenParts : Form
    {

        #region Fields and Properties
        List<OpenPartRow> openPartOrderList = new List<OpenPartRow>(); // holds a list of the open repairs
        IdleTimeChecker IdleTime = new IdleTimeChecker(); //instace of the class that can track idle/inactive time
        
        private int saveScroll; // when the grid is refreshed, this int saves scrolling index
        private int saveRow; // saves selected rowv if number o
        private int filterHeight; // height of all the rows of data,  we use this value to decrease the height of the dgv if there are few entries (no scrolling is needed)


        #endregion





        public OpenParts()
        {
            InitializeComponent();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            var currentIdle = IdleTime.GetInactiveTime();

            if (currentIdle.Value.TotalMinutes < 10) // only query db if user is idle less than 10 min, prevent issues with sleep and not reaching db
            {

                RefreshOrders();

            }
            else
            {
                ((MainForm)MdiParent).LogOut();
                Dispose();
                GC.Collect();


            }
        }

        private void OpenParts_Shown(object sender, EventArgs e)
        {
            RefreshOrders();

            if (dgvOpenParts.Rows.Count > 0)
            {
                dgvOpenParts.Columns[4].HeaderText = "Customer";  // sets th headers of the dgv columns where necessary to deviate from the sql names
                dgvOpenParts.Columns[5].HeaderText = "Vendor";
                dgvOpenParts.Columns[6].HeaderText = "Description";
                dgvOpenParts.Columns[7].HeaderText = "Status";
                dgvOpenParts.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgvOpenParts.Columns[8].HeaderText = "Date Created";
            }
            
        }

        private void RefreshOrders()
        {
            openPartOrderList = ((MainForm)MdiParent).SqlHelper.SqlConn.GetOpenPartOrders(); //loads the list using sql db 

            if (openPartOrderList.Count > 0 )
            {
                // the list is loaded, but before we touch the dgv, capture scroll position and selected row


                if (dgvOpenParts.Rows.Count > 0) // save the non-zero row index of the dgv so we can go back to the same postion after refresh
                {

                    saveScroll = dgvOpenParts.FirstDisplayedCell.RowIndex;


                    if (dgvOpenParts.SelectedCells.Count > 0)
                    {
                        saveRow = dgvOpenParts.SelectedRows[0].Index; //saves the user selected row so we can go back to same row after refresh

                    }
                }
                dgvOpenParts.DataSource = openPartOrderList; // loads dgv with the list

                dgvOpenParts.Columns[0].Visible = false;
                dgvOpenParts.Columns[1].Visible = false;
                dgvOpenParts.Columns[2].Visible = false;
                dgvOpenParts.Columns[3].Visible = false;
                dgvOpenParts.Columns[9].Visible = false;
                dgvOpenParts.ClearSelection();





                if (saveScroll != 0 & saveScroll < dgvOpenParts.Rows.Count) // if scroll was non zero, change the scrolling index to where it was before refresh
                {
                    dgvOpenParts.FirstDisplayedScrollingRowIndex = saveScroll;

                }

                dgvOpenParts.Rows[saveRow].Selected = true;  // set the selected row back to what it was before refresh

                foreach (DataGridViewRow row in dgvOpenParts.Rows) //sets the color coding of the status based on the color coding
                {

                    row.Cells[7].Style.ForeColor = ConstantsLibrary.PartForeColor[row.Cells[9].Value.ToString()];
                    row.Cells[7].Style.BackColor = ConstantsLibrary.PartBackColor[row.Cells[9].Value.ToString()];
                }


                // grabs the height of the rows plus header, if this is smaller than the max height of the dgv, we redraw the control
                filterHeight = dgvOpenParts.ColumnHeadersHeight + dgvOpenParts.Rows.Cast<DataGridViewRow>().Sum(r => r.Height); ;

                if (filterHeight <= dgvOpenParts.MaximumSize.Height)
                {
                    dgvOpenParts.ScrollBars = ScrollBars.None;
                    dgvOpenParts.Height = filterHeight;
                }
                else
                {
                    dgvOpenParts.Height = dgvOpenParts.MaximumSize.Height;
                    dgvOpenParts.ScrollBars = ScrollBars.Vertical;
                }
            }

            
        }

        private void dgvOpenParts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // makes sure user is not clicking on the header
            {

                string[] formUser = new string[2];
                formUser = ((MainForm)MdiParent).SqlHelper.SelectFormUser();

                if (string.IsNullOrWhiteSpace(formUser[0]))
                {
                    return;
                }


                int partID = Convert.ToInt32(dgvOpenParts.SelectedCells[0].Value);

                bool isLocked = ((MainForm)MdiParent).SqlHelper.SqlConn.CheckPartLocked(partID); // returns true or false value to see if record is locked by another user

                if (isLocked == false)
                {
                    


                    PartDetailsForm EditForm; 
                    EditForm = ((MainForm)MdiParent).SqlHelper.EditPartNoRepair(partID); // calls the DV method to prepare an edit form

                    EditForm.FormUser = formUser[0];
                    EditForm.UserFull = formUser[1];
                    EditForm.MdiParent = this.MdiParent;
                    EditForm.FormBus = ((MainForm)MdiParent).SqlHelper;
                    EditForm.Dock = DockStyle.Fill;
                    EditForm.Show();
                    Dispose();
                    GC.Collect();

                }
                else
                {
                    MessageBox.Show("Part Order is Locked.  Please wait for other user to finish or make sure record isn't open on another tech computer!");
                }



            }
        }

        private void cmdNewPart_Click(object sender, EventArgs e)
        {
            CustomerSelectForm newPart = new CustomerSelectForm();
            newPart.OutputType = "Part";
            newPart.MdiParent = this.MdiParent;
            newPart.Dock = DockStyle.Fill;
            newPart.Show();
            Dispose();
            GC.Collect();
        }
    }
}
