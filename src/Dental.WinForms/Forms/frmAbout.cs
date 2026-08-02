using Dental.WinForms.Extensions;
using Guna.UI2.WinForms;

namespace Dental.WinForms.Forms
{
    public partial class frmAbout : Form
    {
        private readonly Color _infoCardNormalColor = Color.White;
        private readonly Color _infoCardHoverColor = Color.FromArgb(248, 251, 255);

        public frmAbout()
        {
            InitializeComponent();
        }

        private void guna2ShadowPanel1_MouseLeave(object sender, EventArgs e)
        {
            if (sender is not Guna2ShadowPanel card)
                return;

            card.FillColor = _infoCardNormalColor;
            card.ShadowDepth = 35;
            card.ShadowShift = 2;
            card.Top += 3;
        }

        private void guna2ShadowPanel1_MouseEnter(object sender, EventArgs e)
        {
            if (sender is not Guna2ShadowPanel card)
                return;

            card.FillColor = _infoCardHoverColor;
            card.ShadowDepth = 60;
            card.ShadowShift = 5;
            card.Top -= 3;
        }

        private void guna2CirclePictureBox3_Click_2(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Clipboard.SetText("+201002608684", TextDataFormat.Text);
            MessageBoxExtensions.ShowInfo("تم نسخ رقم الهاتف بنجاح", "نسخ رقم الهاتف");

            Cursor = Cursors.Default;
        }

        private void guna2CirclePictureBox4_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;


            // Copy the email address to the clipboard
            Clipboard.SetText("mohamedraghebomer@gmail.com", TextDataFormat.Text);

            // Open the default email client with a new email to the specified address
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "mailto:mohamedraghebomer@gmail.com",
                UseShellExecute = true
            });

            Cursor = Cursors.Default;
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Copy the LinkedIn profile URL to the clipboard
            Clipboard.SetText("https://www.mohamedragheb.dev", TextDataFormat.Text);

            // Open the default web browser with the specified URL
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.mohamedragheb.dev",
                UseShellExecute = true
            });

            Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2CirclePictureBox2_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Open the Google Maps location in the default web browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://maps.app.goo.gl/Sgew4mznkkrDGmPb8",
                UseShellExecute = true
            });

            Cursor = Cursors.Default;
        }
    }
}
