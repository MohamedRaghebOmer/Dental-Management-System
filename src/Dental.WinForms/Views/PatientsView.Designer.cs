namespace Dental.WinForms.Views
{
    partial class PatientsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientsView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label7 = new Label();
            label3 = new Label();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblChilderensPercentage = new Label();
            lblAdultsPercentage = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            btnAddNewPatient = new Guna.UI2.WinForms.Guna2Button();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            LoadDataFirstTimeTimer = new System.Windows.Forms.Timer(components);
            guna2ShadowPanel4 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTodayPatientCount = new Label();
            label8 = new Label();
            label9 = new Label();
            lblMalePercentage = new Label();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colAge = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colPhoneNumber = new DataGridViewTextBoxColumn();
            colNextAppointmentDate = new DataGridViewTextBoxColumn();
            colLastVisitDate = new DataGridViewTextBoxColumn();
            colTotalNumberOfVisits = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            تعديلبياناتالمريضToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiCreateAppointment = new ToolStripMenuItem();
            tsmiCreateVisit = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiCopyPhoneNumber = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tsmiRefresh = new ToolStripMenuItem();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblFemalePercentage = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            pnlTotalVisits = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblPatietnsCount = new Label();
            label1 = new Label();
            cbFilterList = new ComboBox();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            dateTimerPicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            cbGender = new ComboBox();
            guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            guna2ShadowPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlTotalVisits.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(1459, 542);
            label7.Name = "label7";
            label7.Size = new Size(103, 31);
            label7.TabIndex = 30;
            label7.Text = "ملحوظه :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(98, 9);
            label3.Name = "label3";
            label3.Size = new Size(192, 28);
            label3.TabIndex = 3;
            label3.Text = "نسبة البالغين للأطفال";
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(lblChilderensPercentage);
            guna2ShadowPanel2.Controls.Add(lblAdultsPercentage);
            guna2ShadowPanel2.Controls.Add(pictureBox3);
            guna2ShadowPanel2.Controls.Add(pictureBox4);
            guna2ShadowPanel2.Controls.Add(label3);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(33, 218);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 150;
            guna2ShadowPanel2.Size = new Size(298, 125);
            guna2ShadowPanel2.TabIndex = 4;
            // 
            // lblChilderensPercentage
            // 
            lblChilderensPercentage.ForeColor = Color.Black;
            lblChilderensPercentage.Location = new Point(15, 55);
            lblChilderensPercentage.Name = "lblChilderensPercentage";
            lblChilderensPercentage.Size = new Size(68, 28);
            lblChilderensPercentage.TabIndex = 10;
            lblChilderensPercentage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAdultsPercentage
            // 
            lblAdultsPercentage.ForeColor = Color.Black;
            lblAdultsPercentage.Location = new Point(159, 55);
            lblAdultsPercentage.Name = "lblAdultsPercentage";
            lblAdultsPercentage.Size = new Size(67, 28);
            lblAdultsPercentage.TabIndex = 7;
            lblAdultsPercentage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(89, 49);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(232, 49);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 40);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // btnAddNewPatient
            // 
            btnAddNewPatient.Animated = true;
            btnAddNewPatient.AnimatedGIF = true;
            btnAddNewPatient.AutoRoundedCorners = true;
            btnAddNewPatient.BackColor = Color.Transparent;
            btnAddNewPatient.BorderRadius = 27;
            btnAddNewPatient.CustomizableEdges = customizableEdges1;
            btnAddNewPatient.DisabledState.BorderColor = Color.DarkGray;
            btnAddNewPatient.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNewPatient.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNewPatient.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNewPatient.FillColor = Color.FromArgb(0, 0, 150);
            btnAddNewPatient.Font = new Font("Segoe UI", 13.8F);
            btnAddNewPatient.ForeColor = Color.White;
            btnAddNewPatient.HoverState.FillColor = Color.MediumBlue;
            btnAddNewPatient.Location = new Point(1331, 461);
            btnAddNewPatient.Name = "btnAddNewPatient";
            btnAddNewPatient.PressedColor = Color.FromArgb(0, 0, 165);
            btnAddNewPatient.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddNewPatient.Size = new Size(216, 57);
            btnAddNewPatient.TabIndex = 5;
            btnAddNewPatient.Text = "إنشاء مريض جديد";
            btnAddNewPatient.Click += btnAddNewPatient_Click;
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
            btnRefresh.TabIndex = 0;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // LoadDataFirstTimeTimer
            // 
            LoadDataFirstTimeTimer.Interval = 10;
            LoadDataFirstTimeTimer.Tick += LoadDataFirstTimeTimer_Tick;
            // 
            // guna2ShadowPanel4
            // 
            guna2ShadowPanel4.BackColor = Color.Transparent;
            guna2ShadowPanel4.Controls.Add(lblTodayPatientCount);
            guna2ShadowPanel4.Controls.Add(label8);
            guna2ShadowPanel4.FillColor = Color.White;
            guna2ShadowPanel4.Location = new Point(831, 218);
            guna2ShadowPanel4.Name = "guna2ShadowPanel4";
            guna2ShadowPanel4.Radius = 10;
            guna2ShadowPanel4.ShadowColor = Color.Black;
            guna2ShadowPanel4.ShadowDepth = 150;
            guna2ShadowPanel4.Size = new Size(298, 125);
            guna2ShadowPanel4.TabIndex = 2;
            // 
            // lblTodayPatientCount
            // 
            lblTodayPatientCount.ForeColor = Color.Black;
            lblTodayPatientCount.Location = new Point(9, 55);
            lblTodayPatientCount.Name = "lblTodayPatientCount";
            lblTodayPatientCount.Size = new Size(281, 28);
            lblTodayPatientCount.TabIndex = 7;
            lblTodayPatientCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(255, 128, 0);
            label8.Location = new Point(144, 9);
            label8.Name = "label8";
            label8.Size = new Size(146, 28);
            label8.TabIndex = 3;
            label8.Text = "عدد مرضى اليوم";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(945, 543);
            label9.Name = "label9";
            label9.Size = new Size(514, 28);
            label9.TabIndex = 10;
            label9.Text = "اضغط علي الصف ضغطتين متتاليتين لتعديل بيانات المريض.";
            // 
            // lblMalePercentage
            // 
            lblMalePercentage.ForeColor = Color.Black;
            lblMalePercentage.Location = new Point(158, 55);
            lblMalePercentage.Name = "lblMalePercentage";
            lblMalePercentage.Size = new Size(67, 28);
            lblMalePercentage.TabIndex = 0;
            lblMalePercentage.TextAlign = ContentAlignment.MiddleLeft;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colAge, colGender, colPhoneNumber, colNextAppointmentDate, colLastVisitDate, colTotalNumberOfVisits });
            dataGridView.ContextMenuStrip = contextMenuStrip1;
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
            dataGridView.Location = new Point(0, 577);
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
            dataGridView.DoubleClick += dataGridView_DoubleClick;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colId.DataPropertyName = "Id";
            colId.HeaderText = "رقم المريض";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 140;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "Name";
            colName.HeaderText = "إسم المريض";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colAge
            // 
            colAge.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colAge.DataPropertyName = "Age";
            colAge.HeaderText = "السن";
            colAge.MinimumWidth = 6;
            colAge.Name = "colAge";
            colAge.ReadOnly = true;
            colAge.Width = 81;
            // 
            // colGender
            // 
            colGender.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGender.DataPropertyName = "Gender";
            colGender.HeaderText = "النوع";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            colGender.Width = 80;
            // 
            // colPhoneNumber
            // 
            colPhoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPhoneNumber.DataPropertyName = "PhoneNumber";
            colPhoneNumber.HeaderText = "رقم الهاتف";
            colPhoneNumber.MinimumWidth = 6;
            colPhoneNumber.Name = "colPhoneNumber";
            colPhoneNumber.ReadOnly = true;
            colPhoneNumber.Width = 126;
            // 
            // colNextAppointmentDate
            // 
            colNextAppointmentDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colNextAppointmentDate.DataPropertyName = "NextAppointmentDateTime";
            colNextAppointmentDate.HeaderText = "تاريخ الزياره القادم";
            colNextAppointmentDate.MinimumWidth = 6;
            colNextAppointmentDate.Name = "colNextAppointmentDate";
            colNextAppointmentDate.ReadOnly = true;
            colNextAppointmentDate.Width = 189;
            // 
            // colLastVisitDate
            // 
            colLastVisitDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colLastVisitDate.DataPropertyName = "LastVisitDateTime";
            colLastVisitDate.HeaderText = "تاريخ أخر زياره";
            colLastVisitDate.MinimumWidth = 6;
            colLastVisitDate.Name = "colLastVisitDate";
            colLastVisitDate.ReadOnly = true;
            colLastVisitDate.Width = 153;
            // 
            // colTotalNumberOfVisits
            // 
            colTotalNumberOfVisits.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTotalNumberOfVisits.DataPropertyName = "TotalNumberOfVisits";
            colTotalNumberOfVisits.HeaderText = "عدد الزيارات الكليه";
            colTotalNumberOfVisits.MinimumWidth = 6;
            colTotalNumberOfVisits.Name = "colTotalNumberOfVisits";
            colTotalNumberOfVisits.ReadOnly = true;
            colTotalNumberOfVisits.Width = 190;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { تعديلبياناتالمريضToolStripMenuItem, toolStripSeparator1, tsmiCreateAppointment, tsmiCreateVisit, toolStripSeparator2, tsmiCopyPhoneNumber, toolStripSeparator3, tsmiRefresh });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(181, 152);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // تعديلبياناتالمريضToolStripMenuItem
            // 
            تعديلبياناتالمريضToolStripMenuItem.Image = Properties.Resources.pen_512;
            تعديلبياناتالمريضToolStripMenuItem.Name = "تعديلبياناتالمريضToolStripMenuItem";
            تعديلبياناتالمريضToolStripMenuItem.Size = new Size(180, 26);
            تعديلبياناتالمريضToolStripMenuItem.Text = "تعديل";
            تعديلبياناتالمريضToolStripMenuItem.Click += dataGridView_DoubleClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // tsmiCreateAppointment
            // 
            tsmiCreateAppointment.Image = Properties.Resources.plus_512;
            tsmiCreateAppointment.Name = "tsmiCreateAppointment";
            tsmiCreateAppointment.Size = new Size(180, 26);
            tsmiCreateAppointment.Text = "إنشاء حجز";
            tsmiCreateAppointment.Click += tsmiCreateAppointment_Click;
            // 
            // tsmiCreateVisit
            // 
            tsmiCreateVisit.Image = Properties.Resources.plus_512;
            tsmiCreateVisit.Name = "tsmiCreateVisit";
            tsmiCreateVisit.Size = new Size(180, 26);
            tsmiCreateVisit.Text = "إنشاء زياره";
            tsmiCreateVisit.Click += tsmiCreateVisit_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // tsmiCopyPhoneNumber
            // 
            tsmiCopyPhoneNumber.Image = (Image)resources.GetObject("tsmiCopyPhoneNumber.Image");
            tsmiCopyPhoneNumber.Name = "tsmiCopyPhoneNumber";
            tsmiCopyPhoneNumber.Size = new Size(180, 26);
            tsmiCopyPhoneNumber.Text = "نسخ رقم الهاتف";
            tsmiCopyPhoneNumber.Click += tsmiCopyPhoneNumber_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(177, 6);
            // 
            // tsmiRefresh
            // 
            tsmiRefresh.Image = Properties.Resources.Refresh_32;
            tsmiRefresh.Name = "tsmiRefresh";
            tsmiRefresh.Size = new Size(180, 26);
            tsmiRefresh.Text = "تحديث";
            tsmiRefresh.Click += tsmiRefresh_Click;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblFemalePercentage);
            guna2ShadowPanel1.Controls.Add(lblMalePercentage);
            guna2ShadowPanel1.Controls.Add(pictureBox2);
            guna2ShadowPanel1.Controls.Add(pictureBox1);
            guna2ShadowPanel1.Controls.Add(label2);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(432, 218);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 150;
            guna2ShadowPanel1.Size = new Size(298, 125);
            guna2ShadowPanel1.TabIndex = 3;
            // 
            // lblFemalePercentage
            // 
            lblFemalePercentage.ForeColor = Color.Black;
            lblFemalePercentage.Location = new Point(10, 55);
            lblFemalePercentage.Name = "lblFemalePercentage";
            lblFemalePercentage.Size = new Size(68, 28);
            lblFemalePercentage.TabIndex = 6;
            lblFemalePercentage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(84, 49);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(231, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(117, 9);
            label2.Name = "label2";
            label2.Size = new Size(172, 28);
            label2.TabIndex = 3;
            label2.Text = "نسبة الذكور والإناث";
            // 
            // pnlTotalVisits
            // 
            pnlTotalVisits.BackColor = Color.Transparent;
            pnlTotalVisits.Controls.Add(lblPatietnsCount);
            pnlTotalVisits.Controls.Add(label1);
            pnlTotalVisits.FillColor = Color.White;
            pnlTotalVisits.Location = new Point(1230, 218);
            pnlTotalVisits.Name = "pnlTotalVisits";
            pnlTotalVisits.Radius = 10;
            pnlTotalVisits.ShadowColor = Color.Black;
            pnlTotalVisits.ShadowDepth = 150;
            pnlTotalVisits.Size = new Size(298, 125);
            pnlTotalVisits.TabIndex = 1;
            // 
            // lblPatietnsCount
            // 
            lblPatietnsCount.ForeColor = Color.Black;
            lblPatietnsCount.Location = new Point(9, 55);
            lblPatietnsCount.Name = "lblPatietnsCount";
            lblPatietnsCount.Size = new Size(281, 28);
            lblPatietnsCount.TabIndex = 4;
            lblPatietnsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(179, 9);
            label1.Name = "label1";
            label1.Size = new Size(111, 28);
            label1.TabIndex = 3;
            label1.Text = "عدد المرضي";
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "رقم المريض", "إسم المريض", "السن", "النوع", "رقم الهاتف", "تاريخ الزياره القادم", "تاريخ أخر زياره", "عدد الزيارات الكليه" });
            cbFilterList.Location = new Point(477, 471);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 9;
            cbFilterList.SelectedIndexChanged += cbFilterList_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderRadius = 7;
            txtFilterValue.CustomizableEdges = customizableEdges3;
            txtFilterValue.DefaultText = "";
            txtFilterValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFilterValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFilterValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = Color.Black;
            txtFilterValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Location = new Point(785, 471);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 6;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.VisibleChanged += txtFilterValue_VisibleChanged;
            // 
            // dateTimerPicker
            // 
            dateTimerPicker.Animated = true;
            dateTimerPicker.BackColor = Color.Transparent;
            dateTimerPicker.BorderColor = Color.White;
            dateTimerPicker.BorderRadius = 15;
            dateTimerPicker.Checked = true;
            dateTimerPicker.CustomizableEdges = customizableEdges5;
            dateTimerPicker.FillColor = Color.White;
            dateTimerPicker.FocusedColor = Color.White;
            dateTimerPicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimerPicker.Format = DateTimePickerFormat.Long;
            dateTimerPicker.HoverState.BorderColor = Color.White;
            dateTimerPicker.HoverState.FillColor = Color.White;
            dateTimerPicker.HoverState.ForeColor = Color.Black;
            dateTimerPicker.Location = new Point(785, 467);
            dateTimerPicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimerPicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimerPicker.Name = "dateTimerPicker";
            dateTimerPicker.RightToLeft = RightToLeft.No;
            dateTimerPicker.ShadowDecoration.BorderRadius = 30;
            dateTimerPicker.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dateTimerPicker.ShadowDecoration.Shadow = new Padding(0);
            dateTimerPicker.Size = new Size(301, 45);
            dateTimerPicker.TabIndex = 7;
            dateTimerPicker.TextAlign = HorizontalAlignment.Center;
            dateTimerPicker.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dateTimerPicker.Visible = false;
            dateTimerPicker.ValueChanged += dateTimerPicker_ValueChanged;
            dateTimerPicker.VisibleChanged += dateTimerPicker_VisibleChanged;
            // 
            // cbGender
            // 
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "ذكر", "أنثى" });
            cbGender.Location = new Point(785, 471);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(301, 36);
            cbGender.TabIndex = 8;
            cbGender.SelectedIndexChanged += cbGender_SelectedIndexChanged;
            cbGender.VisibleChanged += cbGender_VisibleChanged;
            // 
            // PatientsView
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(label7);
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(btnAddNewPatient);
            Controls.Add(btnRefresh);
            Controls.Add(guna2ShadowPanel4);
            Controls.Add(label9);
            Controls.Add(dataGridView);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(pnlTotalVisits);
            Controls.Add(cbFilterList);
            Controls.Add(txtFilterValue);
            Controls.Add(cbGender);
            Controls.Add(dateTimerPicker);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1562, 956);
            MinimumSize = new Size(1562, 956);
            Name = "PatientsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1562, 956);
            Load += PatientView_Load;
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            guna2ShadowPanel4.ResumeLayout(false);
            guna2ShadowPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlTotalVisits.ResumeLayout(false);
            pnlTotalVisits.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPatient;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private System.Windows.Forms.Timer LoadDataFirstTimeTimer;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel4;
        private Label lblTodayPatientCount;
        private Label label8;
        private Label label9;
        private Label lblMalePercentage;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTotalVisits;
        private Label lblPatietnsCount;
        private Label label1;
        private ComboBox cbFilterList;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblFemalePercentage;
        private Label lblChilderensPercentage;
        private Label lblAdultsPercentage;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimerPicker;
        private ComboBox cbGender;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAge;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colPhoneNumber;
        private DataGridViewTextBoxColumn colNextAppointmentDate;
        private DataGridViewTextBoxColumn colLastVisitDate;
        private DataGridViewTextBoxColumn colTotalNumberOfVisits;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem تعديلبياناتالمريضToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiCreateAppointment;
        private ToolStripMenuItem tsmiCreateVisit;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiRefresh;
        private ToolStripMenuItem tsmiCopyPhoneNumber;
        private ToolStripSeparator toolStripSeparator3;
    }
}
