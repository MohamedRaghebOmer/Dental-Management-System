namespace Dental.WinForms.Forms.AddEdit
{
    partial class frmAddEditLabTransaction
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges49 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges50 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges51 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges52 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges53 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges54 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges55 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges56 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtTotalAmount = new Guna.UI2.WinForms.Guna2TextBox();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            txtTreatments = new RichTextBox();
            label2 = new Label();
            label12 = new Label();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            lblPatientId = new Label();
            lblTitile = new Label();
            txtPaidAmount = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnClose = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Animated = true;
            txtTotalAmount.BorderRadius = 10;
            txtTotalAmount.CustomizableEdges = customizableEdges49;
            txtTotalAmount.DefaultText = "";
            txtTotalAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTotalAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTotalAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTotalAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTotalAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTotalAmount.Font = new Font("Segoe UI", 10.2F);
            txtTotalAmount.ForeColor = Color.Black;
            txtTotalAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTotalAmount.Location = new Point(318, 195);
            txtTotalAmount.Margin = new Padding(3, 5, 3, 5);
            txtTotalAmount.MaxLength = 10;
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.PlaceholderText = "";
            txtTotalAmount.RightToLeft = RightToLeft.Yes;
            txtTotalAmount.SelectedText = "";
            txtTotalAmount.ShadowDecoration.CustomizableEdges = customizableEdges50;
            txtTotalAmount.Size = new Size(249, 36);
            txtTotalAmount.TabIndex = 4;
            txtTotalAmount.KeyPress += txtMoney_KeyPress;
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = SystemColors.Control;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges51;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(331, 495);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges52;
            btnSave.Size = new Size(164, 56);
            btnSave.TabIndex = 9;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // txtTreatments
            // 
            txtTreatments.Font = new Font("Segoe UI", 10.2F);
            txtTreatments.Location = new Point(170, 331);
            txtTreatments.MaxLength = 1000;
            txtTreatments.Name = "txtTreatments";
            txtTreatments.Size = new Size(397, 103);
            txtTreatments.TabIndex = 8;
            txtTreatments.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(705, 331);
            label2.Name = "label2";
            label2.Size = new Size(111, 28);
            label2.TabIndex = 7;
            label2.Text = "المشتريات :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 192);
            label12.Location = new Point(691, 199);
            label12.Name = "label12";
            label12.Size = new Size(125, 28);
            label12.TabIndex = 3;
            label12.Text = "المبلغ الكلي :";
            // 
            // txtName
            // 
            txtName.Animated = true;
            txtName.BorderRadius = 10;
            txtName.CustomizableEdges = customizableEdges53;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 10.2F);
            txtName.ForeColor = Color.Black;
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(318, 129);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "";
            txtName.RightToLeft = RightToLeft.Yes;
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges54;
            txtName.Size = new Size(249, 36);
            txtName.TabIndex = 2;
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.FromArgb(0, 0, 192);
            lblPatientId.Location = new Point(692, 133);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(124, 28);
            lblPatientId.TabIndex = 1;
            lblPatientId.Text = "اسم المعمل :";
            // 
            // lblTitile
            // 
            lblTitile.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(234, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(352, 60);
            lblTitile.TabIndex = 0;
            lblTitile.Text = "إضافة تعامل جديد";
            lblTitile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Animated = true;
            txtPaidAmount.BorderRadius = 10;
            txtPaidAmount.CustomizableEdges = customizableEdges55;
            txtPaidAmount.DefaultText = "";
            txtPaidAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPaidAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPaidAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPaidAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Font = new Font("Segoe UI", 10.2F);
            txtPaidAmount.ForeColor = Color.Black;
            txtPaidAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaidAmount.Location = new Point(318, 261);
            txtPaidAmount.Margin = new Padding(3, 5, 3, 5);
            txtPaidAmount.MaxLength = 10;
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.PlaceholderText = "";
            txtPaidAmount.RightToLeft = RightToLeft.Yes;
            txtPaidAmount.SelectedText = "";
            txtPaidAmount.ShadowDecoration.CustomizableEdges = customizableEdges56;
            txtPaidAmount.Size = new Size(249, 36);
            txtPaidAmount.TabIndex = 6;
            txtPaidAmount.KeyPress += txtMoney_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 0, 192);
            label1.Location = new Point(671, 265);
            label1.Name = "label1";
            label1.Size = new Size(145, 28);
            label1.TabIndex = 5;
            label1.Text = "المبلغ المدفوع :";
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
            // btnClose
            // 
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.Red;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 38;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(744, 12);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(53, 41);
            btnClose.TabIndex = 10;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmAddEditLabTransaction
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 563);
            Controls.Add(btnClose);
            Controls.Add(txtPaidAmount);
            Controls.Add(label1);
            Controls.Add(lblTitile);
            Controls.Add(txtTotalAmount);
            Controls.Add(btnSave);
            Controls.Add(txtTreatments);
            Controls.Add(label2);
            Controls.Add(label12);
            Controls.Add(txtName);
            Controls.Add(lblPatientId);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddEditLabTransaction";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة معامله";
            Load += frmAddEditLabTransaction_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTotalAmount;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private RichTextBox txtTreatments;
        private Label label2;
        private Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Label lblPatientId;
        private Label lblTitile;
        private Guna.UI2.WinForms.Guna2TextBox txtPaidAmount;
        private Label label1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}