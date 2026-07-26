namespace Dental.WinForms.UserControls
{
    partial class ctrlNotification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNumber = new Label();
            pbBill = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbBill).BeginInit();
            SuspendLayout();
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.BackColor = Color.Transparent;
            lblNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumber.Location = new Point(36, 13);
            lblNumber.Margin = new Padding(4, 0, 4, 0);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(19, 23);
            lblNumber.TabIndex = 4;
            lblNumber.Text = "0";
            lblNumber.Visible = false;
            // 
            // pbBill
            // 
            pbBill.BackColor = Color.Transparent;
            pbBill.BackgroundImage = Properties.Resources.bell_512;
            pbBill.BackgroundImageLayout = ImageLayout.Zoom;
            pbBill.Location = new Point(4, 0);
            pbBill.Margin = new Padding(4);
            pbBill.Name = "pbBill";
            pbBill.Size = new Size(29, 39);
            pbBill.TabIndex = 3;
            pbBill.TabStop = false;
            // 
            // ctrlNotification
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblNumber);
            Controls.Add(pbBill);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(70, 45);
            MinimumSize = new Size(70, 45);
            Name = "ctrlNotification";
            Size = new Size(70, 45);
            ((System.ComponentModel.ISupportInitialize)pbBill).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumber;
        private PictureBox pbBill;
    }
}
