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
    public partial class RepairDetailsPrint : Form
    {

        private DataSet1 printData;

        public delegate void CustomPrintDelegate();


        public Delegate CustomPrintMethod { get; set; }

        public RepairDetailsPrint(DataSet1 dsIN)
        {
            InitializeComponent();
            printData = dsIN;

            foreach (Control control in crViewer.Controls)
            {
                if (control is System.Windows.Forms.ToolStrip)
                {

                    //Default Print Button
                    ToolStripItem tsItem = ((ToolStrip)control).Items[1];
                    tsItem.Click += new EventHandler(tsItem_Click);


                }
            }

        }

        private void crViewer_Load(object sender, EventArgs e)
        {
            RepairDetails1.SetDataSource(printData);
            crViewer.ReportSource = RepairDetails1;
            crViewer.Refresh();
        }

        void tsItem_Click(object sender, EventArgs e)
        {
            if (CustomPrintMethod != null)
            {
                CustomPrintMethod.DynamicInvoke(null);
            }
        }
    }
}
