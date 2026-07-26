namespace Dental.WinForms.UserControls
{
    partial class ctrlProfile
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pbDoctorPicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lblDocktorName = new Label();
            lblDescription = new Label();
            lblPhoneNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)pbDoctorPicture).BeginInit();
            SuspendLayout();
            // 
            // pbDoctorPicture
            // 
            pbDoctorPicture.BackgroundImage = Properties.Resources.user_512;
            pbDoctorPicture.BackgroundImageLayout = ImageLayout.Zoom;
            pbDoctorPicture.Image = Properties.Resources.user_512;
            pbDoctorPicture.ImageRotate = 0F;
            pbDoctorPicture.Location = new Point(293, 0);
            pbDoctorPicture.Margin = new Padding(4);
            pbDoctorPicture.Name = "pbDoctorPicture";
            pbDoctorPicture.ShadowDecoration.CustomizableEdges = customizableEdges1;
            pbDoctorPicture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pbDoctorPicture.Size = new Size(82, 96);
            pbDoctorPicture.TabIndex = 0;
            pbDoctorPicture.TabStop = false;
            // 
            // lblDocktorName
            // 
            lblDocktorName.AutoSize = true;
            lblDocktorName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDocktorName.Location = new Point(145, 12);
            lblDocktorName.Margin = new Padding(4, 0, 4, 0);
            lblDocktorName.Name = "lblDocktorName";
            lblDocktorName.Size = new Size(140, 31);
            lblDocktorName.TabIndex = 1;
            lblDocktorName.Text = "د/ كريم فتوح";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(147, 43);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(137, 23);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "طب الفم والأسنان";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhoneNumber.Location = new Point(150, 66);
            lblPhoneNumber.Margin = new Padding(4, 0, 4, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.RightToLeft = RightToLeft.No;
            lblPhoneNumber.Size = new Size(130, 23);
            lblPhoneNumber.TabIndex = 3;
            lblPhoneNumber.Text = "+201006169816";
            // 
            // ctrlProfile
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblDescription);
            Controls.Add(lblDocktorName);
            Controls.Add(pbDoctorPicture);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(378, 100);
            MinimumSize = new Size(378, 100);
            Name = "ctrlProfile";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(378, 100);
            ((System.ComponentModel.ISupportInitialize)pbDoctorPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox pbDoctorPicture;
        private Label lblDocktorName;
        private Label lblDescription;
        private Label lblPhoneNumber;
    }
}
