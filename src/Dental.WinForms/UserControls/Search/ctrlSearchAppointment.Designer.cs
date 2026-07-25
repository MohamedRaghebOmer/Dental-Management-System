namespace Dental.WinForms.UserControls.Search
{
    partial class ctrlSearchAppointment
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges41 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges42 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle41 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle42 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle43 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle44 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges43 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges44 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnAddPatientOrAppointment = new FontAwesome.Sharp.IconButton();
            cbSearchBy = new ComboBox();
            txtSearchValue = new Guna.UI2.WinForms.Guna2TextBox();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colAppointmentId = new DataGridViewTextBoxColumn();
            colPatientId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colScheduledVisitDateTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            dtpScheduledVisitDateTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            cbAppointmentStatus = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            filterTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnAddPatientOrAppointment
            // 
            btnAddPatientOrAppointment.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddPatientOrAppointment.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnAddPatientOrAppointment.IconColor = Color.MediumSeaGreen;
            btnAddPatientOrAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddPatientOrAppointment.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddPatientOrAppointment.Location = new Point(334, 69);
            btnAddPatientOrAppointment.Name = "btnAddPatientOrAppointment";
            btnAddPatientOrAppointment.Size = new Size(190, 47);
            btnAddPatientOrAppointment.TabIndex = 3;
            btnAddPatientOrAppointment.Text = " إنشاء حجز جديد";
            btnAddPatientOrAppointment.TextAlign = ContentAlignment.MiddleRight;
            btnAddPatientOrAppointment.UseVisualStyleBackColor = true;
            btnAddPatientOrAppointment.Click += btnAddAppointment_Click;
            // 
            // cbSearchBy
            // 
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchBy.FormattingEnabled = true;
            cbSearchBy.Items.AddRange(new object[] { "رقم الحجز", "رقم المريض", "اسم المريض", "تاريخ الزياره المحجوز", "حالة الحجز" });
            cbSearchBy.Location = new Point(138, 7);
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.Size = new Size(297, 36);
            cbSearchBy.TabIndex = 1;
            cbSearchBy.SelectedIndexChanged += cbSearchBy_SelectedIndexChanged;
            // 
            // txtSearchValue
            // 
            txtSearchValue.BorderRadius = 7;
            txtSearchValue.CustomizableEdges = customizableEdges41;
            txtSearchValue.DefaultText = "";
            txtSearchValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchValue.ForeColor = Color.Black;
            txtSearchValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchValue.Location = new Point(441, 7);
            txtSearchValue.Margin = new Padding(4, 6, 4, 6);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.PlaceholderText = "ابحث عن حجز";
            txtSearchValue.SelectedText = "";
            txtSearchValue.ShadowDecoration.CustomizableEdges = customizableEdges42;
            txtSearchValue.Size = new Size(298, 36);
            txtSearchValue.TabIndex = 0;
            txtSearchValue.TextChanged += txtSearchValue_TextChanged;
            txtSearchValue.KeyPress += txtSearchValue_KeyPress;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle41.BackColor = Color.White;
            dataGridViewCellStyle41.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle41.ForeColor = Color.Black;
            dataGridViewCellStyle41.SelectionBackColor = Color.White;
            dataGridViewCellStyle41.SelectionForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle41;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle42.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle42.ForeColor = Color.White;
            dataGridViewCellStyle42.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle42.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle42;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colAppointmentId, colPatientId, colPatientName, colScheduledVisitDateTime, colStatus });
            dataGridViewCellStyle43.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = Color.White;
            dataGridViewCellStyle43.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle43.ForeColor = Color.Black;
            dataGridViewCellStyle43.SelectionBackColor = Color.White;
            dataGridViewCellStyle43.SelectionForeColor = Color.Black;
            dataGridViewCellStyle43.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle43;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.Location = new Point(0, 194);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = Color.White;
            dataGridViewCellStyle44.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle44.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle44.SelectionBackColor = Color.White;
            dataGridViewCellStyle44.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle44;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.Size = new Size(876, 229);
            dataGridView.TabIndex = 4;
            dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Black;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Black;
            dataGridView.ThemeStyle.GridColor = Color.LightGray;
            dataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F);
            dataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ThemeStyle.HeaderStyle.Height = 35;
            dataGridView.ThemeStyle.ReadOnly = true;
            dataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F);
            dataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dataGridView.ThemeStyle.RowsStyle.Height = 35;
            dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.White;
            dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dataGridView.DoubleClick += dataGridView_DoubleClick;
            // 
            // colAppointmentId
            // 
            colAppointmentId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colAppointmentId.DataPropertyName = "AppointmentId";
            colAppointmentId.HeaderText = "رقم الحجز";
            colAppointmentId.MinimumWidth = 6;
            colAppointmentId.Name = "colAppointmentId";
            colAppointmentId.ReadOnly = true;
            colAppointmentId.Width = 116;
            // 
            // colPatientId
            // 
            colPatientId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colPatientId.DataPropertyName = "PatientId";
            colPatientId.HeaderText = "رقم المريض";
            colPatientId.MinimumWidth = 6;
            colPatientId.Name = "colPatientId";
            colPatientId.ReadOnly = true;
            colPatientId.Width = 140;
            // 
            // colPatientName
            // 
            colPatientName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPatientName.DataPropertyName = "PatientName";
            colPatientName.HeaderText = "اسم المريض";
            colPatientName.MinimumWidth = 6;
            colPatientName.Name = "colPatientName";
            colPatientName.ReadOnly = true;
            // 
            // colScheduledVisitDateTime
            // 
            colScheduledVisitDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colScheduledVisitDateTime.DataPropertyName = "ScheduledVisitDateTime";
            colScheduledVisitDateTime.HeaderText = "تاريخ الزياره المحجوز";
            colScheduledVisitDateTime.MinimumWidth = 6;
            colScheduledVisitDateTime.Name = "colScheduledVisitDateTime";
            colScheduledVisitDateTime.ReadOnly = true;
            colScheduledVisitDateTime.Width = 206;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "حالة الحجز";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 122;
            // 
            // dtpScheduledVisitDateTime
            // 
            dtpScheduledVisitDateTime.Animated = true;
            dtpScheduledVisitDateTime.BackColor = Color.Transparent;
            dtpScheduledVisitDateTime.BorderColor = Color.White;
            dtpScheduledVisitDateTime.BorderRadius = 15;
            dtpScheduledVisitDateTime.Checked = true;
            dtpScheduledVisitDateTime.CustomizableEdges = customizableEdges43;
            dtpScheduledVisitDateTime.FillColor = Color.White;
            dtpScheduledVisitDateTime.FocusedColor = Color.White;
            dtpScheduledVisitDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpScheduledVisitDateTime.Format = DateTimePickerFormat.Long;
            dtpScheduledVisitDateTime.HoverState.BorderColor = Color.White;
            dtpScheduledVisitDateTime.HoverState.FillColor = Color.White;
            dtpScheduledVisitDateTime.HoverState.ForeColor = Color.Black;
            dtpScheduledVisitDateTime.Location = new Point(440, 7);
            dtpScheduledVisitDateTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpScheduledVisitDateTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpScheduledVisitDateTime.Name = "dtpScheduledVisitDateTime";
            dtpScheduledVisitDateTime.RightToLeft = RightToLeft.No;
            dtpScheduledVisitDateTime.ShadowDecoration.BorderRadius = 30;
            dtpScheduledVisitDateTime.ShadowDecoration.CustomizableEdges = customizableEdges44;
            dtpScheduledVisitDateTime.ShadowDecoration.Shadow = new Padding(0);
            dtpScheduledVisitDateTime.Size = new Size(299, 45);
            dtpScheduledVisitDateTime.TabIndex = 13;
            dtpScheduledVisitDateTime.TextAlign = HorizontalAlignment.Center;
            dtpScheduledVisitDateTime.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpScheduledVisitDateTime.Visible = false;
            dtpScheduledVisitDateTime.ValueChanged += dtpScheduledVisitDateTime_ValueChanged;
            // 
            // cbAppointmentStatus
            // 
            cbAppointmentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAppointmentStatus.FormattingEnabled = true;
            cbAppointmentStatus.Items.AddRange(new object[] { "قيد الانتظار", "فائت", "ملغي", "تم حضور الزياره" });
            cbAppointmentStatus.Location = new Point(441, 7);
            cbAppointmentStatus.Name = "cbAppointmentStatus";
            cbAppointmentStatus.Size = new Size(298, 36);
            cbAppointmentStatus.TabIndex = 14;
            cbAppointmentStatus.Visible = false;
            cbAppointmentStatus.SelectedIndexChanged += cbAppointmentStatus_SelectedIndexChanged;
            cbAppointmentStatus.VisibleChanged += cbAppointmentStatus_VisibleChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(770, 157);
            label1.Name = "label1";
            label1.Size = new Size(103, 31);
            label1.TabIndex = 15;
            label1.Text = "ملحوظه: ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(351, 159);
            label2.Name = "label2";
            label2.Size = new Size(427, 28);
            label2.TabIndex = 16;
            label2.Text = "اضغط علي الصف ضغتطين متتاليتين لإختيار الحجز";
            // 
            // filterTimer
            // 
            filterTimer.Interval = 500;
            filterTimer.Tick += filterTimer_Tick;
            // 
            // ctrlSearchAppointment
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Controls.Add(btnAddPatientOrAppointment);
            Controls.Add(cbSearchBy);
            Controls.Add(txtSearchValue);
            Controls.Add(dtpScheduledVisitDateTime);
            Controls.Add(cbAppointmentStatus);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MinimumSize = new Size(607, 423);
            Name = "ctrlSearchAppointment";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(876, 423);
            Load += ctrlSearchAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnAddPatientOrAppointment;
        private ComboBox cbSearchBy;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchValue;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpScheduledVisitDateTime;
        private ComboBox cbAppointmentStatus;
        private DataGridViewTextBoxColumn colAppointmentId;
        private DataGridViewTextBoxColumn colPatientId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colScheduledVisitDateTime;
        private DataGridViewTextBoxColumn colStatus;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer filterTimer;
    }
}
