namespace Dental.WinForms.Forms.AddEdit
{
    partial class frmAddEditVisitRadioghraph
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnClose = new FontAwesome.Sharp.IconButton();
            lblVisitRadiographIdValue = new Label();
            lblVisitRadiographId = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            txtVisitId = new Guna.UI2.WinForms.Guna2TextBox();
            label12 = new Label();
            lblTitile = new Label();
            lblCreatedAt = new Label();
            label2 = new Label();
            pctImage = new PictureBox();
            btnUploadImage = new Guna.UI2.WinForms.Guna2Button();
            btnOpenCurrentImage = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pctImage).BeginInit();
            SuspendLayout();
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
            btnClose.Location = new Point(1119, 12);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(53, 41);
            btnClose.TabIndex = 4;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblVisitRadiographIdValue
            // 
            lblVisitRadiographIdValue.Location = new Point(707, 286);
            lblVisitRadiographIdValue.Name = "lblVisitRadiographIdValue";
            lblVisitRadiographIdValue.Size = new Size(270, 28);
            lblVisitRadiographIdValue.TabIndex = 16;
            lblVisitRadiographIdValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVisitRadiographId
            // 
            lblVisitRadiographId.AutoSize = true;
            lblVisitRadiographId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblVisitRadiographId.ForeColor = Color.FromArgb(0, 0, 192);
            lblVisitRadiographId.Location = new Point(1068, 286);
            lblVisitRadiographId.Name = "lblVisitRadiographId";
            lblVisitRadiographId.Size = new Size(113, 28);
            lblVisitRadiographId.TabIndex = 15;
            lblVisitRadiographId.Text = "رقم الأشعه :";
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.AnimatedGIF = true;
            btnSave.BackColor = Color.Transparent;
            btnSave.BorderRadius = 15;
            btnSave.CustomizableEdges = customizableEdges1;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.Orange;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.HoverState.FillColor = Color.DarkOrange;
            btnSave.Location = new Point(516, 655);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.DarkOrange;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSave.Size = new Size(160, 56);
            btnSave.TabIndex = 3;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // txtVisitId
            // 
            txtVisitId.Animated = true;
            txtVisitId.BorderRadius = 10;
            txtVisitId.CustomizableEdges = customizableEdges7;
            txtVisitId.DefaultText = "";
            txtVisitId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtVisitId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtVisitId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtVisitId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtVisitId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtVisitId.Font = new Font("Segoe UI", 10.2F);
            txtVisitId.ForeColor = Color.Black;
            txtVisitId.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtVisitId.Location = new Point(707, 343);
            txtVisitId.Margin = new Padding(3, 5, 3, 5);
            txtVisitId.MaxLength = 10;
            txtVisitId.Name = "txtVisitId";
            txtVisitId.PlaceholderText = "";
            txtVisitId.SelectedText = "";
            txtVisitId.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtVisitId.Size = new Size(270, 36);
            txtVisitId.TabIndex = 0;
            txtVisitId.KeyPress += txtVisitId_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 192);
            label12.Location = new Point(1074, 347);
            label12.Name = "label12";
            label12.Size = new Size(107, 28);
            label12.TabIndex = 17;
            label12.Text = "رقم الزياره :";
            // 
            // lblTitile
            // 
            lblTitile.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitile.ForeColor = Color.FromArgb(100, 88, 255);
            lblTitile.Location = new Point(335, 9);
            lblTitile.Name = "lblTitile";
            lblTitile.Size = new Size(522, 62);
            lblTitile.TabIndex = 14;
            lblTitile.Text = "اضافة مريض جديد";
            lblTitile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Location = new Point(707, 409);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(270, 28);
            lblCreatedAt.TabIndex = 29;
            lblCreatedAt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(993, 409);
            label2.Name = "label2";
            label2.Size = new Size(188, 28);
            label2.TabIndex = 28;
            label2.Text = "تاريخ تسجيل الأشعه :";
            // 
            // pctImage
            // 
            pctImage.BorderStyle = BorderStyle.FixedSingle;
            pctImage.Location = new Point(12, 111);
            pctImage.Name = "pctImage";
            pctImage.Size = new Size(617, 518);
            pctImage.SizeMode = PictureBoxSizeMode.Zoom;
            pctImage.TabIndex = 30;
            pctImage.TabStop = false;
            pctImage.Click += btnOpenCurrentImage_Click;
            // 
            // btnUploadImage
            // 
            btnUploadImage.Animated = true;
            btnUploadImage.AnimatedGIF = true;
            btnUploadImage.BackColor = Color.Transparent;
            btnUploadImage.BorderRadius = 7;
            btnUploadImage.CustomizableEdges = customizableEdges5;
            btnUploadImage.DisabledState.BorderColor = Color.DarkGray;
            btnUploadImage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUploadImage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUploadImage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUploadImage.FillColor = Color.DarkCyan;
            btnUploadImage.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnUploadImage.ForeColor = Color.Black;
            btnUploadImage.HoverState.FillColor = Color.DarkCyan;
            btnUploadImage.ImageAlign = HorizontalAlignment.Left;
            btnUploadImage.ImageSize = new Size(35, 35);
            btnUploadImage.Location = new Point(945, 520);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.PressedColor = Color.DarkCyan;
            btnUploadImage.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnUploadImage.Size = new Size(187, 55);
            btnUploadImage.TabIndex = 1;
            btnUploadImage.Text = "رفع صوره";
            btnUploadImage.Click += btnUploadImage_Click;
            // 
            // btnOpenCurrentImage
            // 
            btnOpenCurrentImage.Animated = true;
            btnOpenCurrentImage.AnimatedGIF = true;
            btnOpenCurrentImage.BackColor = Color.Transparent;
            btnOpenCurrentImage.BorderRadius = 7;
            btnOpenCurrentImage.CustomizableEdges = customizableEdges3;
            btnOpenCurrentImage.DisabledState.BorderColor = Color.DarkGray;
            btnOpenCurrentImage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOpenCurrentImage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOpenCurrentImage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOpenCurrentImage.Enabled = false;
            btnOpenCurrentImage.FillColor = Color.DarkCyan;
            btnOpenCurrentImage.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnOpenCurrentImage.ForeColor = Color.Black;
            btnOpenCurrentImage.HoverState.FillColor = Color.DarkCyan;
            btnOpenCurrentImage.ImageAlign = HorizontalAlignment.Left;
            btnOpenCurrentImage.ImageSize = new Size(35, 35);
            btnOpenCurrentImage.Location = new Point(691, 520);
            btnOpenCurrentImage.Name = "btnOpenCurrentImage";
            btnOpenCurrentImage.PressedColor = Color.DarkCyan;
            btnOpenCurrentImage.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnOpenCurrentImage.Size = new Size(215, 55);
            btnOpenCurrentImage.TabIndex = 2;
            btnOpenCurrentImage.Text = "فتح الصوره الحاليه";
            btnOpenCurrentImage.Click += btnOpenCurrentImage_Click;
            // 
            // frmAddEditVisitRadioghraph
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(1193, 723);
            Controls.Add(btnOpenCurrentImage);
            Controls.Add(btnUploadImage);
            Controls.Add(pctImage);
            Controls.Add(lblCreatedAt);
            Controls.Add(label2);
            Controls.Add(btnClose);
            Controls.Add(lblVisitRadiographIdValue);
            Controls.Add(lblVisitRadiographId);
            Controls.Add(btnSave);
            Controls.Add(txtVisitId);
            Controls.Add(label12);
            Controls.Add(lblTitile);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmAddEditVisitRadioghraph";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddEditVisitRadioghraph";
            Load += frmAddEditVisitRadioghraph_Load;
            ((System.ComponentModel.ISupportInitialize)pctImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private FontAwesome.Sharp.IconButton btnClose;
        private Label lblVisitRadiographIdValue;
        private Label lblVisitRadiographId;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtVisitId;
        private Label label12;
        private Label lblTitile;
        private Label lblCreatedAt;
        private Label label2;
        private PictureBox pctImage;
        private Guna.UI2.WinForms.Guna2Button btnUploadImage;
        private Guna.UI2.WinForms.Guna2Button btnOpenCurrentImage;
    }
}