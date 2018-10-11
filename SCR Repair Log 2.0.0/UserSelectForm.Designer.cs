namespace SCR_Repair_Tracker
{
    partial class UserSelectForm
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
            this.FlowUserSelect = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FlowUserSelect
            // 
            this.FlowUserSelect.AutoScroll = true;
            this.FlowUserSelect.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowUserSelect.Location = new System.Drawing.Point(35, 26);
            this.FlowUserSelect.Name = "FlowUserSelect";
            this.FlowUserSelect.Padding = new System.Windows.Forms.Padding(25);
            this.FlowUserSelect.Size = new System.Drawing.Size(250, 275);
            this.FlowUserSelect.TabIndex = 0;
            // 
            // UserSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 313);
            this.Controls.Add(this.FlowUserSelect);
            this.Name = "UserSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select User";
            this.Load += new System.EventHandler(this.UserSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowUserSelect;
    }
}