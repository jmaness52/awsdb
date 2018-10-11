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
    public partial class OrderSelectForm : Form
    {
        private string formType;
        private int idOut;

        public string FormType
        {
            get { return formType; }

            set { formType = value; }
        }

        public int IdOut
        {
            get { return idOut; }
            set { idOut = value; }
        }

        public OrderSelectForm()
        {
            InitializeComponent();
        }


        private void dgvOrderSelect_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // makes sure user is not clicking on the header
            {
                if (formType == "Repair")
                {
                    if (MessageBox.Show(string.Format("Customer Name: {0}\nMfg: {1}\nDevice: {2}", dgvOrderSelect.SelectedCells[4].Value.ToString(), dgvOrderSelect.SelectedCells[5].Value.ToString(), dgvOrderSelect.SelectedCells[6].Value.ToString()), "Confirm Repair To Link", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        idOut = Convert.ToInt32(dgvOrderSelect.SelectedCells[0].Value);
                    }
                }
                else if (formType == "Part")
                {
                    idOut = Convert.ToInt32(dgvOrderSelect.SelectedCells[0].Value);
                }


                Hide();
            }
        }
    }
}
