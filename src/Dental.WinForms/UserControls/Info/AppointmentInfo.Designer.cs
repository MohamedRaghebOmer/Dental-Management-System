namespace Dental.WinForms.UserControls.Info
{
    partial class ctrlAppointmentInfo
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
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblAppointmentId = new Label();
            lblActualVisitDateTime = new Label();
            lblCreatedAt = new Label();
            lblAppointmentStatus = new Label();
            lblScheduledVisitDateTime = new Label();
            lblPatientName = new Label();
            lblPatientId = new Label();
            lblNotes = new Label();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(0, 0, 192);
            label8.Location = new Point(377, 177);
            label8.Name = "label8";
            label8.Size = new Size(149, 28);
            label8.TabIndex = 14;
            label8.Text = "ملاحظات الحجز :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(0, 0, 192);
            label7.Location = new Point(832, 177);
            label7.Name = "label7";
            label7.Size = new Size(107, 28);
            label7.TabIndex = 12;
            label7.Text = "حالة الحجز :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 0, 192);
            label6.Location = new Point(343, 120);
            label6.Name = "label6";
            label6.Size = new Size(184, 28);
            label6.TabIndex = 10;
            label6.Text = "تاريخ الزياره الفعلي :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 0, 192);
            label5.Location = new Point(295, 63);
            label5.Name = "label5";
            label5.Size = new Size(234, 28);
            label5.TabIndex = 6;
            label5.Text = "تاريخ الزياره الذي تم حجزه :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 0, 192);
            label4.Location = new Point(364, 6);
            label4.Name = "label4";
            label4.Size = new Size(162, 28);
            label4.TabIndex = 2;
            label4.Text = "تاريخ انشاء الحجز :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(808, 120);
            label3.Name = "label3";
            label3.Size = new Size(131, 28);
            label3.TabIndex = 8;
            label3.Text = "اسم المريض :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(814, 63);
            label2.Name = "label2";
            label2.Size = new Size(125, 28);
            label2.TabIndex = 4;
            label2.Text = "رقم المريض :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 0, 192);
            label1.Location = new Point(838, 6);
            label1.Name = "label1";
            label1.Size = new Size(101, 28);
            label1.TabIndex = 0;
            label1.Text = "رقم الحجز :";
            // 
            // lblAppointmentId
            // 
            lblAppointmentId.Font = new Font("Segoe UI", 12F);
            lblAppointmentId.ForeColor = Color.Black;
            lblAppointmentId.Location = new Point(535, 7);
            lblAppointmentId.Name = "lblAppointmentId";
            lblAppointmentId.Size = new Size(267, 28);
            lblAppointmentId.TabIndex = 22;
            lblAppointmentId.Text = "0";
            lblAppointmentId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActualVisitDateTime
            // 
            lblActualVisitDateTime.Font = new Font("Segoe UI", 12F);
            lblActualVisitDateTime.ForeColor = Color.Black;
            lblActualVisitDateTime.Location = new Point(22, 120);
            lblActualVisitDateTime.Name = "lblActualVisitDateTime";
            lblActualVisitDateTime.Size = new Size(267, 28);
            lblActualVisitDateTime.TabIndex = 23;
            lblActualVisitDateTime.Text = "0";
            lblActualVisitDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Font = new Font("Segoe UI", 12F);
            lblCreatedAt.ForeColor = Color.Black;
            lblCreatedAt.Location = new Point(22, 6);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(267, 28);
            lblCreatedAt.TabIndex = 24;
            lblCreatedAt.Text = "0";
            lblCreatedAt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAppointmentStatus
            // 
            lblAppointmentStatus.Font = new Font("Segoe UI", 12F);
            lblAppointmentStatus.ForeColor = Color.Black;
            lblAppointmentStatus.Location = new Point(535, 177);
            lblAppointmentStatus.Name = "lblAppointmentStatus";
            lblAppointmentStatus.Size = new Size(267, 28);
            lblAppointmentStatus.TabIndex = 25;
            lblAppointmentStatus.Text = "0";
            lblAppointmentStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblScheduledVisitDateTime
            // 
            lblScheduledVisitDateTime.Font = new Font("Segoe UI", 12F);
            lblScheduledVisitDateTime.ForeColor = Color.Black;
            lblScheduledVisitDateTime.Location = new Point(22, 63);
            lblScheduledVisitDateTime.Name = "lblScheduledVisitDateTime";
            lblScheduledVisitDateTime.Size = new Size(267, 28);
            lblScheduledVisitDateTime.TabIndex = 27;
            lblScheduledVisitDateTime.Text = "0";
            lblScheduledVisitDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientName
            // 
            lblPatientName.Font = new Font("Segoe UI", 12F);
            lblPatientName.ForeColor = Color.Black;
            lblPatientName.Location = new Point(535, 120);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(267, 28);
            lblPatientName.TabIndex = 29;
            lblPatientName.Text = "0";
            lblPatientName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientId
            // 
            lblPatientId.Font = new Font("Segoe UI", 12F);
            lblPatientId.ForeColor = Color.Black;
            lblPatientId.Location = new Point(535, 63);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(267, 28);
            lblPatientId.TabIndex = 30;
            lblPatientId.Text = "0";
            lblPatientId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNotes
            // 
            lblNotes.Font = new Font("Segoe UI", 12F);
            lblNotes.ForeColor = Color.Black;
            lblNotes.Location = new Point(3, 177);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(286, 110);
            lblNotes.TabIndex = 31;
            // 
            // ctrlAppointmentInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblNotes);
            Controls.Add(lblPatientId);
            Controls.Add(lblPatientName);
            Controls.Add(lblScheduledVisitDateTime);
            Controls.Add(lblAppointmentStatus);
            Controls.Add(lblCreatedAt);
            Controls.Add(lblActualVisitDateTime);
            Controls.Add(lblAppointmentId);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(942, 287);
            MinimumSize = new Size(942, 287);
            Name = "ctrlAppointmentInfo";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(942, 287);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblAppointmentId;
        private Label lblActualVisitDateTime;
        private Label lblCreatedAt;
        private Label lblAppointmentStatus;
        private Label lblScheduledVisitDateTime;
        private Label lblPatientName;
        private Label lblPatientId;
        private Label lblNotes;
    }
}
