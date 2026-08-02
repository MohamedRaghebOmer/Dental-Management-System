using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.VisitRadioghraph;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using System.ComponentModel;
using System.Diagnostics;

namespace Dental.WinForms.Forms.AddEdit;

public partial class frmAddEditVisitRadioghraph : Form
{
    private readonly IVisitRadioghraphService _visitRadioghraphService;
    private readonly int? _visitRadiographId = null;

    private enum Mode { Add, Edit }
    private readonly Mode _mode = Mode.Add;

    public frmAddEditVisitRadioghraph(
        IVisitRadioghraphService visitRadioghraphService)
    {
        _visitRadioghraphService = visitRadioghraphService;
        InitializeComponent();

        _visitRadiographId = null;
        _mode = Mode.Add;
    }

    public frmAddEditVisitRadioghraph(
        int visitRadiographId,
        IVisitRadioghraphService visitRadioghraphService)
        : this(visitRadioghraphService)
    {
        _visitRadiographId = visitRadiographId;
        _mode = Mode.Edit;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int VisitId
    {
        set => txtVisitId.Text = value.ToString();
    }

    private async void frmAddEditVisitRadioghraph_Load(object sender, EventArgs e)
    {
        Initialize();

        if (_mode == Mode.Edit)
            await LoadVisitRadioghraphUiAsync();
    }

    private void Initialize()
    {
        Text = _mode == Mode.Add ? "إضافة أشعه جديده" : "تعديل بيانات الأشعه";
        lblTitile.Text = _mode == Mode.Add ? "إضافة أشعه جديده" : "تعديل بيانات الأشعه";
        lblVisitRadiographId.Visible = _mode == Mode.Edit;
        lblVisitRadiographIdValue.Visible = _mode == Mode.Edit;
        txtVisitId.Enabled = _mode == Mode.Add;
        btnOpenCurrentImage.Enabled = _mode == Mode.Edit;
        lblCreatedAt.Text = DateTimeHelper.GetArabicDateTime(DateTime.Now);
    }

    private async Task LoadVisitRadioghraphUiAsync()
    {
        if (_mode != Mode.Edit || !_visitRadiographId.HasValue)
            return;

        var visitRadiograph =
            await _visitRadioghraphService.GetByIdAsync(_visitRadiographId.Value);
        if (visitRadiograph.IsFailure)
        {
            if (visitRadiograph.Error.Code == "NotFound")
                MessageBoxExtensions.ShowError("الأشعه غير موجودة");
            else if (visitRadiograph.Error.Code == "InvalidId")
                MessageBoxExtensions.ShowError("رقم الأشعه غير صحيح");
            else
                MessageBoxExtensions.ShowError("حدث خطأ أثناء تحميل الأشعه");

            Close();
            return;
        }

        // Load the 'VisitRadiograph' info into UI
        lblVisitRadiographIdValue.Text = visitRadiograph.Value.Id.ToString();
        txtVisitId.Text = visitRadiograph.Value.VisitId.ToString();
        lblCreatedAt.Text = DateTimeHelper.GetArabicDateTime(visitRadiograph.Value.CreatedAt);
        LoadImageIntoPictureBox(visitRadiograph.Value.ImagePath);
    }

    private void LoadImageIntoPictureBox(string? imagePath)
    {
        pctImage.Image?.Dispose();
        pctImage.Image = null;
        pctImage.ImageLocation = null;
        btnOpenCurrentImage.Enabled = false;

        if (string.IsNullOrWhiteSpace(imagePath))
            return;

        if (!File.Exists(imagePath))
            return;

        using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        pctImage.Image = Image.FromStream(stream).Clone() as Image;
        pctImage.ImageLocation = imagePath;
        btnOpenCurrentImage.Enabled = true;
    }

    private void btnOpenCurrentImage_Click(object sender, EventArgs e)
    {
        OpenImage(pctImage.ImageLocation);
    }

    private void btnUploadImage_Click(object sender, EventArgs e)
    {
        LoadImageIntoPictureBox(SelectImage());
    }

    public static void OpenImage(string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            return;

        if (!File.Exists(imagePath))
            return;

        Process.Start(new ProcessStartInfo
        {
            FileName = imagePath,
            UseShellExecute = true
        });
    }

    private static string? SelectImage()
    {
        using var openFileDialog = new OpenFileDialog();

        openFileDialog.Title = "اختار صوره";
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.webp";
        openFileDialog.CheckFileExists = true;
        openFileDialog.CheckPathExists = true;
        openFileDialog.Multiselect = false;

        return openFileDialog.ShowDialog() == DialogResult.OK
            ? openFileDialog.FileName
            : null;
    }

    private void txtVisitId_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Allow only integer input
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        string message = _mode == Mode.Add
            ? "هل أنت متأكد من إضافة الأشعه؟"
            : "هل أنت متأكد من تعديل بيانات الأشعه؟";

        var sure = MessageBoxExtensions.ShowQuestion(message);
        if (sure != DialogResult.Yes)
            return;


        var dto = GetVisitRadiographDtoFromUi();
        if (dto is null)
            return;

        if (_mode == Mode.Add)
        {
            var addResult = await _visitRadioghraphService.AddAsync(dto);
            if (addResult.IsFailure)
            {
                HandleAddUpdatePadiohraphError(addResult.Error);
                return;
            }
        }
        else
        {
            if (!_visitRadiographId.HasValue)
                return;

            var udpateResult =
                await _visitRadioghraphService.UpdateAsync(_visitRadiographId.Value, dto);
            if (udpateResult.IsFailure)
            {
                HandleAddUpdatePadiohraphError(udpateResult.Error);
                return;
            }
        }

        MessageBoxExtensions.ShowInfo("تم حفظ بيانات الأشعه بنجاح");
        Close();
    }

