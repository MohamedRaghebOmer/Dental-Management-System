namespace Dental.WinForms.Views
{
    partial class VisitView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colVisitId = new DataGridViewTextBoxColumn();
            colAppointmetId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colVisitDateTime = new DataGridViewTextBoxColumn();
            colVisitTreatments = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            colPaidAmount = new DataGridViewTextBoxColumn();
            colDiscountAmount = new DataGridViewTextBoxColumn();
            colRemainedAmount = new DataGridViewTextBoxColumn();
            contextMenuStrip = new ContextMenuStrip(components);
            cmsEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cmsAdd = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            cmsDelete = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cmsRefreshGrid = new ToolStripMenuItem();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            cbFilterList = new ComboBox();
            pnlTotalVisits = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTotalVisits = new Label();
            label1 = new Label();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTotalPaidAmount = new Label();
            label2 = new Label();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTotalDiscountAmount = new Label();
            label3 = new Label();
            guna2ShadowPanel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTotalRemainedAmount = new Label();
            label4 = new Label();
            pnlCardsPeriod = new Guna.UI2.WinForms.Guna2Panel();
            rbThisWeek = new RadioButton();
            rbThisMonth = new RadioButton();
            rbAll = new RadioButton();
            rbToday = new RadioButton();
            btnAddVisit = new Guna.UI2.WinForms.Guna2ImageButton();
            dateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            timerUpdateDateTimePckerMaxDate = new System.Windows.Forms.Timer(components);
            filterTime = new System.Windows.Forms.Timer(components);
            btnRefresh = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            pnlTotalVisits.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            guna2ShadowPanel2.SuspendLayout();
            guna2ShadowPanel3.SuspendLayout();
            pnlCardsPeriod.SuspendLayout();
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colVisitId, colAppointmetId, colPatientName, colVisitDateTime, colVisitTreatments, colTotalAmount, colPaidAmount, colDiscountAmount, colRemainedAmount });
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
            dataGridView.TabIndex = 6;
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
            // 
            // colVisitId
            // 
            colVisitId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colVisitId.DataPropertyName = "VisitId";
            colVisitId.HeaderText = "رقم الزياره";
            colVisitId.MinimumWidth = 6;
            colVisitId.Name = "colVisitId";
            colVisitId.ReadOnly = true;
            colVisitId.Visible = false;
            colVisitId.Width = 150;
            // 
            // colAppointmetId
            // 
            colAppointmetId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colAppointmetId.DataPropertyName = "AppointmentId";
            colAppointmetId.HeaderText = "رقم الحجز";
            colAppointmetId.MinimumWidth = 6;
            colAppointmetId.Name = "colAppointmetId";
            colAppointmetId.ReadOnly = true;
            colAppointmetId.Visible = false;
            colAppointmetId.Width = 150;
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
            // colVisitDateTime
            // 
            colVisitDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colVisitDateTime.DataPropertyName = "VisitDateTime";
            colVisitDateTime.HeaderText = "تاريخ الزياره";
            colVisitDateTime.MinimumWidth = 6;
            colVisitDateTime.Name = "colVisitDateTime";
            colVisitDateTime.ReadOnly = true;
            // 
            // colVisitTreatments
            // 
            colVisitTreatments.DataPropertyName = "VisitTreatmentsNames";
            colVisitTreatments.HeaderText = "الخدمات المقدمه";
            colVisitTreatments.MinimumWidth = 6;
            colVisitTreatments.Name = "colVisitTreatments";
            colVisitTreatments.ReadOnly = true;
            colVisitTreatments.ToolTipText = "الخدمات المقدمه للمريض في الزياره";
            // 
            // colTotalAmount
            // 
            colTotalAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTotalAmount.DataPropertyName = "TotalAmount";
            colTotalAmount.HeaderText = "المبلغ الكلي";
            colTotalAmount.MinimumWidth = 6;
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.ReadOnly = true;
            colTotalAmount.Width = 170;
            // 
            // colPaidAmount
            // 
            colPaidAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPaidAmount.DataPropertyName = "PaidAmount";
            colPaidAmount.HeaderText = "المبلغ المدفوع";
            colPaidAmount.MinimumWidth = 6;
            colPaidAmount.Name = "colPaidAmount";
            colPaidAmount.ReadOnly = true;
            colPaidAmount.Width = 170;
            // 
            // colDiscountAmount
            // 
            colDiscountAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colDiscountAmount.DataPropertyName = "DiscountAmount";
            colDiscountAmount.HeaderText = "مبلغ الخصم";
            colDiscountAmount.MinimumWidth = 6;
            colDiscountAmount.Name = "colDiscountAmount";
            colDiscountAmount.ReadOnly = true;
            colDiscountAmount.Width = 170;
            // 
            // colRemainedAmount
            // 
            colRemainedAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colRemainedAmount.DataPropertyName = "RemainedAmount";
            colRemainedAmount.HeaderText = "المبلغ المتبقي";
            colRemainedAmount.MinimumWidth = 6;
            colRemainedAmount.Name = "colRemainedAmount";
            colRemainedAmount.ReadOnly = true;
            colRemainedAmount.Width = 170;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { cmsEdit, toolStripSeparator1, cmsAdd, toolStripSeparator2, cmsDelete, toolStripSeparator3, cmsRefreshGrid });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.RightToLeft = RightToLeft.Yes;
            contextMenuStrip.Size = new Size(250, 126);
            // 
            // cmsEdit
            // 
            cmsEdit.Image = Properties.Resources.pen_512;
            cmsEdit.Name = "cmsEdit";
            cmsEdit.ShortcutKeys = Keys.Control | Keys.E;
            cmsEdit.Size = new Size(249, 26);
            cmsEdit.Text = "تعديل الزياره";
            cmsEdit.Click += cmsEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(246, 6);
            // 
            // cmsAdd
            // 
            cmsAdd.Image = Properties.Resources.plus_512;
            cmsAdd.Name = "cmsAdd";
            cmsAdd.ShortcutKeys = Keys.Control | Keys.N;
            cmsAdd.Size = new Size(249, 26);
            cmsAdd.Text = "اضافة زياره جديده";
            cmsAdd.Click += cmsAdd_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(246, 6);
            // 
            // cmsDelete
            // 
            cmsDelete.Image = Properties.Resources.bin_512;
            cmsDelete.Name = "cmsDelete";
            cmsDelete.RightToLeftAutoMirrorImage = true;
            cmsDelete.ShortcutKeys = Keys.Delete;
            cmsDelete.Size = new Size(249, 26);
            cmsDelete.Text = "حذف الزياره";
            cmsDelete.Click += cmsDelete_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(246, 6);
            // 
            // cmsRefreshGrid
            // 
            cmsRefreshGrid.Image = Properties.Resources.Refresh_32;
            cmsRefreshGrid.Name = "cmsRefreshGrid";
            cmsRefreshGrid.ShortcutKeys = Keys.F5;
            cmsRefreshGrid.Size = new Size(249, 26);
            cmsRefreshGrid.Text = "تحديث";
            cmsRefreshGrid.Click += cmsRefreshGrid_Click;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderRadius = 5;
            txtFilterValue.CustomizableEdges = customizableEdges8;
            txtFilterValue.DefaultText = "";
            txtFilterValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFilterValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFilterValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = Color.Black;
            txtFilterValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Location = new Point(785, 508);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges9;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 9;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "اسم المريض", "تاريخ الزياره", "الخدمات المقدمه", "المبلغ الكلي", "المبلغ المدفوع", "مبلغ الخصم", "المبلغ المتبقي" });
            cbFilterList.Location = new Point(477, 508);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 10;
            cbFilterList.SelectedIndexChanged += cbFilterList_SelectedIndexChanged;
            // 
            // pnlTotalVisits
            // 
            pnlTotalVisits.BackColor = Color.Transparent;
            pnlTotalVisits.Controls.Add(lblTotalVisits);
            pnlTotalVisits.Controls.Add(label1);
            pnlTotalVisits.FillColor = Color.White;
            pnlTotalVisits.Location = new Point(1234, 282);
            pnlTotalVisits.Name = "pnlTotalVisits";
            pnlTotalVisits.Radius = 10;
            pnlTotalVisits.ShadowColor = Color.Black;
            pnlTotalVisits.ShadowDepth = 150;
            pnlTotalVisits.Size = new Size(295, 125);
            pnlTotalVisits.TabIndex = 11;
            // 
            // lblTotalVisits
            // 
            lblTotalVisits.AutoSize = true;
            lblTotalVisits.ForeColor = Color.Black;
            lblTotalVisits.Location = new Point(136, 55);
            lblTotalVisits.Name = "lblTotalVisits";
            lblTotalVisits.Size = new Size(23, 28);
            lblTotalVisits.TabIndex = 4;
            lblTotalVisits.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(122, 8);
            label1.Name = "label1";
            label1.Size = new Size(165, 28);
            label1.TabIndex = 3;
            label1.Text = "عدد الزيارات الكليه";
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblTotalPaidAmount);
            guna2ShadowPanel1.Controls.Add(label2);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(834, 282);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 150;
            guna2ShadowPanel1.Size = new Size(295, 125);
            guna2ShadowPanel1.TabIndex = 12;
            // 
            // lblTotalPaidAmount
            // 
            lblTotalPaidAmount.AutoSize = true;
            lblTotalPaidAmount.ForeColor = Color.Black;
            lblTotalPaidAmount.Location = new Point(136, 55);
            lblTotalPaidAmount.Name = "lblTotalPaidAmount";
            lblTotalPaidAmount.Size = new Size(23, 28);
            lblTotalPaidAmount.TabIndex = 5;
            lblTotalPaidAmount.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(89, 8);
            label2.Name = "label2";
            label2.Size = new Size(198, 28);
            label2.TabIndex = 3;
            label2.Text = "اجمالي المبلغ المدفوع";
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(lblTotalDiscountAmount);
            guna2ShadowPanel2.Controls.Add(label3);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(434, 282);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 150;
            guna2ShadowPanel2.Size = new Size(295, 125);
            guna2ShadowPanel2.TabIndex = 13;
            // 
            // lblTotalDiscountAmount
            // 
            lblTotalDiscountAmount.AutoSize = true;
            lblTotalDiscountAmount.ForeColor = Color.Black;
            lblTotalDiscountAmount.Location = new Point(136, 55);
            lblTotalDiscountAmount.Name = "lblTotalDiscountAmount";
            lblTotalDiscountAmount.Size = new Size(23, 28);
            lblTotalDiscountAmount.TabIndex = 6;
            lblTotalDiscountAmount.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(77, 8);
            label3.Name = "label3";
            label3.Size = new Size(210, 28);
            label3.TabIndex = 3;
            label3.Text = "اجمالي المبلغ المخصوم";
            // 
            // guna2ShadowPanel3
            // 
            guna2ShadowPanel3.BackColor = Color.Transparent;
            guna2ShadowPanel3.Controls.Add(lblTotalRemainedAmount);
            guna2ShadowPanel3.Controls.Add(label4);
            guna2ShadowPanel3.FillColor = Color.White;
            guna2ShadowPanel3.Location = new Point(34, 282);
            guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            guna2ShadowPanel3.Radius = 10;
            guna2ShadowPanel3.ShadowColor = Color.Black;
            guna2ShadowPanel3.ShadowDepth = 150;
            guna2ShadowPanel3.Size = new Size(295, 125);
            guna2ShadowPanel3.TabIndex = 14;
            // 
            // lblTotalRemainedAmount
            // 
            lblTotalRemainedAmount.AutoSize = true;
            lblTotalRemainedAmount.ForeColor = Color.Black;
            lblTotalRemainedAmount.Location = new Point(136, 55);
            lblTotalRemainedAmount.Name = "lblTotalRemainedAmount";
            lblTotalRemainedAmount.Size = new Size(23, 28);
            lblTotalRemainedAmount.TabIndex = 7;
            lblTotalRemainedAmount.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(90, 8);
            label4.Name = "label4";
            label4.Size = new Size(197, 28);
            label4.TabIndex = 3;
            label4.Text = "اجمالي المبلغ المتبقي";
            // 
            // pnlCardsPeriod
            // 
            pnlCardsPeriod.BackColor = Color.Transparent;
            pnlCardsPeriod.BorderColor = Color.Navy;
            pnlCardsPeriod.BorderRadius = 30;
            pnlCardsPeriod.BorderThickness = 2;
            pnlCardsPeriod.Controls.Add(rbThisWeek);
            pnlCardsPeriod.Controls.Add(rbThisMonth);
            pnlCardsPeriod.Controls.Add(rbAll);
            pnlCardsPeriod.Controls.Add(rbToday);
            pnlCardsPeriod.CustomizableEdges = customizableEdges10;
            pnlCardsPeriod.Location = new Point(1287, 81);
            pnlCardsPeriod.Name = "pnlCardsPeriod";
            pnlCardsPeriod.ShadowDecoration.CustomizableEdges = customizableEdges11;
            pnlCardsPeriod.Size = new Size(272, 168);
            pnlCardsPeriod.TabIndex = 4;
            pnlCardsPeriod.UseTransparentBackground = true;
            // 
            // rbThisWeek
            // 
            rbThisWeek.AutoSize = true;
            rbThisWeek.Location = new Point(137, 51);
            rbThisWeek.Name = "rbThisWeek";
            rbThisWeek.Size = new Size(129, 32);
            rbThisWeek.TabIndex = 7;
            rbThisWeek.Text = "هذا الأسبوع";
            rbThisWeek.UseVisualStyleBackColor = true;
            rbThisWeek.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // rbThisMonth
            // 
            rbThisMonth.AutoSize = true;
            rbThisMonth.Location = new Point(153, 89);
            rbThisMonth.Name = "rbThisMonth";
            rbThisMonth.Size = new Size(113, 32);
            rbThisMonth.TabIndex = 6;
            rbThisMonth.Text = "هذا الشهر";
            rbThisMonth.UseVisualStyleBackColor = true;
            rbThisMonth.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Location = new Point(178, 124);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(88, 32);
            rbAll.TabIndex = 5;
            rbAll.Text = "الجميع";
            rbAll.UseVisualStyleBackColor = true;
            rbAll.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // rbToday
            // 
            rbToday.AutoSize = true;
            rbToday.Checked = true;
            rbToday.Location = new Point(192, 13);
            rbToday.Name = "rbToday";
            rbToday.Size = new Size(74, 32);
            rbToday.TabIndex = 4;
            rbToday.TabStop = true;
            rbToday.Text = "اليوم";
            rbToday.UseVisualStyleBackColor = true;
            rbToday.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
            // 
            // btnAddVisit
            // 
            btnAddVisit.AnimatedGIF = true;
            btnAddVisit.BackColor = Color.Transparent;
            btnAddVisit.CheckedState.ImageSize = new Size(64, 64);
            btnAddVisit.Cursor = Cursors.Hand;
            btnAddVisit.HoverState.ImageSize = new Size(64, 64);
            btnAddVisit.Image = Properties.Resources.plus_512;
            btnAddVisit.ImageOffset = new Point(0, 0);
            btnAddVisit.ImageRotate = 0F;
            btnAddVisit.Location = new Point(1473, 492);
            btnAddVisit.Name = "btnAddVisit";
            btnAddVisit.PressedState.ImageSize = new Size(64, 64);
            btnAddVisit.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnAddVisit.Size = new Size(80, 68);
            btnAddVisit.TabIndex = 15;
            btnAddVisit.UseTransparentBackground = true;
            btnAddVisit.Click += btnAddVisit_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Animated = true;
            dateTimePicker.AutoRoundedCorners = true;
            dateTimePicker.BackColor = Color.Transparent;
            dateTimePicker.BorderColor = Color.White;
            dateTimePicker.BorderRadius = 21;
            dateTimePicker.Checked = true;
            dateTimePicker.CustomizableEdges = customizableEdges13;
            dateTimePicker.FillColor = Color.White;
            dateTimePicker.FocusedColor = Color.White;
            dateTimePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.HoverState.BorderColor = Color.White;
            dateTimePicker.HoverState.FillColor = Color.White;
            dateTimePicker.HoverState.ForeColor = Color.Black;
            dateTimePicker.Location = new Point(785, 504);
            dateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.ShadowDecoration.BorderRadius = 30;
            dateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges14;
            dateTimePicker.ShadowDecoration.Shadow = new Padding(0);
            dateTimePicker.Size = new Size(301, 45);
            dateTimePicker.TabIndex = 16;
            dateTimePicker.TextAlign = HorizontalAlignment.Center;
            dateTimePicker.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // timerUpdateDateTimePckerMaxDate
            // 
            timerUpdateDateTimePckerMaxDate.Interval = 1000;
            timerUpdateDateTimePckerMaxDate.Tick += timer_Tick;
            // 
            // filterTime
            // 
            filterTime.Interval = 400;
            filterTime.Tick += filterTime_Tick;
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
            btnRefresh.TabIndex = 19;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // VisitView
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(btnRefresh);
            Controls.Add(dateTimePicker);
            Controls.Add(btnAddVisit);
            Controls.Add(pnlCardsPeriod);
            Controls.Add(guna2ShadowPanel3);
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(pnlTotalVisits);
            Controls.Add(cbFilterList);
            Controls.Add(txtFilterValue);
            Controls.Add(dataGridView);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1562, 956);
            MinimumSize = new Size(1562, 956);
            Name = "VisitView";
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
            pnlCardsPeriod.ResumeLayout(false);
            pnlCardsPeriod.PerformLayout();
            ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Panel pnlCardsPeriod;
        private RadioButton rbToday;
        private RadioButton rbThisWeek;
        private RadioButton rbThisMonth;
        private RadioButton rbAll;
        private Guna.UI2.WinForms.Guna2ImageButton btnAddVisit;
        private Label lblTotalVisits;
        private Label lblTotalPaidAmount;
        private Label lblTotalDiscountAmount;
        private Label lblTotalRemainedAmount;
        private DataGridViewTextBoxColumn colVisitId;
        private DataGridViewTextBoxColumn colAppointmetId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colVisitDateTime;
        private DataGridViewTextBoxColumn colVisitTreatments;
        private DataGridViewTextBoxColumn colTotalAmount;
        private DataGridViewTextBoxColumn colPaidAmount;
        private DataGridViewTextBoxColumn colDiscountAmount;
        private DataGridViewTextBoxColumn colRemainedAmount;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker;
        private System.Windows.Forms.Timer timerUpdateDateTimePckerMaxDate;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmsEdit;
        private ToolStripMenuItem cmsAdd;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.Timer filterTime;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cmsRefreshGrid;
    }
}
