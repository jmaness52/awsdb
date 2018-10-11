namespace SCR_Repair_Tracker
{
    partial class OpenRepairs
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenRepairs));
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdNewRepair = new System.Windows.Forms.Button();
            this.dgvOpenRepairs = new System.Windows.Forms.DataGridView();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenRepairs)).BeginInit();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Lime;
            this.Label4.Location = new System.Drawing.Point(622, 321);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(209, 50);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Press New Repair to create a new Check In.";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Lime;
            this.Label3.Location = new System.Drawing.Point(622, 246);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(209, 50);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Double Click a customer name from the grid on the left to update an existing repa" +
    "ir entry.  ";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Lime;
            this.Label2.Location = new System.Drawing.Point(671, 198);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(96, 15);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Instructions:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Lucida Bright", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Lime;
            this.Label1.Location = new System.Drawing.Point(295, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(234, 36);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Open Repairs";
            // 
            // cmdNewRepair
            // 
            this.cmdNewRepair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewRepair.Location = new System.Drawing.Point(641, 379);
            this.cmdNewRepair.Name = "cmdNewRepair";
            this.cmdNewRepair.Size = new System.Drawing.Size(148, 32);
            this.cmdNewRepair.TabIndex = 8;
            this.cmdNewRepair.Text = "New Repair";
            this.cmdNewRepair.UseVisualStyleBackColor = true;
            this.cmdNewRepair.Click += new System.EventHandler(this.cmdNewRepair_Click);
            // 
            // dgvOpenRepairs
            // 
            this.dgvOpenRepairs.AllowUserToAddRows = false;
            this.dgvOpenRepairs.AllowUserToDeleteRows = false;
            this.dgvOpenRepairs.AllowUserToResizeColumns = false;
            this.dgvOpenRepairs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvOpenRepairs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOpenRepairs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpenRepairs.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpenRepairs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOpenRepairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpenRepairs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOpenRepairs.EnableHeadersVisualStyles = false;
            this.dgvOpenRepairs.Location = new System.Drawing.Point(50, 61);
            this.dgvOpenRepairs.MaximumSize = new System.Drawing.Size(550, 350);
            this.dgvOpenRepairs.MultiSelect = false;
            this.dgvOpenRepairs.Name = "dgvOpenRepairs";
            this.dgvOpenRepairs.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpenRepairs.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOpenRepairs.RowHeadersVisible = false;
            this.dgvOpenRepairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpenRepairs.Size = new System.Drawing.Size(550, 350);
            this.dgvOpenRepairs.TabIndex = 7;
            this.dgvOpenRepairs.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOpenRepairs_CellMouseDoubleClick);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 7000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // OpenRepairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(843, 474);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmdNewRepair);
            this.Controls.Add(this.dgvOpenRepairs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpenRepairs";
            this.Text = "OpenRepairs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpenRepairs_FormClosed);
            this.Load += new System.EventHandler(this.OpenRepairs_Load);
            this.Shown += new System.EventHandler(this.OpenRepairs_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenRepairs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button cmdNewRepair;
        internal System.Windows.Forms.DataGridView dgvOpenRepairs;
        internal System.Windows.Forms.Timer refreshTimer;
    }
}