    private static void HandleAddUpdatePadiohraphError(Error addResultError)
    {
        switch (addResultError.Code)
        {
            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowWarning("رقم الأشعه غير صحيح");
                break;

            case "NotFound":
            case "VisitRadiograph.NotFound":
                MessageBoxExtensions.ShowWarning("الأشعه غير موجودة");
                break;

            case "ImagePath.Empty":
                MessageBoxExtensions.ShowWarning("الرجاء اختيار صورة الأشعه");
                break;

            case "ImagePath.TooLong":
                MessageBoxExtensions.ShowWarning("مسار صورة الأشعه طويل جدا");
                break;

            default:
                MessageBoxExtensions.ShowError("حدث خطأ أثناء حفظ بيانات الأشعه");
                break;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtVisitId.Text))
        {
            MessageBoxExtensions.ShowWarning("يرجى إدخال رقم الزيارة");
            return false;
        }

        if (!int.TryParse(txtVisitId.Text, out var visitId) || visitId <= 0)
        {
            MessageBoxExtensions.ShowWarning("رقم الزيارة غير صحيح");
            return false;
        }

        if (pctImage.Image == null ||
            string.IsNullOrWhiteSpace(pctImage.ImageLocation) ||
            !File.Exists(pctImage.ImageLocation))
        {
            MessageBoxExtensions.ShowWarning("يرجي اختيار صورة الأشعه");
            return false;
        }

        return true;
    }

    private VisitRadioghraphRequestDto? GetVisitRadiographDtoFromUi()
    {
        var visitId = GetVisitIdFromTextbox();
        if (!visitId.HasValue)
            return null;

        var sourcePath = pctImage.ImageLocation;
        if (string.IsNullOrWhiteSpace(sourcePath))
            return null;

        var fullPath = CopyImage(
            sourcePath, Infrastructure.Constants.DataStoragePaths.ImagesFolderPath);
        if (string.IsNullOrWhiteSpace(fullPath))
            return null;

        return new VisitRadioghraphRequestDto
        {
            VisitId = visitId.Value,
            ImagePath = fullPath
        };
    }

    /// <summary>
    /// Returns the destination path of the copied image, or null if the source image does not exist.
    /// </summary>
    private static string? CopyImage(string sourcePath, string destinationDirectory)
    {
        if (!File.Exists(sourcePath))
            return null;

        Directory.CreateDirectory(destinationDirectory);

        string destinationPath = Path.Combine(
            destinationDirectory,
            $"{Guid.NewGuid()}{Path.GetExtension(sourcePath)}");

        File.Copy(sourcePath, destinationPath);

        return destinationPath;
    }

    private int? GetVisitIdFromTextbox()
    {
        return int.TryParse(txtVisitId.Text, out var visitId) ? visitId : null;
    }
}