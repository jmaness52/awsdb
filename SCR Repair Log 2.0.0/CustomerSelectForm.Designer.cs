namespace SCR_Repair_Tracker
{
    partial class CustomerSelectForm
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
            this.LblSearchInstruction = new System.Windows.Forms.Label();
            this.LblMain = new System.Windows.Forms.Label();
            this.txtTel2New = new System.Windows.Forms.MaskedTextBox();
            this.txtTel1New = new System.Windows.Forms.MaskedTextBox();
            this.cmdCreateNew = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtCustSelect = new System.Windows.Forms.TextBox();
            this.tel2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtNewLN = new System.Windows.Forms.TextBox();
            this.txtNewFN = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdCustSearch = new System.Windows.Forms.Button();
            this.dgvCustSelect = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AltTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSearchInstruction
            // 
            this.LblSearchInstruction.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSearchInstruction.Location = new System.Drawing.Point(34, 354);
            this.LblSearchInstruction.Name = "LblSearchInstruction";
            this.LblSearchInstruction.Size = new System.Drawing.Size(356, 46);
            this.LblSearchInstruction.TabIndex = 17;
            this.LblSearchInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LblMain.Location = new System.Drawing.Point(319, 34);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(0, 37);
            this.LblMain.TabIndex = 16;
            // 
            // txtTel2New
            // 
            this.txtTel2New.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel2New.HidePromptOnLeave = true;
            this.txtTel2New.Location = new System.Drawing.Point(164, 176);
            this.txtTel2New.Mask = "(999) 000-0000";
            this.txtTel2New.Name = "txtTel2New";
            this.txtTel2New.Size = new System.Drawing.Size(82, 20);
            this.txtTel2New.TabIndex = 51;
            this.txtTel2New.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTel2New.Visible = false;
            this.txtTel2New.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Telephone_KeyPress);
            // 
            // txtTel1New
            // 
            this.txtTel1New.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel1New.HidePromptOnLeave = true;
            this.txtTel1New.Location = new System.Drawing.Point(164, 134);
            this.txtTel1New.Mask = "(999) 000-0000";
            this.txtTel1New.Name = "txtTel1New";
            this.txtTel1New.Size = new System.Drawing.Size(82, 20);
            this.txtTel1New.TabIndex = 50;
            this.txtTel1New.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTel1New.TextChanged += new System.EventHandler(this.txtTel1New_TextChanged);
            this.txtTel1New.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Telephone_KeyPress);
            // 
            // cmdCreateNew
            // 
            this.cmdCreateNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCreateNew.Location = new System.Drawing.Point(98, 258);
            this.cmdCreateNew.Name = "cmdCreateNew";
            this.cmdCreateNew.Size = new System.Drawing.Size(181, 39);
            this.cmdCreateNew.TabIndex = 11;
            this.cmdCreateNew.UseVisualStyleBackColor = true;
            this.cmdCreateNew.Click += new System.EventHandler(this.cmdCreateNew_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(32, 96);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(356, 29);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Select From Existing Customers";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(20, 217);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(360, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Please search for existing customers before creating a new entry!!!!";
            // 
            // txtCustSelect
            // 
            this.txtCustSelect.Location = new System.Drawing.Point(37, 322);
            this.txtCustSelect.Name = "txtCustSelect";
            this.txtCustSelect.Size = new System.Drawing.Size(207, 20);
            this.txtCustSelect.TabIndex = 12;
            this.txtCustSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Search_KeyPress);
            // 
            // tel2
            // 
            this.tel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tel2.Location = new System.Drawing.Point(88, 166);
            this.tel2.Name = "tel2";
            this.tel2.Size = new System.Drawing.Size(70, 45);
            this.tel2.TabIndex = 12;
            this.tel2.Text = "(Optional)      Telephone 2:";
            this.tel2.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(88, 137);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(70, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Telephone 1:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(94, 107);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Last Name: ";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(95, 81);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "First Name: ";
            // 
            // txtNewLN
            // 
            this.txtNewLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewLN.Location = new System.Drawing.Point(164, 104);
            this.txtNewLN.MaxLength = 49;
            this.txtNewLN.Name = "txtNewLN";
            this.txtNewLN.Size = new System.Drawing.Size(115, 20);
            this.txtNewLN.TabIndex = 4;
            this.txtNewLN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // txtNewFN
            // 
            this.txtNewFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewFN.Location = new System.Drawing.Point(164, 78);
            this.txtNewFN.MaxLength = 49;
            this.txtNewFN.Name = "txtNewFN";
            this.txtNewFN.Size = new System.Drawing.Size(115, 20);
            this.txtNewFN.TabIndex = 3;
            this.txtNewFN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox1.Controls.Add(this.txtTel2New);
            this.GroupBox1.Controls.Add(this.txtTel1New);
            this.GroupBox1.Controls.Add(this.cmdCreateNew);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.tel2);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtNewLN);
            this.GroupBox1.Controls.Add(this.txtNewFN);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(463, 96);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(370, 315);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "                New Customer";
            // 
            // cmdCustSearch
            // 
            this.cmdCustSearch.Location = new System.Drawing.Point(250, 313);
            this.cmdCustSearch.Name = "cmdCustSearch";
            this.cmdCustSearch.Size = new System.Drawing.Size(127, 38);
            this.cmdCustSearch.TabIndex = 11;
            this.cmdCustSearch.Text = "Search by First Name OR Last Name";
            this.cmdCustSearch.UseVisualStyleBackColor = true;
            this.cmdCustSearch.Click += new System.EventHandler(this.cmdCustSearch_Click);
            // 
            // dgvCustSelect
            // 
            this.dgvCustSelect.AllowUserToAddRows = false;
            this.dgvCustSelect.AllowUserToDeleteRows = false;
            this.dgvCustSelect.AllowUserToResizeColumns = false;
            this.dgvCustSelect.AllowUserToResizeRows = false;
            this.dgvCustSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvCustSelect.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCustSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.Tel1,
            this.AltTel});
            this.dgvCustSelect.Location = new System.Drawing.Point(37, 149);
            this.dgvCustSelect.MaximumSize = new System.Drawing.Size(339, 158);
            this.dgvCustSelect.MultiSelect = false;
            this.dgvCustSelect.Name = "dgvCustSelect";
            this.dgvCustSelect.ReadOnly = true;
            this.dgvCustSelect.RowHeadersVisible = false;
            this.dgvCustSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustSelect.Size = new System.Drawing.Size(322, 23);
            this.dgvCustSelect.TabIndex = 10;
            this.dgvCustSelect.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustSelect_CellMouseDoubleClick);
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustomerName.Frozen = true;
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 122;
            // 
            // Tel1
            // 
            this.Tel1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tel1.Frozen = true;
            this.Tel1.HeaderText = "Telephone Number";
            this.Tel1.Name = "Tel1";
            this.Tel1.ReadOnly = true;
            // 
            // AltTel
            // 
            this.AltTel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AltTel.Frozen = true;
            this.AltTel.HeaderText = "Alt Telephone Number";
            this.AltTel.Name = "AltTel";
            this.AltTel.ReadOnly = true;
            // 
            // CustomerSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 444);
            this.Controls.Add(this.LblSearchInstruction);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtCustSelect);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmdCustSearch);
            this.Controls.Add(this.dgvCustSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer  Select";
            this.Load += new System.EventHandler(this.CustomerSelectForm_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblSearchInstruction;
        internal System.Windows.Forms.Label LblMain;
        internal System.Windows.Forms.MaskedTextBox txtTel2New;
        internal System.Windows.Forms.MaskedTextBox txtTel1New;
        internal System.Windows.Forms.Button cmdCreateNew;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtCustSelect;
        internal System.Windows.Forms.Label tel2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtNewLN;
        internal System.Windows.Forms.TextBox txtNewFN;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button cmdCustSearch;
        internal System.Windows.Forms.DataGridView dgvCustSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltTel;
    }
}