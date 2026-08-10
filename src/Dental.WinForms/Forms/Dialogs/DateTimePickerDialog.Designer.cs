namespace Dental.WinForms.Forms.Dialogs
{
    partial class DateTimePickerDialog
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
            dtpDate = new DateTimePicker();
            dtpTime = new DateTimePicker();
            btnOk = new Guna.UI2.WinForms.Guna2ImageButton();
            btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(8, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(342, 34);
            dtpDate.TabIndex = 0;
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(356, 3);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(143, 34);
            dtpTime.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.AnimatedGIF = true;
            btnOk.BackColor = SystemColors.ButtonHighlight;
            btnOk.CheckedState.ImageSize = new Size(64, 64);
            btnOk.HoverState.ImageSize = new Size(64, 64);
            btnOk.Image = Properties.Resources.check_512;
            btnOk.ImageOffset = new Point(0, 0);
            btnOk.ImageRotate = 0F;
            btnOk.ImageSize = new Size(50, 50);
            btnOk.Location = new Point(182, 236);
            btnOk.Name = "btnOk";
            btnOk.PressedState.ImageSize = new Size(64, 64);
            btnOk.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnOk.Size = new Size(60, 59);
            btnOk.TabIndex = 2;
            btnOk.Click += btnOk_Click;
            // 
            // btnClose
            // 
            btnClose.AnimatedGIF = true;
            btnClose.BackColor = SystemColors.ButtonHighlight;
            btnClose.CheckedState.ImageSize = new Size(64, 64);
            btnClose.HoverState.ImageSize = new Size(64, 64);
            btnClose.Image = Properties.Resources.close_512;
            btnClose.ImageOffset = new Point(0, 0);
            btnClose.ImageRotate = 0F;
            btnClose.ImageSize = new Size(50, 50);
            btnClose.Location = new Point(264, 236);
            btnClose.Name = "btnClose";
            btnClose.PressedState.ImageSize = new Size(64, 64);
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnClose.Size = new Size(60, 59);
            btnClose.TabIndex = 3;
            btnClose.Click += btnClose_Click;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.AnimateWindow = true;
            guna2BorderlessForm1.AnimationInterval = 270;
            guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            guna2BorderlessForm1.BorderRadius = 25;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.HasFormShadow = false;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // DateTimePickerDialog
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(506, 307);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(btnOk);
            Controls.Add(dtpTime);
            Controls.Add(dtpDate);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "DateTimePickerDialog";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "DateTimePickerDialog";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;
        private Guna.UI2.WinForms.Guna2ImageButton btnOk;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}