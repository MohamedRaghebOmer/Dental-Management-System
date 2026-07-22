namespace Dental.WinForms.Forms
{
    partial class frmAppointmentInfo
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
            ctrlAppointmentInfo1 = new Dental.WinForms.UserControls.Info.ctrlAppointmentInfo();
            SuspendLayout();
            // 
            // ctrlAppointmentInfo1
            // 
            ctrlAppointmentInfo1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlAppointmentInfo1.Location = new Point(-2, 13);
            ctrlAppointmentInfo1.Margin = new Padding(4);
            ctrlAppointmentInfo1.MaximumSize = new Size(942, 287);
            ctrlAppointmentInfo1.MinimumSize = new Size(942, 287);
            ctrlAppointmentInfo1.Name = "ctrlAppointmentInfo1";
            ctrlAppointmentInfo1.RightToLeft = RightToLeft.Yes;
            ctrlAppointmentInfo1.Size = new Size(942, 287);
            ctrlAppointmentInfo1.TabIndex = 0;
            // 
            // frmAppointmentInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 316);
            Controls.Add(ctrlAppointmentInfo1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAppointmentInfo";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تفاصيل الحجز";
            Load += frmAppointmentInfo_Load;
            ResumeLayout(false);
        }

        #endregion

        private UserControls.Info.ctrlAppointmentInfo ctrlAppointmentInfo1;
    }
}