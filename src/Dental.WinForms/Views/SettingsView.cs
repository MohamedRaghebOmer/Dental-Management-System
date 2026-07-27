using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.DentalInfo;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.Views;

public partial class SettingsView : UserControl
{
    private readonly IDentalInfoService _dentalInfoService;
    private readonly ILogger<SettingsView> _logger;

    private readonly Image _defaultDoctorImage = Properties.Resources.user_512;
    private readonly Image _defaultDentalImage = Properties.Resources.tooth_512;

    public event EventHandler<SettingsSavedEventArgs>? SettingsSaved;
    public class SettingsSavedEventArgs : EventArgs
    {
        public DentalInfoDto DentalInfo { get; }
        public SettingsSavedEventArgs(DentalInfoDto dentalInfo)
        {
            DentalInfo = dentalInfo;
        }
    }


    private DentalInfoDto? _currentInfo = null;

    public SettingsView(
        IDentalInfoService dentalInfoService,
        ILogger<SettingsView> logger)
    {
        InitializeComponent();

        _dentalInfoService = dentalInfoService;
        _logger = logger;
    }

    private void SettingsView_Paint(object sender, PaintEventArgs e)
    {
        using Pen pen = new(Color.Black, 2);

        int x = Width / 2;
        e.Graphics.DrawLine(pen, x, 0, x, Height);
    }

