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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label12 = new Label();
            txtPatientId = new Guna.UI2.WinForms.Guna2TextBox();
            lblPatientId = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            dtpVisitDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label2 = new Label();
            txtNotes = new RichTextBox();
            lblTitile = new Label();
            dtpVisitTime = new DateTimePicker();
            lblAppointmentId = new Label();
            lblAppointmentIdValue = new Label();
            ctrlSearchPatient1 = new Dental.WinForms.UserControls.Search.ctrlSearchPatient();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnClose = new FontAwesome.Sharp.IconButton();
            change_txtPatientId_FllColorTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 192);
            label12.Location = new Point(1031, 337);
            label12.Name = "label12";
            label12.Size = new Size(222, 28);
            label12.TabIndex = 3;
            label12.Text = "ميعاد الزياره المُراد حجزه :";
            // 
            // txtPatientId
            // 
            txtPatientId.Animated = true;
            txtPatientId.BorderRadius = 10;
            txtPatientId.CustomizableEdges = customizableEdges13;
            txtPatientId.DefaultText = "";
            txtPatientId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPatientId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPatientId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPatientId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPatientId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPatientId.Font = new Font("Segoe UI", 10.2F);
            txtPatientId.ForeColor = Color.Black;
            txtPatientId.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPatientId.Location = new Point(759, 245);
            txtPatientId.Margin = new Padding(3, 5, 3, 5);
            txtPatientId.MaxLength = 6;
            txtPatientId.Name = "txtPatientId";
            txtPatientId.PlaceholderText = "";
            txtPatientId.RightToLeft = RightToLeft.Yes;
            txtPatientId.SelectedText = "";
            txtPatientId.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtPatientId.Size = new Size(249, 36);
            txtPatientId.TabIndex = 2;
            txtPatientId.KeyPress += txtPatientId_KeyPress;
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.FromArgb(0, 0, 192);
            lblPatientId.Location = new Point(1128, 245);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(125, 28);
            lblPatientId.TabIndex = 1;
            lblPatientId.Text = "رقم المريض :";
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = SystemColors.Control;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges15;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(550, 608);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSave.Size = new Size(159, 56);
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
            dtpVisitDate.CustomizableEdges = customizableEdges17;
            dtpVisitDate.FillColor = Color.White;
            dtpVisitDate.FocusedColor = Color.White;
            dtpVisitDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpVisitDate.Format = DateTimePickerFormat.Custom;
            dtpVisitDate.HoverState.BorderColor = Color.White;
            dtpVisitDate.HoverState.FillColor = Color.White;
            dtpVisitDate.HoverState.ForeColor = Color.Black;
            dtpVisitDate.Location = new Point(748, 318);
            dtpVisitDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpVisitDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpVisitDate.Name = "dtpVisitDate";
            dtpVisitDate.RightToLeft = RightToLeft.No;
            dtpVisitDate.ShadowDecoration.BorderRadius = 30;
            dtpVisitDate.ShadowDecoration.CustomizableEdges = customizableEdges18;
            dtpVisitDate.ShadowDecoration.Shadow = new Padding(0);
            dtpVisitDate.Size = new Size(274, 45);
            dtpVisitDate.TabIndex = 4;
            dtpVisitDate.TextAlign = HorizontalAlignment.Center;
            dtpVisitDate.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(1153, 435);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 5;
            label2.Text = "ملاحظات :";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(759, 435);
            txtNotes.MaxLength = 500;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(249, 103);
            txtNotes.TabIndex = 6;
            txtNotes.Text = "";
            // 
            // lblTitile
            // 
            lblTitile.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(470, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(318, 60);
            lblTitile.TabIndex = 0;
            lblTitile.Text = "اضافة حجز جديد";
            lblTitile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpVisitTime
            // 
            dtpVisitTime.CustomFormat = "hh:mm tt";
            dtpVisitTime.Format = DateTimePickerFormat.Custom;
            dtpVisitTime.Location = new Point(830, 369);
            dtpVisitTime.Name = "dtpVisitTime";
            dtpVisitTime.RightToLeft = RightToLeft.No;
            dtpVisitTime.ShowUpDown = true;
            dtpVisitTime.Size = new Size(111, 34);
            dtpVisitTime.TabIndex = 8;
            // 
            // lblAppointmentId
            // 
            lblAppointmentId.AutoSize = true;
            lblAppointmentId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAppointmentId.ForeColor = Color.FromArgb(0, 0, 192);
            lblAppointmentId.Location = new Point(1151, 167);
            lblAppointmentId.Name = "lblAppointmentId";
            lblAppointmentId.Size = new Size(101, 28);
            lblAppointmentId.TabIndex = 9;
            lblAppointmentId.Text = "رقم الحجز :";
            lblAppointmentId.Visible = false;
            // 
            // lblAppointmentIdValue
            // 
            lblAppointmentIdValue.Font = new Font("Segoe UI", 12F);
            lblAppointmentIdValue.Location = new Point(759, 167);
            lblAppointmentIdValue.Name = "lblAppointmentIdValue";
            lblAppointmentIdValue.Size = new Size(249, 28);
            lblAppointmentIdValue.TabIndex = 10;
            lblAppointmentIdValue.Text = "0";
            lblAppointmentIdValue.TextAlign = ContentAlignment.MiddleCenter;
            lblAppointmentIdValue.Visible = false;
            // 
            // ctrlSearchPatient1
            // 
            ctrlSearchPatient1.BackColor = Color.Transparent;
            ctrlSearchPatient1.BorderStyle = BorderStyle.FixedSingle;
            ctrlSearchPatient1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlSearchPatient1.Location = new Point(13, 132);
            ctrlSearchPatient1.Margin = new Padding(4);
            ctrlSearchPatient1.MinimumSize = new Size(553, 412);
            ctrlSearchPatient1.Name = "ctrlSearchPatient1";
            ctrlSearchPatient1.RightToLeft = RightToLeft.Yes;
            ctrlSearchPatient1.Size = new Size(730, 412);
            ctrlSearchPatient1.TabIndex = 11;
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
            btnClose.Location = new Point(1183, 12);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(53, 41);
            btnClose.TabIndex = 12;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // change_txtPatientId_FllColorTimer
            // 
            change_txtPatientId_FllColorTimer.Interval = 500;
            change_txtPatientId_FllColorTimer.Tick += change_txtPatientId_FllColorTimer_Tick;
            // 
            // frmAddEditAppointment
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 676);
            Controls.Add(btnClose);
            Controls.Add(ctrlSearchPatient1);
            Controls.Add(lblAppointmentIdValue);
            Controls.Add(lblAppointmentId);
            Controls.Add(dtpVisitTime);
            Controls.Add(lblTitile);
            Controls.Add(txtNotes);
            Controls.Add(label2);
            Controls.Add(dtpVisitDate);
            Controls.Add(label12);
            Controls.Add(txtPatientId);
            Controls.Add(lblPatientId);
            Controls.Add(btnSave);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.None;
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
        private Label lblPatientId;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpVisitDate;
        private Label label2;
        private RichTextBox txtNotes;
        private Label lblTitile;
        private DateTimePicker dtpVisitTime;
        private Label lblAppointmentId;
        private Label lblAppointmentIdValue;
        private UserControls.Search.ctrlSearchPatient ctrlSearchPatient1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Timer change_txtPatientId_FllColorTimer;
    }
}