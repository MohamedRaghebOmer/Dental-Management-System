namespace Dental.WinForms.Views
{
    partial class LabTransactionsView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabTransactionsView));
            label9 = new Label();
            label8 = new Label();
            pnlSearchAtRadioButtons = new Guna.UI2.WinForms.Guna2Panel();
            rbThisMonth = new RadioButton();
            rbThisWeek = new RadioButton();
            rbToday = new RadioButton();
            label5 = new Label();
            label7 = new Label();
            rbAllTime = new RadioButton();
            dtpSearchAfter = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            loadDataTimer = new System.Windows.Forms.Timer(components);
            dateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnNewTran = new Guna.UI2.WinForms.Guna2Button();
            lblSearchAfter = new Label();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            cbFilterList = new ComboBox();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colLabName = new DataGridViewTextBoxColumn();
            colTreatmentDateTime = new DataGridViewTextBoxColumn();
            colTreatments = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            colPaidAmount = new DataGridViewTextBoxColumn();
            colRemainedAmount = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tsmiEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiAdd = new ToolStripMenuItem();
            tsmiDelete = new ToolStripMenuItem();
            tsmiCopyTreatments = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiRefresh = new ToolStripMenuItem();
            timerUpdateDateTimePckerMaxDate = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            pnlTotalAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTransCount = new Label();
            label4 = new Label();
            lblSumOfRemainedAmount = new Label();
            pnlMissedAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            label13 = new Label();
            lblSumOfPaidAmount = new Label();
            pnlCompletedAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            label2 = new Label();
            lblSumOfTotalAmount = new Label();
            pnlPendingAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            pnlSearchAtRadioButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            pnlTotalAppointments.SuspendLayout();
            pnlMissedAppointments.SuspendLayout();
            pnlCompletedAppointments.SuspendLayout();
            pnlPendingAppointments.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(935, 539);
            label9.Name = "label9";
            label9.Size = new Size(516, 28);
            label9.TabIndex = 49;
            label9.Text = "اضغط علي الصف ضغطتين متتاليتين لتعديل بيانات المعامله.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1451, 538);
            label8.Name = "label8";
            label8.Size = new Size(103, 31);
            label8.TabIndex = 48;
            label8.Text = "ملحوظه :";
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
            pnlSearchAtRadioButtons.CustomizableEdges = customizableEdges1;
            pnlSearchAtRadioButtons.Location = new Point(1210, 10);
            pnlSearchAtRadioButtons.Name = "pnlSearchAtRadioButtons";
            pnlSearchAtRadioButtons.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlSearchAtRadioButtons.Size = new Size(337, 168);
            pnlSearchAtRadioButtons.TabIndex = 46;
            pnlSearchAtRadioButtons.UseTransparentBackground = true;
            // 
            // rbThisMonth
            // 
            rbThisMonth.Anchor = AnchorStyles.Right;
            rbThisMonth.AutoSize = true;
            rbThisMonth.Location = new Point(212, 85);
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
            rbThisWeek.Location = new Point(196, 47);
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
            rbToday.Location = new Point(251, 9);
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
            rbAllTime.Location = new Point(237, 123);
            rbAllTime.Name = "rbAllTime";
            rbAllTime.Size = new Size(88, 32);
            rbAllTime.TabIndex = 9;
            rbAllTime.TabStop = true;
            rbAllTime.Text = "الجميع";
            rbAllTime.UseVisualStyleBackColor = true;
            rbAllTime.CheckedChanged += RadioButtonsFilterPeriods_CheckedChanged;
            // 
            // dtpSearchAfter
            // 
            dtpSearchAfter.Animated = true;
            dtpSearchAfter.BackColor = Color.Transparent;
            dtpSearchAfter.BorderColor = Color.White;
            dtpSearchAfter.BorderRadius = 15;
            dtpSearchAfter.Checked = true;
            dtpSearchAfter.CustomizableEdges = customizableEdges3;
            dtpSearchAfter.FillColor = Color.White;
            dtpSearchAfter.FocusedColor = Color.White;
            dtpSearchAfter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpSearchAfter.Format = DateTimePickerFormat.Long;
            dtpSearchAfter.HoverState.BorderColor = Color.White;
            dtpSearchAfter.HoverState.FillColor = Color.White;
            dtpSearchAfter.HoverState.ForeColor = Color.Black;
            dtpSearchAfter.Location = new Point(516, 391);
            dtpSearchAfter.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpSearchAfter.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpSearchAfter.Name = "dtpSearchAfter";
            dtpSearchAfter.RightToLeft = RightToLeft.No;
            dtpSearchAfter.ShadowDecoration.BorderRadius = 30;
            dtpSearchAfter.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpSearchAfter.ShadowDecoration.Shadow = new Padding(0);
            dtpSearchAfter.Size = new Size(301, 45);
            dtpSearchAfter.TabIndex = 40;
            dtpSearchAfter.TextAlign = HorizontalAlignment.Center;
            dtpSearchAfter.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpSearchAfter.Visible = false;
            dtpSearchAfter.ValueChanged += dtpSearchAfter_ValueChanged;
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
            txtFilterValue.Location = new Point(792, 477);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 42;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // loadDataTimer
            // 
            loadDataTimer.Interval = 10;
            loadDataTimer.Tick += loadDataTimer_Tick;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Animated = true;
            dateTimePicker.BackColor = Color.Transparent;
            dateTimePicker.BorderColor = Color.White;
            dateTimePicker.BorderRadius = 15;
            dateTimePicker.Checked = true;
            dateTimePicker.CustomizableEdges = customizableEdges7;
            dateTimePicker.FillColor = Color.White;
            dateTimePicker.FocusedColor = Color.White;
            dateTimePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.HoverState.BorderColor = Color.White;
            dateTimePicker.HoverState.FillColor = Color.White;
            dateTimePicker.HoverState.ForeColor = Color.Black;
            dateTimePicker.Location = new Point(792, 473);
            dateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.ShadowDecoration.BorderRadius = 30;
            dateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dateTimePicker.ShadowDecoration.Shadow = new Padding(0);
            dateTimePicker.Size = new Size(301, 45);
            dateTimePicker.TabIndex = 44;
            dateTimePicker.TextAlign = HorizontalAlignment.Center;
            dateTimePicker.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dateTimePicker.Visible = false;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // btnNewTran
            // 
            btnNewTran.Animated = true;
            btnNewTran.AnimatedGIF = true;
            btnNewTran.BackColor = Color.Transparent;
            btnNewTran.BorderRadius = 15;
            btnNewTran.CustomizableEdges = customizableEdges9;
            btnNewTran.DisabledState.BorderColor = Color.DarkGray;
            btnNewTran.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNewTran.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNewTran.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNewTran.FillColor = Color.FromArgb(0, 0, 150);
            btnNewTran.Font = new Font("Segoe UI", 13.8F);
            btnNewTran.ForeColor = Color.White;
            btnNewTran.HoverState.FillColor = Color.MediumBlue;
            btnNewTran.Location = new Point(1315, 467);
            btnNewTran.Name = "btnNewTran";
            btnNewTran.PressedColor = Color.FromArgb(0, 0, 165);
            btnNewTran.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnNewTran.Size = new Size(232, 57);
            btnNewTran.TabIndex = 45;
            btnNewTran.Text = "إنشاء معامله جديده";
            btnNewTran.Click += btnNewTran_Click;
            // 
            // lblSearchAfter
            // 
            lblSearchAfter.AutoSize = true;
            lblSearchAfter.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchAfter.Location = new Point(836, 396);
            lblSearchAfter.Name = "lblSearchAfter";
            lblSearchAfter.Size = new Size(221, 31);
            lblSearchAfter.TabIndex = 37;
            lblSearchAfter.Text = "ابحث بعد تاريخ معين :";
            lblSearchAfter.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.Location = new Point(3, 1);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(47, 49);
            btnRefresh.TabIndex = 33;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "إسم المعمل", "تاريخ المعامله", "المشتريات", "القيمه الكليه", "القيمه المدفوعه", "القيمه المتبقيه" });
            cbFilterList.Location = new Point(484, 477);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 41;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colId, colLabName, colTreatmentDateTime, colTreatments, colTotalAmount, colPaidAmount, colRemainedAmount });
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
            dataGridView.TabIndex = 43;
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
            colId.HeaderText = "رقم المعامله";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colLabName
            // 
            colLabName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLabName.DataPropertyName = "LabName";
            colLabName.HeaderText = "إسم المعمل";
            colLabName.MinimumWidth = 6;
            colLabName.Name = "colLabName";
            colLabName.ReadOnly = true;
            // 
            // colTreatmentDateTime
            // 
            colTreatmentDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTreatmentDateTime.DataPropertyName = "TranDateTime";
            colTreatmentDateTime.HeaderText = "تاريخ المعامله";
            colTreatmentDateTime.MinimumWidth = 6;
            colTreatmentDateTime.Name = "colTreatmentDateTime";
            colTreatmentDateTime.ReadOnly = true;
            colTreatmentDateTime.Width = 155;
            // 
            // colTreatments
            // 
            colTreatments.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTreatments.DataPropertyName = "Treatments";
            colTreatments.HeaderText = "المشتريات";
            colTreatments.MinimumWidth = 6;
            colTreatments.Name = "colTreatments";
            colTreatments.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            colTotalAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTotalAmount.DataPropertyName = "TotalAmount";
            colTotalAmount.HeaderText = "القيمه الكليه";
            colTotalAmount.MinimumWidth = 6;
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.ReadOnly = true;
            colTotalAmount.Width = 141;
            // 
            // colPaidAmount
            // 
            colPaidAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPaidAmount.DataPropertyName = "PaidAmount";
            colPaidAmount.HeaderText = "القيمه المدفوعه";
            colPaidAmount.MinimumWidth = 6;
            colPaidAmount.Name = "colPaidAmount";
            colPaidAmount.ReadOnly = true;
            colPaidAmount.Width = 171;
            // 
            // colRemainedAmount
            // 
            colRemainedAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colRemainedAmount.DataPropertyName = "RemainingAmount";
            colRemainedAmount.HeaderText = "القيمه المتبقيه";
            colRemainedAmount.MinimumWidth = 6;
            colRemainedAmount.Name = "colRemainedAmount";
            colRemainedAmount.ReadOnly = true;
            colRemainedAmount.Width = 160;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tsmiEdit, toolStripSeparator1, tsmiAdd, tsmiDelete, tsmiCopyTreatments, toolStripSeparator2, tsmiRefresh });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(180, 146);
            // 
            // tsmiEdit
            // 
            tsmiEdit.Image = Properties.Resources.pen_512;
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.Size = new Size(179, 26);
            tsmiEdit.Text = "تعديل";
            tsmiEdit.Click += tsmiEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(176, 6);
            // 
            // tsmiAdd
            // 
            tsmiAdd.Image = Properties.Resources.plus_512;
            tsmiAdd.Name = "tsmiAdd";
            tsmiAdd.Size = new Size(179, 26);
            tsmiAdd.Text = "إضافة معامله";
            tsmiAdd.Click += tsmiAdd_Click;
            // 
            // tsmiDelete
            // 
            tsmiDelete.Image = Properties.Resources.bin_512;
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new Size(179, 26);
            tsmiDelete.Text = "حذف";
            tsmiDelete.Click += tsmiDelete_Click;
            // 
            // tsmiCopyTreatments
            // 
            tsmiCopyTreatments.Image = (Image)resources.GetObject("tsmiCopyTreatments.Image");
            tsmiCopyTreatments.Name = "tsmiCopyTreatments";
            tsmiCopyTreatments.Size = new Size(179, 26);
            tsmiCopyTreatments.Text = "نسخ المشتريات";
            tsmiCopyTreatments.Click += tsmiCopyTreatments_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(176, 6);
            // 
            // tsmiRefresh
            // 
            tsmiRefresh.Image = Properties.Resources.Refresh_32;
            tsmiRefresh.Name = "tsmiRefresh";
            tsmiRefresh.Size = new Size(179, 26);
            tsmiRefresh.Text = "تحديث";
            tsmiRefresh.Click += tsmiRefresh_Click;
            // 
            // timerUpdateDateTimePckerMaxDate
            // 
            timerUpdateDateTimePckerMaxDate.Interval = 1000;
            timerUpdateDateTimePckerMaxDate.Tick += timerUpdateDateTimePckerMaxDate_Tick;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(157, 8);
            label1.Name = "label1";
            label1.Size = new Size(133, 28);
            label1.TabIndex = 3;
            label1.Text = "عدد المعاملات";
            // 
            // pnlTotalAppointments
            // 
            pnlTotalAppointments.BackColor = Color.Transparent;
            pnlTotalAppointments.Controls.Add(lblTransCount);
            pnlTotalAppointments.Controls.Add(label1);
            pnlTotalAppointments.FillColor = Color.White;
            pnlTotalAppointments.Location = new Point(1214, 217);
            pnlTotalAppointments.Name = "pnlTotalAppointments";
            pnlTotalAppointments.Radius = 10;
            pnlTotalAppointments.ShadowColor = Color.Black;
            pnlTotalAppointments.ShadowDepth = 150;
            pnlTotalAppointments.Size = new Size(298, 125);
            pnlTotalAppointments.TabIndex = 34;
            // 
            // lblTransCount
            // 
            lblTransCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTransCount.ForeColor = Color.Black;
            lblTransCount.Location = new Point(10, 56);
            lblTransCount.Name = "lblTransCount";
            lblTransCount.Size = new Size(287, 28);
            lblTransCount.TabIndex = 4;
            lblTransCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(88, 8);
            label4.Name = "label4";
            label4.Size = new Size(202, 28);
            label4.TabIndex = 3;
            label4.Text = "مجموع المبالغ المتبقيه";
            // 
            // lblSumOfRemainedAmount
            // 
            lblSumOfRemainedAmount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSumOfRemainedAmount.ForeColor = Color.Black;
            lblSumOfRemainedAmount.Location = new Point(2, 56);
            lblSumOfRemainedAmount.Name = "lblSumOfRemainedAmount";
            lblSumOfRemainedAmount.Size = new Size(287, 28);
            lblSumOfRemainedAmount.TabIndex = 7;
            lblSumOfRemainedAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMissedAppointments
            // 
            pnlMissedAppointments.BackColor = Color.Transparent;
            pnlMissedAppointments.Controls.Add(lblSumOfRemainedAmount);
            pnlMissedAppointments.Controls.Add(label4);
            pnlMissedAppointments.FillColor = Color.White;
            pnlMissedAppointments.Location = new Point(44, 217);
            pnlMissedAppointments.Name = "pnlMissedAppointments";
            pnlMissedAppointments.Radius = 10;
            pnlMissedAppointments.ShadowColor = Color.Black;
            pnlMissedAppointments.ShadowDepth = 150;
            pnlMissedAppointments.Size = new Size(298, 125);
            pnlMissedAppointments.TabIndex = 38;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(255, 128, 0);
            label13.Location = new Point(77, 8);
            label13.Name = "label13";
            label13.Size = new Size(213, 28);
            label13.TabIndex = 3;
            label13.Text = "مجموع المبالغ المدفوعه";
            // 
            // lblSumOfPaidAmount
            // 
            lblSumOfPaidAmount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSumOfPaidAmount.ForeColor = Color.Black;
            lblSumOfPaidAmount.Location = new Point(8, 56);
            lblSumOfPaidAmount.Name = "lblSumOfPaidAmount";
            lblSumOfPaidAmount.Size = new Size(287, 28);
            lblSumOfPaidAmount.TabIndex = 6;
            lblSumOfPaidAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCompletedAppointments
            // 
            pnlCompletedAppointments.BackColor = Color.Transparent;
            pnlCompletedAppointments.Controls.Add(lblSumOfPaidAmount);
            pnlCompletedAppointments.Controls.Add(label13);
            pnlCompletedAppointments.FillColor = Color.White;
            pnlCompletedAppointments.Location = new Point(434, 217);
            pnlCompletedAppointments.Name = "pnlCompletedAppointments";
            pnlCompletedAppointments.Radius = 10;
            pnlCompletedAppointments.ShadowColor = Color.Black;
            pnlCompletedAppointments.ShadowDepth = 150;
            pnlCompletedAppointments.Size = new Size(298, 125);
            pnlCompletedAppointments.TabIndex = 36;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(108, 8);
            label2.Name = "label2";
            label2.Size = new Size(183, 28);
            label2.TabIndex = 3;
            label2.Text = "مجموع المبالغ الكليه";
            // 
            // lblSumOfTotalAmount
            // 
            lblSumOfTotalAmount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSumOfTotalAmount.ForeColor = Color.Black;
            lblSumOfTotalAmount.Location = new Point(8, 56);
            lblSumOfTotalAmount.Name = "lblSumOfTotalAmount";
            lblSumOfTotalAmount.Size = new Size(287, 28);
            lblSumOfTotalAmount.TabIndex = 0;
            lblSumOfTotalAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPendingAppointments
            // 
            pnlPendingAppointments.BackColor = Color.Transparent;
            pnlPendingAppointments.Controls.Add(lblSumOfTotalAmount);
            pnlPendingAppointments.Controls.Add(label2);
            pnlPendingAppointments.FillColor = Color.White;
            pnlPendingAppointments.Location = new Point(824, 217);
            pnlPendingAppointments.Name = "pnlPendingAppointments";
            pnlPendingAppointments.Radius = 10;
            pnlPendingAppointments.ShadowColor = Color.Black;
            pnlPendingAppointments.ShadowDepth = 150;
            pnlPendingAppointments.Size = new Size(298, 125);
            pnlPendingAppointments.TabIndex = 35;
            // 
            // LabTransactionsView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkCyan;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(pnlSearchAtRadioButtons);
            Controls.Add(dtpSearchAfter);
            Controls.Add(pnlPendingAppointments);
            Controls.Add(pnlCompletedAppointments);
            Controls.Add(pnlMissedAppointments);
            Controls.Add(btnNewTran);
            Controls.Add(lblSearchAfter);
            Controls.Add(btnRefresh);
            Controls.Add(pnlTotalAppointments);
            Controls.Add(cbFilterList);
            Controls.Add(dataGridView);
            Controls.Add(txtFilterValue);
            Controls.Add(dateTimePicker);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1558, 952);
            MinimumSize = new Size(1558, 952);
            Name = "LabTransactionsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1556, 950);
            Load += LabTransactionsView_Load;
            pnlSearchAtRadioButtons.ResumeLayout(false);
            pnlSearchAtRadioButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            pnlTotalAppointments.ResumeLayout(false);
            pnlTotalAppointments.PerformLayout();
            pnlMissedAppointments.ResumeLayout(false);
            pnlMissedAppointments.PerformLayout();
            pnlCompletedAppointments.ResumeLayout(false);
            pnlCompletedAppointments.PerformLayout();
            pnlPendingAppointments.ResumeLayout(false);
            pnlPendingAppointments.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label8;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchAtRadioButtons;
        private RadioButton rbAllTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpSearchAfter;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private System.Windows.Forms.Timer loadDataTimer;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker;
        private Guna.UI2.WinForms.Guna2Button btnNewTran;
        private Label lblSearchAfter;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private ComboBox cbFilterList;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private System.Windows.Forms.Timer timerUpdateDateTimePckerMaxDate;
        private RadioButton rbThisMonth;
        private RadioButton rbThisWeek;
        private Label label7;
        private Label label5;
        private RadioButton rbToday;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTotalAppointments;
        private Label label4;
        private Label lblSumOfRemainedAmount;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlMissedAppointments;
        private Label label13;
        private Label lblSumOfPaidAmount;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlCompletedAppointments;
        private Label label2;
        private Label lblSumOfTotalAmount;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlPendingAppointments;
        private Label lblTransCount;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colLabName;
        private DataGridViewTextBoxColumn colTreatmentDateTime;
        private DataGridViewTextBoxColumn colTreatments;
        private DataGridViewTextBoxColumn colTotalAmount;
        private DataGridViewTextBoxColumn colPaidAmount;
        private DataGridViewTextBoxColumn colRemainedAmount;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiAdd;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripMenuItem tsmiCopyTreatments;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiRefresh;
    }
}
