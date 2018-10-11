namespace SCR_Repair_Tracker
{
    partial class CheckInPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CheckIn1 = new SCR_Repair_Tracker.CheckIn();
            this.SuspendLayout();
            // 
            // crViewer
            // 
            this.crViewer.ActiveViewIndex = 0;
            this.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewer.Location = new System.Drawing.Point(1, 1);
            this.crViewer.Name = "crViewer";
            this.crViewer.ReportSource = this.CheckIn1;
            this.crViewer.Size = new System.Drawing.Size(1101, 551);
            this.crViewer.TabIndex = 0;
            this.crViewer.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // CheckInPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 551);
            this.Controls.Add(this.crViewer);
            this.Name = "CheckInPrint";
            this.Text = "Check In Print";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewer;
        private CheckIn CheckIn1;
    }
}