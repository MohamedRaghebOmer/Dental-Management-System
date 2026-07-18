namespace Dental.WinForms.UserControls
{
    partial class ctrlDateTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDateTime));
            timer = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            lblDate = new Label();
            pictureBox2 = new PictureBox();
            lblTime = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += OnTimerOnTick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.calendar_512;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(498, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(79, 83);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(278, 35);
            lblDate.Name = "lblDate";
            lblDate.RightToLeft = RightToLeft.Yes;
            lblDate.Size = new Size(194, 31);
            lblDate.TabIndex = 1;
            lblDate.Text = "الثلاثاء 30/12/2026";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(123, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(84, 83);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(24, 35);
            lblTime.Name = "lblTime";
            lblTime.RightToLeft = RightToLeft.Yes;
            lblTime.Size = new Size(104, 31);
            lblTime.TabIndex = 3;
            lblTime.Text = "12:59 ص";
            // 
            // ctrlDateTime
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblTime);
            Controls.Add(pictureBox2);
            Controls.Add(lblDate);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(0, 100);
            MinimumSize = new Size(0, 100);
            Name = "ctrlDateTime";
            Size = new Size(590, 100);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private PictureBox pictureBox1;
        private Label lblDate;
        private PictureBox pictureBox2;
        private Label lblTime;
    }
}
