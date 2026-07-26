namespace Dental.WinForms.Forms
{
    partial class frmAddEditPatient
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            lblTitile = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            txtAge = new Guna.UI2.WinForms.Guna2TextBox();
            label12 = new Label();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            lblPatientId = new Label();
            lblPatientIdValue = new Label();
            SuspendLayout();
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Animated = true;
            txtPhoneNumber.BorderRadius = 10;
            txtPhoneNumber.CustomizableEdges = customizableEdges1;
            txtPhoneNumber.DefaultText = "";
            txtPhoneNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPhoneNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPhoneNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Font = new Font("Segoe UI", 10.2F);
            txtPhoneNumber.ForeColor = Color.Black;
            txtPhoneNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Location = new Point(444, 324);
            txtPhoneNumber.Margin = new Padding(3, 5, 3, 5);
            txtPhoneNumber.MaxLength = 11;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "";
            txtPhoneNumber.SelectedText = "";
            txtPhoneNumber.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPhoneNumber.Size = new Size(249, 36);
            txtPhoneNumber.TabIndex = 11;
            // 
            // lblTitile
            // 
            lblTitile.AutoSize = true;
            lblTitile.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(233, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(394, 62);
            lblTitile.TabIndex = 0;
            lblTitile.Text = "اضافة مريض جديد";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(0, 0, 192);
            label7.Location = new Point(747, 328);
            label7.Name = "label7";
            label7.Size = new Size(111, 28);
            label7.TabIndex = 10;
            label7.Text = "رقم الهاتف :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 0, 192);
            label6.Location = new Point(793, 273);
            label6.Name = "label6";
            label6.Size = new Size(64, 28);
            label6.TabIndex = 7;
            label6.Text = "النوع :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 0, 192);
            label5.Location = new Point(792, 218);
            label5.Name = "label5";
            label5.Size = new Size(65, 28);
            label5.TabIndex = 5;
            label5.Text = "السن :";
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = Color.Transparent;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges3;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(347, 436);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSave.Size = new Size(160, 56);
            btnSave.TabIndex = 12;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Checked = true;
            rbMale.Location = new Point(608, 271);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(61, 32);
            rbMale.TabIndex = 8;
            rbMale.TabStop = true;
            rbMale.Text = "ذكر";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(481, 271);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(69, 32);
            rbFemale.TabIndex = 9;
            rbFemale.Text = "انثي";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // txtAge
            // 
            txtAge.Animated = true;
            txtAge.BorderRadius = 10;
            txtAge.CustomizableEdges = customizableEdges5;
            txtAge.DefaultText = "";
            txtAge.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAge.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAge.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAge.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAge.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAge.Font = new Font("Segoe UI", 10.2F);
            txtAge.ForeColor = Color.Black;
            txtAge.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAge.Location = new Point(444, 214);
            txtAge.Margin = new Padding(3, 5, 3, 5);
            txtAge.MaxLength = 2;
            txtAge.Name = "txtAge";
            txtAge.PlaceholderText = "";
            txtAge.SelectedText = "";
            txtAge.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtAge.Size = new Size(249, 36);
            txtAge.TabIndex = 6;
            txtAge.KeyPress += txtAge_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 192);
            label12.Location = new Point(788, 163);
            label12.Name = "label12";
            label12.Size = new Size(69, 28);
            label12.TabIndex = 3;
            label12.Text = "الإسم :";
            // 
            // txtName
            // 
            txtName.Animated = true;
            txtName.BorderRadius = 10;
            txtName.CustomizableEdges = customizableEdges7;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 10.2F);
            txtName.ForeColor = Color.Black;
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(444, 159);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtName.Size = new Size(249, 36);
            txtName.TabIndex = 4;
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.FromArgb(0, 0, 192);
            lblPatientId.Location = new Point(733, 106);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(125, 28);
            lblPatientId.TabIndex = 1;
            lblPatientId.Text = "رقم المريض :";
            // 
            // lblPatientIdValue
            // 
            lblPatientIdValue.Location = new Point(444, 106);
            lblPatientIdValue.Name = "lblPatientIdValue";
            lblPatientIdValue.Size = new Size(249, 28);
            lblPatientIdValue.TabIndex = 2;
            lblPatientIdValue.Text = "0";
            lblPatientIdValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmAddEditPatient
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 504);
            Controls.Add(lblPatientIdValue);
            Controls.Add(lblPatientId);
            Controls.Add(txtAge);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(btnSave);
            Controls.Add(txtName);
            Controls.Add(label12);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblTitile);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddEditPatient";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة مريض";
            Load += frmAddEditPatient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNumber;
        private Label lblTitile;
        private Label label7;
        private Label label6;
        private Label label5;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private Guna.UI2.WinForms.Guna2TextBox txtAge;
        private Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Label lblPatientId;
        private Label lblPatientIdValue;
    }
}