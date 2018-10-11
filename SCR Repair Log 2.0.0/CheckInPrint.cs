using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;

namespace SCR_Repair_Tracker
{
    public partial class CheckInPrint : Form
    {

        private DataSet1 printData;
        private bool printFlag;
        

        public delegate void CustomPrintDelegate();

        

        public Delegate CustomPrintMethod { get; set; }

        public bool PrintFlag
        {
            get { return printFlag; }
            set { printFlag = value; }
        }

        public CheckInPrint(DataSet1 dsIn)
        {
            InitializeComponent();
            printData = dsIn;

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

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CheckIn1.SetDataSource(printData);
            crViewer.ReportSource = CheckIn1;
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
