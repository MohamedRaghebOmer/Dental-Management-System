using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.ViewsStuff.Interfaces.Patients;
using Dental.Domain.Enums;
using Dental.Domain.Views.Patients;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using System.ComponentModel;

namespace Dental.WinForms.Views;

public partial class PatientsView : UserControl
{
    private readonly IPatientViewService _patientViewService;
    private readonly IPatientService _patientService;
    private readonly IFormFactory _formFactory;

    private bool _isLoading = true;

    private enum GridColumns
    {
        Id,
        Name,
        Age,
        Gender,
        PhoneNumber,
        NextAppointmentDateTime,
        LastVisitDateTime,
        TotalNumberOfVisits
    }
    private GridColumns _currentFilterColumn = GridColumns.Name;

    private static class Constants
    {
        public static class cbFilterBy
        {
            public const string Id = "رقم المريض";
            public const string Name = "إسم المريض";
            public const string Age = "السن";
            public const string Gender = "النوع";
            public const string PhoneNumber = "رقم الهاتف";
            public const string NextAppointmentDateTime = "تاريخ الزياره القادم";
            public const string LastVisitDateTime = "تاريخ أخر زياره";
            public const string TotalNumberOfVisits = "عدد الزيارات الكليه";
        }
    }


    public PatientsView(
        IPatientViewService patientViewService,
        IPatientService patientService,
        IFormFactory formFactory)
    {
        InitializeComponent();
        _isLoading = true;

        _patientViewService = patientViewService;
        _patientService = patientService;
        _formFactory = formFactory;

        dataGridView.AutoGenerateColumns = false;
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView.DataSource = null;
        dataGridView.AlternatingRowsDefaultCellStyle = null;
        dataGridView.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
        dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
    }

    private void PatientView_Load(object sender, EventArgs e)
    {
        Initialize();
        _isLoading = false;
    }

    private void Initialize()
    {
        _currentFilterColumn = GridColumns.Name;
        cbFilterList.Text = Constants.cbFilterBy.Name;
        cbGender.Text = GenderHelper.GenderToString(Gender.Male);
        txtFilterValue.Visible = true;
        cbGender.Visible = false;
        LoadDataFirstTimeTimer.Start();
    }

    private async Task LoadGridAsync(PatientDetailedInfoDto? filterDto = null)
    {
        if (_isLoading)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var data =
                await _patientViewService.GetPatientDetailedInfoDtosAsync(filterDto);

            var dataSource = data.Select(dto => new
            {
                dto.Id,
                dto.Name,
                dto.Age,
                Gender = dto.Gender != null ? GenderHelper.GenderToString(dto.Gender.Value) : null,
                dto.PhoneNumber,

                NextAppointmentDateTime = dto.NextAppointmentDateTime.HasValue
                    ? DateTimeHelper.GetArabicDateTime(dto.NextAppointmentDateTime.Value)
                    : "لا يوجد زيارات مقبله",

                LastVisitDateTime = dto.LastVisitDateTime.HasValue
                    ? DateTimeHelper.GetArabicDateTime(dto.LastVisitDateTime.Value)
                    : "لا يوجد زيارات سابقة",

                dto.TotalNumberOfVisits
            }).ToList();

            dataGridView.DataSource = dataSource;
            LoadCardsAsync(data);
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError("حدث خطأ أثناء تحميل بيانات المرضى: " + ex.Message);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void LoadCardsAsync(List<PatientDetailedInfoDto> data)
    {
        var count = data.Count;

        lblPatietnsCount.Text = count.ToString();

        lblTodayPatientCount.Text = data.Count(
            p => p.NextAppointmentDateTime.HasValue 
                 && p.NextAppointmentDateTime.Value.Date == DateTime.Today).ToString();

        if (count == 0)
        {
            lblMalePercentage.Text = @"%0.00";
            lblFemalePercentage.Text = @"%0.00";
            lblAdultsPercentage.Text = @"%0.00";
            lblChilderensPercentage.Text = @"%0.00";
            return;
        }

        lblMalePercentage.Text = $@"%{data.Count(
            p => p.Gender == Gender.Male) / (double)count * 100:F2}";

