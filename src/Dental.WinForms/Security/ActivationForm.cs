using Dental.Licensing.Core;

namespace Dental.WinForms.Security;

public sealed class ActivationForm : Form
{
    private readonly TextBox txtFingerprint;
    private readonly TextBox txtLicense;
    private readonly Button btnActivate;
    private readonly Button btnCopyFingerprint;

    public ActivationForm()
    {
        Text = "Activate License";
        StartPosition = FormStartPosition.CenterScreen;
        Width = 800;
        Height = 500;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Label lbl1 = new Label
        {
            Left = 20,
            Top = 20,
            Width = 200,
            Text = "Device fingerprint:"
        };

        txtFingerprint = new TextBox
        {
            Left = 20,
            Top = 45,
            Width = 720,
            ReadOnly = true
        };

        btnCopyFingerprint = new Button
        {
            Left = 20,
            Top = 80,
            Width = 180,
            Height = 32,
            Text = "Copy fingerprint"
        };
        btnCopyFingerprint.Click += BtnCopyFingerprint_Click;

        Label lbl2 = new Label
        {
            Left = 20,
            Top = 130,
            Width = 200,
            Text = "Paste license key:"
        };

        txtLicense = new TextBox
        {
            Left = 20,
            Top = 155,
            Width = 720,
            Height = 180,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical
        };

        btnActivate = new Button
        {
            Left = 20,
            Top = 355,
            Width = 160,
            Height = 36,
            Text = "Activate"
        };
        btnActivate.Click += BtnActivate_Click;

        Controls.Add(lbl1);
        Controls.Add(txtFingerprint);
        Controls.Add(btnCopyFingerprint);
        Controls.Add(lbl2);
        Controls.Add(txtLicense);
        Controls.Add(btnActivate);

        Load += ActivationForm_Load;
    }

    private void ActivationForm_Load(object? sender, EventArgs e)
    {
        txtFingerprint.Text = FingerprintService.GetFingerprint();
        txtLicense.Text = string.Empty;
    }

    private void BtnCopyFingerprint_Click(object? sender, EventArgs e)
    {
        Clipboard.SetText(txtFingerprint.Text);
        MessageBox.Show("Fingerprint copied.");
    }

    private void BtnActivate_Click(object? sender, EventArgs e)
    {
        string licenseKey = txtLicense.Text.Trim();

        if (LicenseBootstrapper.Activate(licenseKey, out string error))
        {
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        MessageBox.Show(error, "Activation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}