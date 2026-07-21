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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitView));
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
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            cmsEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cmsDelete = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            cmsNewAppointmentToTheSamePatient = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cmsShowPatientDetails = new ToolStripMenuItem();
            cmsShowAppointmentDetails = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
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
            pnlSearchAtRadioButtons = new Guna.UI2.WinForms.Guna2Panel();
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
            colVisitId = new DataGridViewTextBoxColumn();
            colAppointmentId = new DataGridViewTextBoxColumn();
            colPatientId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colVisitDateTime = new DataGridViewTextBoxColumn();
            colVisitTreatments = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            colPaidAmount = new DataGridViewTextBoxColumn();
            colDiscountAmount = new DataGridViewTextBoxColumn();
            colRemainedAmount = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            pnlTotalVisits.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            guna2ShadowPanel2.SuspendLayout();
            guna2ShadowPanel3.SuspendLayout();
            pnlSearchAtRadioButtons.SuspendLayout();
            SuspendLayout();
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colVisitId, colAppointmentId, colPatientId, colPatientName, colVisitDateTime, colVisitTreatments, colTotalAmount, colPaidAmount, colDiscountAmount, colRemainedAmount });
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
            dataGridView.RowTemplate.ContextMenuStrip = contextMenuStrip;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new Size(1562, 379);
            dataGridView.TabIndex = 9;
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
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { cmsEdit, toolStripSeparator1, cmsDelete, toolStripSeparator4, cmsNewAppointmentToTheSamePatient, toolStripSeparator3, cmsShowPatientDetails, cmsShowAppointmentDetails, toolStripSeparator2, cmsRefreshGrid });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.RightToLeft = RightToLeft.Yes;
            contextMenuStrip.Size = new Size(313, 184);
            // 
            // cmsEdit
            // 
            cmsEdit.Image = Properties.Resources.pen_512;
            cmsEdit.Name = "cmsEdit";
            cmsEdit.ShortcutKeys = Keys.Control | Keys.E;
            cmsEdit.Size = new Size(312, 26);
            cmsEdit.Text = "تعديل الزياره";
            cmsEdit.Click += cmsEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(309, 6);
            // 
            // cmsDelete
            // 
            cmsDelete.Image = Properties.Resources.bin_512;
            cmsDelete.Name = "cmsDelete";
            cmsDelete.RightToLeftAutoMirrorImage = true;
            cmsDelete.ShortcutKeys = Keys.Delete;
            cmsDelete.Size = new Size(312, 26);
            cmsDelete.Text = "حذف الزياره";
            cmsDelete.Click += cmsDelete_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(309, 6);
            // 
            // cmsNewAppointmentToTheSamePatient
            // 
            cmsNewAppointmentToTheSamePatient.Image = Properties.Resources.plus_512;
            cmsNewAppointmentToTheSamePatient.Name = "cmsNewAppointmentToTheSamePatient";
            cmsNewAppointmentToTheSamePatient.ShortcutKeys = Keys.Control | Keys.N;
            cmsNewAppointmentToTheSamePatient.Size = new Size(312, 26);
            cmsNewAppointmentToTheSamePatient.Text = "انشاء حجز اخر لنفس المريض";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(309, 6);
            // 
            // cmsShowPatientDetails
            // 
            cmsShowPatientDetails.Image = (Image)resources.GetObject("cmsShowPatientDetails.Image");
            cmsShowPatientDetails.Name = "cmsShowPatientDetails";
            cmsShowPatientDetails.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            cmsShowPatientDetails.Size = new Size(312, 26);
            cmsShowPatientDetails.Text = "عرض بيانات المريض";
            cmsShowPatientDetails.Click += cmsShowPatientDetails_Click;
            // 
            // cmsShowAppointmentDetails
            // 
            cmsShowAppointmentDetails.Image = Properties.Resources.details_512;
            cmsShowAppointmentDetails.Name = "cmsShowAppointmentDetails";
            cmsShowAppointmentDetails.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            cmsShowAppointmentDetails.Size = new Size(312, 26);
            cmsShowAppointmentDetails.Text = "عرض بيانات الحجز";
            cmsShowAppointmentDetails.Click += cmsShowAppointmentDetails_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(309, 6);
            // 
            // cmsRefreshGrid
            // 
            cmsRefreshGrid.Image = Properties.Resources.Refresh_32;
            cmsRefreshGrid.Name = "cmsRefreshGrid";
            cmsRefreshGrid.ShortcutKeys = Keys.F5;
            cmsRefreshGrid.Size = new Size(312, 26);
            cmsRefreshGrid.Text = "تحديث";
            cmsRefreshGrid.Click += cmsRefreshGrid_Click;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderRadius = 7;
            txtFilterValue.CustomizableEdges = customizableEdges1;
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
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 9;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "رقم الزياره", "رقم الحجز", "اسم المريض", "تاريخ الزياره", "الخدمات المقدمه", "المبلغ الكلي", "المبلغ المدفوع", "مبلغ الخصم", "المبلغ المتبقي" });
            cbFilterList.Location = new Point(477, 508);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 8;
            cbFilterList.SelectedIndexChanged += cbFilterList_SelectedIndexChanged;
            // 
            // pnlTotalVisits
            // 
            pnlTotalVisits.BackColor = Color.Transparent;
            pnlTotalVisits.Controls.Add(lblTotalVisits);
            pnlTotalVisits.Controls.Add(label1);
            pnlTotalVisits.FillColor = Color.White;
            pnlTotalVisits.Location = new Point(1234, 219);
            pnlTotalVisits.Name = "pnlTotalVisits";
            pnlTotalVisits.Radius = 10;
            pnlTotalVisits.ShadowColor = Color.Black;
            pnlTotalVisits.ShadowDepth = 150;
            pnlTotalVisits.Size = new Size(295, 125);
            pnlTotalVisits.TabIndex = 2;
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
            guna2ShadowPanel1.Location = new Point(834, 219);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 150;
            guna2ShadowPanel1.Size = new Size(295, 125);
            guna2ShadowPanel1.TabIndex = 3;
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
            guna2ShadowPanel2.Location = new Point(434, 219);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 150;
            guna2ShadowPanel2.Size = new Size(295, 125);
            guna2ShadowPanel2.TabIndex = 4;
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
            guna2ShadowPanel3.Location = new Point(34, 219);
            guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            guna2ShadowPanel3.Radius = 10;
            guna2ShadowPanel3.ShadowColor = Color.Black;
            guna2ShadowPanel3.ShadowDepth = 150;
            guna2ShadowPanel3.Size = new Size(295, 125);
            guna2ShadowPanel3.TabIndex = 5;
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
            pnlSearchAtRadioButtons.Location = new Point(1287, 18);
            pnlSearchAtRadioButtons.Name = "pnlSearchAtRadioButtons";
            pnlSearchAtRadioButtons.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlSearchAtRadioButtons.Size = new Size(272, 168);
            pnlSearchAtRadioButtons.TabIndex = 1;
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
            rbThisWeek.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
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
            rbThisMonth.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
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
            rbAllTime.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
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
            rbToday.CheckedChanged += RadioButtonsDateTimeFiltering_CheckedChanged;
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
            dtpSearchAfter.Location = new Point(595, 422);
            dtpSearchAfter.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpSearchAfter.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpSearchAfter.Name = "dtpSearchAfter";
            dtpSearchAfter.RightToLeft = RightToLeft.No;
            dtpSearchAfter.ShadowDecoration.BorderRadius = 30;
            dtpSearchAfter.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpSearchAfter.ShadowDecoration.Shadow = new Padding(0);
            dtpSearchAfter.Size = new Size(301, 45);
            dtpSearchAfter.TabIndex = 7;
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
            btnRefresh.TabIndex = 0;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblSearchAfter
            // 
            lblSearchAfter.AutoSize = true;
            lblSearchAfter.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchAfter.Location = new Point(915, 427);
            lblSearchAfter.Name = "lblSearchAfter";
            lblSearchAfter.Size = new Size(221, 31);
            lblSearchAfter.TabIndex = 4;
            lblSearchAfter.Text = "ابحث بعد تاريخ معين :";
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
            btnAddWalkInVisit.FillColor = Color.DarkBlue;
            btnAddWalkInVisit.Font = new Font("Segoe UI", 13.8F);
            btnAddWalkInVisit.ForeColor = Color.White;
            btnAddWalkInVisit.HoverState.FillColor = Color.MediumBlue;
            btnAddWalkInVisit.Location = new Point(1265, 497);
            btnAddWalkInVisit.Name = "btnAddWalkInVisit";
            btnAddWalkInVisit.PressedColor = Color.MediumBlue;
            btnAddWalkInVisit.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAddWalkInVisit.Size = new Size(288, 57);
            btnAddWalkInVisit.TabIndex = 11;
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
            dtpVisitDateTime.CustomizableEdges = customizableEdges9;
            dtpVisitDateTime.FillColor = Color.White;
            dtpVisitDateTime.FocusedColor = Color.White;
            dtpVisitDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpVisitDateTime.Format = DateTimePickerFormat.Long;
            dtpVisitDateTime.HoverState.BorderColor = Color.White;
            dtpVisitDateTime.HoverState.FillColor = Color.White;
            dtpVisitDateTime.HoverState.ForeColor = Color.Black;
            dtpVisitDateTime.Location = new Point(785, 504);
            dtpVisitDateTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpVisitDateTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpVisitDateTime.Name = "dtpVisitDateTime";
            dtpVisitDateTime.RightToLeft = RightToLeft.No;
            dtpVisitDateTime.ShadowDecoration.BorderRadius = 30;
            dtpVisitDateTime.ShadowDecoration.CustomizableEdges = customizableEdges10;
            dtpVisitDateTime.ShadowDecoration.Shadow = new Padding(0);
            dtpVisitDateTime.Size = new Size(301, 45);
            dtpVisitDateTime.TabIndex = 12;
            dtpVisitDateTime.TextAlign = HorizontalAlignment.Center;
            dtpVisitDateTime.Value = new DateTime(2026, 7, 17, 17, 48, 32, 351);
            dtpVisitDateTime.Visible = false;
            dtpVisitDateTime.ValueChanged += dateTimePicker_ValueChanged;
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
            colPatientId.Width = 140;
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
            // colPaidAmount
            // 
            colPaidAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colPaidAmount.DataPropertyName = "PaidAmount";
            colPaidAmount.HeaderText = "المبلغ المدفوع";
            colPaidAmount.MinimumWidth = 100;
            colPaidAmount.Name = "colPaidAmount";
            colPaidAmount.ReadOnly = true;
            colPaidAmount.Width = 160;
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
            // VisitView
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(dtpVisitDateTime);
            Controls.Add(btnAddWalkInVisit);
            Controls.Add(lblSearchAfter);
            Controls.Add(btnRefresh);
            Controls.Add(pnlSearchAtRadioButtons);
            Controls.Add(guna2ShadowPanel3);
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(pnlTotalVisits);
            Controls.Add(cbFilterList);
            Controls.Add(txtFilterValue);
            Controls.Add(dataGridView);
            Controls.Add(dtpSearchAfter);
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
            pnlSearchAtRadioButtons.ResumeLayout(false);
            pnlSearchAtRadioButtons.PerformLayout();
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
        private Label lblTotalPaidAmount;
        private Label lblTotalDiscountAmount;
        private Label lblTotalRemainedAmount;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpSearchAfter;
        private System.Windows.Forms.Timer timerUpdateDateTimePckerMaxDate;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmsEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.Timer filterTimer;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cmsRefreshGrid;
        private Label lblSearchAfter;
        private Guna.UI2.WinForms.Guna2Button btnAddWalkInVisit;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpVisitDateTime;
        private ToolStripMenuItem cmsNewAppointmentToTheSamePatient;
        private ToolStripMenuItem cmsShowPatientDetails;
        private ToolStripMenuItem cmsShowAppointmentDetails;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator2;
        private DataGridViewTextBoxColumn colVisitId;
        private DataGridViewTextBoxColumn colAppointmentId;
        private DataGridViewTextBoxColumn colPatientId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colVisitDateTime;
        private DataGridViewTextBoxColumn colVisitTreatments;
        private DataGridViewTextBoxColumn colTotalAmount;
        private DataGridViewTextBoxColumn colPaidAmount;
        private DataGridViewTextBoxColumn colDiscountAmount;
        private DataGridViewTextBoxColumn colRemainedAmount;
    }
}