        lblFemalePercentage.Text = $@"%{data.Count(
            p => p.Gender == Gender.Female) / (double)count * 100:F2}";

        lblAdultsPercentage.Text = $@"%{data.Count(
            p => p.Age >= 18) / (double)count * 100:F2}";

        lblChilderensPercentage.Text = $@"%{data.Count(
            p => p.Age < 18) / (double)count * 100:F2}";
    }

    private PatientDetailedInfoDto? GetFilterDtoFromUi()
    {
        PatientDetailedInfoDto? filterDto = null;

        switch (_currentFilterColumn)
        {
            case GridColumns.Id:
                if (int.TryParse(txtFilterValue.Text, out int id))
                    filterDto = new PatientDetailedInfoDto { Id = id };
                break;

            case GridColumns.Name:
                filterDto = new PatientDetailedInfoDto
                    { Name = txtFilterValue.Text.Trim() };
                break;

            case GridColumns.Age:
                if (int.TryParse(txtFilterValue.Text, out int age))
                    filterDto = new PatientDetailedInfoDto { Age = age };
                break;


            case GridColumns.Gender:
                filterDto = new PatientDetailedInfoDto
                    { Gender = GenderHelper.GenderFromString(cbGender.Text) };
                break;

            case GridColumns.PhoneNumber:
                filterDto = new PatientDetailedInfoDto
                    { PhoneNumber = txtFilterValue.Text.Trim() };
                break;

            case GridColumns.NextAppointmentDateTime:
                filterDto = new PatientDetailedInfoDto
                    { NextAppointmentDateTime = dateTimerPicker.Value.Date };
                break;

            case GridColumns.LastVisitDateTime:
                filterDto = new PatientDetailedInfoDto
                    { LastVisitDateTime = dateTimerPicker.Value.Date };
                break;

            case GridColumns.TotalNumberOfVisits:
                if (int.TryParse(txtFilterValue.Text, out int totalVisits))
                    filterDto = new PatientDetailedInfoDto { TotalNumberOfVisits = totalVisits };
                break;
        }

        return filterDto;
    }

    private new void Refresh()
    {
        base.Refresh();
        Initialize(); // Restart the 'LoadDataFirstTimeTimer' to load data again
    }

    private async void LoadDataFirstTimeTimer_Tick(object sender, EventArgs e)
    {
        LoadDataFirstTimeTimer.Stop();
        await LoadGridAsync();
    }

    private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentFilterColumn = cbFilterList.Text switch
        {
            Constants.cbFilterBy.Id => GridColumns.Id,
            Constants.cbFilterBy.Name => GridColumns.Name,
            Constants.cbFilterBy.Age => GridColumns.Age,
            Constants.cbFilterBy.Gender => GridColumns.Gender,
            Constants.cbFilterBy.PhoneNumber => GridColumns.PhoneNumber,
            Constants.cbFilterBy.NextAppointmentDateTime => GridColumns.NextAppointmentDateTime,
            Constants.cbFilterBy.LastVisitDateTime => GridColumns.LastVisitDateTime,
            Constants.cbFilterBy.TotalNumberOfVisits => GridColumns.TotalNumberOfVisits,
            _ => throw new ArgumentOutOfRangeException(
                $"Unknown filter column selected. {cbFilterList.Text}")
        };

        txtFilterValue.Visible = _currentFilterColumn is not GridColumns.Gender
            and not GridColumns.NextAppointmentDateTime and not GridColumns.LastVisitDateTime;

        cbGender.Visible = _currentFilterColumn == GridColumns.Gender;

        dateTimerPicker.Visible = _currentFilterColumn is GridColumns.NextAppointmentDateTime
            or GridColumns.LastVisitDateTime;

        if (_currentFilterColumn == GridColumns.Gender)
        {
            cbGender.Text = GenderHelper.GenderToString(Gender.Male);
        }
        else
        {
            txtFilterValue.Clear();
        }
    }

    private async void cbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDtoFromUi());
    }

    private async void cbGender_VisibleChanged(object sender, EventArgs e)
    {
        if (cbGender.Visible)
            await LoadGridAsync(GetFilterDtoFromUi());
    }

    private async void txtFilterValue_TextChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDtoFromUi());
    }

    private async void dateTimerPicker_ValueChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDtoFromUi());
    }

    private async void dateTimerPicker_VisibleChanged(object sender, EventArgs e)
    {
        if (dateTimerPicker.Visible)
            await LoadGridAsync(GetFilterDtoFromUi());
    }

    private async void txtFilterValue_VisibleChanged(object sender, EventArgs e)
    {
        if (txtFilterValue.Visible)
            await LoadGridAsync(GetFilterDtoFromUi());
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    private async void btnAddNewPatient_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditPatient();
        await frm.ShowDialogAsync();
        Refresh();
    }

    private async void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentCell?.RowIndex;
        if (!currentRowIndex.HasValue)
            return;

        var patientId = GetPatientIdFromGird(currentRowIndex.Value);
        if (!patientId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditPatient(patientId.Value);
        await frm.ShowDialogAsync();
        Refresh();
    }

    private int? GetPatientIdFromGird(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            return null;

        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colId)].Value;
        if (int.TryParse(cellValue?.ToString(), out int patientId))
            return patientId;

        return null;

    }

    private async void tsmiCreateAppointment_Click(object sender, EventArgs e)
    {
        var patientId = GetSelectedPatientIdFromGrid();
        if (!patientId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditAppointment();
        frm.Id = patientId.Value;
        await frm.ShowDialogAsync();
        Refresh();
    }

    private async void tsmiCreateVisit_Click(object sender, EventArgs e)
    {
        var patientId = GetSelectedPatientIdFromGrid();
        if (!patientId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditVisit(Forms.frmAddEditVisit.VisitType.WalkIn);
        frm.Id = patientId.Value;
        await frm.ShowDialogAsync();
        Refresh();
    }

    private int? GetSelectedPatientIdFromGrid()
    {
        var currentRowIndex = dataGridView.CurrentCell?.RowIndex;
        if (!currentRowIndex.HasValue)
            return null;

        var cellValue = dataGridView.Rows[currentRowIndex.Value]
            .Cells[nameof(colId)].Value;

        if (int.TryParse(cellValue?.ToString(), out int patientId))
            return patientId;

        return null;
    }

    private void tsmiCopyPhoneNumber_Click(object sender, EventArgs e)
    {
        var phoneNumber = GetSelectedPatientPhoneNumberFromGrid();
        if (!string.IsNullOrEmpty(phoneNumber))
        {
            Clipboard.SetText(phoneNumber, TextDataFormat.Text);
        }
    }

    private string? GetSelectedPatientPhoneNumberFromGrid()
    {
        var currentRowIndex = dataGridView.CurrentCell?.RowIndex;
        if (!currentRowIndex.HasValue)
            return null;

        var cellValue = dataGridView.Rows[currentRowIndex.Value]
            .Cells[nameof(colPhoneNumber)].Value;

        return cellValue?.ToString();
    }

    private void tsmiRefresh_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        if (dataGridView.CurrentCell == null
            || dataGridView.CurrentCell.RowIndex < 0
            || dataGridView.CurrentCell.RowIndex >= dataGridView.Rows.Count)
        {
            e.Cancel = true;
            return;
        }

        if (string.IsNullOrWhiteSpace(GetSelectedPatientPhoneNumberFromGrid()))
            tsmiCopyPhoneNumber.Enabled = false;

        var patientId = GetSelectedPatientIdFromGrid();
        if (patientId is not > 0)
        {
            e.Cancel = true;
            tsmiDelete.Enabled = false;
            return;
        }

        var canDelete = await _patientService.CanDeleteAsync(patientId.Value);
        tsmiDelete.Enabled = canDelete.Value;
    }

    private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e is { Button: MouseButtons.Right, RowIndex: >= 0 } && e.RowIndex < dataGridView.Rows.Count)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }

    private async void tsmiDelete_Click(object sender, EventArgs e)
    {
        var patientId = GetSelectedPatientIdFromGrid();
        if (patientId is not > 0)
            return;

        var result = MessageBox.Show(
            "هل أنت متأكد من حذف المريض؟",
            "تأكيد الحذف",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2,
            MessageBoxOptions.RtlReading);

        if (result != DialogResult.Yes)
            return;

        var deleteResult = await _patientService.DeleteAsync(patientId.Value);
        if (!deleteResult.IsSuccess)
        {
            MessageBoxExtensions.ShowError(deleteResult.Error.Message);
            return;
        }

        MessageBoxExtensions.ShowInfo("تم حذف المريض بنجاح.", "تم الحذف");
        Refresh();
    }
}
