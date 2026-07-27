using System.Runtime.InteropServices.JavaScript;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Material;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;
using Guna.UI2.WinForms;

namespace Dental.WinForms.Forms.AddEdit;

public partial class frmAddEditMaterial : Form
{
    private readonly IMaterialService _materialService;
    private readonly int? _materialId = null;

    private enum Mode
    {
        Add,
        Edit
    }
    private readonly Mode _mode;


    public frmAddEditMaterial(IMaterialService materialService)
    {
        InitializeComponent();

        _materialService = materialService;

        _mode = Mode.Add;
        _materialId = null;
    }

    public frmAddEditMaterial(
        int materialId,
        IMaterialService materialService)
        : this(materialService)
    {
        _mode = Mode.Edit;
        _materialId = materialId;

        Initialize();
    }

    private void frmAddEditMaterial_Load(object sender, EventArgs e)
    {
        if (_mode == Mode.Edit)
            LoadMaterialUi();
    }

    private void Initialize()
    {
        Text = _mode == Mode.Add ? "إضافة خامه" : "تعديل خامه";
        lblTitile.Text = _mode == Mode.Add ? "إضافة خامه جديده" : "تعديل خامه";
    }

    private async void LoadMaterialUi()
    {
        if (_mode != Mode.Edit || _materialId is not > 0)
        {
            MessageBoxExtensions.ShowError("رقم الخامه غير صحيح");
            Close();
            return;
        }
            
        var materialResult = await _materialService.GetByIdAsync(_materialId.Value);
        if (materialResult.IsFailure)
        {
            MessageBoxExtensions.ShowError("الخامه غير موجوده");
            Close();
            return;
        }

        var material = materialResult.Value;
        txtName.Text = material.Name;
        txtQuantity.Text = material.Quantity.ToString();
        txtPrice.Text = material.Price.ToString();
        txtReOrderLevel.Text = material.ReorderLevel.ToString();
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
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        string message = _mode == Mode.Add ? "هل أنت متأكد من إضافة الخامه؟" : "هل أنت متأكد من تعديل الخامه؟";
        if (MessageBoxExtensions.ShowQuestion(message, "تأكيد") != DialogResult.Yes)
            return;

        var requestDto = GetMaterialRequestDtoFromUi();
        if (requestDto == null) 
            return;

        Result? saveResult = null;

        if (_mode == Mode.Add)
            saveResult = await _materialService.CreateAsync(requestDto);
        else
            saveResult = await _materialService.UpdateAsync(_materialId!.Value, requestDto);

        if (saveResult.IsFailure)
        {
            HandelCreateAndUpdateMaterialError(saveResult.Error);
            return;
        }

        MessageBoxExtensions.ShowInfo(_mode == Mode.Add ?
            "تم إضافة الخامه بنجاح" : "تم تعديل الخامه بنجاح", "تم الحفظ");

        Close();
    }

    private void HandelCreateAndUpdateMaterialError(Error error)
    {
        switch (error.Code)
        {
            case "Material.DuplicateName":
                MessageBoxExtensions.ShowWarning("الخامه موجوده مسبقا");
                break;

            case "Name.TooLong":
                MessageBoxExtensions.ShowWarning("اسم الخامه طويل جدا");
                break;


            default:
                MessageBoxExtensions.ShowWarning("حدث خطأ أثناء الحفظ. " + error.Message);
                break;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBoxExtensions.ShowError("الرجاء إدخال اسم الخامه");
            return false;
        }

        if (!decimal.TryParse(txtQuantity.Text, out decimal quantity) || quantity < 0)
        {
            MessageBoxExtensions.ShowError("الرجاء إدخال كميه صالحة");
            return false;
        }

        if (!decimal.TryParse(txtReOrderLevel.Text, out decimal reorderLevel) || reorderLevel < 0)
        {
            MessageBoxExtensions.ShowError("الرجاء إدخال مستوى إعادة الطلب صالح");
            return false;
        }

        if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
        {
            MessageBoxExtensions.ShowError("الرجاء إدخال سعر صالح");
            return false;
        }

        return true;
    }

    private MaterialRequestDto? GetMaterialRequestDtoFromUi()
    {
        if (!decimal.TryParse(txtQuantity.Text, out decimal quantity) || quantity < 0)
            return null;

        if (!decimal.TryParse(txtReOrderLevel.Text, out decimal reorderLevel) || reorderLevel < 0)
            return null;

        if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            return null;

        return new MaterialRequestDto
        {
            Name = txtName.Text.Trim(),
            Quantity = quantity,
            ReorderLevel = reorderLevel,
            Price = price
        };
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
