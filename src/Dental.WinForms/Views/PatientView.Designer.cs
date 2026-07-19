namespace Dental.WinForms.Views
{
    partial class PatientView
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(584, 399);
            label1.Name = "label1";
            label1.Size = new Size(224, 50);
            label1.TabIndex = 0;
            label1.Text = "Patient View";
            // 
            // PatientView
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1562, 956);
            MinimumSize = new Size(1562, 956);
            Name = "PatientView";
            Size = new Size(1562, 956);
            Load += PatientView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}
