using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.ViewsStuff.Interfaces.Visits;
using Dental.Domain.Views.Visit;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Dental.WinForms.Views;

public partial class RadiographsView : UserControl
{
    private readonly IFormFactory _formFactory;
    private readonly ILogger<RadiographsView> _logger;
    private readonly IVisitRadiographViewService _visitRadiographViewService;
    private readonly IVisitRadioghraphService _visitRadioghraphService;
    private bool _isLoading = true;

    private enum GridColumn
    {
        VisitId,
        PatientName,
        RadiographCreatedAt,

        // Not visible in the combo box or gird view,
        // but used in filtering for future extensibility and scalability
        PatientId,
        VisitRadiographId,
        ImagePath
    }

    private GridColumn _currentFilterColumn = GridColumn.PatientName;

    private static class Constants
    {
        public static class cbFilterby
        {
            public const string VisitId = "رقم الزيارة";
            public const string PatientName = "إسم المريض";
            public const string RadiographCreatedAt = "تاريخ إنشاء الأشعة";

            // Not visible in the combo box or gird view,
            // but used in filtering for future extensibility and scalability
            public const string PatientId = "رقم المريض";
            public const string VisitRadiographId = "رقم الأشعة";
            public const string ImagePath = "مسار الصورة";
        }
    }

    public RadiographsView(
        IFormFactory formFactory,
        ILogger<RadiographsView> logger,
        IVisitRadiographViewService visitRadiographViewService,
        IVisitRadioghraphService visitRadioghraphService)
    {
        InitializeComponent();
        _isLoading = true;

        _formFactory = formFactory;
        _logger = logger;
        _visitRadiographViewService = visitRadiographViewService;
        _visitRadioghraphService = visitRadioghraphService;

        dataGridView.AutoGenerateColumns = false;
        dataGridView.DataSource = null;
        dataGridView.AlternatingRowsDefaultCellStyle = null;
    }

    private void RadiographsView_Load(object sender, EventArgs e)
    {
        _isLoading = true;
        Initialize();
        _isLoading = false;
    }

    private void Initialize()
    {
        _currentFilterColumn = GridColumn.PatientName;
        cbFilterList.Text = Constants.cbFilterby.PatientName;

        dateTimePicker.MaxDate = DateTime.Now;
        dtpSearchAfter.MaxDate = DateTime.Now;

        lblSearchAfter.Visible = false;
        dtpSearchAfter.Visible = false;

        txtFilterValue.Clear();
        txtFilterValue.Visible = true;

        rbToday.Checked = false;
        rbThisMonth.Checked = false;
        rbAllTime.Checked = true;

        timerUpdateDateTimePckerMaxDate.Start();
        loadDataTimer.Start();
    }

