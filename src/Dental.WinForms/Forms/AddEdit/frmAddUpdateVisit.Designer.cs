namespace Dental.WinForms.Forms
{
    partial class frmAddUpdateVisit
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges71 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges72 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges73 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges74 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges75 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges76 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges77 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges78 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges79 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges80 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            btnAddPatientOrAppointment = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.teeth;
            pictureBox1.Location = new Point(12, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(367, 544);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(136, 186);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 4;
            label3.Text = "الفك العلوي";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(132, 437);
            label4.Name = "label4";
            label4.Size = new Size(119, 28);
            label4.TabIndex = 5;
            label4.Text = "الفك السفلي";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(732, 607);
            label2.Name = "label2";
            label2.Size = new Size(141, 31);
            label2.TabIndex = 6;
            label2.Text = "المبلغ الكلي :";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(661, 610);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(23, 28);
            lblTotalPrice.TabIndex = 7;
            lblTotalPrice.Text = "0";
            lblTotalPrice.TextChanged += txtMoney_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1303, 219);
            label5.Name = "label5";
            label5.Size = new Size(142, 28);
            label5.TabIndex = 8;
            label5.Text = "المبلغ المدفوع :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1253, 275);
            label6.Name = "label6";
            label6.Size = new Size(192, 28);
            label6.TabIndex = 9;
            label6.Text = "مبلغ الخصم (إن وُجد) :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1154, 332);
            label7.Name = "label7";
            label7.Size = new Size(291, 28);
            label7.TabIndex = 10;
            label7.Text = "القيه المتبقيه (دين علي المريض) :";
            // 
            // txtId
            // 
            txtId.Animated = true;
            txtId.BorderRadius = 10;
            txtId.CustomizableEdges = customizableEdges71;
            txtId.DefaultText = "";
            txtId.DisabledState.BorderColor = Color.FromArgb(213, 218, 223);
            txtId.DisabledState.FillColor = SystemColors.Window;
            txtId.DisabledState.ForeColor = Color.Gray;
            txtId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtId.Font = new Font("Segoe UI", 10.2F);
            txtId.ForeColor = Color.Black;
            txtId.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtId.Location = new Point(890, 157);
            txtId.Margin = new Padding(3, 5, 3, 5);
            txtId.MaxLength = 6;
            txtId.Name = "txtId";
            txtId.PlaceholderText = "";
            txtId.RightToLeft = RightToLeft.Yes;
            txtId.SelectedText = "";
            txtId.ShadowDecoration.CustomizableEdges = customizableEdges72;
            txtId.Size = new Size(249, 36);
            txtId.TabIndex = 0;
            txtId.KeyPress += txtId_KeyPress;
            // 
            // txtDiscountAmount
            // 
            txtDiscountAmount.Animated = true;
            txtDiscountAmount.BorderRadius = 10;
            txtDiscountAmount.CustomizableEdges = customizableEdges73;
            txtDiscountAmount.DefaultText = "";
            txtDiscountAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDiscountAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDiscountAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Font = new Font("Segoe UI", 10.2F);
            txtDiscountAmount.ForeColor = Color.Black;
            txtDiscountAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Location = new Point(890, 271);
            txtDiscountAmount.Margin = new Padding(3, 5, 3, 5);
            txtDiscountAmount.MaxLength = 9;
            txtDiscountAmount.Name = "txtDiscountAmount";
            txtDiscountAmount.PlaceholderText = "";
            txtDiscountAmount.SelectedText = "";
            txtDiscountAmount.ShadowDecoration.CustomizableEdges = customizableEdges74;
            txtDiscountAmount.Size = new Size(249, 36);
            txtDiscountAmount.TabIndex = 3;
            txtDiscountAmount.TextChanged += txtMoney_TextChanged;
            txtDiscountAmount.KeyPress += txtMoney_KeyPress;
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Animated = true;
            txtPaidAmount.BorderRadius = 10;
            txtPaidAmount.CustomizableEdges = customizableEdges75;
            txtPaidAmount.DefaultText = "";
            txtPaidAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPaidAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPaidAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Font = new Font("Segoe UI", 10.2F);
            txtPaidAmount.ForeColor = Color.Black;
            txtPaidAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Location = new Point(890, 215);
            txtPaidAmount.Margin = new Padding(3, 5, 3, 5);
            txtPaidAmount.MaxLength = 9;
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.PlaceholderText = "";
            txtPaidAmount.SelectedText = "";
            txtPaidAmount.ShadowDecoration.CustomizableEdges = customizableEdges76;
            txtPaidAmount.Size = new Size(249, 36);
            txtPaidAmount.TabIndex = 2;
            txtPaidAmount.TextChanged += txtMoney_TextChanged;
            txtPaidAmount.KeyPress += txtMoney_KeyPress;
            // 
            // lblTitile
            // 
            lblTitile.AutoSize = true;
            lblTitile.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(636, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(479, 81);
            lblTitile.TabIndex = 17;
            lblTitile.Text = "اضافة زياره جديده";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle29.BackColor = Color.White;
            dataGridViewCellStyle29.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle29.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle29.SelectionBackColor = Color.White;
            dataGridViewCellStyle29.SelectionForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle30.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle30.ForeColor = Color.White;
            dataGridViewCellStyle30.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle30.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colToothNumber, colTreatmentName, colTreatmentPrice, colNotes });
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = Color.White;
            dataGridViewCellStyle31.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle31.ForeColor = Color.Black;
            dataGridViewCellStyle31.SelectionBackColor = Color.White;
            dataGridViewCellStyle31.SelectionForeColor = Color.Black;
            dataGridViewCellStyle31.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle31;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.Location = new Point(-1, 684);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = Color.White;
            dataGridViewCellStyle32.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle32.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = Color.White;
            dataGridViewCellStyle32.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.ContextMenuStrip = contextMenuStrip;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.Size = new Size(1448, 224);
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
            btnSave.CustomizableEdges = customizableEdges77;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(643, 917);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges78;
            btnSave.Size = new Size(160, 56);
            btnSave.TabIndex = 8;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(1352, 655);
            label8.Name = "label8";
            label8.Size = new Size(91, 28);
            label8.TabIndex = 22;
            label8.Text = "ملحوظه :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F);
            label9.Location = new Point(858, 658);
            label9.Name = "label9";
            label9.Size = new Size(496, 23);
            label9.TabIndex = 23;
            label9.Text = "عند اختيار قيمه من القائمة اضغط Enter لتأكيد الإختيار وتطبيق السعر.";
            // 
            // txtRemainingAmount
            // 
            txtRemainingAmount.Animated = true;
            txtRemainingAmount.BorderRadius = 10;
            txtRemainingAmount.CustomizableEdges = customizableEdges79;
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
            txtRemainingAmount.Location = new Point(890, 328);
            txtRemainingAmount.Margin = new Padding(3, 5, 3, 5);
            txtRemainingAmount.MaxLength = 9;
            txtRemainingAmount.Name = "txtRemainingAmount";
            txtRemainingAmount.PlaceholderText = "";
            txtRemainingAmount.SelectedText = "";
            txtRemainingAmount.ShadowDecoration.CustomizableEdges = customizableEdges80;
            txtRemainingAmount.Size = new Size(249, 36);
            txtRemainingAmount.TabIndex = 4;
            txtRemainingAmount.KeyPress += txtMoney_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1326, 390);
            label10.Name = "label10";
            label10.Size = new Size(117, 28);
            label10.TabIndex = 25;
            label10.Text = "تاريخ الزياره :";
            // 
            // lblVisitDateTime
            // 
            lblVisitDateTime.Location = new Point(809, 390);
            lblVisitDateTime.Name = "lblVisitDateTime";
            lblVisitDateTime.RightToLeft = RightToLeft.Yes;
            lblVisitDateTime.Size = new Size(330, 28);
            lblVisitDateTime.TabIndex = 26;
            lblVisitDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1348, 454);
            label11.Name = "label11";
            label11.Size = new Size(97, 28);
            label11.TabIndex = 27;
            label11.Text = "ملاحظات :";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(795, 451);
            txtNotes.MaxLength = 500;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(344, 120);
            txtNotes.TabIndex = 6;
            txtNotes.Text = "";
            // 
            // lblId
            // 
            lblId.Location = new Point(1303, 161);
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
            btnSearch.ImageAlign = ContentAlignment.TopCenter;
            btnSearch.Location = new Point(833, 150);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(51, 50);
            btnSearch.TabIndex = 29;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddPatientOrAppointment
            // 
            btnAddPatientOrAppointment.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddPatientOrAppointment.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnAddPatientOrAppointment.IconColor = Color.MediumSeaGreen;
            btnAddPatientOrAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddPatientOrAppointment.ImageAlign = ContentAlignment.TopCenter;
            btnAddPatientOrAppointment.Location = new Point(766, 150);
            btnAddPatientOrAppointment.Name = "btnAddPatientOrAppointment";
            btnAddPatientOrAppointment.Size = new Size(51, 50);
            btnAddPatientOrAppointment.TabIndex = 30;
            btnAddPatientOrAppointment.UseVisualStyleBackColor = true;
            btnAddPatientOrAppointment.Visible = false;
            btnAddPatientOrAppointment.Click += btnAddPatientOrAppointment_Click;
            // 
            // frmAddUpdateVisit
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 985);
            Controls.Add(btnAddPatientOrAppointment);
            Controls.Add(btnSearch);
            Controls.Add(lblId);
            Controls.Add(txtNotes);
            Controls.Add(label11);
            Controls.Add(lblVisitDateTime);
            Controls.Add(label10);
            Controls.Add(txtRemainingAmount);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(btnSave);
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
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddUpdateVisit";
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
        private FontAwesome.Sharp.IconButton btnAddPatientOrAppointment;
    }
}