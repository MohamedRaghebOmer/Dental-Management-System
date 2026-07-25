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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            txtSearchValue = new Guna.UI2.WinForms.Guna2TextBox();
            cbSearchBy = new ComboBox();
            btnAddPatientOrAppointment = new FontAwesome.Sharp.IconButton();
            dataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colAge = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colPhoneNumber = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label1 = new Label();
            cbGender = new ComboBox();
            filterTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // txtSearchValue
            // 
            txtSearchValue.Anchor = AnchorStyles.Top;
            txtSearchValue.BorderRadius = 7;
            txtSearchValue.CustomizableEdges = customizableEdges13;
            txtSearchValue.DefaultText = "";
            txtSearchValue.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchValue.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchValue.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchValue.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchValue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchValue.ForeColor = Color.Black;
            txtSearchValue.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchValue.Location = new Point(376, 3);
            txtSearchValue.Margin = new Padding(4, 6, 4, 6);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.PlaceholderText = "ابحث عن مريض";
            txtSearchValue.SelectedText = "";
            txtSearchValue.ShadowDecoration.CustomizableEdges = customizableEdges14;
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
            cbSearchBy.Location = new Point(99, 3);
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
            btnAddPatientOrAppointment.Location = new Point(269, 48);
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
            dataGridViewCellStyle25.BackColor = Color.White;
            dataGridViewCellStyle25.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle25.ForeColor = Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = Color.White;
            dataGridViewCellStyle25.SelectionForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle26.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle26.ForeColor = Color.White;
            dataGridViewCellStyle26.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle26.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colAge, colGender, colPhoneNumber });
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = Color.White;
            dataGridViewCellStyle27.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle27.ForeColor = Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = Color.White;
            dataGridViewCellStyle27.SelectionForeColor = Color.Black;
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle27;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.Location = new Point(0, 178);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = Color.White;
            dataGridViewCellStyle28.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle28.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = Color.White;
            dataGridViewCellStyle28.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.Size = new Size(748, 221);
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
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(200, 146);
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
            label1.Location = new Point(643, 144);
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
            cbGender.Location = new Point(376, 3);
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
            MinimumSize = new Size(511, 338);
            Name = "ctrlSearchPatient";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(748, 399);
            Load += ctrlSearchPatient_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
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
    }
}
