using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;

namespace Dental.WinForms.Forms;

public partial class frmAddEditTreatment : Form
{
    private readonly ITreatmentService _treatmentService;
    private readonly int? _treatmentId = null;

    private enum Mode
    {
        Add,
        Edit
    }
    private readonly Mode _mode = Mode.Add;

    public frmAddEditTreatment(ITreatmentService treatmentService)
    {
        InitializeComponent();
        _treatmentService = treatmentService;
        _mode = Mode.Add;
        _treatmentId = null;
    }

    public frmAddEditTreatment(
        int treatmentId,
        ITreatmentService treatmentService)
        : this(treatmentService)
    {
        _treatmentId = treatmentId;
        _mode = Mode.Edit;
    }

    private async void frmAddEditTreatment_Load(object sender, EventArgs e)
    {
        Initialize();

        if (_mode == Mode.Edit)
            await LoadTreatmentInfoAsync();
    }

    private async Task LoadTreatmentInfoAsync()
    {
        if (_mode != Mode.Edit || _treatmentId is not > 0)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var treatmentResult = await _treatmentService.GetByIdAsync(_treatmentId.Value);

            if (treatmentResult.IsFailure)
            {
                switch (treatmentResult.Error)
                {
                    case "Not Found":
                        MessageBoxExtensions.ShowError("الخدمه غير موجوده", "خطأ");
                        Close();
                        return;

                    case "Invalid Id":
                        MessageBoxExtensions.ShowError("رقم الخدمه غير صالح", "خطأ");
                        Close();
                        return;

                    default:
                        MessageBoxExtensions.ShowError($"حدث خطأ أثناء تحميل بيانات الخدمه: {treatmentResult.Error}", "خطأ");
                        Close();
                        return;
                }
            }

            var treatment = treatmentResult.Value;

            txtName.Text = treatment.Name;
            txtPrice.Text = treatment.Price.ToString("F2");
            txtDescription.Text = treatment.Description;
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError($"حدث خطأ أثناء تحميل بيانات الخدمه: {ex.Message}", "خطأ");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void Initialize()
    {
        Text = _mode == Mode.Add ? "إضافة خدمه جديده" : "تعديل خدمه";
        lblTitile.Text = _mode == Mode.Add ? "إضافة خدمه جديده" : "تعديل خدمه";
    }

    private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        {
            e.Handled = true;
            return;
        }

        if (e.KeyChar == '.' && txtPrice.Text.Contains('.'))
        {
            e.Handled = true;
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput(out string message))
        {
            MessageBoxExtensions.ShowWarning(message);
            return;
        }

        string confirmationMessage = _mode == Mode.Add ?
            "هل أنت متأكد من إضافة الخدمه؟" :
            "هل أنت متأكد من تعديل بيانات الخدمه؟";
        if (MessageBoxExtensions.ShowQuestion(confirmationMessage, "تأكيد الحفظ")
            != DialogResult.Yes)
            return;

        var requestDto = GetTreatmentDtoFromUi();
        if (requestDto is null)
            return;

        Cursor = Cursors.WaitCursor;
        try
        {
            if (_mode == Mode.Add)
            {
                var result = await _treatmentService.CreateAsync(requestDto);
                if (result.IsFailure)
                {
                    HandelAddOrUpdateTreatmentError(result.Error);
                    return;
                }
            }
            else if (_mode == Mode.Edit && _treatmentId is not null)
            {
                var result = await _treatmentService.UpdateAsync(_treatmentId.Value, requestDto);
                if (result.IsFailure)
                {
                    HandelAddOrUpdateTreatmentError(result.Error);
                    return;
                }
            }

            MessageBoxExtensions.ShowInfo("تم حفظ بيانات الخدمه بنجاح");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError($"حدث خطأ أثناء حفظ بيانات الخدمه: {ex.Message}");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void HandelAddOrUpdateTreatmentError(Error resultError)
    {
        switch (resultError.Code)
        {
            case "Money.NonPositiveValue":
                MessageBoxExtensions.ShowWarning("سعر الخدمه يجب أن يكون قيمة موجبة.");
                break;

            case "Treatment.DuplicateName":
                MessageBoxExtensions.ShowWarning("يوجد خدمه مسجله بنفس الإسم.");
                break;

            case "Name.Empty":
                MessageBoxExtensions.ShowWarning("اسم الخدمه غير صالح");
                break;

            case "Name.TooLong":
                MessageBoxExtensions.ShowWarning("اسم الخدمه يجب أن لا يتجاوز 100 حرف.");
                break;

            case "Description.TooLong":
                MessageBoxExtensions.ShowWarning("وصف الخدمه يجب أن لا يتجاوز 100 حرف.");
                break;

            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowWarning("رقم الخدمه يجب أن يكون قيمة موجبة.");
                break;

            case "NotFound":
                MessageBoxExtensions.ShowWarning("الخدمه غير موجوده.");
                break;

            default:
                MessageBoxExtensions.ShowError($"حدث خطأ أثناء حفظ بيانات الخدمه: {resultError.Message}");
                break;
        }
    }

    private bool ValidateInput(out string message)
    {
        message = string.Empty;

        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            message = "الرجاء إدخال اسم الخدمه";
            return false;
        }

        if (txtName.Text.Trim().Length > 100)
        {
            message = "اسم الخدمه يجب أن لا يتجاوز 100 حرف";
            return false;
        }

        if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
        {
            message = "الرجاء إدخال سعر صالح للخدمه";
            return false;
        }

        return true;
    }

    private TreatmentRequestDto? GetTreatmentDtoFromUi()
    {
        if (!decimal.TryParse(txtPrice.Text, out decimal price))
        {
            MessageBoxExtensions.ShowWarning("الرجاء إدخال سعر صالح للخدمه");
            return null;
        }

        return new TreatmentRequestDto
        {
            Name = txtName.Text.Trim(),
            Price = price,
            Description = txtDescription.Text.Trim()
        };
    }
}