    private async Task LoadGridAsync(VisitRadiographView? filterDto = null)
    {
        if (_isLoading)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var dtos = await _visitRadiographViewService.GetAsync(filterDto);
            var dataSource = dtos.Select(dto => new
            {
                dto.VisitId,
                dto.PatientName,

                RadiographCreatedAt = dto.RadiographCreatedAt.HasValue
                    ? DateTimeHelper.GetArabicDateTime(dto.RadiographCreatedAt.Value)
                    : null,

                dto.PatientId,
                dto.VisitRadiographId,
                dto.ImagePath
            }).ToList();

            dataGridView.DataSource = dataSource;
            lblRadiographsCount.Text = dataSource.Count.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading radiographs data.");
            MessageBox.Show("حدث خطأ أثناء تحميل بيانات الأشعة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private VisitRadiographView? GetFilterDto()
    {
        VisitRadiographView? filterDto = null;

        switch (_currentFilterColumn)
        {
            case GridColumn.VisitId:
                if (int.TryParse(txtFilterValue.Text, out int visitId))
                {
                    filterDto = new VisitRadiographView
                    { VisitId = visitId };
                }
                break;

            case GridColumn.RadiographCreatedAt:
                if (dateTimePicker.Visible)
                {
                    filterDto = new VisitRadiographView
                    { RadiographCreatedAt = dateTimePicker.Value.Date };
                }
                break;

            case GridColumn.PatientName:
                if (!string.IsNullOrWhiteSpace(txtFilterValue.Text))
                {
                    filterDto = new VisitRadiographView
                    { PatientName = txtFilterValue.Text.Trim() };
                }
                break;

            case GridColumn.PatientId:
                if (int.TryParse(txtFilterValue.Text, out int patientIdValue))
                {
                    filterDto = new VisitRadiographView
                    { PatientId = patientIdValue };
                }
                break;

            case GridColumn.VisitRadiographId:
                if (int.TryParse(txtFilterValue.Text, out int visitRadiographId))
                {
                    filterDto = new VisitRadiographView
                    { VisitRadiographId = visitRadiographId };
                }
                break;

            case GridColumn.ImagePath:
                if (!string.IsNullOrWhiteSpace(txtFilterValue.Text))
                {
                    filterDto = new VisitRadiographView
                    { ImagePath = txtFilterValue.Text.Trim() };
                }
                break;
        }

        if (rbAllTime.Checked)
        {
            if (filterDto is not null)
            {
                filterDto = filterDto with { FilterAfter = null };
            }
        }
        else
        {
            if (filterDto is null)
            {
                filterDto = new VisitRadiographView { FilterAfter = dtpSearchAfter.Value.Date };
            }
            else
            {
                filterDto = filterDto with { FilterAfter = dtpSearchAfter.Value.Date };
            }
        }

        return filterDto;
    }

    private new void Refresh()
    {
        _isLoading = true;
        Initialize();
        _isLoading = false;
    }

    private async void cbFilterList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _currentFilterColumn = cbFilterList.Text switch
        {
            Constants.cbFilterby.VisitId => GridColumn.VisitId,
            Constants.cbFilterby.PatientName => GridColumn.PatientName,
            Constants.cbFilterby.RadiographCreatedAt => GridColumn.RadiographCreatedAt,
            Constants.cbFilterby.PatientId => GridColumn.PatientId,
            Constants.cbFilterby.VisitRadiographId => GridColumn.VisitRadiographId,
            Constants.cbFilterby.ImagePath => GridColumn.ImagePath,
            _ => GridColumn.VisitId
        };

        txtFilterValue.Visible = _currentFilterColumn != GridColumn.RadiographCreatedAt;
        dateTimePicker.Visible = _currentFilterColumn == GridColumn.RadiographCreatedAt;

        if (_currentFilterColumn != GridColumn.RadiographCreatedAt)
        {
            txtFilterValue.Clear();
            txtFilterValue.Focus();
            EnableSearchAfter();
        }
        else
        {
            dateTimePicker.Value = DateTime.Now.AddSeconds(-2);
            dataGridView.Focus();
            DisableSearchAfter();
        }

        if (rbAllTime.Checked)
        {
            lblSearchAfter.Visible = false;
            dtpSearchAfter.Visible = false;
        }

        await LoadGridAsync(GetFilterDto());
    }

    private async void txtFilterValue_TextChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private async void dateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private void RadioButtonsFilterPeriods_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.Checked)
        {
            dtpSearchAfter.Visible = true;
            lblSearchAfter.Visible = true;

            if (radioButton == rbToday)
            {
                dtpSearchAfter.Value = DateTime.Now.Date;
            }
            else if (radioButton == rbThisWeek)
            {
                dtpSearchAfter.Value = DateTime.Today.Date.StartOfWeek();
            }
            else if (radioButton == rbThisMonth)
            {
                dtpSearchAfter.Value = DateTime.Today.Date.StartOfMonth();
            }
            else if (radioButton == rbAllTime)
            {
                dtpSearchAfter.Visible = false;
                lblSearchAfter.Visible = false;
                dtpSearchAfter.Value = dtpSearchAfter.MinDate.Date;
            }
        }
    }

    private void DisableSearchAfter()
    {
        dtpSearchAfter.Visible = false;
        lblSearchAfter.Visible = false;
        pnlSearchAtRadioButtons.Visible = false;
    }

    private void EnableSearchAfter()
    {
        dtpSearchAfter.Visible = true;
        lblSearchAfter.Visible = true;
        pnlSearchAtRadioButtons.Visible = true;
    }

    private async void dtpSearchAfter_ValueChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (_currentFilterColumn is GridColumn.VisitId
            or GridColumn.PatientId
            or GridColumn.VisitRadiographId)
        {
            // Allow only digits, control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    private async void btnNewVisitRadiograph_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditVisitRadioghraph();
        await frm.ShowDialogAsync();
        Refresh();
    }

    private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e is { Button: MouseButtons.Right, RowIndex: >= 0, ColumnIndex: >= 0 } &&
            e.RowIndex < dataGridView.Rows.Count)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }

    private async void loadDataTimer_Tick(object? sender, EventArgs e)
    {
        loadDataTimer.Stop();
        await LoadGridAsync();
    }

    private void timerUpdateDateTimePckerMaxDate_Tick(object? sender, EventArgs e)
    {
        dtpSearchAfter.MaxDate = DateTime.Now;
        dateTimePicker.MaxDate = DateTime.Now;
    }

    private async void tsmiEdit_Click(object sender, EventArgs e)
    {
        var radiographId = SelectedRadiographId;
        if (radiographId is not > 0)
            return;

        using var frm = _formFactory.Create_frmAddEditVisitRadioghraph(radiographId.Value);
        await frm.ShowDialogAsync();
        Refresh();
    }

    private async void tsmiDelete_Click(object sender, EventArgs e)
    {
        var radiographId = SelectedRadiographId;
        if (radiographId is not > 0)
            return;

        var sure = MessageBox.Show(
            "هل أنت متأكد من رغبتك في حذف هذه الأشعه؟",
            "تأكيد الحذف",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (sure != DialogResult.Yes)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;

            var deleteResult = await _visitRadioghraphService.DeleteAsync(radiographId.Value);
            if (deleteResult.IsFailure)
            {

                if (deleteResult.Error.Code is "NotFound" or "VisitRadiograph.NotFound")
                {
                    MessageBoxExtensions.ShowError("الأشعة غير موجودة.");
                }
                else
                {
                    MessageBoxExtensions.ShowError("حدث خطأ أثناء حذف الأشعه. " + deleteResult.Error);
                }

                return;
            }

            MessageBoxExtensions.ShowInfo("تم حذف الأشعه بنجاح.", "تم الحذف");
            Refresh();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting radiograph with ID {RadiographId}. {Exception}", radiographId, ex);
            MessageBox.Show("حدث خطأ أثناء حذف الأشعة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async void tsmiEditVisit_Click(object sender, EventArgs e)
    {
        var visitId = SelectedVisitId;
        if (visitId is not > 0)
            return;

        using var frm = _formFactory.Create_frmAddEditVisit(visitId.Value);
        await frm.ShowDialogAsync();
        Refresh();
    }

    private async void tsmiEditPatient_Click(object sender, EventArgs e)
    {
        var patientId = SelectedPatientId;
        if (patientId is not > 0)
            return;

        using var frm = _formFactory.Create_frmAddEditPatient(patientId.Value);
        await frm.ShowDialogAsync();
        Refresh();
    }

    private void tsmiOpenRadioghraphImage_Click(object sender, EventArgs e)
    {
        var imagePath = SelectedImagePath;
        if (string.IsNullOrWhiteSpace(imagePath))
            return;

        try
        {
            Cursor = Cursors.WaitCursor;
            if (!File.Exists(imagePath))
            {
                MessageBoxExtensions.ShowError("ملف الأشعة غير موجود.");
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = imagePath,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error opening radiograph image at path {ImagePath}. {Exception}", imagePath, ex);
            MessageBox.Show("حدث خطأ أثناء فتح صورة الأشعة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void tsmiCopyRadiographImage_Click(object sender, EventArgs e)
    {
        var imagePath = SelectedImagePath;
        if (string.IsNullOrWhiteSpace(imagePath))
            return;
        try
        {
            Cursor = Cursors.WaitCursor;
            if (!File.Exists(imagePath))
            {
                MessageBoxExtensions.ShowError("ملف الأشعة غير موجود.");
                return;
            }

            using var image = Image.FromFile(imagePath);

            // Copy a clone so the clipboard doesn't depend on the disposed image.
            Clipboard.SetImage(new Bitmap(image));

            MessageBoxExtensions.ShowInfo(
                "تم نسخ صورة الأشعة إلى الحافظة.", "تم النسخ");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error copying radiograph image path {ImagePath} to clipboard. {Exception}", imagePath, ex);
            MessageBox.Show("حدث خطأ أثناء نسخ مسار صورة الأشعة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async void tsmiAddNewRadiographToTheSameVisit_Click(object sender, EventArgs e)
    {
        var visitId = SelectedVisitId;
        if (visitId is not > 0)
            return;

        using var frm = _formFactory.Create_frmAddEditVisitRadioghraph();
        frm.VisitId = visitId.Value;
        await frm.ShowDialogAsync();
    }

    private void tsmiRefresh_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    private async void txtFilterValue_VisibleChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private int? SelectedRadiographId
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (!currentRowIndex.HasValue)
                return null;

            var cellValue = dataGridView.Rows[currentRowIndex.Value]
                .Cells[nameof(colVisitRadiographId)]
                .Value;

            return cellValue as int?;
        }
    }

    private int? SelectedVisitId
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (!currentRowIndex.HasValue)
                return null;

            var cellValue = dataGridView.Rows[currentRowIndex.Value]
                .Cells[nameof(colVisitId)]
                .Value;

            return cellValue as int?;
        }
    }

    private int? SelectedPatientId
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (!currentRowIndex.HasValue)
                return null;
            var cellValue = dataGridView.Rows[currentRowIndex.Value]
                .Cells[nameof(colPatientId)]
                .Value;
            return cellValue as int?;
        }
    }

    private string? SelectedImagePath
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (!currentRowIndex.HasValue)
                return null;

            var cellValue = dataGridView.Rows[currentRowIndex.Value]
                .Cells[nameof(colImagePath)]
                .Value;

            return cellValue as string;
        }
    }
}