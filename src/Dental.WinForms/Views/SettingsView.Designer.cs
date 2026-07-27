namespace Dental.WinForms.Views
{
    partial class SettingsView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtDoctorName = new Guna.UI2.WinForms.Guna2TextBox();
            txtPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            pbDoctorImage = new PictureBox();
            pbDentalImage = new PictureBox();
            txtDentalDescription = new Guna.UI2.WinForms.Guna2TextBox();
            txtDentalName = new Guna.UI2.WinForms.Guna2TextBox();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnResetDocktorImage = new FontAwesome.Sharp.IconButton();
            btnResetDentalImage = new FontAwesome.Sharp.IconButton();
            btnChangeDoctorImage = new FontAwesome.Sharp.IconButton();
            btnChangeDentalImage = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pbDoctorImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDentalImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(1417, 81);
            label1.Name = "label1";
            label1.Size = new Size(138, 31);
            label1.TabIndex = 0;
            label1.Text = "اسم الدكتور :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(50, 50, 50);
            label2.Location = new Point(605, 193);
            label2.Name = "label2";
            label2.Size = new Size(172, 31);
            label2.TabIndex = 9;
            label2.Text = "تخصص العياده :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(50, 50, 50);
            label3.Location = new Point(1431, 193);
            label3.Name = "label3";
            label3.Size = new Size(128, 31);
            label3.TabIndex = 2;
            label3.Text = "رقم الهاتف :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(50, 50, 50);
            label4.Location = new Point(1400, 353);
            label4.Name = "label4";
            label4.Size = new Size(155, 31);
            label4.TabIndex = 4;
            label4.Text = "صورة الدكتور :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(50, 50, 50);
            label5.Location = new Point(625, 353);
            label5.Name = "label5";
            label5.Size = new Size(152, 31);
            label5.TabIndex = 5;
            label5.Text = "صورة العياده :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(50, 50, 50);
            label6.Location = new Point(642, 81);
            label6.Name = "label6";
            label6.Size = new Size(135, 31);
            label6.TabIndex = 7;
            label6.Text = "إسم العياده :";
            // 
            // txtDoctorName
            // 
            txtDoctorName.Animated = true;
            txtDoctorName.AutoRoundedCorners = true;
            txtDoctorName.BorderRadius = 22;
            txtDoctorName.CustomizableEdges = customizableEdges1;
            txtDoctorName.DefaultText = "";
            txtDoctorName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDoctorName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDoctorName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDoctorName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDoctorName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDoctorName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDoctorName.ForeColor = Color.Black;
            txtDoctorName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDoctorName.Location = new Point(943, 73);
            txtDoctorName.Margin = new Padding(4, 6, 4, 6);
            txtDoctorName.MaxLength = 30;
            txtDoctorName.Name = "txtDoctorName";
            txtDoctorName.PlaceholderText = "";
            txtDoctorName.SelectedText = "";
            txtDoctorName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtDoctorName.Size = new Size(308, 46);
            txtDoctorName.TabIndex = 0;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Animated = true;
            txtPhoneNumber.AutoRoundedCorners = true;
            txtPhoneNumber.BorderRadius = 22;
            txtPhoneNumber.CustomizableEdges = customizableEdges3;
            txtPhoneNumber.DefaultText = "";
            txtPhoneNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPhoneNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPhoneNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.ForeColor = Color.Black;
            txtPhoneNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Location = new Point(943, 185);
            txtPhoneNumber.Margin = new Padding(4, 6, 4, 6);
            txtPhoneNumber.MaxLength = 11;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "";
            txtPhoneNumber.SelectedText = "";
            txtPhoneNumber.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPhoneNumber.Size = new Size(308, 46);
            txtPhoneNumber.TabIndex = 1;
            // 
            // pbDoctorImage
            // 
            pbDoctorImage.BorderStyle = BorderStyle.FixedSingle;
            pbDoctorImage.ErrorImage = Properties.Resources.user_512;
            pbDoctorImage.Image = Properties.Resources.user_512;
            pbDoctorImage.InitialImage = Properties.Resources.user_512;
            pbDoctorImage.Location = new Point(800, 353);
            pbDoctorImage.Name = "pbDoctorImage";
            pbDoctorImage.Size = new Size(594, 596);
            pbDoctorImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbDoctorImage.TabIndex = 9;
            pbDoctorImage.TabStop = false;
            // 
            // pbDentalImage
            // 
            pbDentalImage.BorderStyle = BorderStyle.FixedSingle;
            pbDentalImage.ErrorImage = Properties.Resources.tooth_512;
            pbDentalImage.Image = Properties.Resources.tooth_512;
            pbDentalImage.InitialImage = Properties.Resources.tooth_512;
            pbDentalImage.Location = new Point(3, 353);
            pbDentalImage.Name = "pbDentalImage";
            pbDentalImage.Size = new Size(616, 596);
            pbDentalImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbDentalImage.TabIndex = 10;
            pbDentalImage.TabStop = false;
            // 
            // txtDentalDescription
            // 
            txtDentalDescription.Animated = true;
            txtDentalDescription.AutoRoundedCorners = true;
            txtDentalDescription.BorderRadius = 22;
            txtDentalDescription.CustomizableEdges = customizableEdges5;
            txtDentalDescription.DefaultText = "";
            txtDentalDescription.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDentalDescription.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDentalDescription.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDentalDescription.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDentalDescription.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDentalDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDentalDescription.ForeColor = Color.Black;
            txtDentalDescription.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDentalDescription.Location = new Point(147, 185);
            txtDentalDescription.Margin = new Padding(4, 6, 4, 6);
            txtDentalDescription.MaxLength = 100;
            txtDentalDescription.Name = "txtDentalDescription";
            txtDentalDescription.PlaceholderText = "";
            txtDentalDescription.SelectedText = "";
            txtDentalDescription.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDentalDescription.Size = new Size(308, 46);
            txtDentalDescription.TabIndex = 3;
            // 
            // txtDentalName
            // 
            txtDentalName.Animated = true;
            txtDentalName.AutoRoundedCorners = true;
            txtDentalName.BorderRadius = 22;
            txtDentalName.CustomizableEdges = customizableEdges7;
            txtDentalName.DefaultText = "";
            txtDentalName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDentalName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDentalName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDentalName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDentalName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDentalName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDentalName.ForeColor = Color.Black;
            txtDentalName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDentalName.Location = new Point(147, 73);
            txtDentalName.Margin = new Padding(4, 6, 4, 6);
            txtDentalName.MaxLength = 30;
            txtDentalName.Name = "txtDentalName";
            txtDentalName.PlaceholderText = "";
            txtDentalName.SelectedText = "";
            txtDentalName.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtDentalName.Size = new Size(308, 46);
            txtDentalName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.RoyalBlue;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 43;
            btnSave.Location = new Point(1503, 3);
            btnSave.Name = "btnSave";
            btnSave.RightToLeft = RightToLeft.Yes;
            btnSave.Size = new Size(52, 46);
            btnSave.TabIndex = 14;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnResetDocktorImage
            // 
            btnResetDocktorImage.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnResetDocktorImage.IconColor = Color.Black;
            btnResetDocktorImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnResetDocktorImage.IconSize = 38;
            btnResetDocktorImage.ImageAlign = ContentAlignment.TopCenter;
            btnResetDocktorImage.Location = new Point(1502, 403);
            btnResetDocktorImage.Name = "btnResetDocktorImage";
            btnResetDocktorImage.RightToLeft = RightToLeft.No;
            btnResetDocktorImage.Size = new Size(53, 41);
            btnResetDocktorImage.TabIndex = 16;
            btnResetDocktorImage.UseVisualStyleBackColor = true;
            btnResetDocktorImage.Click += btnResetDoctorImage_Click;
            // 
            // btnResetDentalImage
            // 
            btnResetDentalImage.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnResetDentalImage.IconColor = Color.Black;
            btnResetDentalImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnResetDentalImage.IconSize = 38;
            btnResetDentalImage.ImageAlign = ContentAlignment.TopCenter;
            btnResetDentalImage.Location = new Point(710, 403);
            btnResetDentalImage.Name = "btnResetDentalImage";
            btnResetDentalImage.RightToLeft = RightToLeft.No;
            btnResetDentalImage.Size = new Size(53, 41);
            btnResetDentalImage.TabIndex = 17;
            btnResetDentalImage.UseVisualStyleBackColor = true;
            btnResetDentalImage.Click += btnResetDentalImage_Click;
            // 
            // btnChangeDoctorImage
            // 
            btnChangeDoctorImage.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnChangeDoctorImage.IconColor = Color.RoyalBlue;
            btnChangeDoctorImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChangeDoctorImage.IconSize = 38;
            btnChangeDoctorImage.ImageAlign = ContentAlignment.TopCenter;
            btnChangeDoctorImage.Location = new Point(1502, 450);
            btnChangeDoctorImage.Name = "btnChangeDoctorImage";
            btnChangeDoctorImage.RightToLeft = RightToLeft.No;
            btnChangeDoctorImage.Size = new Size(53, 41);
            btnChangeDoctorImage.TabIndex = 18;
            btnChangeDoctorImage.UseVisualStyleBackColor = true;
            btnChangeDoctorImage.Click += btnChangeDoctorImage_Click;
            // 
            // btnChangeDentalImage
            // 
            btnChangeDentalImage.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnChangeDentalImage.IconColor = Color.RoyalBlue;
            btnChangeDentalImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChangeDentalImage.IconSize = 38;
            btnChangeDentalImage.ImageAlign = ContentAlignment.TopCenter;
            btnChangeDentalImage.Location = new Point(710, 459);
            btnChangeDentalImage.Name = "btnChangeDentalImage";
            btnChangeDentalImage.RightToLeft = RightToLeft.No;
            btnChangeDentalImage.Size = new Size(53, 41);
            btnChangeDentalImage.TabIndex = 19;
            btnChangeDentalImage.UseVisualStyleBackColor = true;
            btnChangeDentalImage.Click += btnChangeDentalImage_Click;
            // 
            // SettingsView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkCyan;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnChangeDentalImage);
            Controls.Add(btnChangeDoctorImage);
            Controls.Add(btnResetDentalImage);
            Controls.Add(btnResetDocktorImage);
            Controls.Add(btnSave);
            Controls.Add(txtDentalDescription);
            Controls.Add(txtDentalName);
            Controls.Add(pbDentalImage);
            Controls.Add(pbDoctorImage);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtDoctorName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximumSize = new Size(1560, 954);
            MinimumSize = new Size(1560, 954);
            Name = "SettingsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1558, 952);
            Load += SettingsView_Load;
            Paint += SettingsView_Paint;
            ((System.ComponentModel.ISupportInitialize)pbDoctorImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDentalImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtDoctorName;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNumber;
        private PictureBox pbDoctorImage;
        private PictureBox pbDentalImage;
        private Guna.UI2.WinForms.Guna2TextBox txtDentalDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtDentalName;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnResetDocktorImage;
        private FontAwesome.Sharp.IconButton btnResetDentalImage;
        private FontAwesome.Sharp.IconButton btnChangeDoctorImage;
        private FontAwesome.Sharp.IconButton btnChangeDentalImage;
    }
}
