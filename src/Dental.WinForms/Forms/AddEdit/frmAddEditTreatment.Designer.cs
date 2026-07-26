namespace Dental.WinForms.Forms
{
    partial class frmAddEditTreatment
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtDescription = new RichTextBox();
            label2 = new Label();
            label12 = new Label();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            lblPatientId = new Label();
            lblTitile = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(314, 275);
            txtDescription.MaxLength = 500;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(249, 103);
            txtDescription.TabIndex = 6;
            txtDescription.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(601, 275);
            label2.Name = "label2";
            label2.Size = new Size(211, 28);
            label2.TabIndex = 5;
            label2.Text = "وصف الخدمه (إن وُجد) :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 192);
            label12.Location = new Point(740, 201);
            label12.Name = "label12";
            label12.Size = new Size(72, 28);
            label12.TabIndex = 3;
            label12.Text = "السعر :";
            // 
            // txtName
            // 
            txtName.Animated = true;
            txtName.BorderRadius = 10;
            txtName.CustomizableEdges = customizableEdges1;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 10.2F);
            txtName.ForeColor = Color.Black;
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(314, 123);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "";
            txtName.RightToLeft = RightToLeft.Yes;
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtName.Size = new Size(249, 36);
            txtName.TabIndex = 2;
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.FromArgb(0, 0, 192);
            lblPatientId.Location = new Point(693, 127);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(119, 28);
            lblPatientId.TabIndex = 1;
            lblPatientId.Text = "اسم الخدمه :";
            // 
            // lblTitile
            // 
            lblTitile.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(12, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(797, 60);
            lblTitile.TabIndex = 0;
            lblTitile.Text = "إضافة خدمه جديده";
            lblTitile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = SystemColors.Control;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges3;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(331, 433);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSave.Size = new Size(159, 56);
            btnSave.TabIndex = 7;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // txtPrice
            // 
            txtPrice.Animated = true;
            txtPrice.BorderRadius = 10;
            txtPrice.CustomizableEdges = customizableEdges5;
            txtPrice.DefaultText = "";
            txtPrice.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPrice.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPrice.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Font = new Font("Segoe UI", 10.2F);
            txtPrice.ForeColor = Color.Black;
            txtPrice.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Location = new Point(314, 197);
            txtPrice.Margin = new Padding(3, 5, 3, 5);
            txtPrice.MaxLength = 10;
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "";
            txtPrice.RightToLeft = RightToLeft.Yes;
            txtPrice.SelectedText = "";
            txtPrice.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPrice.Size = new Size(249, 36);
            txtPrice.TabIndex = 4;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // 
            // frmAddEditTreatment
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 501);
            Controls.Add(txtPrice);
            Controls.Add(btnSave);
            Controls.Add(lblTitile);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(label12);
            Controls.Add(txtName);
            Controls.Add(lblPatientId);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddEditTreatment";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة خدمه جديده";
            Load += frmAddEditTreatment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox txtDescription;
        private Label label2;
        private Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Label lblPatientId;
        private Label lblTitile;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
    }
}