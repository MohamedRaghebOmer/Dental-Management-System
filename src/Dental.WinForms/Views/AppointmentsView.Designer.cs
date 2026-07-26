namespace Dental.WinForms.Views
{
    partial class AppointmentsView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentsView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblTotalAppointments = new Label();
            label1 = new Label();
            pnlPendingAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblPendingAppointments = new Label();
            label2 = new Label();
            pnlCompletedAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblCompletedAppointment = new Label();
            label3 = new Label();
            pnlMissedAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblMissedAppointments = new Label();
            label4 = new Label();
            timerUpdateDateTimePckerMaxDate = new System.Windows.Forms.Timer(components);
            filterTimer = new System.Windows.Forms.Timer(components);
            btnAddNewAppointment = new Guna.UI2.WinForms.Guna2Button();
            lblSearchAfter = new Label();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            pnlTotalAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            cbFilterList = new ComboBox();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colPatientId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colScheduledVisitDateTime = new DataGridViewTextBoxColumn();
            colActualVisitDateTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            contextMenuStrip = new ContextMenuStrip(components);
            tsmiShowDetails = new ToolStripMenuItem();
            tsmiEditAppointment = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiStartVisit = new ToolStripMenuItem();
            tsmiCancelAppointment = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tsmiDeleteAppointment = new ToolStripMenuItem();
            dtpSearchAfter = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            pnlCanceledAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblCanceledAppointments = new Label();
            label6 = new Label();
            pnlSearchAtRadioButtons = new Guna.UI2.WinForms.Guna2Panel();
            rbThisMonth = new RadioButton();
            rbThisWeek = new RadioButton();
            label7 = new Label();
            label5 = new Label();
            rbToday = new RadioButton();
            rbAllTime = new RadioButton();
            loadDataTimer = new System.Windows.Forms.Timer(components);
            cbAppointmentStatus = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            pnlPendingAppointments.SuspendLayout();
            pnlCompletedAppointments.SuspendLayout();
            pnlMissedAppointments.SuspendLayout();
            pnlTotalAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            pnlCanceledAppointments.SuspendLayout();
            pnlSearchAtRadioButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker
            // 
            dateTimePicker.Animated = true;
            dateTimePicker.BackColor = Color.Transparent;
            dateTimePicker.BorderColor = Color.White;
            dateTimePicker.BorderRadius = 15;
            dateTimePicker.Checked = true;
            dateTimePicker.CustomizableEdges = customizableEdges1;
            dateTimePicker.FillColor = Color.White;
            dateTimePicker.FocusedColor = Color.White;
            dateTimePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.HoverState.BorderColor = Color.White;
            dateTimePicker.HoverState.FillColor = Color.White;
            dateTimePicker.HoverState.ForeColor = Color.Black;
            dateTimePicker.Location = new Point(792, 474);
            dateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.ShadowDecoration.BorderRadius = 30;
            dateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dateTimePicker.ShadowDecoration.Shadow = new Padding(0);
            dateTimePicker.Size = new Size(301, 45);
            dateTimePicker.TabIndex = 26;
            dateTimePicker.TextAlign = HorizontalAlignment.Center;
            dateTimePicker.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dateTimePicker.Visible = false;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // lblTotalAppointments
            // 
            lblTotalAppointments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalAppointments.ForeColor = Color.Black;
            lblTotalAppointments.Location = new Point(3, 58);
            lblTotalAppointments.Name = "lblTotalAppointments";
            lblTotalAppointments.Size = new Size(255, 28);
            lblTotalAppointments.TabIndex = 4;
            lblTotalAppointments.Text = "0";
            lblTotalAppointments.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(81, 8);
            label1.Name = "label1";
            label1.Size = new Size(177, 28);
            label1.TabIndex = 3;
            label1.Text = "عدد الحجوزات الكليه";
            // 
            // pnlPendingAppointments
            // 
            pnlPendingAppointments.BackColor = Color.Transparent;
            pnlPendingAppointments.Controls.Add(lblPendingAppointments);
            pnlPendingAppointments.Controls.Add(label2);
            pnlPendingAppointments.FillColor = Color.White;
            pnlPendingAppointments.Location = new Point(953, 218);
            pnlPendingAppointments.Name = "pnlPendingAppointments";
            pnlPendingAppointments.Radius = 10;
            pnlPendingAppointments.ShadowColor = Color.Black;
            pnlPendingAppointments.ShadowDepth = 150;
            pnlPendingAppointments.Size = new Size(266, 125);
            pnlPendingAppointments.TabIndex = 17;
            // 
            // lblPendingAppointments
            // 
            lblPendingAppointments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPendingAppointments.ForeColor = Color.Black;
            lblPendingAppointments.Location = new Point(3, 58);
            lblPendingAppointments.Name = "lblPendingAppointments";
            lblPendingAppointments.Size = new Size(255, 28);
            lblPendingAppointments.TabIndex = 0;
            lblPendingAppointments.Text = "0";
            lblPendingAppointments.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(33, 9);
            label2.Name = "label2";
            label2.Size = new Size(225, 28);
            label2.TabIndex = 3;
            label2.Text = "عدد الحجوزات في الإنتظار";
            // 
            // pnlCompletedAppointments
            // 
            pnlCompletedAppointments.BackColor = Color.Transparent;
            pnlCompletedAppointments.Controls.Add(lblCompletedAppointment);
            pnlCompletedAppointments.Controls.Add(label3);
            pnlCompletedAppointments.FillColor = Color.White;
            pnlCompletedAppointments.Location = new Point(646, 218);
            pnlCompletedAppointments.Name = "pnlCompletedAppointments";
            pnlCompletedAppointments.Radius = 10;
            pnlCompletedAppointments.ShadowColor = Color.Black;
            pnlCompletedAppointments.ShadowDepth = 150;
            pnlCompletedAppointments.Size = new Size(266, 125);
            pnlCompletedAppointments.TabIndex = 18;
            // 
            // lblCompletedAppointment
            // 
            lblCompletedAppointment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCompletedAppointment.ForeColor = Color.Black;
            lblCompletedAppointment.Location = new Point(3, 58);
            lblCompletedAppointment.Name = "lblCompletedAppointment";
            lblCompletedAppointment.Size = new Size(255, 28);
            lblCompletedAppointment.TabIndex = 6;
            lblCompletedAppointment.Text = "0";
            lblCompletedAppointment.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(57, 9);
            label3.Name = "label3";
            label3.Size = new Size(201, 28);
            label3.TabIndex = 3;
            label3.Text = "عدد الحجوزات المكتمله";
            // 
            // pnlMissedAppointments
            // 
            pnlMissedAppointments.BackColor = Color.Transparent;
            pnlMissedAppointments.Controls.Add(lblMissedAppointments);
            pnlMissedAppointments.Controls.Add(label4);
            pnlMissedAppointments.FillColor = Color.White;
            pnlMissedAppointments.Location = new Point(339, 218);
            pnlMissedAppointments.Name = "pnlMissedAppointments";
            pnlMissedAppointments.Radius = 10;
            pnlMissedAppointments.ShadowColor = Color.Black;
            pnlMissedAppointments.ShadowDepth = 150;
            pnlMissedAppointments.Size = new Size(266, 125);
            pnlMissedAppointments.TabIndex = 20;
            // 
            // lblMissedAppointments
            // 
            lblMissedAppointments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMissedAppointments.ForeColor = Color.Black;
            lblMissedAppointments.Location = new Point(3, 58);
            lblMissedAppointments.Name = "lblMissedAppointments";
            lblMissedAppointments.Size = new Size(255, 28);
            lblMissedAppointments.TabIndex = 7;
            lblMissedAppointments.Text = "0";
            lblMissedAppointments.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(76, 9);
            label4.Name = "label4";
            label4.Size = new Size(182, 28);
            label4.TabIndex = 3;
            label4.Text = "عدد الحجوزات الفائته";
            // 
            // timerUpdateDateTimePckerMaxDate
            // 
            timerUpdateDateTimePckerMaxDate.Interval = 1000;
            timerUpdateDateTimePckerMaxDate.Tick += timerUpdateDateTimePckerMaxDate_Tick;
            // 
            // filterTimer
            // 
            filterTimer.Interval = 400;
            filterTimer.Tick += filterTimer_Tick;
            // 
            // btnAddNewAppointment
            // 
            btnAddNewAppointment.Animated = true;
            btnAddNewAppointment.AnimatedGIF = true;
            btnAddNewAppointment.BackColor = Color.Transparent;
            btnAddNewAppointment.BorderRadius = 15;
            btnAddNewAppointment.CustomizableEdges = customizableEdges3;
            btnAddNewAppointment.DisabledState.BorderColor = Color.DarkGray;
            btnAddNewAppointment.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNewAppointment.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNewAppointment.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNewAppointment.FillColor = Color.FromArgb(0, 0, 150);
            btnAddNewAppointment.Font = new Font("Segoe UI", 13.8F);
            btnAddNewAppointment.ForeColor = Color.White;
            btnAddNewAppointment.HoverState.FillColor = Color.MediumBlue;
            btnAddNewAppointment.Location = new Point(1329, 468);
            btnAddNewAppointment.Name = "btnAddNewAppointment";
            btnAddNewAppointment.PressedColor = Color.FromArgb(0, 0, 165);
            btnAddNewAppointment.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAddNewAppointment.Size = new Size(218, 57);
            btnAddNewAppointment.TabIndex = 27;
            btnAddNewAppointment.Text = "إنشاء حجز جديد";
            btnAddNewAppointment.Click += btnAddNewAppointment_Click;
            // 
            // lblSearchAfter
            // 
            lblSearchAfter.AutoSize = true;
            lblSearchAfter.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchAfter.Location = new Point(836, 397);
            lblSearchAfter.Name = "lblSearchAfter";
            lblSearchAfter.Size = new Size(221, 31);
            lblSearchAfter.TabIndex = 19;
            lblSearchAfter.Text = "ابحث بعد تاريخ معين :";
            lblSearchAfter.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.Location = new Point(3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(47, 49);
            btnRefresh.TabIndex = 14;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlTotalAppointments
            // 
            pnlTotalAppointments.BackColor = Color.Transparent;
            pnlTotalAppointments.Controls.Add(lblTotalAppointments);
            pnlTotalAppointments.Controls.Add(label1);
            pnlTotalAppointments.FillColor = Color.White;
            pnlTotalAppointments.Location = new Point(1260, 218);
            pnlTotalAppointments.Name = "pnlTotalAppointments";
            pnlTotalAppointments.Radius = 10;
            pnlTotalAppointments.ShadowColor = Color.Black;
            pnlTotalAppointments.ShadowDepth = 150;
            pnlTotalAppointments.Size = new Size(266, 125);
            pnlTotalAppointments.TabIndex = 16;
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "رقم الحجز", "رقم المريض", "اسم المريض", "تاريخ إنشاء الحجز", "تاريخ الزياره المحجوز", "تاريخ الزياره الفعلي", "حالة الزياره" });
            cbFilterList.Location = new Point(484, 478);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 22;
            cbFilterList.SelectedIndexChanged += cbFilterList_SelectedIndexChanged;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colId, colPatientId, colPatientName, colCreatedAt, colScheduledVisitDateTime, colActualVisitDateTime, colStatus });
            dataGridView.ContextMenuStrip = contextMenuStrip;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.Location = new Point(0, 573);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.ReadOnly = true;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new Size(1558, 379);
            dataGridView.TabIndex = 24;
            dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.Transparent;
            dataGridView.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Black;
            dataGridView.ThemeStyle.GridColor = Color.LightGray;
            dataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ThemeStyle.HeaderStyle.Height = 35;
            dataGridView.ThemeStyle.ReadOnly = true;
            dataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dataGridView.ThemeStyle.RowsStyle.Height = 35;
            dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.DodgerBlue;
            dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            dataGridView.CellMouseDown += dataGridView_CellMouseDown;
            dataGridView.MouseDoubleClick += dataGridView_MouseDoubleClick;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colId.DataPropertyName = "Id";
            colId.HeaderText = "رقم الحجز";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 116;
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
            colPatientName.MinimumWidth = 2;
            colPatientName.Name = "colPatientName";
            colPatientName.ReadOnly = true;
            // 
            // colCreatedAt
            // 
            colCreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCreatedAt.DataPropertyName = "CreatedAt";
            colCreatedAt.HeaderText = "تاريخ إنشاء الحجز";
            colCreatedAt.MinimumWidth = 6;
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;
            colCreatedAt.Width = 176;
            // 
            // colScheduledVisitDateTime
            // 
            colScheduledVisitDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colScheduledVisitDateTime.DataPropertyName = "ScheduledVisitDateTime";
            colScheduledVisitDateTime.HeaderText = "تاريخ الزياره المحجوز";
            colScheduledVisitDateTime.MinimumWidth = 6;
            colScheduledVisitDateTime.Name = "colScheduledVisitDateTime";
            colScheduledVisitDateTime.ReadOnly = true;
            colScheduledVisitDateTime.Width = 206;
            // 
            // colActualVisitDateTime
            // 
            colActualVisitDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colActualVisitDateTime.DataPropertyName = "ActualVisitDateTime";
            colActualVisitDateTime.HeaderText = "تاريخ الزياره الفعلي";
            colActualVisitDateTime.MinimumWidth = 6;
            colActualVisitDateTime.Name = "colActualVisitDateTime";
            colActualVisitDateTime.ReadOnly = true;
            colActualVisitDateTime.Width = 198;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "حالة الحجز";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 122;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { tsmiShowDetails, tsmiEditAppointment, toolStripSeparator2, tsmiStartVisit, tsmiCancelAppointment, toolStripSeparator3, tsmiDeleteAppointment });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.RightToLeft = RightToLeft.Yes;
            contextMenuStrip.Size = new Size(177, 146);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // tsmiShowDetails
            // 
            tsmiShowDetails.Image = Properties.Resources.details_512;
            tsmiShowDetails.Name = "tsmiShowDetails";
            tsmiShowDetails.Size = new Size(176, 26);
            tsmiShowDetails.Text = "عرض التفاصيل";
            tsmiShowDetails.Click += tsmiShowDetails_Click;
            // 
            // tsmiEditAppointment
            // 
            tsmiEditAppointment.Image = Properties.Resources.pen_512;
            tsmiEditAppointment.Name = "tsmiEditAppointment";
            tsmiEditAppointment.Size = new Size(176, 26);
            tsmiEditAppointment.Text = "تعديل";
            tsmiEditAppointment.Click += tsmiEditAppointment_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(173, 6);
            // 
            // tsmiStartVisit
            // 
            tsmiStartVisit.Image = (Image)resources.GetObject("tsmiStartVisit.Image");
            tsmiStartVisit.Name = "tsmiStartVisit";
            tsmiStartVisit.Size = new Size(176, 26);
            tsmiStartVisit.Text = "ابدأ الزياره";
            tsmiStartVisit.Click += tsmiStartVisit_Click;
            // 
            // tsmiCancelAppointment
            // 
            tsmiCancelAppointment.Image = (Image)resources.GetObject("tsmiCancelAppointment.Image");
            tsmiCancelAppointment.Name = "tsmiCancelAppointment";
            tsmiCancelAppointment.Size = new Size(176, 26);
            tsmiCancelAppointment.Text = "إلغاء الحجز";
            tsmiCancelAppointment.Click += tsmiCancelAppointment_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(173, 6);
            // 
            // tsmiDeleteAppointment
            // 
            tsmiDeleteAppointment.Image = Properties.Resources.bin_512;
            tsmiDeleteAppointment.Name = "tsmiDeleteAppointment";
            tsmiDeleteAppointment.Size = new Size(176, 26);
            tsmiDeleteAppointment.Text = "حذف الحجز";
            tsmiDeleteAppointment.Click += tsmiDeleteAppointment_Click;
            // 
            // dtpSearchAfter
            // 
            dtpSearchAfter.Animated = true;
            dtpSearchAfter.BackColor = Color.Transparent;
            dtpSearchAfter.BorderColor = Color.White;
            dtpSearchAfter.BorderRadius = 15;
            dtpSearchAfter.Checked = true;
            dtpSearchAfter.CustomizableEdges = customizableEdges5;
            dtpSearchAfter.FillColor = Color.White;
            dtpSearchAfter.FocusedColor = Color.White;
            dtpSearchAfter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpSearchAfter.Format = DateTimePickerFormat.Long;
            dtpSearchAfter.HoverState.BorderColor = Color.White;
            dtpSearchAfter.HoverState.FillColor = Color.White;
            dtpSearchAfter.HoverState.ForeColor = Color.Black;
            dtpSearchAfter.Location = new Point(516, 392);
            dtpSearchAfter.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpSearchAfter.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpSearchAfter.Name = "dtpSearchAfter";
            dtpSearchAfter.RightToLeft = RightToLeft.No;
            dtpSearchAfter.ShadowDecoration.BorderRadius = 30;
            dtpSearchAfter.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpSearchAfter.ShadowDecoration.Shadow = new Padding(0);
            dtpSearchAfter.Size = new Size(301, 45);
            dtpSearchAfter.TabIndex = 21;
            dtpSearchAfter.TextAlign = HorizontalAlignment.Center;
            dtpSearchAfter.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpSearchAfter.Visible = false;
            dtpSearchAfter.ValueChanged += dtpSearchAfter_ValueChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderRadius = 7;
            txtFilterValue.CustomizableEdges = customizableEdges7;
            txtFilterValue.DefaultText = "";
            txtFilterValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFilterValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFilterValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = Color.Black;
            txtFilterValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Location = new Point(792, 478);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 23;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // pnlCanceledAppointments
            // 
            pnlCanceledAppointments.BackColor = Color.Transparent;
            pnlCanceledAppointments.Controls.Add(lblCanceledAppointments);
            pnlCanceledAppointments.Controls.Add(label6);
            pnlCanceledAppointments.FillColor = Color.White;
            pnlCanceledAppointments.Location = new Point(32, 218);
            pnlCanceledAppointments.Name = "pnlCanceledAppointments";
            pnlCanceledAppointments.Radius = 10;
            pnlCanceledAppointments.ShadowColor = Color.Black;
            pnlCanceledAppointments.ShadowDepth = 150;
            pnlCanceledAppointments.Size = new Size(266, 125);
            pnlCanceledAppointments.TabIndex = 21;
            // 
            // lblCanceledAppointments
            // 
            lblCanceledAppointments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCanceledAppointments.ForeColor = Color.Black;
            lblCanceledAppointments.Location = new Point(3, 58);
            lblCanceledAppointments.Name = "lblCanceledAppointments";
            lblCanceledAppointments.Size = new Size(260, 31);
            lblCanceledAppointments.TabIndex = 7;
            lblCanceledAppointments.Text = "0";
            lblCanceledAppointments.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(255, 128, 0);
            label6.Location = new Point(67, 9);
            label6.Name = "label6";
            label6.Size = new Size(191, 28);
            label6.TabIndex = 3;
            label6.Text = "عدد الحجوزات الملغيه";
            // 
            // pnlSearchAtRadioButtons
            // 
            pnlSearchAtRadioButtons.BackColor = Color.Transparent;
            pnlSearchAtRadioButtons.BorderColor = Color.Navy;
            pnlSearchAtRadioButtons.BorderRadius = 30;
            pnlSearchAtRadioButtons.BorderThickness = 3;
            pnlSearchAtRadioButtons.Controls.Add(rbThisMonth);
            pnlSearchAtRadioButtons.Controls.Add(rbThisWeek);
            pnlSearchAtRadioButtons.Controls.Add(label7);
            pnlSearchAtRadioButtons.Controls.Add(label5);
            pnlSearchAtRadioButtons.Controls.Add(rbToday);
            pnlSearchAtRadioButtons.Controls.Add(rbAllTime);
            pnlSearchAtRadioButtons.CustomizableEdges = customizableEdges9;
            pnlSearchAtRadioButtons.Location = new Point(1210, 10);
            pnlSearchAtRadioButtons.Name = "pnlSearchAtRadioButtons";
            pnlSearchAtRadioButtons.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlSearchAtRadioButtons.Size = new Size(337, 168);
            pnlSearchAtRadioButtons.TabIndex = 28;
            pnlSearchAtRadioButtons.UseTransparentBackground = true;
            // 
            // rbThisMonth
            // 
            rbThisMonth.Anchor = AnchorStyles.Right;
            rbThisMonth.AutoSize = true;
            rbThisMonth.Location = new Point(203, 88);
            rbThisMonth.Name = "rbThisMonth";
            rbThisMonth.Size = new Size(113, 32);
            rbThisMonth.TabIndex = 8;
            rbThisMonth.Text = "هذا الشهر";
            rbThisMonth.UseVisualStyleBackColor = true;
            rbThisMonth.CheckedChanged += raidoButtonsFilterPeriod_CheckedChanged;
            // 
            // rbThisWeek
            // 
            rbThisWeek.Anchor = AnchorStyles.Right;
            rbThisWeek.AutoSize = true;
            rbThisWeek.Location = new Point(187, 50);
            rbThisWeek.Name = "rbThisWeek";
            rbThisWeek.Size = new Size(129, 32);
            rbThisWeek.TabIndex = 7;
            rbThisWeek.Text = "هذا الأسبوع";
            rbThisWeek.UseVisualStyleBackColor = true;
            rbThisWeek.CheckedChanged += raidoButtonsFilterPeriod_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 61);
            label7.Name = "label7";
            label7.Size = new Size(151, 23);
            label7.TabIndex = 4;
            label7.Text = "بداية من يوم السبت";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(4, 99);
            label5.Name = "label5";
            label5.Size = new Size(202, 23);
            label5.TabIndex = 5;
            label5.Text = "بداية من اول يوم في الشهر";
            // 
            // rbToday
            // 
            rbToday.Anchor = AnchorStyles.Right;
            rbToday.AutoSize = true;
            rbToday.Location = new Point(242, 12);
            rbToday.Name = "rbToday";
            rbToday.Size = new Size(74, 32);
            rbToday.TabIndex = 6;
            rbToday.Text = "اليوم";
            rbToday.UseVisualStyleBackColor = true;
            rbToday.CheckedChanged += raidoButtonsFilterPeriod_CheckedChanged;
            // 
            // rbAllTime
            // 
            rbAllTime.Anchor = AnchorStyles.Right;
            rbAllTime.AutoSize = true;
            rbAllTime.Checked = true;
            rbAllTime.Location = new Point(228, 123);
            rbAllTime.Name = "rbAllTime";
            rbAllTime.Size = new Size(88, 32);
            rbAllTime.TabIndex = 9;
            rbAllTime.TabStop = true;
            rbAllTime.Text = "الجميع";
            rbAllTime.UseVisualStyleBackColor = true;
            rbAllTime.CheckedChanged += raidoButtonsFilterPeriod_CheckedChanged;
            // 
            // loadDataTimer
            // 
            loadDataTimer.Interval = 10;
            loadDataTimer.Tick += loadDataTimer_Tick;
            // 
            // cbAppointmentStatus
            // 
            cbAppointmentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAppointmentStatus.FormattingEnabled = true;
            cbAppointmentStatus.Items.AddRange(new object[] { "قيد الانتظار", "تم حضور الزياره", "ملغي", "فائت" });
            cbAppointmentStatus.Location = new Point(792, 478);
            cbAppointmentStatus.Name = "cbAppointmentStatus";
            cbAppointmentStatus.Size = new Size(301, 36);
            cbAppointmentStatus.TabIndex = 30;
            cbAppointmentStatus.Visible = false;
            cbAppointmentStatus.SelectedIndexChanged += cbAppointmentStatus_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(959, 540);
            label9.Name = "label9";
            label9.Size = new Size(486, 28);
            label9.TabIndex = 32;
            label9.Text = "اضغط علي الصف ضغطتين متتاليتين لعرض بيانات الحجز.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1451, 539);
            label8.Name = "label8";
            label8.Size = new Size(103, 31);
            label8.TabIndex = 31;
            label8.Text = "ملحوظه :";
            // 
            // AppointmentsView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkCyan;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(pnlSearchAtRadioButtons);
            Controls.Add(pnlCanceledAppointments);
            Controls.Add(pnlMissedAppointments);
            Controls.Add(pnlPendingAppointments);
            Controls.Add(pnlCompletedAppointments);
            Controls.Add(btnAddNewAppointment);
            Controls.Add(lblSearchAfter);
            Controls.Add(btnRefresh);
            Controls.Add(pnlTotalAppointments);
            Controls.Add(cbFilterList);
            Controls.Add(dataGridView);
            Controls.Add(dtpSearchAfter);
            Controls.Add(cbAppointmentStatus);
            Controls.Add(txtFilterValue);
            Controls.Add(dateTimePicker);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1560, 954);
            MinimumSize = new Size(1560, 954);
            Name = "AppointmentsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1558, 952);
            Load += AppointmentsView_Load;
            pnlPendingAppointments.ResumeLayout(false);
            pnlPendingAppointments.PerformLayout();
            pnlCompletedAppointments.ResumeLayout(false);
            pnlCompletedAppointments.PerformLayout();
            pnlMissedAppointments.ResumeLayout(false);
            pnlMissedAppointments.PerformLayout();
            pnlTotalAppointments.ResumeLayout(false);
            pnlTotalAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip.ResumeLayout(false);
            pnlCanceledAppointments.ResumeLayout(false);
            pnlCanceledAppointments.PerformLayout();
            pnlSearchAtRadioButtons.ResumeLayout(false);
            pnlSearchAtRadioButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker;
        private Label lblTotalAppointments;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlPendingAppointments;
        private Label lblPendingAppointments;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlCompletedAppointments;
        private Label lblCompletedAppointment;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlMissedAppointments;
        private Label lblMissedAppointments;
        private Label label4;
        private System.Windows.Forms.Timer timerUpdateDateTimePckerMaxDate;
        private System.Windows.Forms.Timer filterTimer;
        private Guna.UI2.WinForms.Guna2Button btnAddNewAppointment;
        private Label lblSearchAfter;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTotalAppointments;
        private ComboBox cbFilterList;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpSearchAfter;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlCanceledAppointments;
        private Label lblCanceledAppointments;
        private Label label6;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchAtRadioButtons;
        private Label label5;
        private Label label7;
        private RadioButton rbThisWeek;
        private RadioButton rbThisMonth;
        private RadioButton rbAllTime;
        private RadioButton rbToday;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem tsmiEditAppointment;
        private ToolStripMenuItem tsmiStartVisit;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiCancelAppointment;
        private ToolStripMenuItem tsmiShowDetails;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tsmiDeleteAppointment;
        private System.Windows.Forms.Timer loadDataTimer;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colPatientId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colScheduledVisitDateTime;
        private DataGridViewTextBoxColumn colActualVisitDateTime;
        private DataGridViewTextBoxColumn colStatus;
        private ComboBox cbAppointmentStatus;
        private Label label9;
        private Label label8;
    }
}
