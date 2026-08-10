namespace Dental.WinForms.Views
{
    partial class VisitsView
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitsView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colVisitId = new DataGridViewTextBoxColumn();
            colAppointmentId = new DataGridViewTextBoxColumn();
            colPatientId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colVisitDateTime = new DataGridViewTextBoxColumn();
            colVisitTreatments = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            colTotalPaidAmount = new DataGridViewTextBoxColumn();
            colDiscountAmount = new DataGridViewTextBoxColumn();
            colRemainedAmount = new DataGridViewTextBoxColumn();
            contextMenuStrip = new ContextMenuStrip(components);
            cmsEdit = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            cmsShowPatientDetails = new ToolStripMenuItem();
            cmsShowAppointmentDetails = new ToolStripMenuItem();
            tsmiViewAllRadiographsRelatedToTheVisit = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiAddNewVisitToTheSamePatient = new ToolStripMenuItem();
            tsmiAddNewRadiographToTheSameVisit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cmsDelete = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cmsRefreshGrid = new ToolStripMenuItem();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            cbFilterList = new ComboBox();
            pnlTotalVisits = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTotalVisits = new Label();
            label1 = new Label();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblSumOfPaidAmounts = new Label();
            label2 = new Label();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblSumOfDiscountAmount = new Label();
            label3 = new Label();
            guna2ShadowPanel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblSumOfRemainedAmount = new Label();
            label4 = new Label();
            pnlSearchAtRadioButtons = new Guna.UI2.WinForms.Guna2Panel();
            label6 = new Label();
            label5 = new Label();
            rbThisWeek = new RadioButton();
            rbThisMonth = new RadioButton();
            rbAllTime = new RadioButton();
            rbToday = new RadioButton();
            dtpSearchAfter = new Guna.UI2.WinForms.Guna2DateTimePicker();
            timerUpdateDateTimePckerMaxDate = new System.Windows.Forms.Timer(components);
            filterTimer = new System.Windows.Forms.Timer(components);
            btnRefresh = new FontAwesome.Sharp.IconButton();
            lblSearchAfter = new Label();
            btnAddWalkInVisit = new Guna.UI2.WinForms.Guna2Button();
            dtpVisitDateTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnCreatePreAppointmentVisit = new Guna.UI2.WinForms.Guna2Button();
            LoadDataFirstTimeTimer = new System.Windows.Forms.Timer(components);
            guna2ShadowPanel4 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblSumOfTotalAmount = new Label();
            label8 = new Label();
            label7 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            pnlTotalVisits.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            guna2ShadowPanel2.SuspendLayout();
            guna2ShadowPanel3.SuspendLayout();
            pnlSearchAtRadioButtons.SuspendLayout();
            guna2ShadowPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.Transparent;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.White;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colVisitId, colAppointmentId, colPatientId, colPatientName, colVisitDateTime, colVisitTreatments, colTotalAmount, colTotalPaidAmount, colDiscountAmount, colRemainedAmount });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.Location = new Point(0, 577);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.ContextMenuStrip = contextMenuStrip;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new Size(1562, 379);
            dataGridView.TabIndex = 12;
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
            dataGridView.DataError += dataGridView_DataError;
            dataGridView.DoubleClick += dataGridView_DoubleClick;
            // 
            // colVisitId
            // 
            colVisitId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colVisitId.DataPropertyName = "VisitId";
            colVisitId.HeaderText = "رقم الزياره";
            colVisitId.MinimumWidth = 2;
            colVisitId.Name = "colVisitId";
            colVisitId.ReadOnly = true;
            colVisitId.Width = 122;
            // 
            // colAppointmentId
            // 
            colAppointmentId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colAppointmentId.DataPropertyName = "AppointmentId";
            colAppointmentId.HeaderText = "رقم الحجز";
            colAppointmentId.MinimumWidth = 2;
            colAppointmentId.Name = "colAppointmentId";
            colAppointmentId.ReadOnly = true;
            colAppointmentId.Width = 116;
            // 
            // colPatientId
            // 
            colPatientId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colPatientId.DataPropertyName = "PatientId";
            colPatientId.HeaderText = "رقم المريض";
            colPatientId.MinimumWidth = 2;
            colPatientId.Name = "colPatientId";
            colPatientId.ReadOnly = true;
            colPatientId.Visible = false;
            colPatientId.Width = 125;
            // 
            // colPatientName
            // 
            colPatientName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPatientName.DataPropertyName = "PatientName";
            colPatientName.HeaderText = "اسم المريض";
            colPatientName.MinimumWidth = 200;
            colPatientName.Name = "colPatientName";
            colPatientName.ReadOnly = true;
            colPatientName.Width = 200;
            // 
            // colVisitDateTime
            // 
            colVisitDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            colVisitDateTime.DataPropertyName = "VisitDateTime";
            colVisitDateTime.HeaderText = "تاريخ الزياره";
            colVisitDateTime.MinimumWidth = 2;
            colVisitDateTime.Name = "colVisitDateTime";
            colVisitDateTime.ReadOnly = true;
            colVisitDateTime.Width = 2;
            // 
            // colVisitTreatments
            // 
            colVisitTreatments.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colVisitTreatments.DataPropertyName = "VisitTreatmentsNames";
            colVisitTreatments.HeaderText = "الخدمات المقدمه";
            colVisitTreatments.MinimumWidth = 200;
            colVisitTreatments.Name = "colVisitTreatments";
            colVisitTreatments.ReadOnly = true;
            colVisitTreatments.ToolTipText = "الخدمات المقدمه للمريض في الزياره";
            // 
            // colTotalAmount
            // 
            colTotalAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colTotalAmount.DataPropertyName = "TotalAmount";
            colTotalAmount.HeaderText = "المبلغ الكلي";
            colTotalAmount.MinimumWidth = 100;
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.ReadOnly = true;
            colTotalAmount.Width = 140;
            // 
            // colTotalPaidAmount
            // 
            colTotalPaidAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colTotalPaidAmount.DataPropertyName = "TotalPaidAmount";
            colTotalPaidAmount.HeaderText = "إجمالي المبالغ المدفوعه";
            colTotalPaidAmount.MinimumWidth = 100;
            colTotalPaidAmount.Name = "colTotalPaidAmount";
            colTotalPaidAmount.ReadOnly = true;
            colTotalPaidAmount.Width = 238;
            // 
            // colDiscountAmount
            // 
            colDiscountAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colDiscountAmount.DataPropertyName = "DiscountAmount";
            colDiscountAmount.HeaderText = "مبلغ الخصم";
            colDiscountAmount.MinimumWidth = 100;
            colDiscountAmount.Name = "colDiscountAmount";
            colDiscountAmount.ReadOnly = true;
            colDiscountAmount.Width = 138;
            // 
            // colRemainedAmount
            // 
            colRemainedAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colRemainedAmount.DataPropertyName = "RemainedAmount";
            colRemainedAmount.HeaderText = "المبلغ المتبقي";
            colRemainedAmount.MinimumWidth = 100;
            colRemainedAmount.Name = "colRemainedAmount";
            colRemainedAmount.ReadOnly = true;
            colRemainedAmount.Width = 159;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { cmsEdit, toolStripSeparator4, cmsShowPatientDetails, cmsShowAppointmentDetails, tsmiViewAllRadiographsRelatedToTheVisit, toolStripSeparator2, tsmiAddNewVisitToTheSamePatient, tsmiAddNewRadiographToTheSameVisit, toolStripSeparator1, cmsDelete, toolStripSeparator3, cmsRefreshGrid });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.RightToLeft = RightToLeft.Yes;
            contextMenuStrip.Size = new Size(291, 236);
            // 
            // cmsEdit
            // 
            cmsEdit.Image = Properties.Resources.pen_512;
            cmsEdit.Name = "cmsEdit";
            cmsEdit.ShortcutKeys = Keys.Control | Keys.E;
            cmsEdit.ShowShortcutKeys = false;
            cmsEdit.Size = new Size(290, 26);
            cmsEdit.Text = "تعديل";
            cmsEdit.Click += cmsEdit_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(287, 6);
            // 
            // cmsShowPatientDetails
            // 
            cmsShowPatientDetails.Image = (Image)resources.GetObject("cmsShowPatientDetails.Image");
            cmsShowPatientDetails.Name = "cmsShowPatientDetails";
            cmsShowPatientDetails.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            cmsShowPatientDetails.ShowShortcutKeys = false;
            cmsShowPatientDetails.Size = new Size(290, 26);
            cmsShowPatientDetails.Text = "عرض بيانات المريض";
            cmsShowPatientDetails.Click += cmsShowPatientDetails_Click;
            // 
            // cmsShowAppointmentDetails
            // 
            cmsShowAppointmentDetails.Image = Properties.Resources.details_512;
            cmsShowAppointmentDetails.Name = "cmsShowAppointmentDetails";
            cmsShowAppointmentDetails.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            cmsShowAppointmentDetails.ShowShortcutKeys = false;
            cmsShowAppointmentDetails.Size = new Size(290, 26);
            cmsShowAppointmentDetails.Text = "عرض بيانات الحجز";
            cmsShowAppointmentDetails.Click += cmsShowAppointmentDetails_Click;
            // 
            // tsmiViewAllRadiographsRelatedToTheVisit
            // 
            tsmiViewAllRadiographsRelatedToTheVisit.Image = Properties.Resources.radiograph_512;
            tsmiViewAllRadiographsRelatedToTheVisit.Name = "tsmiViewAllRadiographsRelatedToTheVisit";
            tsmiViewAllRadiographsRelatedToTheVisit.Size = new Size(290, 26);
            tsmiViewAllRadiographsRelatedToTheVisit.Text = "عرض كل الأشعه المرتبطه بالزياره";
            tsmiViewAllRadiographsRelatedToTheVisit.Click += tsmiViewAllRadiographsRelatedToTheVisit_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(287, 6);
            // 
            // tsmiAddNewVisitToTheSamePatient
            // 
            tsmiAddNewVisitToTheSamePatient.Image = Properties.Resources.plus_512;
            tsmiAddNewVisitToTheSamePatient.Name = "tsmiAddNewVisitToTheSamePatient";
            tsmiAddNewVisitToTheSamePatient.Size = new Size(290, 26);
            tsmiAddNewVisitToTheSamePatient.Text = "إضافة زياره أخري لنفس المريض";
            tsmiAddNewVisitToTheSamePatient.Click += tsmiAddNewVisitToTheSamePatient_Click;
            // 
            // tsmiAddNewRadiographToTheSameVisit
            // 
            tsmiAddNewRadiographToTheSameVisit.Image = Properties.Resources.plus_512;
            tsmiAddNewRadiographToTheSameVisit.Name = "tsmiAddNewRadiographToTheSameVisit";
            tsmiAddNewRadiographToTheSameVisit.Size = new Size(290, 26);
            tsmiAddNewRadiographToTheSameVisit.Text = "إضافة أشعة أخري لنفس الزيارة";
            tsmiAddNewRadiographToTheSameVisit.Click += tsmiAddNewRadiographToTheSameVisit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(287, 6);
            // 
            // cmsDelete
            // 
            cmsDelete.Image = Properties.Resources.bin_512;
            cmsDelete.Name = "cmsDelete";
            cmsDelete.RightToLeftAutoMirrorImage = true;
            cmsDelete.ShortcutKeys = Keys.Delete;
            cmsDelete.ShowShortcutKeys = false;
            cmsDelete.Size = new Size(290, 26);
            cmsDelete.Text = "حذف";
            cmsDelete.Click += cmsDelete_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(287, 6);
            // 
            // cmsRefreshGrid
            // 
            cmsRefreshGrid.Image = Properties.Resources.Refresh_32;
            cmsRefreshGrid.Name = "cmsRefreshGrid";
            cmsRefreshGrid.ShortcutKeys = Keys.F5;
            cmsRefreshGrid.ShowShortcutKeys = false;
            cmsRefreshGrid.Size = new Size(290, 26);
            cmsRefreshGrid.Text = "تحديث";
            cmsRefreshGrid.Click += cmsRefreshGrid_Click;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderRadius = 7;
            txtFilterValue.CustomizableEdges = customizableEdges13;
            txtFilterValue.DefaultText = "";
            txtFilterValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFilterValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFilterValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = Color.Black;
            txtFilterValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Location = new Point(785, 472);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 9;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "رقم الزياره", "رقم الحجز", "اسم المريض", "تاريخ الزياره", "الخدمات المقدمه", "المبلغ الكلي", "إجمالي المبالغ المدفوعه", "مبلغ الخصم", "المبلغ المتبقي" });
            cbFilterList.Location = new Point(477, 472);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 11;
            cbFilterList.SelectedIndexChanged += cbFilterList_SelectedIndexChanged;
            // 
            // pnlTotalVisits
            // 
            pnlTotalVisits.BackColor = Color.Transparent;
            pnlTotalVisits.Controls.Add(lblTotalVisits);
            pnlTotalVisits.Controls.Add(label1);
            pnlTotalVisits.FillColor = Color.White;
            pnlTotalVisits.Location = new Point(1273, 219);
            pnlTotalVisits.Name = "pnlTotalVisits";
            pnlTotalVisits.Radius = 10;
            pnlTotalVisits.ShadowColor = Color.Black;
            pnlTotalVisits.ShadowDepth = 150;
            pnlTotalVisits.Size = new Size(266, 125);
            pnlTotalVisits.TabIndex = 2;
            // 
            // lblTotalVisits
            // 
            lblTotalVisits.ForeColor = Color.Black;
            lblTotalVisits.Location = new Point(3, 55);
            lblTotalVisits.Name = "lblTotalVisits";
            lblTotalVisits.Size = new Size(260, 28);
            lblTotalVisits.TabIndex = 4;
            lblTotalVisits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(93, 8);
            label1.Name = "label1";
            label1.Size = new Size(165, 28);
            label1.TabIndex = 3;
            label1.Text = "عدد الزيارات الكليه";
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblSumOfPaidAmounts);
            guna2ShadowPanel1.Controls.Add(label2);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(819, 219);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 150;
            guna2ShadowPanel1.Size = new Size(322, 125);
            guna2ShadowPanel1.TabIndex = 3;
            // 
            // lblSumOfPaidAmounts
            // 
            lblSumOfPaidAmounts.ForeColor = Color.Black;
            lblSumOfPaidAmounts.Location = new Point(3, 55);
            lblSumOfPaidAmounts.Name = "lblSumOfPaidAmounts";
            lblSumOfPaidAmounts.Size = new Size(319, 28);
            lblSumOfPaidAmounts.TabIndex = 0;
            lblSumOfPaidAmounts.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(38, 8);
            label2.Name = "label2";
            label2.Size = new Size(277, 28);
            label2.TabIndex = 3;
            label2.Text = "مجموع إجمالي المبالغ المدفوعه";
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(lblSumOfDiscountAmount);
            guna2ShadowPanel2.Controls.Add(label3);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(421, 219);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 150;
            guna2ShadowPanel2.Size = new Size(266, 125);
            guna2ShadowPanel2.TabIndex = 4;
            // 
            // lblSumOfDiscountAmount
            // 
            lblSumOfDiscountAmount.ForeColor = Color.Black;
            lblSumOfDiscountAmount.Location = new Point(3, 55);
            lblSumOfDiscountAmount.Name = "lblSumOfDiscountAmount";
            lblSumOfDiscountAmount.Size = new Size(260, 28);
            lblSumOfDiscountAmount.TabIndex = 6;
            lblSumOfDiscountAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(33, 8);
            label3.Name = "label3";
            label3.Size = new Size(225, 28);
            label3.TabIndex = 3;
            label3.Text = "مجموع المبالغ المخصومه";
            // 
            // guna2ShadowPanel3
            // 
            guna2ShadowPanel3.BackColor = Color.Transparent;
            guna2ShadowPanel3.Controls.Add(lblSumOfRemainedAmount);
            guna2ShadowPanel3.Controls.Add(label4);
            guna2ShadowPanel3.FillColor = Color.White;
            guna2ShadowPanel3.Location = new Point(23, 219);
            guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            guna2ShadowPanel3.Radius = 10;
            guna2ShadowPanel3.ShadowColor = Color.Black;
            guna2ShadowPanel3.ShadowDepth = 150;
            guna2ShadowPanel3.Size = new Size(266, 125);
            guna2ShadowPanel3.TabIndex = 5;
            // 
            // lblSumOfRemainedAmount
            // 
            lblSumOfRemainedAmount.ForeColor = Color.Black;
            lblSumOfRemainedAmount.Location = new Point(3, 55);
            lblSumOfRemainedAmount.Name = "lblSumOfRemainedAmount";
            lblSumOfRemainedAmount.Size = new Size(260, 28);
            lblSumOfRemainedAmount.TabIndex = 7;
            lblSumOfRemainedAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(56, 8);
            label4.Name = "label4";
            label4.Size = new Size(202, 28);
            label4.TabIndex = 3;
            label4.Text = "مجموع المبالغ المتبقيه";
            // 
            // pnlSearchAtRadioButtons
            // 
            pnlSearchAtRadioButtons.BackColor = Color.Transparent;
            pnlSearchAtRadioButtons.BorderColor = Color.Navy;
            pnlSearchAtRadioButtons.BorderRadius = 30;
            pnlSearchAtRadioButtons.BorderThickness = 3;
            pnlSearchAtRadioButtons.Controls.Add(label6);
            pnlSearchAtRadioButtons.Controls.Add(label5);
            pnlSearchAtRadioButtons.Controls.Add(rbThisWeek);
            pnlSearchAtRadioButtons.Controls.Add(rbThisMonth);
            pnlSearchAtRadioButtons.Controls.Add(rbAllTime);
            pnlSearchAtRadioButtons.Controls.Add(rbToday);
            pnlSearchAtRadioButtons.CustomizableEdges = customizableEdges15;
            pnlSearchAtRadioButtons.Location = new Point(1210, 10);
            pnlSearchAtRadioButtons.Name = "pnlSearchAtRadioButtons";
            pnlSearchAtRadioButtons.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlSearchAtRadioButtons.Size = new Size(337, 168);
            pnlSearchAtRadioButtons.TabIndex = 0;
            pnlSearchAtRadioButtons.UseTransparentBackground = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(7, 99);
            label6.Name = "label6";
            label6.Size = new Size(202, 23);
            label6.TabIndex = 5;
            label6.Text = "بداية من اول يوم في الشهر";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 61);
            label5.Name = "label5";
            label5.Size = new Size(151, 23);
            label5.TabIndex = 4;
            label5.Text = "بداية من يوم السبت";
            // 
            // rbThisWeek
            // 
            rbThisWeek.Anchor = AnchorStyles.Right;
            rbThisWeek.AutoSize = true;
            rbThisWeek.Location = new Point(190, 51);
            rbThisWeek.Name = "rbThisWeek";
            rbThisWeek.Size = new Size(129, 32);
            rbThisWeek.TabIndex = 1;
            rbThisWeek.Text = "هذا الأسبوع";
            rbThisWeek.UseVisualStyleBackColor = true;
            rbThisWeek.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // rbThisMonth
            // 
            rbThisMonth.Anchor = AnchorStyles.Right;
            rbThisMonth.AutoSize = true;
            rbThisMonth.Location = new Point(206, 89);
            rbThisMonth.Name = "rbThisMonth";
            rbThisMonth.Size = new Size(113, 32);
            rbThisMonth.TabIndex = 2;
            rbThisMonth.Text = "هذا الشهر";
            rbThisMonth.UseVisualStyleBackColor = true;
            rbThisMonth.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // rbAllTime
            // 
            rbAllTime.Anchor = AnchorStyles.Right;
            rbAllTime.AutoSize = true;
            rbAllTime.Checked = true;
            rbAllTime.Location = new Point(231, 124);
            rbAllTime.Name = "rbAllTime";
            rbAllTime.Size = new Size(88, 32);
            rbAllTime.TabIndex = 3;
            rbAllTime.TabStop = true;
            rbAllTime.Text = "الجميع";
            rbAllTime.UseVisualStyleBackColor = true;
            rbAllTime.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // rbToday
            // 
            rbToday.Anchor = AnchorStyles.Right;
            rbToday.AutoSize = true;
            rbToday.Location = new Point(245, 13);
            rbToday.Name = "rbToday";
            rbToday.Size = new Size(74, 32);
            rbToday.TabIndex = 0;
            rbToday.Text = "اليوم";
            rbToday.UseVisualStyleBackColor = true;
            rbToday.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // dtpSearchAfter
            // 
            dtpSearchAfter.Animated = true;
            dtpSearchAfter.BackColor = Color.Transparent;
            dtpSearchAfter.BorderColor = Color.White;
            dtpSearchAfter.BorderRadius = 15;
            dtpSearchAfter.Checked = true;
            dtpSearchAfter.CustomizableEdges = customizableEdges17;
            dtpSearchAfter.FillColor = Color.White;
            dtpSearchAfter.FocusedColor = Color.White;
            dtpSearchAfter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpSearchAfter.Format = DateTimePickerFormat.Long;
            dtpSearchAfter.HoverState.BorderColor = Color.White;
            dtpSearchAfter.HoverState.FillColor = Color.White;
            dtpSearchAfter.HoverState.ForeColor = Color.Black;
            dtpSearchAfter.Location = new Point(511, 386);
            dtpSearchAfter.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpSearchAfter.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpSearchAfter.Name = "dtpSearchAfter";
            dtpSearchAfter.RightToLeft = RightToLeft.No;
            dtpSearchAfter.ShadowDecoration.BorderRadius = 30;
            dtpSearchAfter.ShadowDecoration.CustomizableEdges = customizableEdges18;
            dtpSearchAfter.ShadowDecoration.Shadow = new Padding(0);
            dtpSearchAfter.Size = new Size(301, 45);
            dtpSearchAfter.TabIndex = 8;
            dtpSearchAfter.TextAlign = HorizontalAlignment.Center;
            dtpSearchAfter.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpSearchAfter.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // timerUpdateDateTimePckerMaxDate
            // 
            timerUpdateDateTimePckerMaxDate.Interval = 1000;
            timerUpdateDateTimePckerMaxDate.Tick += timer_Tick;
            // 
            // filterTimer
            // 
            filterTimer.Interval = 400;
            filterTimer.Tick += filterTimer_Tick;
            // 
            // btnRefresh
            // 
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.Location = new Point(3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(47, 49);
            btnRefresh.TabIndex = 1;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblSearchAfter
            // 
            lblSearchAfter.AutoSize = true;
            lblSearchAfter.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchAfter.Location = new Point(831, 391);
            lblSearchAfter.Name = "lblSearchAfter";
            lblSearchAfter.Size = new Size(221, 31);
            lblSearchAfter.TabIndex = 7;
            lblSearchAfter.Text = "ابحث بعد تاريخ معين :";
            // 
            // btnAddWalkInVisit
            // 
            btnAddWalkInVisit.Animated = true;
            btnAddWalkInVisit.AnimatedGIF = true;
            btnAddWalkInVisit.BackColor = Color.Transparent;
            btnAddWalkInVisit.BorderRadius = 7;
            btnAddWalkInVisit.CustomizableEdges = customizableEdges19;
            btnAddWalkInVisit.DisabledState.BorderColor = Color.DarkGray;
            btnAddWalkInVisit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddWalkInVisit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddWalkInVisit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddWalkInVisit.FillColor = Color.FromArgb(0, 0, 150);
            btnAddWalkInVisit.Font = new Font("Segoe UI", 13.8F);
            btnAddWalkInVisit.ForeColor = Color.White;
            btnAddWalkInVisit.HoverState.FillColor = Color.MediumBlue;
            btnAddWalkInVisit.Location = new Point(1259, 379);
            btnAddWalkInVisit.Name = "btnAddWalkInVisit";
            btnAddWalkInVisit.PressedColor = Color.FromArgb(0, 0, 165);
            btnAddWalkInVisit.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnAddWalkInVisit.Size = new Size(288, 57);
            btnAddWalkInVisit.TabIndex = 6;
            btnAddWalkInVisit.Text = "ابدأ زياره بدون حجز مسبق";
            btnAddWalkInVisit.Click += btnAddWalkInVisit_Click;
            // 
            // dtpVisitDateTime
            // 
            dtpVisitDateTime.Animated = true;
            dtpVisitDateTime.BackColor = Color.Transparent;
            dtpVisitDateTime.BorderColor = Color.White;
            dtpVisitDateTime.BorderRadius = 15;
            dtpVisitDateTime.Checked = true;
            dtpVisitDateTime.CustomizableEdges = customizableEdges21;
            dtpVisitDateTime.FillColor = Color.White;
            dtpVisitDateTime.FocusedColor = Color.White;
            dtpVisitDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpVisitDateTime.Format = DateTimePickerFormat.Long;
            dtpVisitDateTime.HoverState.BorderColor = Color.White;
            dtpVisitDateTime.HoverState.FillColor = Color.White;
            dtpVisitDateTime.HoverState.ForeColor = Color.Black;
            dtpVisitDateTime.Location = new Point(785, 468);
            dtpVisitDateTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpVisitDateTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpVisitDateTime.Name = "dtpVisitDateTime";
            dtpVisitDateTime.RightToLeft = RightToLeft.No;
            dtpVisitDateTime.ShadowDecoration.BorderRadius = 30;
            dtpVisitDateTime.ShadowDecoration.CustomizableEdges = customizableEdges22;
            dtpVisitDateTime.ShadowDecoration.Shadow = new Padding(0);
            dtpVisitDateTime.Size = new Size(301, 45);
            dtpVisitDateTime.TabIndex = 10;
            dtpVisitDateTime.TextAlign = HorizontalAlignment.Center;
            dtpVisitDateTime.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpVisitDateTime.Visible = false;
            dtpVisitDateTime.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // btnCreatePreAppointmentVisit
            // 
            btnCreatePreAppointmentVisit.Animated = true;
            btnCreatePreAppointmentVisit.AnimatedGIF = true;
            btnCreatePreAppointmentVisit.BackColor = Color.Transparent;
            btnCreatePreAppointmentVisit.BorderRadius = 7;
            btnCreatePreAppointmentVisit.CustomizableEdges = customizableEdges23;
            btnCreatePreAppointmentVisit.DisabledState.BorderColor = Color.DarkGray;
            btnCreatePreAppointmentVisit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreatePreAppointmentVisit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreatePreAppointmentVisit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreatePreAppointmentVisit.FillColor = Color.FromArgb(0, 0, 150);
            btnCreatePreAppointmentVisit.Font = new Font("Segoe UI", 13.8F);
            btnCreatePreAppointmentVisit.ForeColor = Color.White;
            btnCreatePreAppointmentVisit.HoverState.FillColor = Color.MediumBlue;
            btnCreatePreAppointmentVisit.Location = new Point(1259, 456);
            btnCreatePreAppointmentVisit.Name = "btnCreatePreAppointmentVisit";
            btnCreatePreAppointmentVisit.PressedColor = Color.FromArgb(0, 0, 165);
            btnCreatePreAppointmentVisit.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnCreatePreAppointmentVisit.Size = new Size(288, 57);
            btnCreatePreAppointmentVisit.TabIndex = 9;
            btnCreatePreAppointmentVisit.Text = "ابدأ زياره بحجز مسبق";
            btnCreatePreAppointmentVisit.Click += btnCreatePreAppointmentVisit_Click;
            // 
            // LoadDataFirstTimeTimer
            // 
            LoadDataFirstTimeTimer.Interval = 10;
            LoadDataFirstTimeTimer.Tick += LoadDataFirstTimeTimer_Tick;
            // 
            // guna2ShadowPanel4
            // 
            guna2ShadowPanel4.BackColor = Color.Transparent;
            guna2ShadowPanel4.Controls.Add(lblSumOfTotalAmount);
            guna2ShadowPanel4.Controls.Add(label8);
            guna2ShadowPanel4.FillColor = Color.White;
            guna2ShadowPanel4.Location = new Point(616, 41);
            guna2ShadowPanel4.Name = "guna2ShadowPanel4";
            guna2ShadowPanel4.Radius = 10;
            guna2ShadowPanel4.ShadowColor = Color.Black;
            guna2ShadowPanel4.ShadowDepth = 150;
            guna2ShadowPanel4.Size = new Size(266, 125);
            guna2ShadowPanel4.TabIndex = 8;
            guna2ShadowPanel4.Visible = false;
            // 
            // lblSumOfTotalAmount
            // 
            lblSumOfTotalAmount.ForeColor = Color.Black;
            lblSumOfTotalAmount.Location = new Point(3, 55);
            lblSumOfTotalAmount.Name = "lblSumOfTotalAmount";
            lblSumOfTotalAmount.Size = new Size(260, 28);
            lblSumOfTotalAmount.TabIndex = 7;
            lblSumOfTotalAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(255, 128, 0);
            label8.Location = new Point(75, 8);
            label8.Name = "label8";
            label8.Size = new Size(183, 28);
            label8.TabIndex = 3;
            label8.Text = "مجموع المبالغ الكليه";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(1459, 543);
            label7.Name = "label7";
            label7.Size = new Size(103, 31);
            label7.TabIndex = 13;
            label7.Text = "ملحوظه :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(961, 544);
            label9.Name = "label9";
            label9.Size = new Size(496, 28);
            label9.TabIndex = 14;
            label9.Text = "اضغط علي الصف ضغطتين متتاليتين لتعديل بيانات الزياره.";
            // 
            // VisitsView
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(guna2ShadowPanel4);
            Controls.Add(btnCreatePreAppointmentVisit);
            Controls.Add(btnAddWalkInVisit);
            Controls.Add(lblSearchAfter);
            Controls.Add(btnRefresh);
            Controls.Add(pnlSearchAtRadioButtons);
            Controls.Add(guna2ShadowPanel3);
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(pnlTotalVisits);
            Controls.Add(cbFilterList);
            Controls.Add(dataGridView);
            Controls.Add(dtpSearchAfter);
            Controls.Add(dtpVisitDateTime);
            Controls.Add(txtFilterValue);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1562, 956);
            MinimumSize = new Size(1562, 956);
            Name = "VisitsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1562, 956);
            Load += VisitView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip.ResumeLayout(false);
            pnlTotalVisits.ResumeLayout(false);
            pnlTotalVisits.PerformLayout();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            guna2ShadowPanel3.ResumeLayout(false);
            guna2ShadowPanel3.PerformLayout();
            pnlSearchAtRadioButtons.ResumeLayout(false);
            pnlSearchAtRadioButtons.PerformLayout();
            guna2ShadowPanel4.ResumeLayout(false);
            guna2ShadowPanel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private ComboBox cbFilterList;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTotalVisits;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel3;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchAtRadioButtons;
        private RadioButton rbToday;
        private RadioButton rbThisWeek;
        private RadioButton rbThisMonth;
        private RadioButton rbAllTime;
        private Label lblTotalVisits;
        private Label lblSumOfPaidAmounts;
        private Label lblSumOfDiscountAmount;
        private Label lblSumOfRemainedAmount;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpSearchAfter;
        private System.Windows.Forms.Timer timerUpdateDateTimePckerMaxDate;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmsEdit;
        private ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.Timer filterTimer;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private ToolStripMenuItem cmsRefreshGrid;
        private Label lblSearchAfter;
        private Guna.UI2.WinForms.Guna2Button btnAddWalkInVisit;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpVisitDateTime;
        private ToolStripMenuItem cmsShowPatientDetails;
        private ToolStripMenuItem cmsShowAppointmentDetails;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator2;
        private Guna.UI2.WinForms.Guna2Button btnCreatePreAppointmentVisit;
        private System.Windows.Forms.Timer LoadDataFirstTimeTimer;
        private Label label5;
        private Label label6;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel4;
        private Label lblSumOfTotalAmount;
        private Label label8;
        private Label label7;
        private Label label9;
        private DataGridViewTextBoxColumn colVisitId;
        private DataGridViewTextBoxColumn colAppointmentId;
        private DataGridViewTextBoxColumn colPatientId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colVisitDateTime;
        private DataGridViewTextBoxColumn colVisitTreatments;
        private DataGridViewTextBoxColumn colTotalAmount;
        private DataGridViewTextBoxColumn colTotalPaidAmount;
        private DataGridViewTextBoxColumn colDiscountAmount;
        private DataGridViewTextBoxColumn colRemainedAmount;
        private ToolStripMenuItem tsmiAddNewVisitToTheSamePatient;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiAddNewRadiographToTheSameVisit;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tsmiViewAllRadiographsRelatedToTheVisit;
    }
}
