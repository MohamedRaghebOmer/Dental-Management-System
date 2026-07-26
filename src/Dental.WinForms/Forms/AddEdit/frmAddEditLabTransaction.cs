using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.LabTransaction;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;
using Guna.UI2.WinForms;

namespace Dental.WinForms.Forms.AddEdit;

public partial class frmAddEditLabTransaction : Form
{
    private readonly ILabTransactionService _labTransactionService;
    private readonly int? _labTranId = null;

    private enum Mode
    {
        Add,
        Edit
    }
    private readonly Mode _mode = Mode.Add;

    public frmAddEditLabTransaction(
        ILabTransactionService labTransactionService)
    {
        InitializeComponent();

        _labTransactionService = labTransactionService;
        _mode = Mode.Add;
        _labTranId = null;
    }

    public frmAddEditLabTransaction(
        int labTranId,
        ILabTransactionService labTransactionService)
        : this(labTransactionService)
    {
        _mode = Mode.Edit;
        _labTranId = labTranId;
    }

    private async void frmAddEditLabTransaction_Load(object sender, EventArgs e)
    {
        Initialize();

        if (_mode == Mode.Edit)
            await LoadLabTransactionInfoAsync();
    }

    private async Task LoadLabTransactionInfoAsync()
    {
        if (_mode != Mode.Edit || _labTranId is not > 0)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var labTransactionResult = await _labTransactionService.GetByIdAsync(_labTranId.Value);
            if (labTransactionResult.IsFailure)
            {
                switch (labTransactionResult.Error)
                {
                    case "Not Found":
                        MessageBoxExtensions.ShowError("لم يتم العثور على بيانات الخدمه.", "خطأ");
                        Close();
                        return;
                    default:
                        MessageBoxExtensions.ShowError($"حدث خطأ أثناء تحميل بيانات الخدمه: {labTransactionResult.Error}", "خطأ");
                        Close();
                        return;
                }
            }

            var labTransaction = labTransactionResult.Value;

            // Populate the form fields with the lab transaction data
            txtName.Text = labTransaction.LabName;
            txtTotalAmount.Text = labTransaction.TotalAmount.ToString("F2");
            txtPaidAmount.Text = labTransaction.PaidAmount.ToString("F2");
            txtTreatments.Text = labTransaction.Treatments;
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError(
                $"حدث خطأ أثناء تحميل بيانات المعامله: {ex.Message}");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void Initialize()
    {
        Text = _mode == Mode.Add ? "إضافة معامله" : "تعديل معامله";
        lblTitile.Text = _mode == Mode.Add ? "إضافة معامله" : "تعديل معامله";
    }

    private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        {
            e.Handled = true;
            return;
        }

        if (sender is Guna2TextBox textBox)
        {
            // Allow only one decimal point
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput(out string message))
        {
            MessageBoxExtensions.ShowWarning(message);
            return;
        }

        string confirmMessage = _mode == Mode.Add ? "هل أنت متأكد من إضافة المعامله؟" : "هل أنت متأكد من تعديل المعامله؟";

        var result = MessageBoxExtensions.ShowQuestion(confirmMessage, "تأكيد");
        if (result != DialogResult.Yes)
            return;

        var requestDto = GetLabTransactionDtoFromUi();
        if (requestDto is null)
            return;

        Cursor = Cursors.WaitCursor;
        try
        {
            if (_mode == Mode.Add)
            {
                var saveResult = await _labTransactionService.CreateAsync(requestDto);
                if (saveResult.IsFailure)
                {
                    HandelAddOrUpdateTranError(saveResult.Error);
                    return;
                }
            }
            else if (_mode == Mode.Edit && _labTranId is > 0)
            {
                var saveResult = await _labTransactionService.UpdateAsync(_labTranId.Value, requestDto);
                if (saveResult.IsFailure)
                {
                    HandelAddOrUpdateTranError(saveResult.Error);
                    return;
                }
            }

            MessageBoxExtensions.ShowInfo("تم حفظ بيانات المعامله بنجاح");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError($"حدث خطأ أثناء حفظ بيانات المعامله: {ex.Message}");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void HandelAddOrUpdateTranError(Error saveResultError)
    {
        switch (saveResultError.Code)
        {
            case "Money.NonPositiveValue":
                MessageBoxExtensions.ShowWarning("سعر الخدمه يجب أن يكون قيمة موجبة.");
                break;

            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowWarning("رقم الخدمه يجب أن يكون قيمة موجبة.");
                break;

            case "NotFound":
                MessageBoxExtensions.ShowWarning("الخدمه غير موجوده.");
                break;

            case "LabName.Empty":
                MessageBoxExtensions.ShowWarning("اسم الخدمه مطلوب.");
                break;

            case "LabName.TooLong":
                MessageBoxExtensions.ShowWarning("اسم الخدمه طويل جداً.");
                break;

            case "Treatments.TooLong":
                MessageBoxExtensions.ShowWarning("عدد الخدمه يجب أن لا يتجاوز 1000 خدمه.");
                break;

            default:
                MessageBoxExtensions.ShowError($"حدث خطأ أثناء حفظ بيانات الخدمه: {saveResultError.Message}");
                break;
        }
    }

    private LabTransactionRequestDto? GetLabTransactionDtoFromUi()
    {
        if (!decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount) || totalAmount < 0)
            return null;

        if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount) || paidAmount < 0)
            return null;

        return new LabTransactionRequestDto
        {
            LabName = txtName.Text.Trim(),
            TotalAmount = totalAmount,
            PaidAmount = paidAmount,
            Treatments = txtTreatments.Text.Trim()
        };
    }

    private bool ValidateInput(out string message)
    {
        message = string.Empty;

        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            message = "اسم المعامله مطلوب.";
            return false;
        }

        if (!decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount) || totalAmount < 0)
        {
            message = "المبلغ الكلي غير صالح.";
            return false;
        }

        if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount) || paidAmount < 0)
        {
            message = "المبلغ المدفوع غير صالح.";
            return false;
        }

        return true;
    }
}
