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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentsView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dtpVisitDateTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
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
            pnlSearchAtRadioButtons = new Guna.UI2.WinForms.Guna2Panel();
            rbThisWeek = new RadioButton();
            rbThisMonth = new RadioButton();
            rbAllTime = new RadioButton();
            rbToday = new RadioButton();
            timerUpdateDateTimePckerMaxDate = new System.Windows.Forms.Timer(components);
            filterTimer = new System.Windows.Forms.Timer(components);
            btnCreatePreAppointmentVisit = new Guna.UI2.WinForms.Guna2Button();
            btnAddWalkInVisit = new Guna.UI2.WinForms.Guna2Button();
            lblSearchAfter = new Label();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            pnlTotalVisits = new Guna.UI2.WinForms.Guna2ShadowPanel();
            cbFilterList = new ComboBox();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colAppointmentId = new DataGridViewTextBoxColumn();
            colPatientId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colScheduledVisitDateTime = new DataGridViewTextBoxColumn();
            colActualVisitDateTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            contextMenuStrip = new ContextMenuStrip(components);
            cmsEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cmsDelete = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            cmsAddNewWalkInVisitToTheSamePatient = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cmsShowPatientDetails = new ToolStripMenuItem();
            cmsShowAppointmentDetails = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            cmsRefreshGrid = new ToolStripMenuItem();
            dtpSearchAfter = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            guna2ShadowPanel1.SuspendLayout();
            guna2ShadowPanel2.SuspendLayout();
            guna2ShadowPanel3.SuspendLayout();
            pnlSearchAtRadioButtons.SuspendLayout();
            pnlTotalVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dtpVisitDateTime
            // 
            dtpVisitDateTime.Animated = true;
            dtpVisitDateTime.BackColor = Color.Transparent;
            dtpVisitDateTime.BorderColor = Color.White;
            dtpVisitDateTime.BorderRadius = 15;
            dtpVisitDateTime.Checked = true;
            dtpVisitDateTime.CustomizableEdges = customizableEdges1;
            dtpVisitDateTime.FillColor = Color.White;
            dtpVisitDateTime.FocusedColor = Color.White;
            dtpVisitDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpVisitDateTime.Format = DateTimePickerFormat.Long;
            dtpVisitDateTime.HoverState.BorderColor = Color.White;
            dtpVisitDateTime.HoverState.FillColor = Color.White;
            dtpVisitDateTime.HoverState.ForeColor = Color.Black;
            dtpVisitDateTime.Location = new Point(785, 503);
            dtpVisitDateTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpVisitDateTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpVisitDateTime.Name = "dtpVisitDateTime";
            dtpVisitDateTime.RightToLeft = RightToLeft.No;
            dtpVisitDateTime.ShadowDecoration.BorderRadius = 30;
            dtpVisitDateTime.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpVisitDateTime.ShadowDecoration.Shadow = new Padding(0);
            dtpVisitDateTime.Size = new Size(301, 45);
            dtpVisitDateTime.TabIndex = 26;
            dtpVisitDateTime.TextAlign = HorizontalAlignment.Center;
            dtpVisitDateTime.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpVisitDateTime.Visible = false;
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
            label1.Location = new Point(110, 8);
            label1.Name = "label1";
            label1.Size = new Size(177, 28);
            label1.TabIndex = 3;
            label1.Text = "عدد الحجوزات الكليه";
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblTotalPaidAmount);
            guna2ShadowPanel1.Controls.Add(label2);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(834, 218);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 150;
            guna2ShadowPanel1.Size = new Size(295, 125);
            guna2ShadowPanel1.TabIndex = 17;
            // 
            // lblTotalPaidAmount
            // 
            lblTotalPaidAmount.AutoSize = true;
            lblTotalPaidAmount.ForeColor = Color.Black;
            lblTotalPaidAmount.Location = new Point(136, 55);
            lblTotalPaidAmount.Name = "lblTotalPaidAmount";
            lblTotalPaidAmount.Size = new Size(23, 28);
            lblTotalPaidAmount.TabIndex = 0;
            lblTotalPaidAmount.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(74, 8);
            label2.Name = "label2";
            label2.Size = new Size(213, 28);
            label2.TabIndex = 3;
            label2.Text = "مجموع المبالغ المدفوعه";
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(lblTotalDiscountAmount);
            guna2ShadowPanel2.Controls.Add(label3);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(434, 218);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 150;
            guna2ShadowPanel2.Size = new Size(295, 125);
            guna2ShadowPanel2.TabIndex = 18;
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
            label3.Location = new Point(62, 8);
            label3.Name = "label3";
            label3.Size = new Size(225, 28);
            label3.TabIndex = 3;
            label3.Text = "مجموع المبالغ المخصومه";
            // 
            // guna2ShadowPanel3
            // 
            guna2ShadowPanel3.BackColor = Color.Transparent;
            guna2ShadowPanel3.Controls.Add(lblTotalRemainedAmount);
            guna2ShadowPanel3.Controls.Add(label4);
            guna2ShadowPanel3.FillColor = Color.White;
            guna2ShadowPanel3.Location = new Point(34, 218);
            guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            guna2ShadowPanel3.Radius = 10;
            guna2ShadowPanel3.ShadowColor = Color.Black;
            guna2ShadowPanel3.ShadowDepth = 150;
            guna2ShadowPanel3.Size = new Size(295, 125);
            guna2ShadowPanel3.TabIndex = 20;
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
            label4.Location = new Point(85, 8);
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
            pnlSearchAtRadioButtons.BorderThickness = 2;
            pnlSearchAtRadioButtons.Controls.Add(rbThisWeek);
            pnlSearchAtRadioButtons.Controls.Add(rbThisMonth);
            pnlSearchAtRadioButtons.Controls.Add(rbAllTime);
            pnlSearchAtRadioButtons.Controls.Add(rbToday);
            pnlSearchAtRadioButtons.CustomizableEdges = customizableEdges3;
            pnlSearchAtRadioButtons.Location = new Point(1287, 17);
            pnlSearchAtRadioButtons.Name = "pnlSearchAtRadioButtons";
            pnlSearchAtRadioButtons.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlSearchAtRadioButtons.Size = new Size(272, 168);
            pnlSearchAtRadioButtons.TabIndex = 15;
            pnlSearchAtRadioButtons.UseTransparentBackground = true;
            // 
            // rbThisWeek
            // 
            rbThisWeek.AutoSize = true;
            rbThisWeek.Location = new Point(137, 51);
            rbThisWeek.Name = "rbThisWeek";
            rbThisWeek.Size = new Size(129, 32);
            rbThisWeek.TabIndex = 1;
            rbThisWeek.Text = "هذا الأسبوع";
            rbThisWeek.UseVisualStyleBackColor = true;
            // 
            // rbThisMonth
            // 
            rbThisMonth.AutoSize = true;
            rbThisMonth.Location = new Point(153, 89);
            rbThisMonth.Name = "rbThisMonth";
            rbThisMonth.Size = new Size(113, 32);
            rbThisMonth.TabIndex = 2;
            rbThisMonth.Text = "هذا الشهر";
            rbThisMonth.UseVisualStyleBackColor = true;
            // 
            // rbAllTime
            // 
            rbAllTime.AutoSize = true;
            rbAllTime.Checked = true;
            rbAllTime.Location = new Point(178, 124);
            rbAllTime.Name = "rbAllTime";
            rbAllTime.Size = new Size(88, 32);
            rbAllTime.TabIndex = 3;
            rbAllTime.TabStop = true;
            rbAllTime.Text = "الجميع";
            rbAllTime.UseVisualStyleBackColor = true;
            // 
            // rbToday
            // 
            rbToday.AutoSize = true;
            rbToday.Location = new Point(192, 13);
            rbToday.Name = "rbToday";
            rbToday.Size = new Size(74, 32);
            rbToday.TabIndex = 0;
            rbToday.Text = "اليوم";
            rbToday.UseVisualStyleBackColor = true;
            // 
            // timerUpdateDateTimePckerMaxDate
            // 
            timerUpdateDateTimePckerMaxDate.Interval = 1000;
            // 
            // filterTimer
            // 
            filterTimer.Interval = 400;
            // 
            // btnCreatePreAppointmentVisit
            // 
            btnCreatePreAppointmentVisit.Animated = true;
            btnCreatePreAppointmentVisit.AnimatedGIF = true;
            btnCreatePreAppointmentVisit.BackColor = Color.Transparent;
            btnCreatePreAppointmentVisit.BorderRadius = 7;
            btnCreatePreAppointmentVisit.CustomizableEdges = customizableEdges5;
            btnCreatePreAppointmentVisit.DisabledState.BorderColor = Color.DarkGray;
            btnCreatePreAppointmentVisit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreatePreAppointmentVisit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreatePreAppointmentVisit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreatePreAppointmentVisit.FillColor = Color.FromArgb(0, 0, 150);
            btnCreatePreAppointmentVisit.Font = new Font("Segoe UI", 13.8F);
            btnCreatePreAppointmentVisit.ForeColor = Color.White;
            btnCreatePreAppointmentVisit.HoverState.FillColor = Color.MediumBlue;
            btnCreatePreAppointmentVisit.Location = new Point(1271, 503);
            btnCreatePreAppointmentVisit.Name = "btnCreatePreAppointmentVisit";
            btnCreatePreAppointmentVisit.PressedColor = Color.FromArgb(0, 0, 165);
            btnCreatePreAppointmentVisit.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCreatePreAppointmentVisit.Size = new Size(288, 57);
            btnCreatePreAppointmentVisit.TabIndex = 27;
            btnCreatePreAppointmentVisit.Text = "ابدأ زياره بحجز مسبق";
            // 
            // btnAddWalkInVisit
            // 
            btnAddWalkInVisit.Animated = true;
            btnAddWalkInVisit.AnimatedGIF = true;
            btnAddWalkInVisit.BackColor = Color.Transparent;
            btnAddWalkInVisit.BorderRadius = 7;
            btnAddWalkInVisit.CustomizableEdges = customizableEdges7;
            btnAddWalkInVisit.DisabledState.BorderColor = Color.DarkGray;
            btnAddWalkInVisit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddWalkInVisit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddWalkInVisit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddWalkInVisit.FillColor = Color.FromArgb(0, 0, 150);
            btnAddWalkInVisit.Font = new Font("Segoe UI", 13.8F);
            btnAddWalkInVisit.ForeColor = Color.White;
            btnAddWalkInVisit.HoverState.FillColor = Color.MediumBlue;
            btnAddWalkInVisit.Location = new Point(1271, 426);
            btnAddWalkInVisit.Name = "btnAddWalkInVisit";
            btnAddWalkInVisit.PressedColor = Color.FromArgb(0, 0, 165);
            btnAddWalkInVisit.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAddWalkInVisit.Size = new Size(288, 57);
            btnAddWalkInVisit.TabIndex = 25;
            btnAddWalkInVisit.Text = "ابدأ زياره بدون حجز مسبق";
            // 
            // lblSearchAfter
            // 
            lblSearchAfter.AutoSize = true;
            lblSearchAfter.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchAfter.Location = new Point(915, 426);
            lblSearchAfter.Name = "lblSearchAfter";
            lblSearchAfter.Size = new Size(221, 31);
            lblSearchAfter.TabIndex = 19;
            lblSearchAfter.Text = "ابحث بعد تاريخ معين :";
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
            // 
            // pnlTotalVisits
            // 
            pnlTotalVisits.BackColor = Color.Transparent;
            pnlTotalVisits.Controls.Add(lblTotalVisits);
            pnlTotalVisits.Controls.Add(label1);
            pnlTotalVisits.FillColor = Color.White;
            pnlTotalVisits.Location = new Point(1234, 218);
            pnlTotalVisits.Name = "pnlTotalVisits";
            pnlTotalVisits.Radius = 10;
            pnlTotalVisits.ShadowColor = Color.Black;
            pnlTotalVisits.ShadowDepth = 150;
            pnlTotalVisits.Size = new Size(295, 125);
            pnlTotalVisits.TabIndex = 16;
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "رقم الزياره", "رقم الحجز", "اسم المريض", "تاريخ الزياره", "الخدمات المقدمه", "المبلغ الكلي", "المبلغ المدفوع", "مبلغ الخصم", "المبلغ المتبقي" });
            cbFilterList.Location = new Point(477, 507);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 22;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colAppointmentId, colPatientId, colPatientName, colCreatedAt, colScheduledVisitDateTime, colActualVisitDateTime, colStatus });
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
            dataGridView.Location = new Point(0, 575);
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
            dataGridView.RowTemplate.ContextMenuStrip = contextMenuStrip;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new Size(1560, 379);
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
            colPatientName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPatientName.DataPropertyName = "PatientName";
            colPatientName.HeaderText = "اسم المريض";
            colPatientName.MinimumWidth = 2;
            colPatientName.Name = "colPatientName";
            colPatientName.ReadOnly = true;
            colPatientName.Width = 230;
            // 
            // colCreatedAt
            // 
            colCreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            colCreatedAt.HeaderText = "تاريخ انشاء الحجز";
            colCreatedAt.MinimumWidth = 6;
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;
            colCreatedAt.Width = 6;
            // 
            // colScheduledVisitDateTime
            // 
            colScheduledVisitDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            colScheduledVisitDateTime.HeaderText = "تاريخ الزياره المحجوز";
            colScheduledVisitDateTime.MinimumWidth = 6;
            colScheduledVisitDateTime.Name = "colScheduledVisitDateTime";
            colScheduledVisitDateTime.ReadOnly = true;
            colScheduledVisitDateTime.Width = 6;
            // 
            // colActualVisitDateTime
            // 
            colActualVisitDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            colActualVisitDateTime.HeaderText = "تاريخ الزياره الفعلي";
            colActualVisitDateTime.MinimumWidth = 6;
            colActualVisitDateTime.Name = "colActualVisitDateTime";
            colActualVisitDateTime.ReadOnly = true;
            colActualVisitDateTime.Width = 6;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            colStatus.HeaderText = "حالة الحجز";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 6;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { cmsEdit, toolStripSeparator1, cmsDelete, toolStripSeparator4, cmsAddNewWalkInVisitToTheSamePatient, toolStripSeparator3, cmsShowPatientDetails, cmsShowAppointmentDetails, toolStripSeparator2, cmsRefreshGrid });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.RightToLeft = RightToLeft.Yes;
            contextMenuStrip.Size = new Size(233, 184);
            // 
            // cmsEdit
            // 
            cmsEdit.Image = Properties.Resources.pen_512;
            cmsEdit.Name = "cmsEdit";
            cmsEdit.ShortcutKeys = Keys.Control | Keys.E;
            cmsEdit.ShowShortcutKeys = false;
            cmsEdit.Size = new Size(232, 26);
            cmsEdit.Text = "تعديل الزياره";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(229, 6);
            // 
            // cmsDelete
            // 
            cmsDelete.Image = Properties.Resources.bin_512;
            cmsDelete.Name = "cmsDelete";
            cmsDelete.RightToLeftAutoMirrorImage = true;
            cmsDelete.ShortcutKeys = Keys.Delete;
            cmsDelete.ShowShortcutKeys = false;
            cmsDelete.Size = new Size(232, 26);
            cmsDelete.Text = "حذف الزياره";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(229, 6);
            // 
            // cmsAddNewWalkInVisitToTheSamePatient
            // 
            cmsAddNewWalkInVisitToTheSamePatient.Image = Properties.Resources.plus_512;
            cmsAddNewWalkInVisitToTheSamePatient.Name = "cmsAddNewWalkInVisitToTheSamePatient";
            cmsAddNewWalkInVisitToTheSamePatient.ShowShortcutKeys = false;
            cmsAddNewWalkInVisitToTheSamePatient.Size = new Size(232, 26);
            cmsAddNewWalkInVisitToTheSamePatient.Text = "انشاء زياره لنفس المريض";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(229, 6);
            // 
            // cmsShowPatientDetails
            // 
            cmsShowPatientDetails.Image = (Image)resources.GetObject("cmsShowPatientDetails.Image");
            cmsShowPatientDetails.Name = "cmsShowPatientDetails";
            cmsShowPatientDetails.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            cmsShowPatientDetails.ShowShortcutKeys = false;
            cmsShowPatientDetails.Size = new Size(232, 26);
            cmsShowPatientDetails.Text = "عرض بيانات المريض";
            // 
            // cmsShowAppointmentDetails
            // 
            cmsShowAppointmentDetails.Image = Properties.Resources.details_512;
            cmsShowAppointmentDetails.Name = "cmsShowAppointmentDetails";
            cmsShowAppointmentDetails.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            cmsShowAppointmentDetails.ShowShortcutKeys = false;
            cmsShowAppointmentDetails.Size = new Size(232, 26);
            cmsShowAppointmentDetails.Text = "عرض بيانات الحجز";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(229, 6);
            // 
            // cmsRefreshGrid
            // 
            cmsRefreshGrid.Image = Properties.Resources.Refresh_32;
            cmsRefreshGrid.Name = "cmsRefreshGrid";
            cmsRefreshGrid.ShortcutKeys = Keys.F5;
            cmsRefreshGrid.ShowShortcutKeys = false;
            cmsRefreshGrid.Size = new Size(232, 26);
            cmsRefreshGrid.Text = "تحديث";
            // 
            // dtpSearchAfter
            // 
            dtpSearchAfter.Animated = true;
            dtpSearchAfter.BackColor = Color.Transparent;
            dtpSearchAfter.BorderColor = Color.White;
            dtpSearchAfter.BorderRadius = 15;
            dtpSearchAfter.Checked = true;
            dtpSearchAfter.CustomizableEdges = customizableEdges9;
            dtpSearchAfter.FillColor = Color.White;
            dtpSearchAfter.FocusedColor = Color.White;
            dtpSearchAfter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpSearchAfter.Format = DateTimePickerFormat.Long;
            dtpSearchAfter.HoverState.BorderColor = Color.White;
            dtpSearchAfter.HoverState.FillColor = Color.White;
            dtpSearchAfter.HoverState.ForeColor = Color.Black;
            dtpSearchAfter.Location = new Point(595, 421);
            dtpSearchAfter.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpSearchAfter.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpSearchAfter.Name = "dtpSearchAfter";
            dtpSearchAfter.RightToLeft = RightToLeft.No;
            dtpSearchAfter.ShadowDecoration.BorderRadius = 30;
            dtpSearchAfter.ShadowDecoration.CustomizableEdges = customizableEdges10;
            dtpSearchAfter.ShadowDecoration.Shadow = new Padding(0);
            dtpSearchAfter.Size = new Size(301, 45);
            dtpSearchAfter.TabIndex = 21;
            dtpSearchAfter.TextAlign = HorizontalAlignment.Center;
            dtpSearchAfter.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderRadius = 7;
            txtFilterValue.CustomizableEdges = customizableEdges11;
            txtFilterValue.DefaultText = "";
            txtFilterValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFilterValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFilterValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFilterValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = Color.Black;
            txtFilterValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFilterValue.Location = new Point(785, 507);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 23;
            // 
            // AppointmentsView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkCyan;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(dtpVisitDateTime);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(guna2ShadowPanel3);
            Controls.Add(pnlSearchAtRadioButtons);
            Controls.Add(btnCreatePreAppointmentVisit);
            Controls.Add(btnAddWalkInVisit);
            Controls.Add(lblSearchAfter);
            Controls.Add(btnRefresh);
            Controls.Add(pnlTotalVisits);
            Controls.Add(cbFilterList);
            Controls.Add(dataGridView);
            Controls.Add(dtpSearchAfter);
            Controls.Add(txtFilterValue);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1562, 956);
            MinimumSize = new Size(1562, 956);
            Name = "AppointmentsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1560, 954);
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            guna2ShadowPanel3.ResumeLayout(false);
            guna2ShadowPanel3.PerformLayout();
            pnlSearchAtRadioButtons.ResumeLayout(false);
            pnlSearchAtRadioButtons.PerformLayout();
            pnlTotalVisits.ResumeLayout(false);
            pnlTotalVisits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpVisitDateTime;
        private Label lblTotalVisits;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Label lblTotalPaidAmount;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Label lblTotalDiscountAmount;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel3;
        private Label lblTotalRemainedAmount;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchAtRadioButtons;
        private RadioButton rbThisWeek;
        private RadioButton rbThisMonth;
        private RadioButton rbAllTime;
        private RadioButton rbToday;
        private System.Windows.Forms.Timer timerUpdateDateTimePckerMaxDate;
        private System.Windows.Forms.Timer filterTimer;
        private Guna.UI2.WinForms.Guna2Button btnCreatePreAppointmentVisit;
        private Guna.UI2.WinForms.Guna2Button btnAddWalkInVisit;
        private Label lblSearchAfter;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTotalVisits;
        private ComboBox cbFilterList;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmsEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cmsDelete;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem cmsAddNewWalkInVisitToTheSamePatient;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cmsShowPatientDetails;
        private ToolStripMenuItem cmsShowAppointmentDetails;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem cmsRefreshGrid;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpSearchAfter;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private DataGridViewTextBoxColumn colAppointmentId;
        private DataGridViewTextBoxColumn colPatientId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colScheduledVisitDateTime;
        private DataGridViewTextBoxColumn colActualVisitDateTime;
        private DataGridViewTextBoxColumn colStatus;
    }
}
