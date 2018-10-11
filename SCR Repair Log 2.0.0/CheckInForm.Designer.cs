namespace SCR_Repair_Tracker
{
    partial class CheckInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label18 = new System.Windows.Forms.Label();
            this.dgvNotesHistory = new System.Windows.Forms.DataGridView();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.txtNoteAdd = new System.Windows.Forms.TextBox();
            this.cmdAddNote = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdClose = new System.Windows.Forms.ToolStripButton();
            this.cmdCustEdit = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.panViewCust = new System.Windows.Forms.Panel();
            this.txtTel2 = new System.Windows.Forms.MaskedTextBox();
            this.txtTel1 = new System.Windows.Forms.MaskedTextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.txtCustEditLN = new System.Windows.Forms.TextBox();
            this.cmdSaveCustEdit = new System.Windows.Forms.Button();
            this.txtCustEditFN = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.panEditCust = new System.Windows.Forms.Panel();
            this.Label17 = new System.Windows.Forms.Label();
            this.txtTel2Edit = new System.Windows.Forms.MaskedTextBox();
            this.txtTel1Edit = new System.Windows.Forms.MaskedTextBox();
            this.PrintPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.cmdClearNote = new System.Windows.Forms.Button();
            this.txtPartCost = new System.Windows.Forms.TextBox();
            this.txtSvcFee = new System.Windows.Forms.TextBox();
            this.panStaticRepairDetails = new System.Windows.Forms.Panel();
            this.dgvCheckInItems = new System.Windows.Forms.DataGridView();
            this.BtnClearItem = new System.Windows.Forms.Button();
            this.lblRepairsInCI = new System.Windows.Forms.Label();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.panAccRadio = new System.Windows.Forms.Panel();
            this.optAccYes = new System.Windows.Forms.RadioButton();
            this.optAccNo = new System.Windows.Forms.RadioButton();
            this.panPWradio = new System.Windows.Forms.Panel();
            this.optPWYes = new System.Windows.Forms.RadioButton();
            this.optPWNo = new System.Windows.Forms.RadioButton();
            this.txtAddMfg = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.LBaccEdit = new System.Windows.Forms.CheckedListBox();
            this.labelACC = new System.Windows.Forms.Label();
            this.cbxMFGselect = new System.Windows.Forms.ComboBox();
            this.cbxTypeDevice = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.CloseTimer = new System.Windows.Forms.Timer(this.components);
            this.chkTax = new System.Windows.Forms.CheckBox();
            this.PanSvcApproval = new System.Windows.Forms.Panel();
            this.OptSvcYes = new System.Windows.Forms.RadioButton();
            this.OptSvcNo = new System.Windows.Forms.RadioButton();
            this.LblSvcApproved = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotesHistory)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            this.panViewCust.SuspendLayout();
            this.panEditCust.SuspendLayout();
            this.panStaticRepairDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInItems)).BeginInit();
            this.panAccRadio.SuspendLayout();
            this.panPWradio.SuspendLayout();
            this.PanSvcApproval.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(253, 23);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(110, 13);
            this.Label18.TabIndex = 2;
            this.Label18.Text = "AlternateTelephone #";
            // 
            // dgvNotesHistory
            // 
            this.dgvNotesHistory.AllowUserToAddRows = false;
            this.dgvNotesHistory.AllowUserToDeleteRows = false;
            this.dgvNotesHistory.AllowUserToResizeColumns = false;
            this.dgvNotesHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvNotesHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNotesHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvNotesHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvNotesHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNotesHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvNotesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotesHistory.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotesHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNotesHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNotesHistory.GridColor = System.Drawing.SystemColors.Control;
            this.dgvNotesHistory.Location = new System.Drawing.Point(517, 0);
            this.dgvNotesHistory.MultiSelect = false;
            this.dgvNotesHistory.Name = "dgvNotesHistory";
            this.dgvNotesHistory.RowHeadersVisible = false;
            this.dgvNotesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotesHistory.Size = new System.Drawing.Size(346, 194);
            this.dgvNotesHistory.TabIndex = 72;
            this.dgvNotesHistory.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNotesHistory_CellMouseDoubleClick);
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtCustName.Location = new System.Drawing.Point(9, 31);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(155, 20);
            this.txtCustName.TabIndex = 16;
            this.txtCustName.TabStop = false;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(542, 235);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(33, 13);
            this.Label12.TabIndex = 77;
            this.Label12.Text = "Note:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(685, 385);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(58, 13);
            this.Label11.TabIndex = 76;
            this.Label11.Text = "Total Cost:";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(555, 385);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(67, 13);
            this.Label10.TabIndex = 75;
            this.Label10.Text = "Service Fee:";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(569, 413);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(53, 13);
            this.Label9.TabIndex = 74;
            this.Label9.Text = "Part Cost:";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label16.Location = new System.Drawing.Point(308, 9);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(180, 25);
            this.Label16.TabIndex = 86;
            this.Label16.Text = "Repair Check In";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Enabled = false;
            this.txtTotalCost.Location = new System.Drawing.Point(746, 382);
            this.txtTotalCost.MaxLength = 7;
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(44, 20);
            this.txtTotalCost.TabIndex = 83;
            // 
            // txtNoteAdd
            // 
            this.txtNoteAdd.Location = new System.Drawing.Point(545, 252);
            this.txtNoteAdd.MaxLength = 150;
            this.txtNoteAdd.Multiline = true;
            this.txtNoteAdd.Name = "txtNoteAdd";
            this.txtNoteAdd.Size = new System.Drawing.Size(224, 49);
            this.txtNoteAdd.TabIndex = 79;
            this.txtNoteAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoteAdd_KeyPress);
            // 
            // cmdAddNote
            // 
            this.cmdAddNote.Location = new System.Drawing.Point(775, 264);
            this.cmdAddNote.Name = "cmdAddNote";
            this.cmdAddNote.Size = new System.Drawing.Size(75, 21);
            this.cmdAddNote.TabIndex = 80;
            this.cmdAddNote.Text = "Add Note";
            this.cmdAddNote.UseVisualStyleBackColor = true;
            this.cmdAddNote.Click += new System.EventHandler(this.cmdAddNote_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(214, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(68, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Telephone #";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(335, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(110, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "AlternateTelephone #";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSave,
            this.cmdClose});
            this.ToolStrip1.Location = new System.Drawing.Point(546, 302);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip1.Size = new System.Drawing.Size(298, 66);
            this.ToolStrip1.TabIndex = 84;
            this.ToolStrip1.TabStop = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Enabled = false;
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(84, 63);
            this.cmdSave.Text = "Check In";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(158, 63);
            this.cmdClose.Text = "Exit Without Saving";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdCustEdit
            // 
            this.cmdCustEdit.Location = new System.Drawing.Point(35, 57);
            this.cmdCustEdit.Name = "cmdCustEdit";
            this.cmdCustEdit.Size = new System.Drawing.Size(101, 21);
            this.cmdCustEdit.TabIndex = 1;
            this.cmdCustEdit.Text = "Edit Customer Info";
            this.cmdCustEdit.UseVisualStyleBackColor = true;
            this.cmdCustEdit.Click += new System.EventHandler(this.cmdCustEdit_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(88, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Customer Name: ";
            // 
            // panViewCust
            // 
            this.panViewCust.Controls.Add(this.txtTel2);
            this.panViewCust.Controls.Add(this.txtTel1);
            this.panViewCust.Controls.Add(this.cmdCustEdit);
            this.panViewCust.Controls.Add(this.txtCustName);
            this.panViewCust.Controls.Add(this.Label2);
            this.panViewCust.Controls.Add(this.Label1);
            this.panViewCust.Controls.Add(this.Label3);
            this.panViewCust.Location = new System.Drawing.Point(7, 40);
            this.panViewCust.Name = "panViewCust";
            this.panViewCust.Size = new System.Drawing.Size(495, 85);
            this.panViewCust.TabIndex = 88;
            // 
            // txtTel2
            // 
            this.txtTel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTel2.Location = new System.Drawing.Point(347, 31);
            this.txtTel2.Mask = "(999) 000-0000";
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.ReadOnly = true;
            this.txtTel2.Size = new System.Drawing.Size(87, 20);
            this.txtTel2.TabIndex = 52;
            this.txtTel2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtTel1
            // 
            this.txtTel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTel1.Location = new System.Drawing.Point(217, 31);
            this.txtTel1.Mask = "(999) 000-0000";
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.ReadOnly = true;
            this.txtTel1.Size = new System.Drawing.Size(88, 20);
            this.txtTel1.TabIndex = 51;
            this.txtTel1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(3, 39);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(58, 13);
            this.Label19.TabIndex = 48;
            this.Label19.Text = "Last Name";
            // 
            // txtCustEditLN
            // 
            this.txtCustEditLN.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustEditLN.Location = new System.Drawing.Point(4, 55);
            this.txtCustEditLN.MaxLength = 49;
            this.txtCustEditLN.Name = "txtCustEditLN";
            this.txtCustEditLN.Size = new System.Drawing.Size(88, 20);
            this.txtCustEditLN.TabIndex = 3;
            this.txtCustEditLN.TextChanged += new System.EventHandler(this.CustomerInfoChanged);
            this.txtCustEditLN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerName_Keypress);
            // 
            // cmdSaveCustEdit
            // 
            this.cmdSaveCustEdit.Location = new System.Drawing.Point(375, 35);
            this.cmdSaveCustEdit.Name = "cmdSaveCustEdit";
            this.cmdSaveCustEdit.Size = new System.Drawing.Size(101, 21);
            this.cmdSaveCustEdit.TabIndex = 10;
            this.cmdSaveCustEdit.Text = "Save Customer";
            this.cmdSaveCustEdit.UseVisualStyleBackColor = true;
            this.cmdSaveCustEdit.Click += new System.EventHandler(this.cmdSaveCustEdit_Click);
            // 
            // txtCustEditFN
            // 
            this.txtCustEditFN.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustEditFN.Location = new System.Drawing.Point(4, 16);
            this.txtCustEditFN.MaxLength = 49;
            this.txtCustEditFN.Name = "txtCustEditFN";
            this.txtCustEditFN.Size = new System.Drawing.Size(88, 20);
            this.txtCustEditFN.TabIndex = 2;
            this.txtCustEditFN.TextChanged += new System.EventHandler(this.CustomerInfoChanged);
            this.txtCustEditFN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerName_Keypress);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(143, 23);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(68, 13);
            this.Label13.TabIndex = 1;
            this.Label13.Text = "Telephone #";
            // 
            // panEditCust
            // 
            this.panEditCust.Controls.Add(this.Label17);
            this.panEditCust.Controls.Add(this.txtTel2Edit);
            this.panEditCust.Controls.Add(this.txtTel1Edit);
            this.panEditCust.Controls.Add(this.Label19);
            this.panEditCust.Controls.Add(this.txtCustEditLN);
            this.panEditCust.Controls.Add(this.cmdSaveCustEdit);
            this.panEditCust.Controls.Add(this.txtCustEditFN);
            this.panEditCust.Controls.Add(this.Label13);
            this.panEditCust.Controls.Add(this.Label18);
            this.panEditCust.Location = new System.Drawing.Point(7, 40);
            this.panEditCust.Name = "panEditCust";
            this.panEditCust.Size = new System.Drawing.Size(495, 85);
            this.panEditCust.TabIndex = 89;
            this.panEditCust.Visible = false;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(3, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(60, 13);
            this.Label17.TabIndex = 0;
            this.Label17.Text = "First Name:";
            // 
            // txtTel2Edit
            // 
            this.txtTel2Edit.Location = new System.Drawing.Point(256, 38);
            this.txtTel2Edit.Mask = "(999) 000-0000";
            this.txtTel2Edit.Name = "txtTel2Edit";
            this.txtTel2Edit.Size = new System.Drawing.Size(88, 20);
            this.txtTel2Edit.TabIndex = 50;
            this.txtTel2Edit.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTel2Edit.TextChanged += new System.EventHandler(this.CustomerInfoChanged);
            this.txtTel2Edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerPhone_Keypress);
            // 
            // txtTel1Edit
            // 
            this.txtTel1Edit.Location = new System.Drawing.Point(133, 39);
            this.txtTel1Edit.Mask = "(999) 000-0000";
            this.txtTel1Edit.Name = "txtTel1Edit";
            this.txtTel1Edit.Size = new System.Drawing.Size(88, 20);
            this.txtTel1Edit.TabIndex = 49;
            this.txtTel1Edit.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTel1Edit.TextChanged += new System.EventHandler(this.CustomerInfoChanged);
            this.txtTel1Edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerPhone_Keypress);
            // 
            // PrintPreviewDialog1
            // 
            this.PrintPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.PrintPreviewDialog1.Document = this.PrintDocument1;
            this.PrintPreviewDialog1.Enabled = true;
            this.PrintPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("PrintPreviewDialog1.Icon")));
            this.PrintPreviewDialog1.Name = "PrintPreviewDialog1";
            this.PrintPreviewDialog1.Visible = false;
            // 
            // cmdClearNote
            // 
            this.cmdClearNote.Location = new System.Drawing.Point(583, 208);
            this.cmdClearNote.Name = "cmdClearNote";
            this.cmdClearNote.Size = new System.Drawing.Size(186, 21);
            this.cmdClearNote.TabIndex = 71;
            this.cmdClearNote.TabStop = false;
            this.cmdClearNote.Text = "Clear Selected Note";
            this.cmdClearNote.UseVisualStyleBackColor = true;
            this.cmdClearNote.Click += new System.EventHandler(this.cmdClearNote_Click);
            // 
            // txtPartCost
            // 
            this.txtPartCost.Location = new System.Drawing.Point(625, 410);
            this.txtPartCost.MaxLength = 7;
            this.txtPartCost.Name = "txtPartCost";
            this.txtPartCost.Size = new System.Drawing.Size(44, 20);
            this.txtPartCost.TabIndex = 82;
            this.txtPartCost.TextChanged += new System.EventHandler(this.Cost_TextChanged);
            this.txtPartCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cost_Keypress);
            // 
            // txtSvcFee
            // 
            this.txtSvcFee.Location = new System.Drawing.Point(625, 382);
            this.txtSvcFee.MaxLength = 7;
            this.txtSvcFee.Name = "txtSvcFee";
            this.txtSvcFee.Size = new System.Drawing.Size(44, 20);
            this.txtSvcFee.TabIndex = 81;
            this.txtSvcFee.TextChanged += new System.EventHandler(this.Cost_TextChanged);
            this.txtSvcFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cost_Keypress);
            // 
            // panStaticRepairDetails
            // 
            this.panStaticRepairDetails.Controls.Add(this.dgvCheckInItems);
            this.panStaticRepairDetails.Controls.Add(this.BtnClearItem);
            this.panStaticRepairDetails.Controls.Add(this.lblRepairsInCI);
            this.panStaticRepairDetails.Controls.Add(this.BtnAddItem);
            this.panStaticRepairDetails.Controls.Add(this.panAccRadio);
            this.panStaticRepairDetails.Controls.Add(this.panPWradio);
            this.panStaticRepairDetails.Controls.Add(this.txtAddMfg);
            this.panStaticRepairDetails.Controls.Add(this.Label15);
            this.panStaticRepairDetails.Controls.Add(this.Label14);
            this.panStaticRepairDetails.Controls.Add(this.txtPass);
            this.panStaticRepairDetails.Controls.Add(this.LBaccEdit);
            this.panStaticRepairDetails.Controls.Add(this.labelACC);
            this.panStaticRepairDetails.Controls.Add(this.cbxMFGselect);
            this.panStaticRepairDetails.Controls.Add(this.cbxTypeDevice);
            this.panStaticRepairDetails.Controls.Add(this.Label7);
            this.panStaticRepairDetails.Controls.Add(this.Label6);
            this.panStaticRepairDetails.Controls.Add(this.Label5);
            this.panStaticRepairDetails.Controls.Add(this.Label4);
            this.panStaticRepairDetails.Location = new System.Drawing.Point(7, 111);
            this.panStaticRepairDetails.Name = "panStaticRepairDetails";
            this.panStaticRepairDetails.Size = new System.Drawing.Size(504, 370);
            this.panStaticRepairDetails.TabIndex = 90;
            // 
            // dgvCheckInItems
            // 
            this.dgvCheckInItems.AllowUserToAddRows = false;
            this.dgvCheckInItems.AllowUserToDeleteRows = false;
            this.dgvCheckInItems.AllowUserToResizeColumns = false;
            this.dgvCheckInItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.dgvCheckInItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCheckInItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCheckInItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCheckInItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCheckInItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCheckInItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheckInItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCheckInItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCheckInItems.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCheckInItems.Location = new System.Drawing.Point(242, 111);
            this.dgvCheckInItems.MaximumSize = new System.Drawing.Size(276, 146);
            this.dgvCheckInItems.MultiSelect = false;
            this.dgvCheckInItems.Name = "dgvCheckInItems";
            this.dgvCheckInItems.RowHeadersVisible = false;
            this.dgvCheckInItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckInItems.Size = new System.Drawing.Size(276, 146);
            this.dgvCheckInItems.TabIndex = 92;
            // 
            // BtnClearItem
            // 
            this.BtnClearItem.Location = new System.Drawing.Point(278, 308);
            this.BtnClearItem.Name = "BtnClearItem";
            this.BtnClearItem.Size = new System.Drawing.Size(198, 32);
            this.BtnClearItem.TabIndex = 93;
            this.BtnClearItem.Text = "Remove Repair";
            this.BtnClearItem.UseVisualStyleBackColor = true;
            this.BtnClearItem.Visible = false;
            this.BtnClearItem.Click += new System.EventHandler(this.BtnClearItem_Click);
            // 
            // lblRepairsInCI
            // 
            this.lblRepairsInCI.AutoSize = true;
            this.lblRepairsInCI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepairsInCI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRepairsInCI.Location = new System.Drawing.Point(308, 83);
            this.lblRepairsInCI.Name = "lblRepairsInCI";
            this.lblRepairsInCI.Size = new System.Drawing.Size(138, 25);
            this.lblRepairsInCI.TabIndex = 92;
            this.lblRepairsInCI.Text = "Repairs List";
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Location = new System.Drawing.Point(278, 270);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(198, 32);
            this.BtnAddItem.TabIndex = 60;
            this.BtnAddItem.Text = "Add Repair";
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // panAccRadio
            // 
            this.panAccRadio.Controls.Add(this.optAccYes);
            this.panAccRadio.Controls.Add(this.optAccNo);
            this.panAccRadio.Location = new System.Drawing.Point(81, 156);
            this.panAccRadio.Name = "panAccRadio";
            this.panAccRadio.Size = new System.Drawing.Size(144, 34);
            this.panAccRadio.TabIndex = 57;
            // 
            // optAccYes
            // 
            this.optAccYes.AutoSize = true;
            this.optAccYes.Location = new System.Drawing.Point(15, 8);
            this.optAccYes.Name = "optAccYes";
            this.optAccYes.Size = new System.Drawing.Size(43, 17);
            this.optAccYes.TabIndex = 21;
            this.optAccYes.Text = "Yes";
            this.optAccYes.UseVisualStyleBackColor = true;
            this.optAccYes.CheckedChanged += new System.EventHandler(this.OptAccCheckChanged);
            // 
            // optAccNo
            // 
            this.optAccNo.AutoSize = true;
            this.optAccNo.Checked = true;
            this.optAccNo.Location = new System.Drawing.Point(64, 8);
            this.optAccNo.Name = "optAccNo";
            this.optAccNo.Size = new System.Drawing.Size(39, 17);
            this.optAccNo.TabIndex = 22;
            this.optAccNo.TabStop = true;
            this.optAccNo.Text = "No";
            this.optAccNo.UseVisualStyleBackColor = true;
            this.optAccNo.CheckedChanged += new System.EventHandler(this.OptAccCheckChanged);
            // 
            // panPWradio
            // 
            this.panPWradio.Controls.Add(this.optPWYes);
            this.panPWradio.Controls.Add(this.optPWNo);
            this.panPWradio.Location = new System.Drawing.Point(75, 86);
            this.panPWradio.Name = "panPWradio";
            this.panPWradio.Size = new System.Drawing.Size(146, 32);
            this.panPWradio.TabIndex = 56;
            // 
            // optPWYes
            // 
            this.optPWYes.AutoSize = true;
            this.optPWYes.Location = new System.Drawing.Point(6, 7);
            this.optPWYes.Name = "optPWYes";
            this.optPWYes.Size = new System.Drawing.Size(43, 17);
            this.optPWYes.TabIndex = 16;
            this.optPWYes.Text = "Yes";
            this.optPWYes.UseVisualStyleBackColor = true;
            this.optPWYes.CheckedChanged += new System.EventHandler(this.OptPwCheckChanged);
            // 
            // optPWNo
            // 
            this.optPWNo.AutoSize = true;
            this.optPWNo.Checked = true;
            this.optPWNo.Location = new System.Drawing.Point(55, 7);
            this.optPWNo.Name = "optPWNo";
            this.optPWNo.Size = new System.Drawing.Size(39, 17);
            this.optPWNo.TabIndex = 17;
            this.optPWNo.TabStop = true;
            this.optPWNo.Text = "No";
            this.optPWNo.UseVisualStyleBackColor = true;
            this.optPWNo.CheckedChanged += new System.EventHandler(this.OptPwCheckChanged);
            // 
            // txtAddMfg
            // 
            this.txtAddMfg.Enabled = false;
            this.txtAddMfg.Location = new System.Drawing.Point(342, 41);
            this.txtAddMfg.MaxLength = 49;
            this.txtAddMfg.Name = "txtAddMfg";
            this.txtAddMfg.Size = new System.Drawing.Size(155, 20);
            this.txtAddMfg.TabIndex = 14;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(348, 25);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(98, 13);
            this.Label15.TabIndex = 27;
            this.Label15.Text = " Add Manufacturer:";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(9, 127);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(56, 13);
            this.Label14.TabIndex = 13;
            this.Label14.Text = "Password:";
            // 
            // txtPass
            // 
            this.txtPass.Enabled = false;
            this.txtPass.Location = new System.Drawing.Point(74, 124);
            this.txtPass.MaxLength = 49;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(155, 20);
            this.txtPass.TabIndex = 19;
            // 
            // LBaccEdit
            // 
            this.LBaccEdit.Enabled = false;
            this.LBaccEdit.FormattingEnabled = true;
            this.LBaccEdit.Location = new System.Drawing.Point(81, 196);
            this.LBaccEdit.Name = "LBaccEdit";
            this.LBaccEdit.Size = new System.Drawing.Size(155, 124);
            this.LBaccEdit.TabIndex = 53;
            // 
            // labelACC
            // 
            this.labelACC.AutoSize = true;
            this.labelACC.Location = new System.Drawing.Point(6, 196);
            this.labelACC.Name = "labelACC";
            this.labelACC.Size = new System.Drawing.Size(67, 13);
            this.labelACC.TabIndex = 54;
            this.labelACC.Text = "Accessories:";
            // 
            // cbxMFGselect
            // 
            this.cbxMFGselect.DropDownHeight = 125;
            this.cbxMFGselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMFGselect.FormattingEnabled = true;
            this.cbxMFGselect.IntegralHeight = false;
            this.cbxMFGselect.Location = new System.Drawing.Point(180, 41);
            this.cbxMFGselect.MaximumSize = new System.Drawing.Size(136, 0);
            this.cbxMFGselect.MinimumSize = new System.Drawing.Size(136, 0);
            this.cbxMFGselect.Name = "cbxMFGselect";
            this.cbxMFGselect.Size = new System.Drawing.Size(136, 21);
            this.cbxMFGselect.TabIndex = 48;
            // 
            // cbxTypeDevice
            // 
            this.cbxTypeDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypeDevice.FormattingEnabled = true;
            this.cbxTypeDevice.Location = new System.Drawing.Point(8, 41);
            this.cbxTypeDevice.Name = "cbxTypeDevice";
            this.cbxTypeDevice.Size = new System.Drawing.Size(136, 21);
            this.cbxTypeDevice.TabIndex = 47;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(-1, 163);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(82, 13);
            this.Label7.TabIndex = 46;
            this.Label7.Text = "Accessories?";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(0, 95);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(68, 13);
            this.Label6.TabIndex = 45;
            this.Label6.Text = "Password?";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(177, 25);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(76, 13);
            this.Label5.TabIndex = 44;
            this.Label5.Text = " Manufacturer:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(5, 25);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(83, 13);
            this.Label4.TabIndex = 43;
            this.Label4.Text = "Type of Device:";
            // 
            // CloseTimer
            // 
            this.CloseTimer.Enabled = true;
            this.CloseTimer.Interval = 1000;
            // 
            // chkTax
            // 
            this.chkTax.AutoSize = true;
            this.chkTax.Location = new System.Drawing.Point(716, 413);
            this.chkTax.Name = "chkTax";
            this.chkTax.Size = new System.Drawing.Size(74, 17);
            this.chkTax.TabIndex = 91;
            this.chkTax.Text = "Show Tax";
            this.chkTax.UseVisualStyleBackColor = true;
            this.chkTax.CheckStateChanged += new System.EventHandler(this.Cost_TextChanged);
            // 
            // PanSvcApproval
            // 
            this.PanSvcApproval.Controls.Add(this.OptSvcYes);
            this.PanSvcApproval.Controls.Add(this.OptSvcNo);
            this.PanSvcApproval.Location = new System.Drawing.Point(644, 436);
            this.PanSvcApproval.Name = "PanSvcApproval";
            this.PanSvcApproval.Size = new System.Drawing.Size(146, 32);
            this.PanSvcApproval.TabIndex = 58;
            // 
            // OptSvcYes
            // 
            this.OptSvcYes.AutoSize = true;
            this.OptSvcYes.Location = new System.Drawing.Point(6, 7);
            this.OptSvcYes.Name = "OptSvcYes";
            this.OptSvcYes.Size = new System.Drawing.Size(43, 17);
            this.OptSvcYes.TabIndex = 16;
            this.OptSvcYes.Text = "Yes";
            this.OptSvcYes.UseVisualStyleBackColor = true;
            // 
            // OptSvcNo
            // 
            this.OptSvcNo.AutoSize = true;
            this.OptSvcNo.Location = new System.Drawing.Point(55, 7);
            this.OptSvcNo.Name = "OptSvcNo";
            this.OptSvcNo.Size = new System.Drawing.Size(39, 17);
            this.OptSvcNo.TabIndex = 17;
            this.OptSvcNo.Text = "No";
            this.OptSvcNo.UseVisualStyleBackColor = true;
            // 
            // LblSvcApproved
            // 
            this.LblSvcApproved.AutoSize = true;
            this.LblSvcApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSvcApproved.Location = new System.Drawing.Point(523, 445);
            this.LblSvcApproved.Name = "LblSvcApproved";
            this.LblSvcApproved.Size = new System.Drawing.Size(115, 13);
            this.LblSvcApproved.TabIndex = 57;
            this.LblSvcApproved.Text = "Service Approved?";
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 467);
            this.Controls.Add(this.PanSvcApproval);
            this.Controls.Add(this.LblSvcApproved);
            this.Controls.Add(this.dgvNotesHistory);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.txtNoteAdd);
            this.Controls.Add(this.cmdAddNote);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.panViewCust);
            this.Controls.Add(this.panEditCust);
            this.Controls.Add(this.cmdClearNote);
            this.Controls.Add(this.txtPartCost);
            this.Controls.Add(this.txtSvcFee);
            this.Controls.Add(this.panStaticRepairDetails);
            this.Controls.Add(this.chkTax);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckInForm";
            this.Text = "CheckInForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckInForm_FormClosing);
            this.Load += new System.EventHandler(this.CheckInForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotesHistory)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panViewCust.ResumeLayout(false);
            this.panViewCust.PerformLayout();
            this.panEditCust.ResumeLayout(false);
            this.panEditCust.PerformLayout();
            this.panStaticRepairDetails.ResumeLayout(false);
            this.panStaticRepairDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInItems)).EndInit();
            this.panAccRadio.ResumeLayout(false);
            this.panAccRadio.PerformLayout();
            this.panPWradio.ResumeLayout(false);
            this.panPWradio.PerformLayout();
            this.PanSvcApproval.ResumeLayout(false);
            this.PanSvcApproval.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label18;
        public System.Windows.Forms.DataGridView dgvNotesHistory;
        internal System.Windows.Forms.TextBox txtCustName;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox txtTotalCost;
        internal System.Windows.Forms.TextBox txtNoteAdd;
        internal System.Windows.Forms.Button cmdAddNote;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton cmdSave;
        internal System.Windows.Forms.ToolStripButton cmdClose;
        internal System.Windows.Forms.Button cmdCustEdit;
        internal System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Panel panViewCust;
        internal System.Windows.Forms.MaskedTextBox txtTel2;
        internal System.Windows.Forms.MaskedTextBox txtTel1;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox txtCustEditLN;
        internal System.Windows.Forms.Button cmdSaveCustEdit;
        internal System.Windows.Forms.TextBox txtCustEditFN;
        internal System.Windows.Forms.Label Label13;
        public System.Windows.Forms.Panel panEditCust;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox txtTel2Edit;
        internal System.Windows.Forms.MaskedTextBox txtTel1Edit;
        internal System.Windows.Forms.PrintPreviewDialog PrintPreviewDialog1;
        internal System.Drawing.Printing.PrintDocument PrintDocument1;
        internal System.Windows.Forms.Button cmdClearNote;
        internal System.Windows.Forms.TextBox txtPartCost;
        internal System.Windows.Forms.TextBox txtSvcFee;
        internal System.Windows.Forms.Panel panStaticRepairDetails;
        internal System.Windows.Forms.Panel panAccRadio;
        internal System.Windows.Forms.RadioButton optAccYes;
        internal System.Windows.Forms.RadioButton optAccNo;
        internal System.Windows.Forms.Panel panPWradio;
        internal System.Windows.Forms.RadioButton optPWYes;
        internal System.Windows.Forms.RadioButton optPWNo;
        internal System.Windows.Forms.TextBox txtAddMfg;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtPass;
        internal System.Windows.Forms.CheckedListBox LBaccEdit;
        internal System.Windows.Forms.Label labelACC;
        internal System.Windows.Forms.ComboBox cbxMFGselect;
        internal System.Windows.Forms.ComboBox cbxTypeDevice;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Timer CloseTimer;
        internal System.Windows.Forms.CheckBox chkTax;
        private System.Windows.Forms.Button BtnAddItem;
        internal System.Windows.Forms.Panel PanSvcApproval;
        internal System.Windows.Forms.RadioButton OptSvcYes;
        internal System.Windows.Forms.RadioButton OptSvcNo;
        internal System.Windows.Forms.Label LblSvcApproved;
        internal System.Windows.Forms.Label lblRepairsInCI;
        private System.Windows.Forms.Button BtnClearItem;
        public System.Windows.Forms.DataGridView dgvCheckInItems;
    }
}