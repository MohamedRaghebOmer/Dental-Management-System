namespace Dental.WinForms.Forms.AddEdit
{
    partial class frmAddEditMaterial
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            lblTitile = new Label();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            lblPatientId = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            txtReOrderLevel = new Guna.UI2.WinForms.Guna2TextBox();
            label12 = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = SystemColors.Control;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges11;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(333, 463);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSave.Size = new Size(159, 56);
            btnSave.TabIndex = 4;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // lblTitile
            // 
            lblTitile.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(234, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(356, 60);
            lblTitile.TabIndex = 1;
            lblTitile.Text = "إضافة خامه جديده";
            lblTitile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            txtName.Animated = true;
            txtName.BorderRadius = 10;
            txtName.CustomizableEdges = customizableEdges13;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 10.2F);
            txtName.ForeColor = Color.Black;
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(322, 150);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "";
            txtName.RightToLeft = RightToLeft.Yes;
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtName.Size = new Size(249, 36);
            txtName.TabIndex = 0;
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.FromArgb(0, 0, 192);
            lblPatientId.Location = new Point(752, 154);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(69, 28);
            lblPatientId.TabIndex = 2;
            lblPatientId.Text = "الإسم :";
            // 
            // btnClose
            // 
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.Red;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 38;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(757, 19);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(53, 41);
            btnClose.TabIndex = 5;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtPrice
            // 
            txtPrice.Animated = true;
            txtPrice.BorderRadius = 10;
            txtPrice.CustomizableEdges = customizableEdges15;
            txtPrice.DefaultText = "";
            txtPrice.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPrice.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPrice.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Font = new Font("Segoe UI", 10.2F);
            txtPrice.ForeColor = Color.Black;
            txtPrice.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Location = new Point(322, 345);
            txtPrice.Margin = new Padding(3, 5, 3, 5);
            txtPrice.MaxLength = 10;
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "";
            txtPrice.RightToLeft = RightToLeft.Yes;
            txtPrice.SelectedText = "";
            txtPrice.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtPrice.Size = new Size(249, 36);
            txtPrice.TabIndex = 3;
            txtPrice.KeyPress += txtMoney_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(709, 349);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 8;
            label3.Text = "سعر الشراء :";
            // 
            // txtQuantity
            // 
            txtQuantity.Animated = true;
            txtQuantity.BorderRadius = 10;
            txtQuantity.CustomizableEdges = customizableEdges17;
            txtQuantity.DefaultText = "";
            txtQuantity.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtQuantity.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtQuantity.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtQuantity.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtQuantity.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtQuantity.Font = new Font("Segoe UI", 10.2F);
            txtQuantity.ForeColor = Color.Black;
            txtQuantity.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtQuantity.Location = new Point(322, 215);
            txtQuantity.Margin = new Padding(3, 5, 3, 5);
            txtQuantity.MaxLength = 10;
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PlaceholderText = "";
            txtQuantity.RightToLeft = RightToLeft.Yes;
            txtQuantity.SelectedText = "";
            txtQuantity.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtQuantity.Size = new Size(249, 36);
            txtQuantity.TabIndex = 1;
            txtQuantity.KeyPress += txtMoney_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 0, 192);
            label1.Location = new Point(683, 219);
            label1.Name = "label1";
            label1.Size = new Size(138, 28);
            label1.TabIndex = 4;
            label1.Text = "الكميه المتاحه :";
            // 
            // txtReOrderLevel
            // 
            txtReOrderLevel.Animated = true;
            txtReOrderLevel.BorderRadius = 10;
            txtReOrderLevel.CustomizableEdges = customizableEdges19;
            txtReOrderLevel.DefaultText = "";
            txtReOrderLevel.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtReOrderLevel.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtReOrderLevel.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtReOrderLevel.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtReOrderLevel.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtReOrderLevel.Font = new Font("Segoe UI", 10.2F);
            txtReOrderLevel.ForeColor = Color.Black;
            txtReOrderLevel.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtReOrderLevel.Location = new Point(322, 280);
            txtReOrderLevel.Margin = new Padding(3, 5, 3, 5);
            txtReOrderLevel.MaxLength = 10;
            txtReOrderLevel.Name = "txtReOrderLevel";
            txtReOrderLevel.PlaceholderText = "";
            txtReOrderLevel.RightToLeft = RightToLeft.Yes;
            txtReOrderLevel.SelectedText = "";
            txtReOrderLevel.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txtReOrderLevel.Size = new Size(249, 36);
            txtReOrderLevel.TabIndex = 2;
            txtReOrderLevel.KeyPress += txtMoney_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 192);
            label12.Location = new Point(592, 284);
            label12.Name = "label12";
            label12.Size = new Size(229, 28);
            label12.TabIndex = 6;
            label12.Text = "الحد الأدنى لإعادة الطلب :";
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
            // frmAddEditMaterial
            // 
            AcceptButton = btnSave;
            AutoScaleMode = AutoScaleMode.None;
            CancelButton = btnClose;
            ClientSize = new Size(825, 531);
            Controls.Add(txtPrice);
            Controls.Add(label3);
            Controls.Add(txtQuantity);
            Controls.Add(label1);
            Controls.Add(txtReOrderLevel);
            Controls.Add(label12);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(lblTitile);
            Controls.Add(txtName);
            Controls.Add(lblPatientId);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddEditMaterial";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة خامه";
            Load += frmAddEditMaterial_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Label lblTitile;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Label lblPatientId;
        private FontAwesome.Sharp.IconButton btnClose;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtReOrderLevel;
        private Label label12;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}