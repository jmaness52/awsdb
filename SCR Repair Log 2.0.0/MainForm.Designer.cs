namespace SCR_Repair_Tracker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.miRepairs = new System.Windows.Forms.ToolStripMenuItem();
            this.msiOpenRepairs = new System.Windows.Forms.ToolStripMenuItem();
            this.msiNewRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCompletedRepairs = new System.Windows.Forms.ToolStripMenuItem();
            this.miPartOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.msiOpenOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.msiNewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCompletedOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.miReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.ControlText;
            this.mainMenu.Enabled = false;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRepairs,
            this.miPartOrders,
            this.miReports});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(884, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "Main Menu";
            // 
            // miRepairs
            // 
            this.miRepairs.BackColor = System.Drawing.SystemColors.ControlText;
            this.miRepairs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiOpenRepairs,
            this.msiNewRepair,
            this.msiCompletedRepairs});
            this.miRepairs.ForeColor = System.Drawing.SystemColors.Control;
            this.miRepairs.Name = "miRepairs";
            this.miRepairs.Size = new System.Drawing.Size(57, 20);
            this.miRepairs.Text = "Repairs";
            // 
            // msiOpenRepairs
            // 
            this.msiOpenRepairs.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.msiOpenRepairs.ForeColor = System.Drawing.SystemColors.Control;
            this.msiOpenRepairs.Name = "msiOpenRepairs";
            this.msiOpenRepairs.Size = new System.Drawing.Size(171, 22);
            this.msiOpenRepairs.Text = "Open Repairs";
            this.msiOpenRepairs.Click += new System.EventHandler(this.msiOpenRepairs_Click);
            // 
            // msiNewRepair
            // 
            this.msiNewRepair.BackColor = System.Drawing.SystemColors.ControlText;
            this.msiNewRepair.ForeColor = System.Drawing.SystemColors.Control;
            this.msiNewRepair.Name = "msiNewRepair";
            this.msiNewRepair.Size = new System.Drawing.Size(171, 22);
            this.msiNewRepair.Text = "New Repair";
            this.msiNewRepair.Click += new System.EventHandler(this.msiNewRepair_Click);
            // 
            // msiCompletedRepairs
            // 
            this.msiCompletedRepairs.BackColor = System.Drawing.SystemColors.ControlText;
            this.msiCompletedRepairs.ForeColor = System.Drawing.SystemColors.Control;
            this.msiCompletedRepairs.Name = "msiCompletedRepairs";
            this.msiCompletedRepairs.Size = new System.Drawing.Size(171, 22);
            this.msiCompletedRepairs.Text = "Search Completed";
            this.msiCompletedRepairs.Click += new System.EventHandler(this.msiCompletedRepairs_Click);
            // 
            // miPartOrders
            // 
            this.miPartOrders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiOpenOrders,
            this.msiNewOrder,
            this.msiCompletedOrders});
            this.miPartOrders.ForeColor = System.Drawing.SystemColors.Control;
            this.miPartOrders.Name = "miPartOrders";
            this.miPartOrders.Size = new System.Drawing.Size(78, 20);
            this.miPartOrders.Text = "Part Orders";
            // 
            // msiOpenOrders
            // 
            this.msiOpenOrders.BackColor = System.Drawing.SystemColors.ControlText;
            this.msiOpenOrders.ForeColor = System.Drawing.SystemColors.Control;
            this.msiOpenOrders.Name = "msiOpenOrders";
            this.msiOpenOrders.Size = new System.Drawing.Size(171, 22);
            this.msiOpenOrders.Text = "Open Orders";
            this.msiOpenOrders.Click += new System.EventHandler(this.msiOpenOrders_Click);
            // 
            // msiNewOrder
            // 
            this.msiNewOrder.BackColor = System.Drawing.SystemColors.ControlText;
            this.msiNewOrder.ForeColor = System.Drawing.SystemColors.Control;
            this.msiNewOrder.Name = "msiNewOrder";
            this.msiNewOrder.Size = new System.Drawing.Size(171, 22);
            this.msiNewOrder.Text = "Create New";
            this.msiNewOrder.Click += new System.EventHandler(this.msiNewOrder_Click);
            // 
            // msiCompletedOrders
            // 
            this.msiCompletedOrders.BackColor = System.Drawing.SystemColors.ControlText;
            this.msiCompletedOrders.ForeColor = System.Drawing.SystemColors.Control;
            this.msiCompletedOrders.Name = "msiCompletedOrders";
            this.msiCompletedOrders.Size = new System.Drawing.Size(171, 22);
            this.msiCompletedOrders.Text = "Search Completed";
            this.msiCompletedOrders.Click += new System.EventHandler(this.msiCompletedOrders_Click);
            // 
            // miReports
            // 
            this.miReports.ForeColor = System.Drawing.SystemColors.Control;
            this.miReports.Name = "miReports";
            this.miReports.Size = new System.Drawing.Size(59, 20);
            this.miReports.Text = "Reports";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(850, 480);
            this.Name = "MainForm";
            this.Text = " SCR Repair Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem miRepairs;
        private System.Windows.Forms.ToolStripMenuItem msiOpenRepairs;
        private System.Windows.Forms.ToolStripMenuItem msiNewRepair;
        private System.Windows.Forms.ToolStripMenuItem msiCompletedRepairs;
        private System.Windows.Forms.ToolStripMenuItem miPartOrders;
        private System.Windows.Forms.ToolStripMenuItem msiOpenOrders;
        private System.Windows.Forms.ToolStripMenuItem msiNewOrder;
        private System.Windows.Forms.ToolStripMenuItem msiCompletedOrders;
        private System.Windows.Forms.ToolStripMenuItem miReports;
        public System.Windows.Forms.MenuStrip mainMenu;
    }
}

