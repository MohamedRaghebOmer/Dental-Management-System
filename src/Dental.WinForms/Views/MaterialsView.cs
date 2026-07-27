using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Domain.Enums;
using Dental.Domain.Views.Material;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.Views;

public partial class MaterialsView : UserControl
{
    private readonly IFormFactory _formFactory;
    private readonly IMaterialService _materialService;
    private readonly ILogger<MaterialsView> _logger;
    private bool _isLoading = true;

    private enum FilterColumn
    {
        Name,
        Quantity,
        ReOrderLevel,
        Price,
        Status
    }
    private FilterColumn _currentFilterColumn;

    private static class Constants
    {
        public static class cbFilterBy
        {
            public const string Name = "الإسم";
            public const string Quantity = "الكميه المتاحه";
            public const string ReOrderLevel = "حد إعادة الطلب";
            public const string Price = "سعر الشراء";
            public const string Status = "الحاله";
        }

        public static class cbFilterStatus
        {
            public const string All = "الكل";
            public const string Available = "متوفر";
            public const string LowStock = "منخفض";
            public const string OutOfStock = "نفد";
        }
    }

    public MaterialsView(
        IFormFactory formFactory,
        IMaterialService materialService,
        ILogger<MaterialsView> logger)
    {
        InitializeComponent();

        _formFactory = formFactory;
        _materialService = materialService;
        _logger = logger;

        dataGridView.AutoGenerateColumns = false;
        dataGridView.DataSource = null;
        dataGridView.AlternatingRowsDefaultCellStyle = null;

        _isLoading = true;
    }

    private void MaterialsView_Load(object sender, EventArgs e)
    {
        Initilaize();
        _isLoading = false;
    }

    private void Initilaize()
    {
        cbFilterList.Text = Constants.cbFilterBy.Name;
        _currentFilterColumn = FilterColumn.Name;

        cbMaterialStatus.Visible = false;
        cbMaterialStatus.Text = Constants.cbFilterStatus.All;

        txtFilterValue.Visible = true;
        txtFilterValue.Clear();

        loadDataTimer.Start();
    }

    private void Refresh(object? sender, EventArgs? e)
    {
        _isLoading = true;
        Initilaize();
        _isLoading = false;
    }

