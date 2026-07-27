namespace Dental.WinForms.Views
{
    partial class MaterialsView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label9 = new Label();
            pnlPendingAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblLowStockCount = new Label();
            label2 = new Label();
            pnlCompletedAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblOutOfStockCount = new Label();
            label13 = new Label();
            btnNewMaterial = new Guna.UI2.WinForms.Guna2Button();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            pnlTotalAppointments = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblMaterialsCount = new Label();
            label1 = new Label();
            cbFilterList = new ComboBox();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colReorderLevel = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tsmiEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiAdd = new ToolStripMenuItem();
            tsmiDelete = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiCopyName = new ToolStripMenuItem();
            tsmiRefresh = new ToolStripMenuItem();
            txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            label8 = new Label();
            cbMaterialStatus = new ComboBox();
            loadDataTimer = new System.Windows.Forms.Timer(components);
            نسخإسمالToolStripMenuItem1 = new ToolStripMenuItem();
            تحديثToolStripMenuItem = new ToolStripMenuItem();
            pnlPendingAppointments.SuspendLayout();
            pnlCompletedAppointments.SuspendLayout();
            pnlTotalAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(955, 540);
            label9.Name = "label9";
            label9.Size = new Size(497, 28);
            label9.TabIndex = 59;
            label9.Text = "اضغط علي الصف ضغطتين متتاليتين لتعديل بيانات الخامه.";
            // 
            // pnlPendingAppointments
            // 
            pnlPendingAppointments.BackColor = Color.Transparent;
            pnlPendingAppointments.Controls.Add(lblLowStockCount);
            pnlPendingAppointments.Controls.Add(label2);
            pnlPendingAppointments.FillColor = Color.White;
            pnlPendingAppointments.Location = new Point(620, 217);
            pnlPendingAppointments.Name = "pnlPendingAppointments";
            pnlPendingAppointments.Radius = 10;
            pnlPendingAppointments.ShadowColor = Color.Black;
            pnlPendingAppointments.ShadowDepth = 150;
            pnlPendingAppointments.Size = new Size(319, 128);
            pnlPendingAppointments.TabIndex = 52;
            // 
            // lblLowStockCount
            // 
            lblLowStockCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLowStockCount.ForeColor = Color.Black;
            lblLowStockCount.Location = new Point(3, 56);
            lblLowStockCount.Name = "lblLowStockCount";
            lblLowStockCount.Size = new Size(313, 31);
            lblLowStockCount.TabIndex = 8;
            lblLowStockCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(87, 9);
            label2.Name = "label2";
            label2.Size = new Size(224, 28);
            label2.TabIndex = 3;
            label2.Text = "الخامات منخفضة المخزون";
            // 
            // pnlCompletedAppointments
            // 
            pnlCompletedAppointments.BackColor = Color.Transparent;
            pnlCompletedAppointments.Controls.Add(lblOutOfStockCount);
            pnlCompletedAppointments.Controls.Add(label13);
            pnlCompletedAppointments.FillColor = Color.White;
            pnlCompletedAppointments.Location = new Point(169, 217);
            pnlCompletedAppointments.Name = "pnlCompletedAppointments";
            pnlCompletedAppointments.Radius = 10;
            pnlCompletedAppointments.ShadowColor = Color.Black;
            pnlCompletedAppointments.ShadowDepth = 150;
            pnlCompletedAppointments.Size = new Size(319, 128);
            pnlCompletedAppointments.TabIndex = 53;
            // 
            // lblOutOfStockCount
            // 
            lblOutOfStockCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblOutOfStockCount.ForeColor = Color.Black;
            lblOutOfStockCount.Location = new Point(3, 56);
            lblOutOfStockCount.Name = "lblOutOfStockCount";
            lblOutOfStockCount.Size = new Size(313, 31);
            lblOutOfStockCount.TabIndex = 8;
            lblOutOfStockCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(255, 128, 0);
            label13.Location = new Point(164, 9);
            label13.Name = "label13";
            label13.Size = new Size(147, 28);
            label13.TabIndex = 3;
            label13.Text = "الخامات المنتهيه";
            // 
            // btnNewMaterial
            // 
            btnNewMaterial.Animated = true;
            btnNewMaterial.AnimatedGIF = true;
            btnNewMaterial.BackColor = Color.Transparent;
            btnNewMaterial.BorderRadius = 15;
            btnNewMaterial.CustomizableEdges = customizableEdges1;
            btnNewMaterial.DisabledState.BorderColor = Color.DarkGray;
            btnNewMaterial.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNewMaterial.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNewMaterial.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNewMaterial.FillColor = Color.FromArgb(0, 0, 150);
            btnNewMaterial.Font = new Font("Segoe UI", 13.8F);
            btnNewMaterial.ForeColor = Color.White;
            btnNewMaterial.HoverState.FillColor = Color.MediumBlue;
            btnNewMaterial.Location = new Point(1315, 467);
            btnNewMaterial.Name = "btnNewMaterial";
            btnNewMaterial.PressedColor = Color.FromArgb(0, 0, 165);
            btnNewMaterial.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnNewMaterial.Size = new Size(232, 57);
            btnNewMaterial.TabIndex = 58;
            btnNewMaterial.Text = "إضافة خامه جديده";
            btnNewMaterial.Click += btnNewMaterial_Click;
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
            btnRefresh.TabIndex = 50;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += Refresh;
            // 
            // pnlTotalAppointments
            // 
            pnlTotalAppointments.BackColor = Color.Transparent;
            pnlTotalAppointments.Controls.Add(lblMaterialsCount);
            pnlTotalAppointments.Controls.Add(label1);
            pnlTotalAppointments.FillColor = Color.White;
            pnlTotalAppointments.Location = new Point(1071, 217);
            pnlTotalAppointments.Name = "pnlTotalAppointments";
            pnlTotalAppointments.Radius = 10;
            pnlTotalAppointments.ShadowColor = Color.Black;
            pnlTotalAppointments.ShadowDepth = 150;
            pnlTotalAppointments.Size = new Size(319, 128);
            pnlTotalAppointments.TabIndex = 51;
            // 
            // lblMaterialsCount
            // 
            lblMaterialsCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMaterialsCount.ForeColor = Color.Black;
            lblMaterialsCount.Location = new Point(3, 56);
            lblMaterialsCount.Name = "lblMaterialsCount";
            lblMaterialsCount.Size = new Size(313, 31);
            lblMaterialsCount.TabIndex = 7;
            lblMaterialsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(171, 9);
            label1.Name = "label1";
            label1.Size = new Size(140, 28);
            label1.TabIndex = 3;
            label1.Text = "إجمالي الخامات";
            // 
            // cbFilterList
            // 
            cbFilterList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterList.FormattingEnabled = true;
            cbFilterList.Items.AddRange(new object[] { "الإسم", "الكميه المتاحه", "حد إعادة الطلب", "سعر الشراء", "الحاله" });
            cbFilterList.Location = new Point(484, 477);
            cbFilterList.Name = "cbFilterList";
            cbFilterList.Size = new Size(301, 36);
            cbFilterList.TabIndex = 55;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colQuantity, colReorderLevel, colPrice, colStatus });
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
            dataGridView.Location = new Point(0, 573);
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
            dataGridView.Size = new Size(1558, 379);
            dataGridView.TabIndex = 57;
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
            colId.HeaderText = "رقم الخامه";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "Name";
            colName.HeaderText = "الإسم";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "الكميه المتاحه";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            // 
            // colReorderLevel
            // 
            colReorderLevel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colReorderLevel.DataPropertyName = "ReorderLevel";
            colReorderLevel.HeaderText = "حد إعادة الطلب";
            colReorderLevel.MinimumWidth = 6;
            colReorderLevel.Name = "colReorderLevel";
            colReorderLevel.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "سعر الشراء";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "الحاله";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tsmiEdit, toolStripSeparator1, tsmiAdd, tsmiDelete, toolStripSeparator2, tsmiCopyName, tsmiRefresh });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(183, 146);
            // 
            // tsmiEdit
            // 
            tsmiEdit.Image = Properties.Resources.pen_512;
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.Size = new Size(182, 26);
            tsmiEdit.Text = "تعديل";
            tsmiEdit.Click += dataGridView_DoubleClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(179, 6);
            // 
            // tsmiAdd
            // 
            tsmiAdd.Image = Properties.Resources.plus_512;
            tsmiAdd.Name = "tsmiAdd";
            tsmiAdd.Size = new Size(182, 26);
            tsmiAdd.Text = "إضافه";
            tsmiAdd.Click += btnNewMaterial_Click;
            // 
            // tsmiDelete
            // 
            tsmiDelete.Image = Properties.Resources.bin_512;
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new Size(182, 26);
            tsmiDelete.Text = "حذف";
            tsmiDelete.Click += tsmiDelete_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(179, 6);
            // 
            // tsmiCopyName
            // 
            tsmiCopyName.Image = Properties.Resources.copy;
            tsmiCopyName.Name = "tsmiCopyName";
            tsmiCopyName.Size = new Size(182, 26);
            tsmiCopyName.Text = "نسخ إسم الخامه";
            tsmiCopyName.Click += tsmiCopyName_Click;
            // 
            // tsmiRefresh
            // 
            tsmiRefresh.Image = Properties.Resources.Refresh_32;
            tsmiRefresh.Name = "tsmiRefresh";
            tsmiRefresh.Size = new Size(182, 26);
            tsmiRefresh.Text = "تحديث";
            tsmiRefresh.Click += Refresh;
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
            txtFilterValue.Location = new Point(792, 477);
            txtFilterValue.Margin = new Padding(4, 6, 4, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "ابحث هنا";
            txtFilterValue.SelectedText = "";
            txtFilterValue.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtFilterValue.Size = new Size(301, 36);
            txtFilterValue.TabIndex = 56;
            txtFilterValue.TextChanged += RefreshData;
            txtFilterValue.VisibleChanged += RefreshData;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1454, 539);
            label8.Name = "label8";
            label8.Size = new Size(103, 31);
            label8.TabIndex = 60;
            label8.Text = "ملحوظه :";
            // 
            // cbMaterialStatus
            // 
            cbMaterialStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaterialStatus.FormattingEnabled = true;
            cbMaterialStatus.Items.AddRange(new object[] { "الكل", "متوفر", "منخفض", "نفد" });
            cbMaterialStatus.Location = new Point(792, 477);
            cbMaterialStatus.Name = "cbMaterialStatus";
            cbMaterialStatus.Size = new Size(301, 36);
            cbMaterialStatus.TabIndex = 61;
            cbMaterialStatus.Visible = false;
            cbMaterialStatus.SelectedIndexChanged += RefreshData;
            cbMaterialStatus.VisibleChanged += RefreshData;
            // 
            // loadDataTimer
            // 
            loadDataTimer.Interval = 10;
            loadDataTimer.Tick += loadDataTimer_Tick;
            // 
            // نسخإسمالToolStripMenuItem1
            // 
            نسخإسمالToolStripMenuItem1.Name = "نسخإسمالToolStripMenuItem1";
            نسخإسمالToolStripMenuItem1.Size = new Size(32, 19);
            // 
            // تحديثToolStripMenuItem
            // 
            تحديثToolStripMenuItem.Name = "تحديثToolStripMenuItem";
            تحديثToolStripMenuItem.Size = new Size(32, 19);
            // 
            // MaterialsView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkCyan;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(pnlPendingAppointments);
            Controls.Add(pnlCompletedAppointments);
            Controls.Add(btnNewMaterial);
            Controls.Add(btnRefresh);
            Controls.Add(pnlTotalAppointments);
            Controls.Add(cbFilterList);
            Controls.Add(dataGridView);
            Controls.Add(txtFilterValue);
            Controls.Add(cbMaterialStatus);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1560, 954);
            MinimumSize = new Size(1560, 954);
            Name = "MaterialsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1558, 952);
            Load += MaterialsView_Load;
            pnlPendingAppointments.ResumeLayout(false);
            pnlPendingAppointments.PerformLayout();
            pnlCompletedAppointments.ResumeLayout(false);
            pnlCompletedAppointments.PerformLayout();
            pnlTotalAppointments.ResumeLayout(false);
            pnlTotalAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlPendingAppointments;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlCompletedAppointments;
        private Label label13;
        private Guna.UI2.WinForms.Guna2Button btnNewMaterial;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlTotalAppointments;
        private ComboBox cbFilterList;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Label label8;
        private ComboBox cbMaterialStatus;
        private Label lblMaterialsCount;
        private Label label1;
        private Label lblLowStockCount;
        private Label lblOutOfStockCount;
        private System.Windows.Forms.Timer loadDataTimer;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiAdd;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiCopyName;
        private ToolStripMenuItem tsmiRefresh;
        private ToolStripMenuItem نسخإسمالToolStripMenuItem1;
        private ToolStripMenuItem تحديثToolStripMenuItem;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colReorderLevel;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStatus;
    }
}
