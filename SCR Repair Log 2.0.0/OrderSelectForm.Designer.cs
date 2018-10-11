namespace SCR_Repair_Tracker
{
    partial class OrderSelectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderSelectForm));
            this.dgvOrderSelect = new System.Windows.Forms.DataGridView();
            this.LblInstruct = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderSelect
            // 
            this.dgvOrderSelect.AllowUserToAddRows = false;
            this.dgvOrderSelect.AllowUserToDeleteRows = false;
            this.dgvOrderSelect.AllowUserToResizeColumns = false;
            this.dgvOrderSelect.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvOrderSelect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderSelect.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderSelect.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrderSelect.EnableHeadersVisualStyles = false;
            this.dgvOrderSelect.Location = new System.Drawing.Point(12, 64);
            this.dgvOrderSelect.MaximumSize = new System.Drawing.Size(550, 350);
            this.dgvOrderSelect.MultiSelect = false;
            this.dgvOrderSelect.Name = "dgvOrderSelect";
            this.dgvOrderSelect.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderSelect.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrderSelect.RowHeadersVisible = false;
            this.dgvOrderSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderSelect.Size = new System.Drawing.Size(520, 185);
            this.dgvOrderSelect.TabIndex = 8;
            this.dgvOrderSelect.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrderSelect_CellMouseDoubleClick);
            // 
            // LblInstruct
            // 
            this.LblInstruct.BackColor = System.Drawing.Color.Transparent;
            this.LblInstruct.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInstruct.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblInstruct.Location = new System.Drawing.Point(12, 9);
            this.LblInstruct.Name = "LblInstruct";
            this.LblInstruct.Size = new System.Drawing.Size(520, 36);
            this.LblInstruct.TabIndex = 10;
            this.LblInstruct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 261);
            this.ControlBox = false;
            this.Controls.Add(this.LblInstruct);
            this.Controls.Add(this.dgvOrderSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderSelectForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvOrderSelect;
        internal System.Windows.Forms.Label LblInstruct;
    }
}