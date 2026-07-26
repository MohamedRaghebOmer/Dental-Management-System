namespace Dental.WinForms.Views
{
    partial class TreatmentsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreatmentsView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tsmiEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiAdd = new ToolStripMenuItem();
            tsmiDelete = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiCopyName = new ToolStripMenuItem();
            tsmiRefresh = new ToolStripMenuItem();
            txtSearchValue = new Guna.UI2.WinForms.Guna2TextBox();
            btnAddNewTreatment = new Guna.UI2.WinForms.Guna2Button();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            label9 = new Label();
            guna2ShadowPanel4 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTreatmentsCount = new Label();
            label8 = new Label();
            loadDataTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            guna2ShadowPanel4.SuspendLayout();
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
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPrice, colDescription });
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
            dataGridView.TabIndex = 13;
            dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.Transparent;
            dataGridView.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.DodgerBlue;
            dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.White;
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
            colId.HeaderText = "رقم الخدمه";
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
            colName.HeaderText = "الخدمه";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "السعر";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "الوصف";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tsmiEdit, toolStripSeparator1, tsmiAdd, tsmiDelete, toolStripSeparator2, tsmiCopyName, tsmiRefresh });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(187, 146);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // tsmiEdit
            // 
            tsmiEdit.Image = Properties.Resources.pen_512;
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.Size = new Size(186, 26);
            tsmiEdit.Text = "تعديل";
            tsmiEdit.Click += tsmiEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(183, 6);
            // 
            // tsmiAdd
            // 
            tsmiAdd.Image = Properties.Resources.plus_512;
            tsmiAdd.Name = "tsmiAdd";
            tsmiAdd.Size = new Size(186, 26);
            tsmiAdd.Text = "إضافه خدمه";
            tsmiAdd.Click += tsmiAdd_Click;
            // 
            // tsmiDelete
            // 
            tsmiDelete.Enabled = false;
            tsmiDelete.Image = Properties.Resources.bin_512;
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new Size(186, 26);
            tsmiDelete.Text = "حذف";
            tsmiDelete.Click += tsmiDelete_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(183, 6);
            // 
            // tsmiCopyName
            // 
            tsmiCopyName.Image = (Image)resources.GetObject("tsmiCopyName.Image");
            tsmiCopyName.Name = "tsmiCopyName";
            tsmiCopyName.Size = new Size(186, 26);
            tsmiCopyName.Text = "نسخ اسم الخدمه";
            tsmiCopyName.Click += tsmiCopyName_Click;
            // 
            // tsmiRefresh
            // 
            tsmiRefresh.Image = Properties.Resources.Refresh_32;
            tsmiRefresh.Name = "tsmiRefresh";
            tsmiRefresh.Size = new Size(186, 26);
            tsmiRefresh.Text = "تحديث";
            tsmiRefresh.Click += tsmiRefresh_Click;
            // 
            // txtSearchValue
            // 
            txtSearchValue.BorderRadius = 7;
            txtSearchValue.CustomizableEdges = customizableEdges1;
            txtSearchValue.DefaultText = "";
            txtSearchValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchValue.ForeColor = Color.Black;
            txtSearchValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchValue.Location = new Point(631, 498);
            txtSearchValue.Margin = new Padding(4, 6, 4, 6);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.PlaceholderText = "ابحث بإسم الخدمه";
            txtSearchValue.SelectedText = "";
            txtSearchValue.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearchValue.Size = new Size(301, 36);
            txtSearchValue.TabIndex = 29;
            txtSearchValue.TextChanged += txtSearchValue_TextChanged;
            // 
            // btnAddNewTreatment
            // 
            btnAddNewTreatment.Animated = true;
            btnAddNewTreatment.AnimatedGIF = true;
            btnAddNewTreatment.BackColor = Color.Transparent;
            btnAddNewTreatment.CustomizableEdges = customizableEdges3;
            btnAddNewTreatment.DisabledState.BorderColor = Color.DarkGray;
            btnAddNewTreatment.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNewTreatment.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNewTreatment.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNewTreatment.FillColor = Color.FromArgb(0, 0, 150);
            btnAddNewTreatment.Font = new Font("Segoe UI", 13.8F);
            btnAddNewTreatment.ForeColor = Color.White;
            btnAddNewTreatment.HoverState.FillColor = Color.MediumBlue;
            btnAddNewTreatment.Location = new Point(1343, 3);
            btnAddNewTreatment.Name = "btnAddNewTreatment";
            btnAddNewTreatment.PressedColor = Color.FromArgb(0, 0, 165);
            btnAddNewTreatment.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAddNewTreatment.Size = new Size(216, 57);
            btnAddNewTreatment.TabIndex = 30;
            btnAddNewTreatment.Text = "إنشاء خدمه جديده";
            btnAddNewTreatment.Click += btnAddNewTreatment_Click;
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
            btnRefresh.TabIndex = 31;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(1456, 543);
            label7.Name = "label7";
            label7.Size = new Size(103, 31);
            label7.TabIndex = 32;
            label7.Text = "ملحوظه :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(953, 544);
            label9.Name = "label9";
            label9.Size = new Size(502, 28);
            label9.TabIndex = 33;
            label9.Text = "اضغط علي الصف ضغطتين متتاليتين لتعديل بيانات الخدمه.";
            // 
            // guna2ShadowPanel4
            // 
            guna2ShadowPanel4.BackColor = Color.Transparent;
            guna2ShadowPanel4.Controls.Add(lblTreatmentsCount);
            guna2ShadowPanel4.Controls.Add(label8);
            guna2ShadowPanel4.FillColor = Color.White;
            guna2ShadowPanel4.Location = new Point(610, 205);
            guna2ShadowPanel4.Name = "guna2ShadowPanel4";
            guna2ShadowPanel4.Radius = 10;
            guna2ShadowPanel4.ShadowColor = Color.Black;
            guna2ShadowPanel4.ShadowDepth = 150;
            guna2ShadowPanel4.Size = new Size(342, 133);
            guna2ShadowPanel4.TabIndex = 37;
            // 
            // lblTreatmentsCount
            // 
            lblTreatmentsCount.ForeColor = Color.Black;
            lblTreatmentsCount.Location = new Point(3, 61);
            lblTreatmentsCount.Name = "lblTreatmentsCount";
            lblTreatmentsCount.Size = new Size(336, 28);
            lblTreatmentsCount.TabIndex = 7;
            lblTreatmentsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(255, 128, 0);
            label8.Location = new Point(152, 9);
            label8.Name = "label8";
            label8.Size = new Size(183, 28);
            label8.TabIndex = 3;
            label8.Text = "عدد الخدمات المتاحه";
            // 
            // loadDataTimer
            // 
            loadDataTimer.Interval = 10;
            loadDataTimer.Tick += loadDataTimer_Tick;
            // 
            // TreatmentsView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkCyan;
            Controls.Add(guna2ShadowPanel4);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(btnRefresh);
            Controls.Add(btnAddNewTreatment);
            Controls.Add(txtSearchValue);
            Controls.Add(dataGridView);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximumSize = new Size(1562, 956);
            MinimumSize = new Size(1562, 956);
            Name = "TreatmentsView";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1562, 956);
            Load += TreatmentsView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            guna2ShadowPanel4.ResumeLayout(false);
            guna2ShadowPanel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchValue;
        private Guna.UI2.WinForms.Guna2Button btnAddNewTreatment;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private Label label7;
        private Label label9;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel4;
        private Label label8;
        private Label lblTreatmentsCount;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripMenuItem tsmiAdd;
        private ToolStripMenuItem tsmiRefresh;
        private ToolStripMenuItem tsmiCopyName;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer loadDataTimer;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colDescription;
    }
}
