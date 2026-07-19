namespace Dental.WinForms.Forms
{
    partial class frmAddEditAppointment
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label12 = new Label();
            txtPatientId = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            dtpVisitDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label2 = new Label();
            txtNotes = new RichTextBox();
            lblTitile = new Label();
            dtpVisitTime = new DateTimePicker();
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(498, 190);
            label12.Name = "label12";
            label12.Size = new Size(217, 28);
            label12.TabIndex = 3;
            label12.Text = "ميعاد الزياره المُراد حجزه :";
            // 
            // txtPatientId
            // 
            txtPatientId.Animated = true;
            txtPatientId.BorderRadius = 10;
            txtPatientId.CustomizableEdges = customizableEdges7;
            txtPatientId.DefaultText = "";
            txtPatientId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPatientId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPatientId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPatientId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPatientId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPatientId.Font = new Font("Segoe UI", 10.2F);
            txtPatientId.ForeColor = Color.Black;
            txtPatientId.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPatientId.Location = new Point(215, 119);
            txtPatientId.Margin = new Padding(3, 5, 3, 5);
            txtPatientId.MaxLength = 6;
            txtPatientId.Name = "txtPatientId";
            txtPatientId.PlaceholderText = "";
            txtPatientId.RightToLeft = RightToLeft.Yes;
            txtPatientId.SelectedText = "";
            txtPatientId.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPatientId.Size = new Size(249, 36);
            txtPatientId.TabIndex = 2;
            txtPatientId.KeyPress += txtPatientId_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(593, 123);
            label1.Name = "label1";
            label1.Size = new Size(122, 28);
            label1.TabIndex = 1;
            label1.Text = "رقم المريض :";
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = SystemColors.Control;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges9;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(292, 418);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSave.Size = new Size(143, 52);
            btnSave.TabIndex = 7;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // dtpVisitDate
            // 
            dtpVisitDate.Animated = true;
            dtpVisitDate.AutoRoundedCorners = true;
            dtpVisitDate.BackColor = Color.Transparent;
            dtpVisitDate.BorderColor = Color.White;
            dtpVisitDate.BorderRadius = 21;
            dtpVisitDate.Checked = true;
            dtpVisitDate.CustomizableEdges = customizableEdges11;
            dtpVisitDate.FillColor = Color.White;
            dtpVisitDate.FocusedColor = Color.White;
            dtpVisitDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpVisitDate.Format = DateTimePickerFormat.Custom;
            dtpVisitDate.HoverState.BorderColor = Color.White;
            dtpVisitDate.HoverState.FillColor = Color.White;
            dtpVisitDate.HoverState.ForeColor = Color.Black;
            dtpVisitDate.Location = new Point(200, 182);
            dtpVisitDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpVisitDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpVisitDate.Name = "dtpVisitDate";
            dtpVisitDate.RightToLeft = RightToLeft.No;
            dtpVisitDate.ShadowDecoration.BorderRadius = 30;
            dtpVisitDate.ShadowDecoration.CustomizableEdges = customizableEdges12;
            dtpVisitDate.ShadowDecoration.Shadow = new Padding(0);
            dtpVisitDate.Size = new Size(279, 45);
            dtpVisitDate.TabIndex = 4;
            dtpVisitDate.TextAlign = HorizontalAlignment.Center;
            dtpVisitDate.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(618, 257);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 5;
            label2.Text = "ملاحظات :";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(215, 262);
            txtNotes.MaxLength = 500;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(249, 103);
            txtNotes.TabIndex = 6;
            txtNotes.Text = "";
            // 
            // lblTitile
            // 
            lblTitile.AutoSize = true;
            lblTitile.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(206, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(314, 60);
            lblTitile.TabIndex = 0;
            lblTitile.Text = "اضافة حجز جديد";
            // 
            // dtpVisitTime
            // 
            dtpVisitTime.CustomFormat = "hh:mm tt";
            dtpVisitTime.Format = DateTimePickerFormat.Custom;
            dtpVisitTime.Location = new Point(75, 187);
            dtpVisitTime.Name = "dtpVisitTime";
            dtpVisitTime.RightToLeft = RightToLeft.No;
            dtpVisitTime.ShowUpDown = true;
            dtpVisitTime.Size = new Size(111, 34);
            dtpVisitTime.TabIndex = 8;
            // 
            // frmAddEditAppointment
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 482);
            Controls.Add(dtpVisitTime);
            Controls.Add(lblTitile);
            Controls.Add(txtNotes);
            Controls.Add(label2);
            Controls.Add(dtpVisitDate);
            Controls.Add(btnSave);
            Controls.Add(label12);
            Controls.Add(txtPatientId);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddEditAppointment";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة حجز";
            Load += frmAddAppointment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtPatientId;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpVisitDate;
        private Label label2;
        private RichTextBox txtNotes;
        private Label lblTitile;
        private DateTimePicker dtpVisitTime;
    }
}