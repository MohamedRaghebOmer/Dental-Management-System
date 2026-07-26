namespace Dental.WinForms.UserControls.Search
{
    partial class ctrlSearchPatient
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
            txtSearchValue = new Guna.UI2.WinForms.Guna2TextBox();
            cbSearchBy = new ComboBox();
            btnAddPatientOrAppointment = new FontAwesome.Sharp.IconButton();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colAge = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colPhoneNumber = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tsmiEditPatient = new ToolStripMenuItem();
            tsmiDeletePatient = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiAddPatient = new ToolStripMenuItem();
            label2 = new Label();
            label1 = new Label();
            cbGender = new ComboBox();
            filterTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearchValue
            // 
            txtSearchValue.Anchor = AnchorStyles.Top;
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
            txtSearchValue.Location = new Point(374, 3);
            txtSearchValue.Margin = new Padding(4, 6, 4, 6);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.PlaceholderText = "ابحث عن مريض";
            txtSearchValue.SelectedText = "";
            txtSearchValue.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearchValue.Size = new Size(270, 36);
            txtSearchValue.TabIndex = 0;
            txtSearchValue.TextChanged += txtSearchValue_TextChanged;
            txtSearchValue.KeyPress += txtSearchValue_KeyPress;
            // 
            // cbSearchBy
            // 
            cbSearchBy.Anchor = AnchorStyles.Top;
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchBy.FormattingEnabled = true;
            cbSearchBy.Items.AddRange(new object[] { "اسم المريض", "رقم المريض", "السن", "النوع", "رقم الهاتف" });
            cbSearchBy.Location = new Point(97, 3);
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.Size = new Size(270, 36);
            cbSearchBy.TabIndex = 1;
            cbSearchBy.SelectedIndexChanged += cbSearchBy_SelectedIndexChanged;
            // 
            // btnAddPatientOrAppointment
            // 
            btnAddPatientOrAppointment.Anchor = AnchorStyles.Top;
            btnAddPatientOrAppointment.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddPatientOrAppointment.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnAddPatientOrAppointment.IconColor = Color.MediumSeaGreen;
            btnAddPatientOrAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddPatientOrAppointment.ImageAlign = ContentAlignment.TopLeft;
            btnAddPatientOrAppointment.Location = new Point(267, 48);
            btnAddPatientOrAppointment.Name = "btnAddPatientOrAppointment";
            btnAddPatientOrAppointment.Size = new Size(210, 50);
            btnAddPatientOrAppointment.TabIndex = 2;
            btnAddPatientOrAppointment.Text = "إنشاء مريض جديد";
            btnAddPatientOrAppointment.TextAlign = ContentAlignment.MiddleRight;
            btnAddPatientOrAppointment.UseVisualStyleBackColor = true;
            btnAddPatientOrAppointment.Click += btnAddNewPatient_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colAge, colGender, colPhoneNumber });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.Location = new Point(0, 189);
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
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.RowTemplate.ContextMenuStrip = contextMenuStrip1;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.Size = new Size(741, 221);
            dataGridView.TabIndex = 5;
            dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Black;
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
            dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.White;
            dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dataGridView.CellMouseDown += dataGridView_CellMouseDown;
            dataGridView.DoubleClick += dataGridView_DoubleClick;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colId.DataPropertyName = "Id";
            colId.HeaderText = "رقم المريض";
            colId.MinimumWidth = 30;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 140;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "Name";
            colName.HeaderText = "اسم المريض";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colAge
            // 
            colAge.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colAge.DataPropertyName = "Age";
            colAge.HeaderText = "السن";
            colAge.MinimumWidth = 6;
            colAge.Name = "colAge";
            colAge.ReadOnly = true;
            colAge.Width = 81;
            // 
            // colGender
            // 
            colGender.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGender.DataPropertyName = "Gender";
            colGender.HeaderText = "النوع";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            colGender.Width = 80;
            // 
            // colPhoneNumber
            // 
            colPhoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colPhoneNumber.DataPropertyName = "PhoneNumber";
            colPhoneNumber.HeaderText = "رقم الهاتف";
            colPhoneNumber.MinimumWidth = 6;
            colPhoneNumber.Name = "colPhoneNumber";
            colPhoneNumber.ReadOnly = true;
            colPhoneNumber.Width = 126;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tsmiEditPatient, tsmiDeletePatient, toolStripSeparator1, tsmiAddPatient });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(215, 88);
            // 
            // tsmiEditPatient
            // 
            tsmiEditPatient.Image = Properties.Resources.pen_512;
            tsmiEditPatient.Name = "tsmiEditPatient";
            tsmiEditPatient.Size = new Size(214, 26);
            tsmiEditPatient.Text = "تعديل بيانات المريض";
            tsmiEditPatient.Click += tsmiEditPatient_Click;
            // 
            // tsmiDeletePatient
            // 
            tsmiDeletePatient.Image = Properties.Resources.bin_512;
            tsmiDeletePatient.Name = "tsmiDeletePatient";
            tsmiDeletePatient.Size = new Size(214, 26);
            tsmiDeletePatient.Text = "حذف المريض";
            tsmiDeletePatient.Click += tsmiDeletePatient_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(211, 6);
            // 
            // tsmiAddPatient
            // 
            tsmiAddPatient.Image = Properties.Resources.plus_512;
            tsmiAddPatient.Name = "tsmiAddPatient";
            tsmiAddPatient.Size = new Size(214, 26);
            tsmiAddPatient.Text = "إضافة مريض جديد";
            tsmiAddPatient.Click += tsmiAddPatient_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(193, 152);
            label2.Name = "label2";
            label2.Size = new Size(451, 28);
            label2.TabIndex = 4;
            label2.Text = "اضغط علي الصف ضغتطين متتاليتين لإختيار المريض";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(636, 150);
            label1.Name = "label1";
            label1.Size = new Size(103, 31);
            label1.TabIndex = 3;
            label1.Text = "ملحوظه: ";
            // 
            // cbGender
            // 
            cbGender.Anchor = AnchorStyles.Top;
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "ذكر", "أنثي" });
            cbGender.Location = new Point(374, 3);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(270, 36);
            cbGender.TabIndex = 0;
            cbGender.SelectedIndexChanged += cbGender_SelectedIndexChanged;
            cbGender.VisibleChanged += cbGender_VisibleChanged;
            // 
            // filterTimer
            // 
            filterTimer.Interval = 500;
            filterTimer.Tick += filterTimer_Tick;
            // 
            // ctrlSearchPatient
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Controls.Add(btnAddPatientOrAppointment);
            Controls.Add(cbSearchBy);
            Controls.Add(cbGender);
            Controls.Add(txtSearchValue);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MinimumSize = new Size(553, 412);
            Name = "ctrlSearchPatient";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(741, 410);
            Load += ctrlSearchPatient_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtSearchValue;
        private ComboBox cbSearchBy;
        private FontAwesome.Sharp.IconButton btnAddPatientOrAppointment;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAge;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colPhoneNumber;
        private ComboBox cbGender;
        private System.Windows.Forms.Timer filterTimer;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiEditPatient;
        private ToolStripMenuItem tsmiAddPatient;
        private ToolStripMenuItem tsmiDeletePatient;
        private ToolStripSeparator toolStripSeparator1;
    }
}
