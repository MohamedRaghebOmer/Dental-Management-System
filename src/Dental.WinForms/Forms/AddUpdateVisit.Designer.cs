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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            dgvToothNumAndTreatments = new Guna.UI2.WinForms.Guna2DataGridView();
            colToothNumber = new DataGridViewComboBoxColumn();
            colTreatmentId = new DataGridViewTextBoxColumn();
            colTreatment = new DataGridViewComboBoxColumn();
            colTreatmentPrice = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            lblTotalPrice = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtAppointmentId = new Guna.UI2.WinForms.Guna2TextBox();
            txtDiscountAmount = new Guna.UI2.WinForms.Guna2TextBox();
            txtPaidAmount = new Guna.UI2.WinForms.Guna2TextBox();
            txtRemainingAmount = new Guna.UI2.WinForms.Guna2TextBox();
            lblTitile = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvToothNumAndTreatments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1173, 233);
            label1.Name = "label1";
            label1.Size = new Size(170, 28);
            label1.TabIndex = 0;
            label1.Text = "رقم الحجز (إن وُجد) :";
            // 
            // dgvToothNumAndTreatments
            // 
            dgvToothNumAndTreatments.AllowUserToOrderColumns = true;
            dgvToothNumAndTreatments.AllowUserToResizeColumns = false;
            dgvToothNumAndTreatments.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvToothNumAndTreatments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvToothNumAndTreatments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvToothNumAndTreatments.ColumnHeadersHeight = 30;
            dgvToothNumAndTreatments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvToothNumAndTreatments.Columns.AddRange(new DataGridViewColumn[] { colToothNumber, colTreatmentId, colTreatment, colTreatmentPrice });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvToothNumAndTreatments.DefaultCellStyle = dataGridViewCellStyle6;
            dgvToothNumAndTreatments.Dock = DockStyle.Bottom;
            dgvToothNumAndTreatments.GridColor = Color.FromArgb(231, 229, 255);
            dgvToothNumAndTreatments.Location = new Point(0, 562);
            dgvToothNumAndTreatments.Name = "dgvToothNumAndTreatments";
            dgvToothNumAndTreatments.ReadOnly = true;
            dgvToothNumAndTreatments.RowHeadersVisible = false;
            dgvToothNumAndTreatments.RowHeadersWidth = 51;
            dgvToothNumAndTreatments.Size = new Size(1355, 221);
            dgvToothNumAndTreatments.TabIndex = 4;
            dgvToothNumAndTreatments.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvToothNumAndTreatments.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvToothNumAndTreatments.ThemeStyle.HeaderStyle.Height = 30;
            dgvToothNumAndTreatments.ThemeStyle.ReadOnly = true;
            dgvToothNumAndTreatments.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvToothNumAndTreatments.ThemeStyle.RowsStyle.Height = 29;
            // 
            // colToothNumber
            // 
            colToothNumber.DataPropertyName = "ToothNumber";
            colToothNumber.HeaderText = "رقم السن";
            colToothNumber.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" });
            colToothNumber.MinimumWidth = 6;
            colToothNumber.Name = "colToothNumber";
            colToothNumber.ReadOnly = true;
            colToothNumber.Resizable = DataGridViewTriState.True;
            colToothNumber.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colTreatmentId
            // 
            colTreatmentId.DataPropertyName = "TreatmentId";
            colTreatmentId.HeaderText = "TreatmentId";
            colTreatmentId.MinimumWidth = 6;
            colTreatmentId.Name = "colTreatmentId";
            colTreatmentId.ReadOnly = true;
            // 
            // colTreatment
            // 
            colTreatment.DataPropertyName = "Name";
            colTreatment.HeaderText = "الخدمه المقدمه";
            colTreatment.MinimumWidth = 6;
            colTreatment.Name = "colTreatment";
            colTreatment.ReadOnly = true;
            colTreatment.Resizable = DataGridViewTriState.True;
            colTreatment.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colTreatmentPrice
            // 
            colTreatmentPrice.DataPropertyName = "Price";
            colTreatmentPrice.HeaderText = "سعر الخدمه";
            colTreatmentPrice.MinimumWidth = 6;
            colTreatmentPrice.Name = "colTreatmentPrice";
            colTreatmentPrice.ReadOnly = true;
            colTreatmentPrice.ToolTipText = "سعر الخدمه المقدمه للمريض (حشو، تنظيف، الخ...)";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.teeth;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(367, 544);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(135, 151);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 4;
            label3.Text = "الفك العلوي";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(135, 398);
            label4.Name = "label4";
            label4.Size = new Size(119, 28);
            label4.TabIndex = 5;
            label4.Text = "الفك السفلي";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(758, 500);
            label2.Name = "label2";
            label2.Size = new Size(141, 31);
            label2.TabIndex = 6;
            label2.Text = "المبلغ الكلي :";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(713, 503);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(23, 28);
            lblTotalPrice.TabIndex = 7;
            lblTotalPrice.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1201, 288);
            label5.Name = "label5";
            label5.Size = new Size(142, 28);
            label5.TabIndex = 8;
            label5.Text = "المبلغ المدفوع :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1151, 343);
            label6.Name = "label6";
            label6.Size = new Size(192, 28);
            label6.TabIndex = 9;
            label6.Text = "مبلغ الخصم (إن وُجد) :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1052, 398);
            label7.Name = "label7";
            label7.Size = new Size(291, 28);
            label7.TabIndex = 10;
            label7.Text = "القيه المتبقيه (دين علي المريض) :";
            // 
            // txtAppointmentId
            // 
            txtAppointmentId.Animated = true;
            txtAppointmentId.BorderRadius = 10;
            txtAppointmentId.CustomizableEdges = customizableEdges9;
            txtAppointmentId.DefaultText = "";
            txtAppointmentId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAppointmentId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAppointmentId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAppointmentId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAppointmentId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAppointmentId.Font = new Font("Segoe UI", 9F);
            txtAppointmentId.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAppointmentId.Location = new Point(788, 229);
            txtAppointmentId.Margin = new Padding(3, 4, 3, 4);
            txtAppointmentId.Name = "txtAppointmentId";
            txtAppointmentId.PlaceholderText = "";
            txtAppointmentId.SelectedText = "";
            txtAppointmentId.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtAppointmentId.Size = new Size(249, 36);
            txtAppointmentId.TabIndex = 0;
            // 
            // txtDiscountAmount
            // 
            txtDiscountAmount.Animated = true;
            txtDiscountAmount.BorderRadius = 10;
            txtDiscountAmount.CustomizableEdges = customizableEdges11;
            txtDiscountAmount.DefaultText = "";
            txtDiscountAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDiscountAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDiscountAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDiscountAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Font = new Font("Segoe UI", 9F);
            txtDiscountAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDiscountAmount.Location = new Point(788, 339);
            txtDiscountAmount.Margin = new Padding(3, 4, 3, 4);
            txtDiscountAmount.Name = "txtDiscountAmount";
            txtDiscountAmount.PlaceholderText = "";
            txtDiscountAmount.SelectedText = "";
            txtDiscountAmount.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtDiscountAmount.Size = new Size(249, 36);
            txtDiscountAmount.TabIndex = 2;
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Animated = true;
            txtPaidAmount.BorderRadius = 10;
            txtPaidAmount.CustomizableEdges = customizableEdges13;
            txtPaidAmount.DefaultText = "";
            txtPaidAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPaidAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPaidAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Font = new Font("Segoe UI", 9F);
            txtPaidAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Location = new Point(788, 284);
            txtPaidAmount.Margin = new Padding(3, 4, 3, 4);
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.PlaceholderText = "";
            txtPaidAmount.SelectedText = "";
            txtPaidAmount.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtPaidAmount.Size = new Size(249, 36);
            txtPaidAmount.TabIndex = 1;
            // 
            // txtRemainingAmount
            // 
            txtRemainingAmount.Animated = true;
            txtRemainingAmount.BorderRadius = 10;
            txtRemainingAmount.CustomizableEdges = customizableEdges15;
            txtRemainingAmount.DefaultText = "";
            txtRemainingAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtRemainingAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtRemainingAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtRemainingAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRemainingAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRemainingAmount.Font = new Font("Segoe UI", 9F);
            txtRemainingAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRemainingAmount.Location = new Point(788, 394);
            txtRemainingAmount.Margin = new Padding(3, 4, 3, 4);
            txtRemainingAmount.Name = "txtRemainingAmount";
            txtRemainingAmount.PlaceholderText = "";
            txtRemainingAmount.ReadOnly = true;
            txtRemainingAmount.SelectedText = "";
            txtRemainingAmount.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtRemainingAmount.Size = new Size(249, 36);
            txtRemainingAmount.TabIndex = 3;
            // 
            // lblTitile
            // 
            lblTitile.AutoSize = true;
            lblTitile.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(612, 12);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(479, 81);
            lblTitile.TabIndex = 17;
            lblTitile.Text = "اضافة زياره جديده";
            // 
            // frmAddUpdateVisit
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1355, 783);
            Controls.Add(lblTitile);
            Controls.Add(txtRemainingAmount);
            Controls.Add(txtPaidAmount);
            Controls.Add(txtDiscountAmount);
            Controls.Add(txtAppointmentId);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblTotalPrice);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(dgvToothNumAndTreatments);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddUpdateVisit";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "اضافة زياره";
            Load += AddUpdateVisit_Load;
            ((System.ComponentModel.ISupportInitialize)dgvToothNumAndTreatments).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvToothNumAndTreatments;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label lblTotalPrice;
        private Label label5;
        private Label label6;
        private Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtAppointmentId;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscountAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtPaidAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtRemainingAmount;
        private Label lblTitile;
        private DataGridViewComboBoxColumn colToothNumber;
        private DataGridViewTextBoxColumn colTreatmentId;
        private DataGridViewComboBoxColumn colTreatment;
        private DataGridViewTextBoxColumn colTreatmentPrice;
    }
}