    private async Task LoadGridAsync(MaterialFilterDto? filterDto = null)
    {
        if (_isLoading)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var data = await _materialService.FilterAsync(filterDto);

            var dataSource = data.Select(m => new
            {
                m.Id,
                m.Name,
                m.Quantity,
                m.ReorderLevel,
                Price = $"{m.Price:F2}",
                Status = m.Status.HasValue ? MaterialStatusHelper.ToString(m.Status.Value) : string.Empty
            }).ToList();

            dataGridView.DataSource = dataSource;

            await LoadCardsAsync(data);
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError("حدث خطأ أثناء تحميل البيانات. " + ex.Message);
            _logger.LogError(ex, "Error occurred while loading material data");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async Task LoadCardsAsync(List<MaterialFilterDto> materials)
    {
        lblMaterialsCount.Text = materials.Count.ToString();

        lblLowStockCount.Text = materials.Count(
            m => m.Status == MaterialStatus.LowStock).ToString();

        lblOutOfStockCount.Text = materials.Count(
            m => m.Status == MaterialStatus.OutOfStock).ToString();
    }

    private MaterialFilterDto? GetFilterDto()
    {
        MaterialFilterDto? filterDto = null;
        var filterValue = txtFilterValue.Text.Trim();

        switch (_currentFilterColumn)
        {
            case FilterColumn.Name:
                filterDto = new MaterialFilterDto { Name = filterValue };
                break;

            case FilterColumn.Quantity:
                if (decimal.TryParse(filterValue, out decimal quantity))
                {
                    filterDto = new MaterialFilterDto { Quantity = quantity };
                }
                break;

            case FilterColumn.ReOrderLevel:
                if (decimal.TryParse(filterValue, out decimal reorderLevel))
                {
                    filterDto = new MaterialFilterDto { ReorderLevel = reorderLevel };
                }
                break;

            case FilterColumn.Price:
                if (decimal.TryParse(filterValue, out decimal price))
                {
                    filterDto = new MaterialFilterDto { Price = price };
                }
                break;

            case FilterColumn.Status:
                var cbText = cbMaterialStatus.Text;
                if (!string.IsNullOrWhiteSpace(cbText))
                {
                    filterDto = cbText switch
                    {
                        Constants.cbFilterStatus.All => new MaterialFilterDto
                        { Status = null },

                        Constants.cbFilterStatus.Available => new MaterialFilterDto
                        { Status = MaterialStatus.Available },

                        Constants.cbFilterStatus.LowStock => new MaterialFilterDto
                        { Status = MaterialStatus.LowStock },

                        Constants.cbFilterStatus.OutOfStock => new MaterialFilterDto
                        { Status = MaterialStatus.OutOfStock },

                        _ => filterDto
                    };
                }

                break;
        }

        return filterDto;
    }

    private async void loadDataTimer_Tick(object sender, EventArgs e)
    {
        loadDataTimer.Stop();
        await LoadGridAsync();
    }

    private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentFilterColumn = cbFilterList.Text switch
        {
            Constants.cbFilterBy.Name => FilterColumn.Name,
            Constants.cbFilterBy.Quantity => FilterColumn.Quantity,
            Constants.cbFilterBy.ReOrderLevel => FilterColumn.ReOrderLevel,
            Constants.cbFilterBy.Price => FilterColumn.Price,
            Constants.cbFilterBy.Status => FilterColumn.Status,
            _ => _currentFilterColumn
        };

        cbMaterialStatus.Visible = _currentFilterColumn == FilterColumn.Status;
        txtFilterValue.Visible = _currentFilterColumn != FilterColumn.Status;

        if (_currentFilterColumn == FilterColumn.Status)
        {
            cbMaterialStatus.Text = Constants.cbFilterStatus.All;
            cbMaterialStatus.Focus();
        }
        else
        {
            txtFilterValue.Clear();
            txtFilterValue.Focus();
        }

        RefreshData();
    }

    private async void RefreshData(object? sender = null, EventArgs? e = null)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private async void btnNewMaterial_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditMaterial();
        await frm.ShowDialogAsync();
        Refresh(null, null);
    }

    private async void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        var currentId = SelectedMaterialId;
        if (!currentId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditMaterial(currentId.Value);
        await frm.ShowDialogAsync();
        Refresh(null, null);
    }

    private int? SelectedMaterialId
    {
        get
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                if (selectedRow.Cells[nameof(colId)].Value is int id)
                {
                    return id;
                }
            }
            return null;
        }
    }

    private async void tsmiDelete_Click(object sender, EventArgs e)
    {
        var currentId = SelectedMaterialId;
        if (!currentId.HasValue)
            return;

        if (MessageBoxExtensions.ShowQuestion("هل أنت متأكد من حذف الخامه؟") == DialogResult.Yes)
        {
            try
            {
                var deleteResult = await _materialService.DeleteAsync(currentId.Value);
                if (deleteResult.IsFailure)
                {
                    MessageBoxExtensions.ShowError("حدث خطأ أثناء حذف الخامه. " + deleteResult.Error.Message);
                    return;
                }

                MessageBoxExtensions.ShowInfo("تم حذف الخامه بنجاح.", "تم الحذف");
                Refresh(null, null);
            }
            catch (Exception ex)
            {
                MessageBoxExtensions.ShowError("حدث خطأ أثناء حذف الخامه. " + ex.Message);
                _logger.LogError(ex, "Error occurred while deleting material with ID {MaterialId}", currentId.Value);
            }
        }
    }

    private void tsmiCopyName_Click(object sender, EventArgs e)
    {
        var name = SelectedMaterialName;
        if (string.IsNullOrWhiteSpace(name))
            return;

        Clipboard.SetText(name, TextDataFormat.Text);
    }

    private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }

    private string? SelectedMaterialName
    {
        get
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                if (selectedRow.Cells[nameof(colName)].Value is string name)
                {
                    return name;
                }
            }
            return null;
        }
    }
}
