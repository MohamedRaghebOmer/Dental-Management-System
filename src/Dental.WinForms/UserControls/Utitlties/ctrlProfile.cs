namespace Dental.WinForms.UserControls;

public partial class ctrlProfile : UserControl
{
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
}