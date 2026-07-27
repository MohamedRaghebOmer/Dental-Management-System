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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            lblTotalPrice = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtId = new Guna.UI2.WinForms.Guna2TextBox();
            txtDiscountAmount = new Guna.UI2.WinForms.Guna2TextBox();
            txtPaidAmount = new Guna.UI2.WinForms.Guna2TextBox();
            lblTitile = new Label();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colToothNumber = new DataGridViewComboBoxColumn();
            colTreatmentName = new DataGridViewComboBoxColumn();
            colTreatmentPrice = new DataGridViewTextBoxColumn();
            colNotes = new DataGridViewTextBoxColumn();
            contextMenuStrip = new ContextMenuStrip(components);
            cmsDelete = new ToolStripMenuItem();
            cmsEdit = new ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.teeth;
            pictureBox1.Location = new Point(2, 565);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(318, 461);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(100, 693);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 4;
            label3.Text = "الفك العلوي";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(97, 871);
            label4.Name = "label4";
            label4.Size = new Size(119, 28);
            label4.TabIndex = 5;
            label4.Text = "الفك السفلي";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(958, 602);
            label2.Name = "label2";
            label2.Size = new Size(141, 31);
            label2.TabIndex = 6;
            label2.Text = "المبلغ الكلي :";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(887, 606);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(23, 28);
            lblTotalPrice.TabIndex = 7;
            lblTotalPrice.Text = "0";
            lblTotalPrice.TextChanged += txtMoney_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1438, 197);
            label5.Name = "label5";
            label5.Size = new Size(142, 28);
            label5.TabIndex = 8;
            label5.Text = "المبلغ المدفوع :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1388, 253);
            label6.Name = "label6";
            label6.Size = new Size(192, 28);
            label6.TabIndex = 9;
            label6.Text = "مبلغ الخصم (إن وُجد) :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1289, 310);
            label7.Name = "label7";
            label7.Size = new Size(291, 28);
            label7.TabIndex = 10;
            label7.Text = "القيه المتبقيه (دين علي المريض) :";
            // 
            // txtId
            // 
            txtId.Animated = true;
            txtId.BorderRadius = 10;
            txtId.CustomizableEdges = customizableEdges11;
            txtId.DefaultText = "";
            txtId.DisabledState.BorderColor = Color.FromArgb(213, 218, 223);
            txtId.DisabledState.FillColor = SystemColors.Window;
            txtId.DisabledState.ForeColor = Color.Gray;
            txtId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtId.Font = new Font("Segoe UI", 10.2F);
            txtId.ForeColor = Color.Black;
            txtId.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtId.Location = new Point(990, 135);
            txtId.Margin = new Padding(3, 5, 3, 5);
            txtId.MaxLength = 6;
            txtId.Name = "txtId";
            txtId.PlaceholderText = "";
            txtId.RightToLeft = RightToLeft.Yes;
            txtId.SelectedText = "";
            txtId.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtId.Size = new Size(294, 40);
            txtId.TabIndex = 0;
            txtId.KeyPress += txtId_KeyPress;
            // 
            // txtDiscountAmount
            // 
            txtDiscountAmount.Animated = true;
            txtDiscountAmount.BorderRadius = 10;
            txtDiscountAmount.CustomizableEdges = customizableEdges13;
            txtDiscountAmount.DefaultText = "";
            txtDiscountAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDiscountAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDiscountAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Font = new Font("Segoe UI", 10.2F);
            txtDiscountAmount.ForeColor = Color.Black;
            txtDiscountAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Location = new Point(990, 249);
            txtDiscountAmount.Margin = new Padding(3, 5, 3, 5);
            txtDiscountAmount.MaxLength = 9;
            txtDiscountAmount.Name = "txtDiscountAmount";
            txtDiscountAmount.PlaceholderText = "";
            txtDiscountAmount.SelectedText = "";
            txtDiscountAmount.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtDiscountAmount.Size = new Size(294, 40);
            txtDiscountAmount.TabIndex = 3;
            txtDiscountAmount.TextChanged += txtMoney_TextChanged;
            txtDiscountAmount.KeyPress += txtMoney_KeyPress;
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Animated = true;
            txtPaidAmount.BorderRadius = 10;
            txtPaidAmount.CustomizableEdges = customizableEdges15;
            txtPaidAmount.DefaultText = "";
            txtPaidAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPaidAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPaidAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Font = new Font("Segoe UI", 10.2F);
            txtPaidAmount.ForeColor = Color.Black;
            txtPaidAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Location = new Point(990, 193);
            txtPaidAmount.Margin = new Padding(3, 5, 3, 5);
            txtPaidAmount.MaxLength = 9;
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.PlaceholderText = "";
            txtPaidAmount.SelectedText = "";
            txtPaidAmount.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtPaidAmount.Size = new Size(294, 40);
            txtPaidAmount.TabIndex = 2;
            txtPaidAmount.TextChanged += txtMoney_TextChanged;
            txtPaidAmount.KeyPress += txtMoney_KeyPress;
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
            // dataGridView
            // 
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.White;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colToothNumber, colTreatmentName, colTreatmentPrice, colNotes });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.White;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.Location = new Point(326, 683);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
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
            dataGridView.Size = new Size(1270, 272);
            dataGridView.TabIndex = 7;
            dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Black;
            dataGridView.ThemeStyle.GridColor = Color.LightGray;
            dataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F);
            dataGridView.ThemeStyle.HeaderStyle.Height = 35;
            dataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F);
            dataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dataGridView.ThemeStyle.RowsStyle.Height = 35;
            dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.White;
            dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
            dataGridView.DataError += dataGridView_DataError;
            dataGridView.MouseDown += dataGridView_MouseDown;
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
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { cmsDelete, cmsEdit });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.RightToLeft = RightToLeft.Yes;
            contextMenuStrip.Size = new Size(227, 56);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // cmsDelete
            // 
            cmsDelete.Image = Properties.Resources.bin_512;
            cmsDelete.Name = "cmsDelete";
            cmsDelete.ShortcutKeys = Keys.Delete;
            cmsDelete.Size = new Size(226, 26);
            cmsDelete.Text = "حذف";
            cmsDelete.Click += cmsDelete_Click;
            // 
            // cmsEdit
            // 
            cmsEdit.Image = Properties.Resources.pen_512;
            cmsEdit.Name = "cmsEdit";
            cmsEdit.ShortcutKeys = Keys.Control | Keys.E;
            cmsEdit.Size = new Size(226, 26);
            cmsEdit.Text = "تعديل الخدمات";
            cmsEdit.Click += cmsEdit_Click;
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = SystemColors.Control;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges17;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(878, 977);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnSave.Size = new Size(160, 56);
            btnSave.TabIndex = 8;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(1502, 652);
            label8.Name = "label8";
            label8.Size = new Size(91, 28);
            label8.TabIndex = 22;
            label8.Text = "ملحوظه :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F);
            label9.Location = new Point(1010, 656);
            label9.Name = "label9";
            label9.Size = new Size(496, 23);
            label9.TabIndex = 23;
            label9.Text = "عند اختيار قيمه من القائمة اضغط Enter لتأكيد الإختيار وتطبيق السعر.";
            // 
            // txtRemainingAmount
            // 
            txtRemainingAmount.Animated = true;
            txtRemainingAmount.BorderRadius = 10;
            txtRemainingAmount.CustomizableEdges = customizableEdges19;
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
            txtRemainingAmount.Location = new Point(990, 306);
            txtRemainingAmount.Margin = new Padding(3, 5, 3, 5);
            txtRemainingAmount.MaxLength = 9;
            txtRemainingAmount.Name = "txtRemainingAmount";
            txtRemainingAmount.PlaceholderText = "";
            txtRemainingAmount.SelectedText = "";
            txtRemainingAmount.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txtRemainingAmount.Size = new Size(294, 40);
            txtRemainingAmount.TabIndex = 4;
            txtRemainingAmount.KeyPress += txtMoney_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1461, 368);
            label10.Name = "label10";
            label10.Size = new Size(117, 28);
            label10.TabIndex = 25;
            label10.Text = "تاريخ الزياره :";
            // 
            // lblVisitDateTime
            // 
            lblVisitDateTime.Location = new Point(990, 368);
            lblVisitDateTime.Name = "lblVisitDateTime";
            lblVisitDateTime.RightToLeft = RightToLeft.Yes;
            lblVisitDateTime.Size = new Size(294, 28);
            lblVisitDateTime.TabIndex = 26;
            lblVisitDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1483, 432);
            label11.Name = "label11";
            label11.Size = new Size(97, 28);
            label11.TabIndex = 27;
            label11.Text = "ملاحظات :";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(990, 429);
            txtNotes.MaxLength = 500;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(294, 120);
            txtNotes.TabIndex = 6;
            txtNotes.Text = "";
            // 
            // lblId
            // 
            lblId.Location = new Point(1438, 139);
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
            btnSearch.Location = new Point(806, 135);
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
            ctrlSearchAppointment1.Location = new Point(13, 135);
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
            ctrlSearchPatient1.Location = new Point(13, 135);
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
            btnClose.Location = new Point(1523, 12);
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
            // frmAddEditVisit
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1596, 1055);
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
            Controls.Add(dataGridView);
            Controls.Add(lblTitile);
            Controls.Add(txtPaidAmount);
            Controls.Add(txtDiscountAmount);
            Controls.Add(txtId);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
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
            MaximumSize = new Size(1596, 1055);
            MinimizeBox = false;
            MinimumSize = new Size(1596, 1055);
            Name = "frmAddEditVisit";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة زياره";
            Load += AddUpdateVisit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label lblTotalPrice;
        private Label label5;
        private Label label6;
        private Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtId;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscountAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtPaidAmount;
        private Label lblTitile;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Label label8;
        private Label label9;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmsDelete;
        private ToolStripMenuItem cmsEdit;
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
    }
}