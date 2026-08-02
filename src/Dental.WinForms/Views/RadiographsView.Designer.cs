namespace Dental.WinForms.Views
{
    partial class RadiographsView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label9 = new Label();
            label8 = new Label();
            dtpSearchAfter = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnNewVisitRadiograph = new Guna.UI2.WinForms.Guna2Button();
            lblSearchAfter = new Label();
            pnlTotalAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblRadiographsCount = new Label();
            label1 = new Label();
            cbFilterList = new ComboBox();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colVisitId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colRadiographCreatedAt = new DataGridViewTextBoxColumn();
            colPatientId = new DataGridViewTextBoxColumn();
            colVisitRadiographId = new DataGridViewTextBoxColumn();
            colImagePath = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tsmiEdit = new ToolStripMenuItem();
            tsmiDelete = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiEditVisit = new ToolStripMenuItem();
            tsmiEditPatient = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiOpenRadioghraphImage = new ToolStripMenuItem();
            tsmiCopyRadiographImage = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tsmiAddNewRadiographToTheSameVisit = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            tsmiRefresh = new ToolStripMenuItem();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            pnlSearchAtRadioButtons = new Guna.UI2.WinForms.Guna2Panel();
            rbThisMonth = new RadioButton();
            rbThisWeek = new RadioButton();
            rbToday = new RadioButton();
            label5 = new Label();
            label7 = new Label();
            rbAllTime = new RadioButton();
            dateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            loadDataTimer = new System.Windows.Forms.Timer(components);
            timerUpdateDateTimePckerMaxDate = new System.Windows.Forms.Timer(components);
            btnRefresh = new FontAwesome.Sharp.IconButton();
            pnlTotalAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            pnlSearchAtRadioButtons.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(969, 538);
            label9.Name = "label9";
            label9.Size = new Size(479, 28);
            label9.TabIndex = 58;
            label9.Text = "اضغط علي الصف ضغطتين متتاليتين لفتح صورة الأشعه.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1454, 537);
            label8.Name = "label8";
            label8.Size = new Size(103, 31);
            label8.TabIndex = 57;
            label8.Text = "ملحوظه :";
            // 
            // dtpSearchAfter
            // 
            dtpSearchAfter.Animated = true;
            dtpSearchAfter.BackColor = Color.Transparent;
            dtpSearchAfter.BorderColor = Color.White;
            dtpSearchAfter.BorderRadius = 15;
            dtpSearchAfter.Checked = true;
            dtpSearchAfter.CustomizableEdges = customizableEdges1;
            dtpSearchAfter.FillColor = Color.White;
            dtpSearchAfter.FocusedColor = Color.White;
            dtpSearchAfter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpSearchAfter.Format = DateTimePickerFormat.Long;
            dtpSearchAfter.HoverState.BorderColor = Color.White;
            dtpSearchAfter.HoverState.FillColor = Color.White;
            dtpSearchAfter.HoverState.ForeColor = Color.Black;
            dtpSearchAfter.Location = new Point(508, 375);
            dtpSearchAfter.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpSearchAfter.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpSearchAfter.Name = "dtpSearchAfter";
            dtpSearchAfter.RightToLeft = RightToLeft.No;
            dtpSearchAfter.ShadowDecoration.BorderRadius = 30;
            dtpSearchAfter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpSearchAfter.ShadowDecoration.Shadow = new Padding(0);
            dtpSearchAfter.Size = new Size(301, 45);
            dtpSearchAfter.TabIndex = 52;
            dtpSearchAfter.TextAlign = HorizontalAlignment.Center;
            dtpSearchAfter.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpSearchAfter.Visible = false;
            dtpSearchAfter.ValueChanged += dtpSearchAfter_ValueChanged;
            // 
            // btnNewVisitRadiograph
            // 
            btnNewVisitRadiograph.Animated = true;
            btnNewVisitRadiograph.AnimatedGIF = true;
            btnNewVisitRadiograph.BackColor = Color.Transparent;
            btnNewVisitRadiograph.BorderRadius = 15;
            btnNewVisitRadiograph.CustomizableEdges = customizableEdges3;
            btnNewVisitRadiograph.DisabledState.BorderColor = Color.DarkGray;
            btnNewVisitRadiograph.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNewVisitRadiograph.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNewVisitRadiograph.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNewVisitRadiograph.FillColor = Color.FromArgb(0, 0, 150);
            btnNewVisitRadiograph.Font = new Font("Segoe UI", 13.8F);
            btnNewVisitRadiograph.ForeColor = Color.White;
            btnNewVisitRadiograph.HoverState.FillColor = Color.MediumBlue;
            btnNewVisitRadiograph.Location = new Point(1312, 457);
            btnNewVisitRadiograph.Name = "btnNewVisitRadiograph";
            btnNewVisitRadiograph.PressedColor = Color.FromArgb(0, 0, 165);
            btnNewVisitRadiograph.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnNewVisitRadiograph.Size = new Size(232, 57);
            btnNewVisitRadiograph.TabIndex = 56;
            btnNewVisitRadiograph.Text = "إنشاء أشعه جديده";
            btnNewVisitRadiograph.Click += btnNewVisitRadiograph_Click;
            // 
            // lblSearchAfter
            // 
            lblSearchAfter.AutoSize = true;
            lblSearchAfter.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchAfter.Location = new Point(828, 380);
            lblSearchAfter.Name = "lblSearchAfter";
            lblSearchAfter.Size = new Size(221, 31);
            lblSearchAfter.TabIndex = 51;
            lblSearchAfter.Text = "ابحث بعد تاريخ معين :";
            lblSearchAfter.Visible = false;
            // 
            // pnlTotalAppointments
            // 
            pnlTotalAppointments.BackColor = Color.Transparent;
            pnlTotalAppointments.Controls.Add(lblRadiographsCount);
            pnlTotalAppointments.Controls.Add(label1);
            pnlTotalAppointments.FillColor = Color.White;
            pnlTotalAppointments.Location = new Point(609, 163);
            pnlTotalAppointments.Name = "pnlTotalAppointments";
            pnlTotalAppointments.Radius = 10;
            pnlTotalAppointments.ShadowColor = Color.Black;
            pnlTotalAppointments.ShadowDepth = 150;
            pnlTotalAppointments.Size = new Size(298, 130);
            pnlTotalAppointments.TabIndex = 50;
            // 
            // lblRadiographsCount
            // 
            lblRadiographsCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRadiographsCount.ForeColor = Color.Black;
            lblRadiographsCount.Location = new Point(3, 59);
            lblRadiographsCount.Name = "lblRadiographsCount";
            lblRadiographsCount.Size = new Size(295, 24);
            lblRadiographsCount.TabIndex = 4;
            lblRadiographsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(171, 9);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 3;
            label1.Text = "عدد الأشعات";
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "رقم الزيارة", "إسم المريض", "تاريخ إنشاء الأشعة" });
            cbFilterList.Location = new Point(474, 468);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 53;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colVisitId, colPatientName, colRadiographCreatedAt, colPatientId, colVisitRadiographId, colImagePath });
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
            dataGridView.Location = new Point(0, 571);
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
            dataGridView.RowTemplate.ContextMenuStrip = contextMenuStrip1;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.ReadOnly = true;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new Size(1556, 379);
            dataGridView.TabIndex = 55;
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
            dataGridView.DoubleClick += tsmiOpenRadioghraphImage_Click;
            // 
            // colVisitId
            // 
            colVisitId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colVisitId.DataPropertyName = "VisitId";
            colVisitId.HeaderText = "رقم الزياره";
            colVisitId.MinimumWidth = 6;
            colVisitId.Name = "colVisitId";
            colVisitId.ReadOnly = true;
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
            // colRadiographCreatedAt
            // 
            colRadiographCreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRadiographCreatedAt.DataPropertyName = "RadiographCreatedAt";
            colRadiographCreatedAt.HeaderText = "تاريخ الأشعه";
            colRadiographCreatedAt.MinimumWidth = 6;
            colRadiographCreatedAt.Name = "colRadiographCreatedAt";
            colRadiographCreatedAt.ReadOnly = true;
            // 
            // colPatientId
            // 
            colPatientId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colPatientId.DataPropertyName = "PatientId";
            colPatientId.HeaderText = "رقم المريض";
            colPatientId.MinimumWidth = 6;
            colPatientId.Name = "colPatientId";
            colPatientId.ReadOnly = true;
            colPatientId.Visible = false;
            colPatientId.Width = 125;
            // 
            // colVisitRadiographId
            // 
            colVisitRadiographId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colVisitRadiographId.DataPropertyName = "VisitRadiographId";
            colVisitRadiographId.HeaderText = "رقم الأشعه";
            colVisitRadiographId.MinimumWidth = 6;
            colVisitRadiographId.Name = "colVisitRadiographId";
            colVisitRadiographId.ReadOnly = true;
            colVisitRadiographId.Visible = false;
            colVisitRadiographId.Width = 125;
            // 
            // colImagePath
            // 
            colImagePath.DataPropertyName = "ImagePath";
            colImagePath.HeaderText = "مسار صورة الأشعه";
            colImagePath.MinimumWidth = 6;
            colImagePath.Name = "colImagePath";
            colImagePath.ReadOnly = true;
            colImagePath.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tsmiEdit, tsmiDelete, toolStripSeparator1, tsmiEditVisit, tsmiEditPatient, toolStripSeparator2, tsmiOpenRadioghraphImage, tsmiCopyRadiographImage, toolStripSeparator3, tsmiAddNewRadiographToTheSameVisit, toolStripSeparator4, tsmiRefresh });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(284, 236);
            // 
            // tsmiEdit
            // 
            tsmiEdit.Image = Properties.Resources.pen_512;
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.Size = new Size(283, 26);
            tsmiEdit.Text = "تعديل";
            tsmiEdit.Click += tsmiEdit_Click;
            // 
            // tsmiDelete
            // 
            tsmiDelete.Image = Properties.Resources.bin_512;
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new Size(283, 26);
            tsmiDelete.Text = "حذف";
            tsmiDelete.Click += tsmiDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(280, 6);
            // 
            // tsmiEditVisit
            // 
            tsmiEditVisit.Image = Properties.Resources.pen_512;
            tsmiEditVisit.Name = "tsmiEditVisit";
            tsmiEditVisit.Size = new Size(283, 26);
            tsmiEditVisit.Text = "تعديل الزياره";
            tsmiEditVisit.Click += tsmiEditVisit_Click;
            // 
            // tsmiEditPatient
            // 
            tsmiEditPatient.Image = Properties.Resources.pen_512;
            tsmiEditPatient.Name = "tsmiEditPatient";
            tsmiEditPatient.Size = new Size(283, 26);
            tsmiEditPatient.Text = "تعديل المريض";
            tsmiEditPatient.Click += tsmiEditPatient_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(280, 6);
            // 
            // tsmiOpenRadioghraphImage
            // 
            tsmiOpenRadioghraphImage.Image = Properties.Resources.photo_512;
            tsmiOpenRadioghraphImage.Name = "tsmiOpenRadioghraphImage";
            tsmiOpenRadioghraphImage.Size = new Size(283, 26);
            tsmiOpenRadioghraphImage.Text = "فتح صورة الأشعه";
            tsmiOpenRadioghraphImage.Click += tsmiOpenRadioghraphImage_Click;
            // 
            // tsmiCopyRadiographImage
            // 
            tsmiCopyRadiographImage.Image = Properties.Resources.copy;
            tsmiCopyRadiographImage.Name = "tsmiCopyRadiographImage";
            tsmiCopyRadiographImage.Size = new Size(283, 26);
            tsmiCopyRadiographImage.Text = "نسخ صورة الأشعه";
            tsmiCopyRadiographImage.Click += tsmiCopyRadiographImage_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(280, 6);
            // 
            // tsmiAddNewRadiographToTheSameVisit
            // 
            tsmiAddNewRadiographToTheSameVisit.Image = Properties.Resources.plus_512;
            tsmiAddNewRadiographToTheSameVisit.Name = "tsmiAddNewRadiographToTheSameVisit";
            tsmiAddNewRadiographToTheSameVisit.Size = new Size(283, 26);
            tsmiAddNewRadiographToTheSameVisit.Text = "إضافة أشعه جديده لنفس الزياره";
            tsmiAddNewRadiographToTheSameVisit.Click += tsmiAddNewRadiographToTheSameVisit_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(280, 6);
            // 
            // tsmiRefresh
            // 
            tsmiRefresh.Image = Properties.Resources.Refresh_32;
            tsmiRefresh.Name = "tsmiRefresh";
            tsmiRefresh.Size = new Size(283, 26);
            tsmiRefresh.Text = "تحديث";
            tsmiRefresh.Click += tsmiRefresh_Click;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderRadius = 7;
            txtFilterValue.CustomizableEdges = customizableEdges5;
            txtFilterValue.DefaultText = "";
            txtFilterValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFilterValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFilterValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = Color.Black;
            txtFilterValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Location = new Point(782, 468);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 54;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.VisibleChanged += txtFilterValue_VisibleChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // pnlSearchAtRadioButtons
            // 
            pnlSearchAtRadioButtons.BackColor = Color.Transparent;
            pnlSearchAtRadioButtons.BorderColor = Color.Navy;
            pnlSearchAtRadioButtons.BorderRadius = 30;
            pnlSearchAtRadioButtons.BorderThickness = 3;
            pnlSearchAtRadioButtons.Controls.Add(rbThisMonth);
            pnlSearchAtRadioButtons.Controls.Add(rbThisWeek);
            pnlSearchAtRadioButtons.Controls.Add(rbToday);
            pnlSearchAtRadioButtons.Controls.Add(label5);
            pnlSearchAtRadioButtons.Controls.Add(label7);
            pnlSearchAtRadioButtons.Controls.Add(rbAllTime);
            pnlSearchAtRadioButtons.CustomizableEdges = customizableEdges7;
            pnlSearchAtRadioButtons.Location = new Point(1194, 16);
            pnlSearchAtRadioButtons.Name = "pnlSearchAtRadioButtons";
            pnlSearchAtRadioButtons.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlSearchAtRadioButtons.Size = new Size(350, 168);
            pnlSearchAtRadioButtons.TabIndex = 59;
            pnlSearchAtRadioButtons.UseTransparentBackground = true;
            // 
            // rbThisMonth
            // 
            rbThisMonth.Anchor = AnchorStyles.Right;
            rbThisMonth.AutoSize = true;
            rbThisMonth.Location = new Point(224, 87);
            rbThisMonth.Name = "rbThisMonth";
            rbThisMonth.Size = new Size(113, 32);
            rbThisMonth.TabIndex = 14;
            rbThisMonth.Text = "هذا الشهر";
            rbThisMonth.UseVisualStyleBackColor = true;
            rbThisMonth.CheckedChanged += RadioButtonsFilterPeriods_CheckedChanged;
            // 
            // rbThisWeek
            // 
            rbThisWeek.Anchor = AnchorStyles.Right;
            rbThisWeek.AutoSize = true;
            rbThisWeek.Location = new Point(208, 49);
            rbThisWeek.Name = "rbThisWeek";
            rbThisWeek.Size = new Size(129, 32);
            rbThisWeek.TabIndex = 13;
            rbThisWeek.Text = "هذا الأسبوع";
            rbThisWeek.UseVisualStyleBackColor = true;
            rbThisWeek.CheckedChanged += RadioButtonsFilterPeriods_CheckedChanged;
            // 
            // rbToday
            // 
            rbToday.Anchor = AnchorStyles.Right;
            rbToday.AutoSize = true;
            rbToday.Location = new Point(263, 11);
            rbToday.Name = "rbToday";
            rbToday.Size = new Size(74, 32);
            rbToday.TabIndex = 12;
            rbToday.Text = "اليوم";
            rbToday.UseVisualStyleBackColor = true;
            rbToday.CheckedChanged += RadioButtonsFilterPeriods_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 96);
            label5.Name = "label5";
            label5.Size = new Size(202, 23);
            label5.TabIndex = 11;
            label5.Text = "بداية من اول يوم في الشهر";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(34, 58);
            label7.Name = "label7";
            label7.Size = new Size(151, 23);
            label7.TabIndex = 10;
            label7.Text = "بداية من يوم السبت";
            // 
            // rbAllTime
            // 
            rbAllTime.Anchor = AnchorStyles.Right;
            rbAllTime.AutoSize = true;
            rbAllTime.Checked = true;
            rbAllTime.Location = new Point(249, 125);
            rbAllTime.Name = "rbAllTime";
            rbAllTime.Size = new Size(88, 32);
            rbAllTime.TabIndex = 9;
            rbAllTime.TabStop = true;
            rbAllTime.Text = "الجميع";
            rbAllTime.UseVisualStyleBackColor = true;
            rbAllTime.CheckedChanged += RadioButtonsFilterPeriods_CheckedChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Animated = true;
            dateTimePicker.BackColor = Color.Transparent;
            dateTimePicker.BorderColor = Color.White;
            dateTimePicker.BorderRadius = 15;
            dateTimePicker.Checked = true;
            dateTimePicker.CustomizableEdges = customizableEdges9;
            dateTimePicker.FillColor = Color.White;
            dateTimePicker.FocusedColor = Color.White;
            dateTimePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.HoverState.BorderColor = Color.White;
            dateTimePicker.HoverState.FillColor = Color.White;
            dateTimePicker.HoverState.ForeColor = Color.Black;
            dateTimePicker.Location = new Point(782, 464);
            dateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.ShadowDecoration.BorderRadius = 30;
            dateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges10;
            dateTimePicker.ShadowDecoration.Shadow = new Padding(0);
            dateTimePicker.Size = new Size(301, 45);
            dateTimePicker.TabIndex = 60;
            dateTimePicker.TextAlign = HorizontalAlignment.Center;
            dateTimePicker.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dateTimePicker.Visible = false;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            dateTimePicker.VisibleChanged += txtFilterValue_VisibleChanged;
            // 
            // loadDataTimer
            // 
            loadDataTimer.Interval = 10;
            loadDataTimer.Tick += loadDataTimer_Tick;
            // 
            // timerUpdateDateTimePckerMaxDate
            // 
            timerUpdateDateTimePckerMaxDate.Interval = 1000;
            timerUpdateDateTimePckerMaxDate.Tick += timerUpdateDateTimePckerMaxDate_Tick;
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
            btnRefresh.TabIndex = 61;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // RadiographsView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkCyan;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnRefresh);
            Controls.Add(pnlSearchAtRadioButtons);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dtpSearchAfter);
            Controls.Add(btnNewVisitRadiograph);
            Controls.Add(lblSearchAfter);
            Controls.Add(pnlTotalAppointments);
            Controls.Add(cbFilterList);
            Controls.Add(dataGridView);
            Controls.Add(dateTimePicker);
            Controls.Add(txtFilterValue);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1558, 952);
            MinimumSize = new Size(1558, 952);
            Name = "RadiographsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1556, 950);
            Load += RadiographsView_Load;
            pnlTotalAppointments.ResumeLayout(false);
            pnlTotalAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            pnlSearchAtRadioButtons.ResumeLayout(false);
            pnlSearchAtRadioButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpSearchAfter;
        private Guna.UI2.WinForms.Guna2Button btnNewVisitRadiograph;
        private Label lblSearchAfter;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTotalAppointments;
        private Label lblRadiographsCount;
        private Label label1;
        private ComboBox cbFilterList;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchAtRadioButtons;
        private RadioButton rbThisMonth;
        private RadioButton rbThisWeek;
        private RadioButton rbToday;
        private Label label5;
        private Label label7;
        private RadioButton rbAllTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker;
        private System.Windows.Forms.Timer loadDataTimer;
        private System.Windows.Forms.Timer timerUpdateDateTimePckerMaxDate;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiEditVisit;
        private ToolStripMenuItem tsmiEditPatient;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiOpenRadioghraphImage;
        private ToolStripMenuItem tsmiCopyRadiographImage;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tsmiAddNewRadiographToTheSameVisit;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem tsmiRefresh;
        private DataGridViewTextBoxColumn colVisitId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colRadiographCreatedAt;
        private DataGridViewTextBoxColumn colPatientId;
        private DataGridViewTextBoxColumn colVisitRadiographId;
        private DataGridViewTextBoxColumn colImagePath;
    }
}
