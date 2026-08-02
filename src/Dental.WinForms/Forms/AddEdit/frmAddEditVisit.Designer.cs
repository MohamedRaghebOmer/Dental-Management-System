namespace Dental.WinForms.Forms
{
    partial class frmAddEditVisit
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            lblTotalPrice = new Label();
            label6 = new Label();
            label7 = new Label();
            txtId = new Guna.UI2.WinForms.Guna2TextBox();
            txtDiscountAmount = new Guna.UI2.WinForms.Guna2TextBox();
            lblTitile = new Label();
            dgvVisitTreatments = new Guna.UI2.WinForms.Guna2DataGridView();
            colToothNumber = new DataGridViewComboBoxColumn();
            colTreatmentName = new DataGridViewComboBoxColumn();
            colTreatmentPrice = new DataGridViewTextBoxColumn();
            colNotes = new DataGridViewTextBoxColumn();
            cmsTreatmetnsGrid = new ContextMenuStrip(components);
            tsmiTreatmentsDelete = new ToolStripMenuItem();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            label8 = new Label();
            label9 = new Label();
            txtRemainingAmount = new Guna.UI2.WinForms.Guna2TextBox();
            label10 = new Label();
            lblVisitDateTime = new Label();
            label11 = new Label();
            txtNotes = new RichTextBox();
            lblId = new Label();
            timer = new System.Windows.Forms.Timer(components);
            btnSearch = new FontAwesome.Sharp.IconButton();
            ctrlSearchAppointment1 = new Dental.WinForms.UserControls.Search.ctrlSearchAppointment();
            ctrlSearchPatient1 = new Dental.WinForms.UserControls.Search.ctrlSearchPatient();
            btnClose = new FontAwesome.Sharp.IconButton();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            dgvVisitPayments = new Guna.UI2.WinForms.Guna2DataGridView();
            col_Payments_VisitPaymentId = new DataGridViewTextBoxColumn();
            col_Payments_VisitId = new DataGridViewTextBoxColumn();
            col_Payments_PaidAmount = new DataGridViewTextBoxColumn();
            col_Payments_OldPaidAmount = new DataGridViewTextBoxColumn();
            col_Payments_PaymentDateTime = new DataGridViewTextBoxColumn();
            col_Payments_ConvertablePaymentDateTime = new DataGridViewTextBoxColumn();
            cmsPaymentsGrid = new ContextMenuStrip(components);
            tsmiPaymentsDelete = new ToolStripMenuItem();
            lblSumOfPaidAmounts = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVisitTreatments).BeginInit();
            cmsTreatmetnsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitPayments).BeginInit();
            cmsPaymentsGrid.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.teeth;
            pictureBox1.Location = new Point(12, 559);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(339, 479);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(122, 696);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 4;
            label3.Text = "الفك العلوي";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(119, 874);
            label4.Name = "label4";
            label4.Size = new Size(119, 28);
            label4.TabIndex = 5;
            label4.Text = "الفك السفلي";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(956, 680);
            label2.Name = "label2";
            label2.Size = new Size(141, 31);
            label2.TabIndex = 6;
            label2.Text = "المبلغ الكلي :";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.Location = new Point(750, 681);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(200, 28);
            lblTotalPrice.TabIndex = 7;
            lblTotalPrice.Text = "0";
            lblTotalPrice.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalPrice.TextChanged += txtMoney_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1402, 194);
            label6.Name = "label6";
            label6.Size = new Size(192, 28);
            label6.TabIndex = 9;
            label6.Text = "مبلغ الخصم (إن وُجد) :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1303, 253);
            label7.Name = "label7";
            label7.Size = new Size(291, 28);
            label7.TabIndex = 10;
            label7.Text = "القيه المتبقيه (دين علي المريض) :";
            // 
            // txtId
            // 
            txtId.Animated = true;
            txtId.BorderRadius = 10;
            txtId.CustomizableEdges = customizableEdges1;
            txtId.DefaultText = "";
            txtId.DisabledState.BorderColor = Color.FromArgb(213, 218, 223);
            txtId.DisabledState.FillColor = SystemColors.Window;
            txtId.DisabledState.ForeColor = Color.Gray;
            txtId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtId.Font = new Font("Segoe UI", 10.2F);
            txtId.ForeColor = Color.Black;
            txtId.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtId.Location = new Point(1004, 129);
            txtId.Margin = new Padding(3, 5, 3, 5);
            txtId.MaxLength = 6;
            txtId.Name = "txtId";
            txtId.PlaceholderText = "";
            txtId.RightToLeft = RightToLeft.Yes;
            txtId.SelectedText = "";
            txtId.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtId.Size = new Size(294, 40);
            txtId.TabIndex = 0;
            txtId.KeyPress += txtId_KeyPress;
            // 
            // txtDiscountAmount
            // 
            txtDiscountAmount.Animated = true;
            txtDiscountAmount.BorderRadius = 10;
            txtDiscountAmount.CustomizableEdges = customizableEdges3;
            txtDiscountAmount.DefaultText = "";
            txtDiscountAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDiscountAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDiscountAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Font = new Font("Segoe UI", 10.2F);
            txtDiscountAmount.ForeColor = Color.Black;
            txtDiscountAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Location = new Point(1004, 188);
            txtDiscountAmount.Margin = new Padding(3, 5, 3, 5);
            txtDiscountAmount.MaxLength = 9;
            txtDiscountAmount.Name = "txtDiscountAmount";
            txtDiscountAmount.PlaceholderText = "";
            txtDiscountAmount.SelectedText = "";
            txtDiscountAmount.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtDiscountAmount.Size = new Size(294, 40);
            txtDiscountAmount.TabIndex = 3;
            txtDiscountAmount.TextChanged += txtMoney_TextChanged;
            txtDiscountAmount.KeyPress += txtMoney_KeyPress;
            // 
            // lblTitile
            // 
            lblTitile.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(559, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(479, 81);
            lblTitile.TabIndex = 17;
            lblTitile.Text = "اضافة زياره جديده";
            lblTitile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvVisitTreatments
            // 
            dgvVisitTreatments.AllowUserToOrderColumns = true;
            dgvVisitTreatments.AllowUserToResizeColumns = false;
            dgvVisitTreatments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dgvVisitTreatments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvVisitTreatments.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvVisitTreatments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvVisitTreatments.ColumnHeadersHeight = 35;
            dgvVisitTreatments.Columns.AddRange(new DataGridViewColumn[] { colToothNumber, colTreatmentName, colTreatmentPrice, colNotes });
            dgvVisitTreatments.ContextMenuStrip = cmsTreatmetnsGrid;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvVisitTreatments.DefaultCellStyle = dataGridViewCellStyle3;
            dgvVisitTreatments.GridColor = Color.LightGray;
            dgvVisitTreatments.Location = new Point(357, 746);
            dgvVisitTreatments.MultiSelect = false;
            dgvVisitTreatments.Name = "dgvVisitTreatments";
            dgvVisitTreatments.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvVisitTreatments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvVisitTreatments.RowHeadersVisible = false;
            dgvVisitTreatments.RowHeadersWidth = 51;
            dgvVisitTreatments.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvVisitTreatments.RowTemplate.Height = 35;
            dgvVisitTreatments.RowTemplate.Resizable = DataGridViewTriState.False;
            dgvVisitTreatments.Size = new Size(1246, 237);
            dgvVisitTreatments.TabIndex = 7;
            dgvVisitTreatments.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvVisitTreatments.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvVisitTreatments.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dgvVisitTreatments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.White;
            dgvVisitTreatments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Black;
            dgvVisitTreatments.ThemeStyle.GridColor = Color.LightGray;
            dgvVisitTreatments.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F);
            dgvVisitTreatments.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVisitTreatments.ThemeStyle.HeaderStyle.Height = 35;
            dgvVisitTreatments.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;
            dgvVisitTreatments.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F);
            dgvVisitTreatments.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvVisitTreatments.ThemeStyle.RowsStyle.Height = 35;
            dgvVisitTreatments.ThemeStyle.RowsStyle.SelectionBackColor = Color.DodgerBlue;
            dgvVisitTreatments.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            dgvVisitTreatments.CellValueChanged += DataGridViewCellValueChanged;
            dgvVisitTreatments.DataError += dataGridView_DataError;
            dgvVisitTreatments.RowsRemoved += dgvVisitTreatments_RowsRemoved;
            dgvVisitTreatments.MouseDown += dataGridView_MouseDown;
            // 
            // colToothNumber
            // 
            colToothNumber.DataPropertyName = "ToothNumber";
            colToothNumber.HeaderText = "رقم السن";
            colToothNumber.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" });
            colToothNumber.MaxDropDownItems = 32;
            colToothNumber.MinimumWidth = 6;
            colToothNumber.Name = "colToothNumber";
            colToothNumber.ToolTipText = "رقم السن/الدرس في الصوره الموضحه اعلاه";
            // 
            // colTreatmentName
            // 
            colTreatmentName.DataPropertyName = "Name";
            colTreatmentName.HeaderText = "الخدمه المقدمه";
            colTreatmentName.MaxDropDownItems = 100;
            colTreatmentName.MinimumWidth = 6;
            colTreatmentName.Name = "colTreatmentName";
            colTreatmentName.ToolTipText = "الخدمه المقدمه للعميل";
            // 
            // colTreatmentPrice
            // 
            colTreatmentPrice.DataPropertyName = "Price";
            colTreatmentPrice.HeaderText = "سعر الخدمه";
            colTreatmentPrice.MinimumWidth = 6;
            colTreatmentPrice.Name = "colTreatmentPrice";
            colTreatmentPrice.ReadOnly = true;
            colTreatmentPrice.ToolTipText = "سعر الخدمه المقدمه للعميل";
            // 
            // colNotes
            // 
            colNotes.DataPropertyName = "Notes";
            colNotes.HeaderText = "ملاحظات عن الخدمه المقدمه";
            colNotes.MinimumWidth = 6;
            colNotes.Name = "colNotes";
            colNotes.ToolTipText = "ملحظات اضافيه عن العلاج المقدم";
            // 
            // cmsTreatmetnsGrid
            // 
            cmsTreatmetnsGrid.ImageScalingSize = new Size(20, 20);
            cmsTreatmetnsGrid.Items.AddRange(new ToolStripItem[] { tsmiTreatmentsDelete });
            cmsTreatmetnsGrid.Name = "contextMenuStrip";
            cmsTreatmetnsGrid.RightToLeft = RightToLeft.Yes;
            cmsTreatmetnsGrid.Size = new Size(147, 30);
            cmsTreatmetnsGrid.Opening += contextMenuStrip_Opening;
            // 
            // tsmiTreatmentsDelete
            // 
            tsmiTreatmentsDelete.Image = Properties.Resources.bin_512;
            tsmiTreatmentsDelete.Name = "tsmiTreatmentsDelete";
            tsmiTreatmentsDelete.ShortcutKeys = Keys.Delete;
            tsmiTreatmentsDelete.Size = new Size(146, 26);
            tsmiTreatmentsDelete.Text = "حذف";
            tsmiTreatmentsDelete.Click += cmsDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = SystemColors.Control;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges5;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(902, 997);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSave.Size = new Size(160, 56);
            btnSave.TabIndex = 8;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(1493, 715);
            label8.Name = "label8";
            label8.Size = new Size(91, 28);
            label8.TabIndex = 22;
            label8.Text = "ملحوظه :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F);
            label9.Location = new Point(1001, 719);
            label9.Name = "label9";
            label9.Size = new Size(496, 23);
            label9.TabIndex = 23;
            label9.Text = "عند اختيار قيمه من القائمة اضغط Enter لتأكيد الإختيار وتطبيق السعر.";
            // 
            // txtRemainingAmount
            // 
            txtRemainingAmount.Animated = true;
            txtRemainingAmount.BorderRadius = 10;
            txtRemainingAmount.CustomizableEdges = customizableEdges7;
            txtRemainingAmount.DefaultText = "";
            txtRemainingAmount.DisabledState.BorderColor = Color.FromArgb(213, 218, 223);
            txtRemainingAmount.DisabledState.FillColor = Color.White;
            txtRemainingAmount.DisabledState.ForeColor = Color.Gray;
            txtRemainingAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRemainingAmount.Enabled = false;
            txtRemainingAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRemainingAmount.Font = new Font("Segoe UI", 10.2F);
            txtRemainingAmount.ForeColor = Color.Black;
            txtRemainingAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRemainingAmount.Location = new Point(1004, 247);
            txtRemainingAmount.Margin = new Padding(3, 5, 3, 5);
            txtRemainingAmount.MaxLength = 9;
            txtRemainingAmount.Name = "txtRemainingAmount";
            txtRemainingAmount.PlaceholderText = "";
            txtRemainingAmount.SelectedText = "";
            txtRemainingAmount.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtRemainingAmount.Size = new Size(294, 40);
            txtRemainingAmount.TabIndex = 4;
            txtRemainingAmount.KeyPress += txtMoney_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1475, 312);
            label10.Name = "label10";
            label10.Size = new Size(117, 28);
            label10.TabIndex = 25;
            label10.Text = "تاريخ الزياره :";
            // 
            // lblVisitDateTime
            // 
            lblVisitDateTime.Location = new Point(1004, 312);
            lblVisitDateTime.Name = "lblVisitDateTime";
            lblVisitDateTime.RightToLeft = RightToLeft.Yes;
            lblVisitDateTime.Size = new Size(294, 28);
            lblVisitDateTime.TabIndex = 26;
            lblVisitDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1497, 371);
            label11.Name = "label11";
            label11.Size = new Size(97, 28);
            label11.TabIndex = 27;
            label11.Text = "ملاحظات :";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(1004, 371);
            txtNotes.MaxLength = 500;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(294, 73);
            txtNotes.TabIndex = 6;
            txtNotes.Text = "";
            // 
            // lblId
            // 
            lblId.Location = new Point(1452, 135);
            lblId.Name = "lblId";
            lblId.Size = new Size(142, 28);
            lblId.TabIndex = 28;
            lblId.Text = "رقم الحجز :";
            lblId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnSearch.IconColor = Color.DodgerBlue;
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 37;
            btnSearch.ImageAlign = ContentAlignment.TopLeft;
            btnSearch.Location = new Point(805, 129);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(178, 40);
            btnSearch.TabIndex = 31;
            btnSearch.Text = "عرض التفاصيل";
            btnSearch.TextAlign = ContentAlignment.TopRight;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Visible = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // ctrlSearchAppointment1
            // 
            ctrlSearchAppointment1.BackColor = Color.Transparent;
            ctrlSearchAppointment1.BorderStyle = BorderStyle.FixedSingle;
            ctrlSearchAppointment1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlSearchAppointment1.Location = new Point(12, 129);
            ctrlSearchAppointment1.Margin = new Padding(4);
            ctrlSearchAppointment1.MinimumSize = new Size(607, 423);
            ctrlSearchAppointment1.Name = "ctrlSearchAppointment1";
            ctrlSearchAppointment1.RightToLeft = RightToLeft.Yes;
            ctrlSearchAppointment1.Size = new Size(970, 423);
            ctrlSearchAppointment1.TabIndex = 32;
            // 
            // ctrlSearchPatient1
            // 
            ctrlSearchPatient1.BackColor = Color.Transparent;
            ctrlSearchPatient1.BorderStyle = BorderStyle.FixedSingle;
            ctrlSearchPatient1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlSearchPatient1.Location = new Point(12, 129);
            ctrlSearchPatient1.Margin = new Padding(4);
            ctrlSearchPatient1.MinimumSize = new Size(511, 338);
            ctrlSearchPatient1.Name = "ctrlSearchPatient1";
            ctrlSearchPatient1.RightToLeft = RightToLeft.Yes;
            ctrlSearchPatient1.Size = new Size(970, 423);
            ctrlSearchPatient1.TabIndex = 33;
            // 
            // btnClose
            // 
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.Red;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 38;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(1522, 22);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(53, 41);
            btnClose.TabIndex = 34;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
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
            // dgvVisitPayments
            // 
            dgvVisitPayments.AllowUserToOrderColumns = true;
            dgvVisitPayments.AllowUserToResizeColumns = false;
            dgvVisitPayments.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.White;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dgvVisitPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvVisitPayments.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvVisitPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvVisitPayments.ColumnHeadersHeight = 35;
            dgvVisitPayments.Columns.AddRange(new DataGridViewColumn[] { col_Payments_VisitPaymentId, col_Payments_VisitId, col_Payments_PaidAmount, col_Payments_OldPaidAmount, col_Payments_PaymentDateTime, col_Payments_ConvertablePaymentDateTime });
            dgvVisitPayments.ContextMenuStrip = cmsPaymentsGrid;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvVisitPayments.DefaultCellStyle = dataGridViewCellStyle7;
            dgvVisitPayments.GridColor = Color.LightGray;
            dgvVisitPayments.Location = new Point(1004, 499);
            dgvVisitPayments.MultiSelect = false;
            dgvVisitPayments.Name = "dgvVisitPayments";
            dgvVisitPayments.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvVisitPayments.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvVisitPayments.RowHeadersVisible = false;
            dgvVisitPayments.RowHeadersWidth = 51;
            dgvVisitPayments.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvVisitPayments.RowTemplate.Height = 35;
            dgvVisitPayments.RowTemplate.Resizable = DataGridViewTriState.False;
            dgvVisitPayments.Size = new Size(588, 178);
            dgvVisitPayments.TabIndex = 36;
            dgvVisitPayments.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvVisitPayments.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvVisitPayments.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dgvVisitPayments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.White;
            dgvVisitPayments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Black;
            dgvVisitPayments.ThemeStyle.GridColor = Color.LightGray;
            dgvVisitPayments.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F);
            dgvVisitPayments.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVisitPayments.ThemeStyle.HeaderStyle.Height = 35;
            dgvVisitPayments.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;
            dgvVisitPayments.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F);
            dgvVisitPayments.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvVisitPayments.ThemeStyle.RowsStyle.Height = 35;
            dgvVisitPayments.ThemeStyle.RowsStyle.SelectionBackColor = Color.DodgerBlue;
            dgvVisitPayments.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            dgvVisitPayments.CellValueChanged += dgvVisitPayments_CellValueChanged;
            dgvVisitPayments.RowsRemoved += dgvVisitPayments_RowsRemoved;
            dgvVisitPayments.MouseDown += dgvVisitPayments_MouseDown;
            // 
            // col_Payments_VisitPaymentId
            // 
            col_Payments_VisitPaymentId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_Payments_VisitPaymentId.DataPropertyName = "VisitPaymentId";
            col_Payments_VisitPaymentId.HeaderText = "رقم الدفع";
            col_Payments_VisitPaymentId.MinimumWidth = 6;
            col_Payments_VisitPaymentId.Name = "col_Payments_VisitPaymentId";
            col_Payments_VisitPaymentId.ReadOnly = true;
            col_Payments_VisitPaymentId.Visible = false;
            col_Payments_VisitPaymentId.Width = 125;
            // 
            // col_Payments_VisitId
            // 
            col_Payments_VisitId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_Payments_VisitId.DataPropertyName = "VisitId";
            col_Payments_VisitId.HeaderText = "رقم الزياره";
            col_Payments_VisitId.MinimumWidth = 6;
            col_Payments_VisitId.Name = "col_Payments_VisitId";
            col_Payments_VisitId.ReadOnly = true;
            col_Payments_VisitId.Visible = false;
            col_Payments_VisitId.Width = 125;
            // 
            // col_Payments_PaidAmount
            // 
            col_Payments_PaidAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_Payments_PaidAmount.DataPropertyName = "PaidAmount";
            col_Payments_PaidAmount.HeaderText = "المبلغ المدفوع";
            col_Payments_PaidAmount.MinimumWidth = 6;
            col_Payments_PaidAmount.Name = "col_Payments_PaidAmount";
            col_Payments_PaidAmount.Width = 160;
            // 
            // col_Payments_OldPaidAmount
            // 
            col_Payments_OldPaidAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_Payments_OldPaidAmount.DataPropertyName = "PaidAmount";
            col_Payments_OldPaidAmount.HeaderText = "القيمه المدفوعه الأصليه";
            col_Payments_OldPaidAmount.MinimumWidth = 6;
            col_Payments_OldPaidAmount.Name = "col_Payments_OldPaidAmount";
            col_Payments_OldPaidAmount.ReadOnly = true;
            col_Payments_OldPaidAmount.Visible = false;
            col_Payments_OldPaidAmount.Width = 125;
            // 
            // col_Payments_PaymentDateTime
            // 
            col_Payments_PaymentDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_Payments_PaymentDateTime.DataPropertyName = "PaymentDateTime";
            col_Payments_PaymentDateTime.HeaderText = "تاريخ الدفع";
            col_Payments_PaymentDateTime.MinimumWidth = 6;
            col_Payments_PaymentDateTime.Name = "col_Payments_PaymentDateTime";
            col_Payments_PaymentDateTime.ReadOnly = true;
            // 
            // col_Payments_ConvertablePaymentDateTime
            // 
            col_Payments_ConvertablePaymentDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_Payments_ConvertablePaymentDateTime.DataPropertyName = "ConvertablePaymentDateTime";
            col_Payments_ConvertablePaymentDateTime.HeaderText = "تاريخ الزياره القابل للتحويل";
            col_Payments_ConvertablePaymentDateTime.MinimumWidth = 6;
            col_Payments_ConvertablePaymentDateTime.Name = "col_Payments_ConvertablePaymentDateTime";
            col_Payments_ConvertablePaymentDateTime.ReadOnly = true;
            col_Payments_ConvertablePaymentDateTime.Visible = false;
            col_Payments_ConvertablePaymentDateTime.Width = 125;
            // 
            // cmsPaymentsGrid
            // 
            cmsPaymentsGrid.ImageScalingSize = new Size(20, 20);
            cmsPaymentsGrid.Items.AddRange(new ToolStripItem[] { tsmiPaymentsDelete });
            cmsPaymentsGrid.Name = "cmsPaymentsGrid";
            cmsPaymentsGrid.RightToLeft = RightToLeft.Yes;
            cmsPaymentsGrid.Size = new Size(115, 30);
            cmsPaymentsGrid.Opening += cmsPaymentsGrid_Opening;
            // 
            // tsmiPaymentsDelete
            // 
            tsmiPaymentsDelete.Image = Properties.Resources.bin_512;
            tsmiPaymentsDelete.Name = "tsmiPaymentsDelete";
            tsmiPaymentsDelete.Size = new Size(114, 26);
            tsmiPaymentsDelete.Text = "حذف";
            tsmiPaymentsDelete.Click += tsmiPaymentsDelete_Click;
            // 
            // lblSumOfPaidAmounts
            // 
            lblSumOfPaidAmounts.Location = new Point(1014, 459);
            lblSumOfPaidAmounts.Name = "lblSumOfPaidAmounts";
            lblSumOfPaidAmounts.Size = new Size(226, 28);
            lblSumOfPaidAmounts.TabIndex = 38;
            lblSumOfPaidAmounts.Text = "0";
            lblSumOfPaidAmounts.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(1246, 459);
            label5.Name = "label5";
            label5.Size = new Size(218, 28);
            label5.TabIndex = 37;
            label5.Text = "إجمالي المبالغ المدفوعه:";
            // 
            // frmAddEditVisit
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1596, 1064);
            Controls.Add(lblSumOfPaidAmounts);
            Controls.Add(label5);
            Controls.Add(dgvVisitPayments);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(btnSearch);
            Controls.Add(lblId);
            Controls.Add(txtNotes);
            Controls.Add(label11);
            Controls.Add(lblVisitDateTime);
            Controls.Add(label10);
            Controls.Add(txtRemainingAmount);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dgvVisitTreatments);
            Controls.Add(lblTitile);
            Controls.Add(txtDiscountAmount);
            Controls.Add(txtId);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(lblTotalPrice);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(ctrlSearchPatient1);
            Controls.Add(ctrlSearchAppointment1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddEditVisit";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة زياره";
            Load += AddUpdateVisit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVisitTreatments).EndInit();
            cmsTreatmetnsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVisitPayments).EndInit();
            cmsPaymentsGrid.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label lblTotalPrice;
        private Label label6;
        private Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtId;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscountAmount;
        private Label lblTitile;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVisitTreatments;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Label label8;
        private Label label9;
        private ContextMenuStrip cmsTreatmetnsGrid;
        private ToolStripMenuItem tsmiTreatmentsDelete;
        private Guna.UI2.WinForms.Guna2TextBox txtRemainingAmount;
        private Label label10;
        private Label lblVisitDateTime;
        private Label label11;
        private RichTextBox txtNotes;
        private Label lblId;
        private DataGridViewComboBoxColumn colToothNumber;
        private DataGridViewComboBoxColumn colTreatmentName;
        private DataGridViewTextBoxColumn colTreatmentPrice;
        private DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.Timer timer;
        private FontAwesome.Sharp.IconButton btnSearch;
        private UserControls.Search.ctrlSearchAppointment ctrlSearchAppointment1;
        private UserControls.Search.ctrlSearchPatient ctrlSearchPatient1;
        private FontAwesome.Sharp.IconButton btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVisitPayments;
        private ContextMenuStrip cmsPaymentsGrid;
        private ToolStripMenuItem tsmiPaymentsDelete;
        private Label lblSumOfPaidAmounts;
        private Label label5;
        private DataGridViewTextBoxColumn col_Payments_VisitPaymentId;
        private DataGridViewTextBoxColumn col_Payments_VisitId;
        private DataGridViewTextBoxColumn col_Payments_PaidAmount;
        private DataGridViewTextBoxColumn col_Payments_OldPaidAmount;
        private DataGridViewTextBoxColumn col_Payments_PaymentDateTime;
        private DataGridViewTextBoxColumn col_Payments_ConvertablePaymentDateTime;
    }
}