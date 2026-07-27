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
            components = new System.ComponentModel.Container();
            ctrlAppointmentInfo1 = new Dental.WinForms.UserControls.Info.ctrlAppointmentInfo();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnClose = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // ctrlAppointmentInfo1
            // 
            ctrlAppointmentInfo1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlAppointmentInfo1.Location = new Point(0, 62);
            ctrlAppointmentInfo1.Margin = new Padding(4);
            ctrlAppointmentInfo1.MaximumSize = new Size(942, 287);
            ctrlAppointmentInfo1.MinimumSize = new Size(942, 287);
            ctrlAppointmentInfo1.Name = "ctrlAppointmentInfo1";
            ctrlAppointmentInfo1.RightToLeft = RightToLeft.Yes;
            ctrlAppointmentInfo1.Size = new Size(942, 287);
            ctrlAppointmentInfo1.TabIndex = 0;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.AnimateWindow = true;
            guna2BorderlessForm1.AnimationInterval = 270;
            guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            guna2BorderlessForm1.BorderRadius = 85;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.HasFormShadow = false;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnClose
            // 
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.Red;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 38;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(887, 12);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(43, 39);
            btnClose.TabIndex = 13;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmAppointmentInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 356);
            Controls.Add(btnClose);
            Controls.Add(ctrlAppointmentInfo1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
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
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}