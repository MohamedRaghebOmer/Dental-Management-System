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
            pbDoctorImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lblDoctorName = new Label();
            lblDescription = new Label();
            lblPhoneNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)pbDoctorImage).BeginInit();
            SuspendLayout();
            // 
            // pbDoctorImage
            // 
            pbDoctorImage.BackgroundImageLayout = ImageLayout.Zoom;
            pbDoctorImage.Image = Properties.Resources.user_512;
            pbDoctorImage.ImageRotate = 0F;
            pbDoctorImage.Location = new Point(374, 0);
            pbDoctorImage.Margin = new Padding(4);
            pbDoctorImage.Name = "pbDoctorImage";
            pbDoctorImage.ShadowDecoration.CustomizableEdges = customizableEdges1;
            pbDoctorImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pbDoctorImage.Size = new Size(100, 100);
            pbDoctorImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbDoctorImage.TabIndex = 0;
            pbDoctorImage.TabStop = false;
            pbDoctorImage.Click += pbDoctorImage_Click;
            // 
            // lblDoctorName
            // 
            lblDoctorName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoctorName.Location = new Point(4, 12);
            lblDoctorName.Margin = new Padding(4, 0, 4, 0);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(362, 31);
            lblDoctorName.TabIndex = 1;
            lblDoctorName.Text = "د/ كريم فتوح";
            lblDoctorName.TextAlign = ContentAlignment.MiddleLeft;
            lblDoctorName.Click += pbDoctorImage_Click;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(0, 43);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(365, 23);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "طب الفم والأسنان";
            lblDescription.TextAlign = ContentAlignment.MiddleLeft;
            lblDescription.Click += pbDoctorImage_Click;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhoneNumber.Location = new Point(0, 66);
            lblPhoneNumber.Margin = new Padding(4, 0, 4, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.RightToLeft = RightToLeft.Yes;
            lblPhoneNumber.Size = new Size(361, 23);
            lblPhoneNumber.TabIndex = 3;
            lblPhoneNumber.Text = "01006169816";
            lblPhoneNumber.TextAlign = ContentAlignment.MiddleLeft;
            lblPhoneNumber.Click += pbDoctorImage_Click;
            // 
            // ctrlProfile
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblDescription);
            Controls.Add(lblDoctorName);
            Controls.Add(pbDoctorImage);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(474, 100);
            MinimumSize = new Size(474, 100);
            Name = "ctrlProfile";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(474, 100);
            Click += pbDoctorImage_Click;
            ((System.ComponentModel.ISupportInitialize)pbDoctorImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox pbDoctorImage;
        private Label lblDoctorName;
        private Label lblDescription;
        private Label lblPhoneNumber;
    }
}
