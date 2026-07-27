namespace Dental.WinForms.UserControls;

public partial class ctrlProfile : UserControl
{
    public event EventHandler? ControlClicked;

    public ctrlProfile()
    {
        InitializeComponent();
    }

    public void SetDoctorImage(Image? image)
    {
        var oldImage = pbDoctorImage.Image;
        pbDoctorImage.Image = image is null ? null : new Bitmap(image);
        oldImage?.Dispose();
    }

    public void SetDoctorName(string? doctorName)
    {
        lblDoctorName.Text = doctorName ?? string.Empty;
    }

    public void SetPhoneNumber(string? phoneNumber)
    {
        lblPhoneNumber.Text = phoneNumber ?? string.Empty;
    }

    public void SetDescription(string? description)
    {
        lblDescription.Text = description ?? string.Empty;
    }

    private void pbDoctorImage_Click(object sender, EventArgs e)
    {
        OnControlClicked();
    }

    protected virtual void OnControlClicked()
    {
        ControlClicked?.Invoke(this, EventArgs.Empty);
    }
}