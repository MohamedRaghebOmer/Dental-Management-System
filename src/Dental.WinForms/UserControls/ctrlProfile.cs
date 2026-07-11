using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.DentalInfo;
using Dental.Application.Errors;
using Dental.Domain.Errors;
using Dental.Domain.Shared;
using Dental.WinForms.Properties;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.UserControls;

public partial class ctrlProfile : UserControl
{
    private readonly ILogger<ctrlProfile> _logger = default!;
    private readonly IDentalInfoService _infoService = default!;
    private const int _profileId = 1; // The profile ID is always 1

    public ctrlProfile()
    {
        InitializeComponent();
    }

    public ctrlProfile(
        IDentalInfoService infoService,
        ILogger<ctrlProfile> logger) : this()
    {
        _logger = logger;
        _infoService = infoService;

        Load += CtrlProfile_Load;
    }

    public override async void Refresh()
    {
        base.Refresh();
        await SetValues();
    }

    public async Task Update(DentalInfoDto dto)
    {
        var updateResult = await _infoService.UpdateAsync(dto);
        if (updateResult.IsFailure)
        {
            HandleError(updateResult);
            return;
        }

        SetUi(updateResult.Value);
    }


    private async void CtrlProfile_Load(object? sender, EventArgs e)
    {
        await SetValues();
    }

    private async Task SetValues()
    {
        try
        {
            var existingValuesResult = await _infoService.GetAsync();
            if (existingValuesResult.IsFailure)
            {
                return;
            }

            SetUi(existingValuesResult.Value);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "An error occurred while setting the profile values.");
        }
    }

    private void SetUi(DentalInfoDto existingValuesResult)
    {
        lblDocktorName.Text = existingValuesResult.DoctorName ?? string.Empty;
        lblDescription.Text = existingValuesResult.DentalDescription ?? string.Empty;
        lblPhoneNumber.Text = existingValuesResult.PhoneNumber ?? string.Empty;

        try
        {
            pbDoctorPicture.Image = Image.FromFile(
                existingValuesResult.PicturePath?? string.Empty);
        }
        catch
        {
            pbDoctorPicture.Image = Resources.user_512;
            MessageBox.Show("حدث خطأ اثناء تحميل الصوره، برجاء التواصل مع المطور.",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _logger?.LogWarning(
                "Failed to load image from path: {PicturePath}. Using default image instead.",
                existingValuesResult.PicturePath);
        }
    }

    private static void HandleError(Result updateResult)
    {
        if (updateResult.Error == ServiceErrors.NotFound)
        {
            // this is unexpected, since the profile should always exist
            MessageBox.Show("حدث خطأ اثناء تحديث الملف الشخصي، برجاء التواصل مع المطور.",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (updateResult.Error == ServiceErrors.InvalidId)
        {
            MessageBox.Show("حدث خطأ اثناء تحديث الملف الشخصي، برجاء التواصل مع المطور.",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (updateResult.Error == DomainErrors.DentalInfo.DoctorNameTooLong)
        {
            MessageBox.Show("اسم الطبيب طويل جداً، برجاء إدخال اسم أقصر.",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (updateResult.Error == DomainErrors.DentalInfo.DentalDescriptionTooLong)
        {
            MessageBox.Show("وصف العيادة طويل جداً، برجاء إدخال وصف أقصر.",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (updateResult.Error == DomainErrors.DentalInfo.PhoneNumberTooLong)
        {
            MessageBox.Show("رقم الهاتف طويل جداً، برجاء إدخال رقم هاتف أقصر.",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (updateResult.Error == DomainErrors.DentalInfo.PicturePathTooLong)
        {
            MessageBox.Show("مسار الصورة طويل جداً، برجاء إدخال مسار أقصر.",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}