    private async void SettingsView_Load(object sender, EventArgs e)
    {
        try
        {
            Cursor = Cursors.WaitCursor;

            _currentInfo = await _dentalInfoService.GetAsync();

            txtDoctorName.Text = _currentInfo.DoctorName ?? string.Empty;
            txtPhoneNumber.Text = _currentInfo.PhoneNumber ?? string.Empty;
            txtDentalName.Text = _currentInfo.DentalName ?? string.Empty;
            txtDentalDescription.Text = _currentInfo.DentalDescription ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(_currentInfo.DoctorPicturePath)
                && File.Exists(_currentInfo.DoctorPicturePath))
            {
                SetPictureBoxImage(pbDoctorImage, LoadImageFromFile(_currentInfo.DoctorPicturePath));
                pbDoctorImage.Tag = _currentInfo.DoctorPicturePath;
            }
            else
            {
                SetPictureBoxImage(pbDoctorImage, _defaultDoctorImage);
                pbDoctorImage.Tag = null;
            }

            if (!string.IsNullOrWhiteSpace(_currentInfo.DentalPicturePath)
                && File.Exists(_currentInfo.DentalPicturePath))
            {
                SetPictureBoxImage(pbDentalImage, LoadImageFromFile(_currentInfo.DentalPicturePath));
                pbDentalImage.Tag = _currentInfo.DentalPicturePath;
            }
            else
            {
                SetPictureBoxImage(pbDentalImage, _defaultDentalImage);
                pbDentalImage.Tag = null;
            }
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError("حدث خطأ أثناء تحميل بيانات العيادة. يرجى المحاولة مرة أخرى.");
            _logger.LogError(ex, "Error loading dental info.");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void btnResetDoctorImage_Click(object sender, EventArgs e)
    {
        SetPictureBoxImage(pbDoctorImage, _defaultDoctorImage);
        pbDoctorImage.Tag = null;
    }

    private void btnResetDentalImage_Click(object sender, EventArgs e)
    {
        SetPictureBoxImage(pbDentalImage, _defaultDentalImage);
        pbDentalImage.Tag = null;
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        var (doctorPath, dentalPath) = CopyImagesAndGetPaths();

        var dto = new DentalInfoDto(
            DoctorName: txtDoctorName.Text.Trim(),
            PhoneNumber: txtPhoneNumber.Text.Trim(),
            DentalName: txtDentalName.Text.Trim(),
            DentalDescription: txtDentalDescription.Text.Trim(),
            DoctorPicturePath: doctorPath,// ?? _currentInfo?.DoctorPicturePath,
            DentalPicturePath: dentalPath// ?? _currentInfo?.DentalPicturePath
        );

        try
        {
            Cursor = Cursors.WaitCursor;

            var setResult = await _dentalInfoService.SetAsync(dto);
            if (setResult.IsFailure)
            {
                HandelSetResultError(setResult.Error);
                return;
            }

            _currentInfo = dto;

            OnSettingsSaved(dto);
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError("حدث خطأ أثناء حفظ بيانات العيادة. يرجى المحاولة مرة أخرى.");
            _logger.LogError(ex, "Error saving dental info.");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private (string?, string?) CopyImagesAndGetPaths()
    {
        var newDoctorImagePath = SaveSelectedImage(pbDoctorImage);
        var newDentalImagePath = SaveSelectedImage(pbDentalImage);

        return (newDoctorImagePath, newDentalImagePath);
    }

    private void HandelSetResultError(Error setResultError)
    {
        switch (setResultError.Code)
        {
            case "DentalInfo.DoctorNameTooLong":
                MessageBoxExtensions.ShowError(
                    "اسم الطبيب طويل جدًا. يرجى إدخال اسم أقصر.");
                break;
            case "DentalInfo.PhoneNumberTooLong":
                MessageBoxExtensions.ShowError(
                    "رقم الهاتف طويل جدًا. يرجى إدخال رقم أقصر.");
                break;
            case "DentalInfo.DentalNameTooLong":
                MessageBoxExtensions.ShowError(
                    "اسم العيادة طويل جدًا. يرجى إدخال اسم أقصر.");
                break;
            case "DentalInfo.DentalDescriptionTooLong":
                MessageBoxExtensions.ShowError(
                    "وصف العيادة طويل جدًا. يرجى إدخال وصف أقصر.");
                break;

            default:
                MessageBoxExtensions.ShowError(
                    "حدث خطأ أثناء حفظ بيانات العيادة. يرجى المحاولة مرة أخرى.");
                _logger.LogError("Error saving dental info: {ErrorCode} - {ErrorMessage}",
                    setResultError.Code, setResultError.Message);
                break;
        }
    }

    private void btnChangeDoctorImage_Click(object sender, EventArgs e)
    {
        LoadImage(pbDoctorImage);
    }

    private void LoadImage(PictureBox pictureBox)
    {
        using var openFileDialog = new OpenFileDialog
        {
            Title = "إختار صورة",
            Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp",
            Multiselect = false
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
            return;

        var selectedPath = openFileDialog.FileName;

        SetPictureBoxImage(pictureBox, LoadImageFromFile(selectedPath));
        pictureBox.Tag = selectedPath;
    }

    private void btnChangeDentalImage_Click(object sender, EventArgs e)
    {
        LoadImage(pbDentalImage);
    }

    protected virtual void OnSettingsSaved(DentalInfoDto dentalInfo)
    {
        SettingsSaved?.Invoke(this, new SettingsSavedEventArgs(dentalInfo));
    }

    private static Image LoadImageFromFile(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var tempImage = Image.FromStream(stream);
        return new Bitmap(tempImage);
    }

    private void SetPictureBoxImage(PictureBox pictureBox, Image newImage)
    {
        var oldImage = pictureBox.Image;
        pictureBox.Image = newImage;

        if (oldImage is not null
            && !ReferenceEquals(oldImage, _defaultDoctorImage)
            && !ReferenceEquals(oldImage, _defaultDentalImage))
        {
            oldImage.Dispose();
        }
    }

    private static string? SaveSelectedImage(PictureBox pictureBox)
    {
        if (pictureBox.Tag is not string sourcePath
            || string.IsNullOrWhiteSpace(sourcePath)
            || !File.Exists(sourcePath))
        {
            return null;
        }

        var imagesFolder = Infrastructure.Constants.DataStoragePaths.ImagesFolderPath;
        var sourceFullPath = Path.GetFullPath(sourcePath);
        var imagesFolderFullPath = Path.GetFullPath(imagesFolder);

        if (sourceFullPath.StartsWith(imagesFolderFullPath, StringComparison.OrdinalIgnoreCase))
        {
            return sourcePath;
        }

        var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(sourcePath)}";
        var destinationPath = Path.Combine(imagesFolder, newFileName);

        File.Copy(sourcePath, destinationPath, overwrite: true);

        return destinationPath;
    }
}