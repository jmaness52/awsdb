namespace SCR_Repair_Tracker
{
    partial class PartDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartDetailsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblPartDetailTitle = new System.Windows.Forms.Label();
            this.panViewCust = new System.Windows.Forms.Panel();
            this.txtTel2 = new System.Windows.Forms.MaskedTextBox();
            this.txtTel1 = new System.Windows.Forms.MaskedTextBox();
            this.cmdCustEdit = new System.Windows.Forms.Button();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.CbxVendorSelect = new System.Windows.Forms.ComboBox();
            this.LblVendor = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.CbxPartStatus = new System.Windows.Forms.ComboBox();
            this.TxtPartLink = new System.Windows.Forms.TextBox();
            this.LblPartLink = new System.Windows.Forms.Label();
            this.LblPriceBefore = new System.Windows.Forms.Label();
            this.LblPriceAfter = new System.Windows.Forms.Label();
            this.TxtPriceBefore = new System.Windows.Forms.TextBox();
            this.TxtPriceAfter = new System.Windows.Forms.TextBox();
            this.BtnEditDetails = new System.Windows.Forms.Button();
            this.lblNotePart = new System.Windows.Forms.Label();
            this.txtNoteAdd = new System.Windows.Forms.TextBox();
            this.tsPartOnlyControls = new System.Windows.Forms.ToolStrip();
            this.cmdSavePart = new System.Windows.Forms.ToolStripButton();
            this.cmdPrintPart = new System.Windows.Forms.ToolStripButton();
            this.cmdClosePart = new System.Windows.Forms.ToolStripButton();
            this.LblPartTitle = new System.Windows.Forms.Label();
            this.TxtPartDesc = new System.Windows.Forms.TextBox();
            this.panEditCust = new System.Windows.Forms.Panel();
            this.Label17 = new System.Windows.Forms.Label();
            this.txtTel2Edit = new System.Windows.Forms.MaskedTextBox();
            this.txtTel1Edit = new System.Windows.Forms.MaskedTextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.txtCustEditLN = new System.Windows.Forms.TextBox();
            this.cmdSaveCustEdit = new System.Windows.Forms.Button();
            this.txtCustEditFN = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.dgvNotesHistory = new System.Windows.Forms.DataGridView();
            this.BtnAddNote = new System.Windows.Forms.Button();
            this.TxtAddVendor = new System.Windows.Forms.TextBox();
            this.LblAddVendor = new System.Windows.Forms.Label();
            this.cmdClearNote = new System.Windows.Forms.Button();
            this.PanStaticDetails = new System.Windows.Forms.Panel();
            this.BtnLinkRepair = new System.Windows.Forms.Button();
            this.BtnGotoRepair = new System.Windows.Forms.Button();
            this.PanRepairConnection = new System.Windows.Forms.Panel();
            this.panViewCust.SuspendLayout();
            this.tsPartOnlyControls.SuspendLayout();
            this.panEditCust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotesHistory)).BeginInit();
            this.PanStaticDetails.SuspendLayout();
            this.PanRepairConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblPartDetailTitle
            // 
            this.LblPartDetailTitle.AutoSize = true;
            this.LblPartDetailTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPartDetailTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblPartDetailTitle.Location = new System.Drawing.Point(12, 9);
            this.LblPartDetailTitle.Name = "LblPartDetailTitle";
            this.LblPartDetailTitle.Size = new System.Drawing.Size(135, 25);
            this.LblPartDetailTitle.TabIndex = 66;
            this.LblPartDetailTitle.Text = "Part Details";
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
            this.panViewCust.Location = new System.Drawing.Point(17, 46);
            this.panViewCust.Name = "panViewCust";
            this.panViewCust.Size = new System.Drawing.Size(495, 85);
            this.panViewCust.TabIndex = 71;
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
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtCustName.Location = new System.Drawing.Point(4, 31);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(155, 20);
            this.txtCustName.TabIndex = 16;
            this.txtCustName.TabStop = false;
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
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(88, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Customer Name: ";
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
            // CbxVendorSelect
            // 
            this.CbxVendorSelect.DropDownHeight = 125;
            this.CbxVendorSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxVendorSelect.FormattingEnabled = true;
            this.CbxVendorSelect.IntegralHeight = false;
            this.CbxVendorSelect.Location = new System.Drawing.Point(7, 30);
            this.CbxVendorSelect.MaximumSize = new System.Drawing.Size(136, 0);
            this.CbxVendorSelect.MinimumSize = new System.Drawing.Size(136, 0);
            this.CbxVendorSelect.Name = "CbxVendorSelect";
            this.CbxVendorSelect.Size = new System.Drawing.Size(136, 21);
            this.CbxVendorSelect.TabIndex = 70;
            this.CbxVendorSelect.SelectionChangeCommitted += new System.EventHandler(this.cbxVendorSelect_SelectionChangeCommitted);
            // 
            // LblVendor
            // 
            this.LblVendor.AutoSize = true;
            this.LblVendor.Location = new System.Drawing.Point(52, 176);
            this.LblVendor.Name = "LblVendor";
            this.LblVendor.Size = new System.Drawing.Size(44, 13);
            this.LblVendor.TabIndex = 66;
            this.LblVendor.Text = "Vendor:";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(107, 325);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(40, 13);
            this.LblStatus.TabIndex = 79;
            this.LblStatus.Text = "Status:";
            // 
            // CbxPartStatus
            // 
            this.CbxPartStatus.DropDownHeight = 125;
            this.CbxPartStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxPartStatus.FormattingEnabled = true;
            this.CbxPartStatus.IntegralHeight = false;
            this.CbxPartStatus.Location = new System.Drawing.Point(105, 341);
            this.CbxPartStatus.MaximumSize = new System.Drawing.Size(136, 0);
            this.CbxPartStatus.MinimumSize = new System.Drawing.Size(136, 0);
            this.CbxPartStatus.Name = "CbxPartStatus";
            this.CbxPartStatus.Size = new System.Drawing.Size(136, 21);
            this.CbxPartStatus.TabIndex = 80;
            // 
            // TxtPartLink
            // 
            this.TxtPartLink.Location = new System.Drawing.Point(7, 97);
            this.TxtPartLink.Name = "TxtPartLink";
            this.TxtPartLink.Size = new System.Drawing.Size(228, 20);
            this.TxtPartLink.TabIndex = 85;
            // 
            // LblPartLink
            // 
            this.LblPartLink.AutoSize = true;
            this.LblPartLink.Location = new System.Drawing.Point(44, 243);
            this.LblPartLink.Name = "LblPartLink";
            this.LblPartLink.Size = new System.Drawing.Size(52, 13);
            this.LblPartLink.TabIndex = 86;
            this.LblPartLink.Text = "Part Link:";
            // 
            // LblPriceBefore
            // 
            this.LblPriceBefore.AutoSize = true;
            this.LblPriceBefore.Location = new System.Drawing.Point(560, 396);
            this.LblPriceBefore.Name = "LblPriceBefore";
            this.LblPriceBefore.Size = new System.Drawing.Size(126, 13);
            this.LblPriceBefore.TabIndex = 87;
            this.LblPriceBefore.Text = "Part Cost Before Markup:";
            // 
            // LblPriceAfter
            // 
            this.LblPriceAfter.AutoSize = true;
            this.LblPriceAfter.Location = new System.Drawing.Point(598, 419);
            this.LblPriceAfter.Name = "LblPriceAfter";
            this.LblPriceAfter.Size = new System.Drawing.Size(88, 13);
            this.LblPriceAfter.TabIndex = 88;
            this.LblPriceAfter.Text = "Customer\'s Price:";
            // 
            // TxtPriceBefore
            // 
            this.TxtPriceBefore.Location = new System.Drawing.Point(692, 393);
            this.TxtPriceBefore.Name = "TxtPriceBefore";
            this.TxtPriceBefore.Size = new System.Drawing.Size(40, 20);
            this.TxtPriceBefore.TabIndex = 89;
            this.TxtPriceBefore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cost_Keypress);
            // 
            // TxtPriceAfter
            // 
            this.TxtPriceAfter.Location = new System.Drawing.Point(692, 416);
            this.TxtPriceAfter.Name = "TxtPriceAfter";
            this.TxtPriceAfter.Size = new System.Drawing.Size(40, 20);
            this.TxtPriceAfter.TabIndex = 90;
            this.TxtPriceAfter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cost_Keypress);
            // 
            // BtnEditDetails
            // 
            this.BtnEditDetails.Location = new System.Drawing.Point(260, 97);
            this.BtnEditDetails.Name = "BtnEditDetails";
            this.BtnEditDetails.Size = new System.Drawing.Size(134, 25);
            this.BtnEditDetails.TabIndex = 91;
            this.BtnEditDetails.Text = "Edit Part Details";
            this.BtnEditDetails.UseVisualStyleBackColor = true;
            this.BtnEditDetails.Click += new System.EventHandler(this.BtnEditDetails_Click);
            // 
            // lblNotePart
            // 
            this.lblNotePart.AutoSize = true;
            this.lblNotePart.Location = new System.Drawing.Point(508, 238);
            this.lblNotePart.Name = "lblNotePart";
            this.lblNotePart.Size = new System.Drawing.Size(33, 13);
            this.lblNotePart.TabIndex = 93;
            this.lblNotePart.Text = "Note:";
            // 
            // txtNoteAdd
            // 
            this.txtNoteAdd.Location = new System.Drawing.Point(547, 238);
            this.txtNoteAdd.MaxLength = 150;
            this.txtNoteAdd.Multiline = true;
            this.txtNoteAdd.Name = "txtNoteAdd";
            this.txtNoteAdd.Size = new System.Drawing.Size(224, 49);
            this.txtNoteAdd.TabIndex = 94;
            this.txtNoteAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoteAdd_KeyPress);
            // 
            // tsPartOnlyControls
            // 
            this.tsPartOnlyControls.AutoSize = false;
            this.tsPartOnlyControls.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPartOnlyControls.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPartOnlyControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSavePart,
            this.cmdPrintPart,
            this.cmdClosePart});
            this.tsPartOnlyControls.Location = new System.Drawing.Point(547, 296);
            this.tsPartOnlyControls.Name = "tsPartOnlyControls";
            this.tsPartOnlyControls.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPartOnlyControls.Size = new System.Drawing.Size(224, 66);
            this.tsPartOnlyControls.TabIndex = 95;
            this.tsPartOnlyControls.TabStop = true;
            // 
            // cmdSavePart
            // 
            this.cmdSavePart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSavePart.Image = ((System.Drawing.Image)(resources.GetObject("cmdSavePart.Image")));
            this.cmdSavePart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSavePart.Name = "cmdSavePart";
            this.cmdSavePart.Size = new System.Drawing.Size(60, 63);
            this.cmdSavePart.Text = "Save";
            this.cmdSavePart.Click += new System.EventHandler(this.cmdSavePart_Click);
            // 
            // cmdPrintPart
            // 
            this.cmdPrintPart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintPart.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrintPart.Image")));
            this.cmdPrintPart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPrintPart.Name = "cmdPrintPart";
            this.cmdPrintPart.Size = new System.Drawing.Size(59, 63);
            this.cmdPrintPart.Text = "Print";
            // 
            // cmdClosePart
            // 
            this.cmdClosePart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClosePart.Image = ((System.Drawing.Image)(resources.GetObject("cmdClosePart.Image")));
            this.cmdClosePart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdClosePart.Name = "cmdClosePart";
            this.cmdClosePart.Size = new System.Drawing.Size(57, 63);
            this.cmdClosePart.Text = "Exit ";
            this.cmdClosePart.Click += new System.EventHandler(this.cmdClosePart_Click);
            // 
            // LblPartTitle
            // 
            this.LblPartTitle.AutoSize = true;
            this.LblPartTitle.Location = new System.Drawing.Point(11, 274);
            this.LblPartTitle.Name = "LblPartTitle";
            this.LblPartTitle.Size = new System.Drawing.Size(85, 13);
            this.LblPartTitle.TabIndex = 96;
            this.LblPartTitle.Text = "Part Description:";
            // 
            // TxtPartDesc
            // 
            this.TxtPartDesc.Location = new System.Drawing.Point(7, 129);
            this.TxtPartDesc.Name = "TxtPartDesc";
            this.TxtPartDesc.Size = new System.Drawing.Size(228, 20);
            this.TxtPartDesc.TabIndex = 97;
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
            this.panEditCust.Location = new System.Drawing.Point(17, 46);
            this.panEditCust.Name = "panEditCust";
            this.panEditCust.Size = new System.Drawing.Size(495, 85);
            this.panEditCust.TabIndex = 69;
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
            this.dgvNotesHistory.Location = new System.Drawing.Point(518, 3);
            this.dgvNotesHistory.MultiSelect = false;
            this.dgvNotesHistory.Name = "dgvNotesHistory";
            this.dgvNotesHistory.RowHeadersVisible = false;
            this.dgvNotesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotesHistory.Size = new System.Drawing.Size(346, 194);
            this.dgvNotesHistory.TabIndex = 98;
            this.dgvNotesHistory.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNotesHistory_CellMouseDoubleClick);
            // 
            // BtnAddNote
            // 
            this.BtnAddNote.Location = new System.Drawing.Point(777, 252);
            this.BtnAddNote.Name = "BtnAddNote";
            this.BtnAddNote.Size = new System.Drawing.Size(75, 21);
            this.BtnAddNote.TabIndex = 99;
            this.BtnAddNote.Text = "Add Note";
            this.BtnAddNote.UseVisualStyleBackColor = true;
            this.BtnAddNote.Click += new System.EventHandler(this.cmdAddNote_Click);
            // 
            // TxtAddVendor
            // 
            this.TxtAddVendor.Enabled = false;
            this.TxtAddVendor.Location = new System.Drawing.Point(235, 27);
            this.TxtAddVendor.Name = "TxtAddVendor";
            this.TxtAddVendor.Size = new System.Drawing.Size(167, 20);
            this.TxtAddVendor.TabIndex = 104;
            // 
            // LblAddVendor
            // 
            this.LblAddVendor.AutoSize = true;
            this.LblAddVendor.Location = new System.Drawing.Point(163, 30);
            this.LblAddVendor.Name = "LblAddVendor";
            this.LblAddVendor.Size = new System.Drawing.Size(66, 13);
            this.LblAddVendor.TabIndex = 105;
            this.LblAddVendor.Text = "Add Vendor:";
            // 
            // cmdClearNote
            // 
            this.cmdClearNote.Location = new System.Drawing.Point(578, 203);
            this.cmdClearNote.Name = "cmdClearNote";
            this.cmdClearNote.Size = new System.Drawing.Size(186, 21);
            this.cmdClearNote.TabIndex = 106;
            this.cmdClearNote.TabStop = false;
            this.cmdClearNote.Text = "Clear Selected Note";
            this.cmdClearNote.UseVisualStyleBackColor = true;
            this.cmdClearNote.Click += new System.EventHandler(this.cmdClearNote_Click);
            // 
            // PanStaticDetails
            // 
            this.PanStaticDetails.Controls.Add(this.LblAddVendor);
            this.PanStaticDetails.Controls.Add(this.TxtPartDesc);
            this.PanStaticDetails.Controls.Add(this.TxtAddVendor);
            this.PanStaticDetails.Controls.Add(this.TxtPartLink);
            this.PanStaticDetails.Controls.Add(this.BtnEditDetails);
            this.PanStaticDetails.Controls.Add(this.CbxVendorSelect);
            this.PanStaticDetails.Location = new System.Drawing.Point(95, 146);
            this.PanStaticDetails.Name = "PanStaticDetails";
            this.PanStaticDetails.Size = new System.Drawing.Size(407, 177);
            this.PanStaticDetails.TabIndex = 107;
            // 
            // BtnLinkRepair
            // 
            this.BtnLinkRepair.Location = new System.Drawing.Point(16, 12);
            this.BtnLinkRepair.Name = "BtnLinkRepair";
            this.BtnLinkRepair.Size = new System.Drawing.Size(134, 25);
            this.BtnLinkRepair.TabIndex = 103;
            this.BtnLinkRepair.Text = "Attach to a Repair";
            this.BtnLinkRepair.UseVisualStyleBackColor = true;
            this.BtnLinkRepair.Click += new System.EventHandler(this.BtnLinkRepair_Click);
            // 
            // BtnGotoRepair
            // 
            this.BtnGotoRepair.Location = new System.Drawing.Point(16, 43);
            this.BtnGotoRepair.Name = "BtnGotoRepair";
            this.BtnGotoRepair.Size = new System.Drawing.Size(134, 25);
            this.BtnGotoRepair.TabIndex = 108;
            this.BtnGotoRepair.Text = "View Repair";
            this.BtnGotoRepair.UseVisualStyleBackColor = true;
            this.BtnGotoRepair.Click += new System.EventHandler(this.BtnGotoRepair_Click);
            // 
            // PanRepairConnection
            // 
            this.PanRepairConnection.Controls.Add(this.BtnLinkRepair);
            this.PanRepairConnection.Controls.Add(this.BtnGotoRepair);
            this.PanRepairConnection.Location = new System.Drawing.Point(343, 359);
            this.PanRepairConnection.Name = "PanRepairConnection";
            this.PanRepairConnection.Size = new System.Drawing.Size(169, 77);
            this.PanRepairConnection.TabIndex = 104;
            this.PanRepairConnection.Visible = false;
            // 
            // PartDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 467);
            this.ControlBox = false;
            this.Controls.Add(this.PanRepairConnection);
            this.Controls.Add(this.PanStaticDetails);
            this.Controls.Add(this.cmdClearNote);
            this.Controls.Add(this.BtnAddNote);
            this.Controls.Add(this.dgvNotesHistory);
            this.Controls.Add(this.LblPartTitle);
            this.Controls.Add(this.tsPartOnlyControls);
            this.Controls.Add(this.txtNoteAdd);
            this.Controls.Add(this.lblNotePart);
            this.Controls.Add(this.TxtPriceAfter);
            this.Controls.Add(this.TxtPriceBefore);
            this.Controls.Add(this.LblPriceAfter);
            this.Controls.Add(this.LblPriceBefore);
            this.Controls.Add(this.LblPartLink);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.CbxPartStatus);
            this.Controls.Add(this.panViewCust);
            this.Controls.Add(this.panEditCust);
            this.Controls.Add(this.LblPartDetailTitle);
            this.Controls.Add(this.LblVendor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PartDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Part Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartDetailsForm_FormClosing);
            this.panViewCust.ResumeLayout(false);
            this.panViewCust.PerformLayout();
            this.tsPartOnlyControls.ResumeLayout(false);
            this.tsPartOnlyControls.PerformLayout();
            this.panEditCust.ResumeLayout(false);
            this.panEditCust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotesHistory)).EndInit();
            this.PanStaticDetails.ResumeLayout(false);
            this.PanStaticDetails.PerformLayout();
            this.PanRepairConnection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblPartDetailTitle;
        public System.Windows.Forms.Panel panViewCust;
        internal System.Windows.Forms.MaskedTextBox txtTel2;
        internal System.Windows.Forms.MaskedTextBox txtTel1;
        internal System.Windows.Forms.Button cmdCustEdit;
        internal System.Windows.Forms.TextBox txtCustName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox CbxVendorSelect;
        internal System.Windows.Forms.Label LblVendor;
        internal System.Windows.Forms.Label LblStatus;
        internal System.Windows.Forms.ComboBox CbxPartStatus;
        private System.Windows.Forms.Label LblPartLink;
        private System.Windows.Forms.Label LblPriceBefore;
        private System.Windows.Forms.Label LblPriceAfter;
        internal System.Windows.Forms.Button BtnEditDetails;
        private System.Windows.Forms.Label lblNotePart;
        internal System.Windows.Forms.TextBox txtNoteAdd;
        internal System.Windows.Forms.ToolStrip tsPartOnlyControls;
        internal System.Windows.Forms.ToolStripButton cmdSavePart;
        internal System.Windows.Forms.ToolStripButton cmdPrintPart;
        internal System.Windows.Forms.ToolStripButton cmdClosePart;
        private System.Windows.Forms.Label LblPartTitle;
        public System.Windows.Forms.Panel panEditCust;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox txtTel2Edit;
        internal System.Windows.Forms.MaskedTextBox txtTel1Edit;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox txtCustEditLN;
        internal System.Windows.Forms.Button cmdSaveCustEdit;
        internal System.Windows.Forms.TextBox txtCustEditFN;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label18;
        public System.Windows.Forms.DataGridView dgvNotesHistory;
        internal System.Windows.Forms.Button BtnAddNote;
        private System.Windows.Forms.TextBox TxtAddVendor;
        internal System.Windows.Forms.Label LblAddVendor;
        internal System.Windows.Forms.Button cmdClearNote;
        internal System.Windows.Forms.TextBox TxtPriceBefore;
        internal System.Windows.Forms.TextBox TxtPriceAfter;
        internal System.Windows.Forms.TextBox TxtPartLink;
        internal System.Windows.Forms.TextBox TxtPartDesc;
        internal System.Windows.Forms.Panel PanStaticDetails;
        internal System.Windows.Forms.Button BtnLinkRepair;
        internal System.Windows.Forms.Button BtnGotoRepair;
        internal System.Windows.Forms.Panel PanRepairConnection;
    }
}