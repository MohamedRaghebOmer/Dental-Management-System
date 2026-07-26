using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Patient;
using Dental.Application.ViewsStuff.Interfaces.Patients;
using Dental.Domain.Enums;
using Dental.Domain.Views.Patients;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Global.Helpers;

namespace Dental.WinForms.UserControls.Search;

public partial class ctrlSearchPatient : UserControl
{
    private IPatientViewService? _patientViewService = null;
    private IPatientService? _patientService = null;
    private IFormFactory? _formFactory = null;

    private bool _isLoading = true;

    public event EventHandler<PatientResponseDto>? PatientSelected;

    private static class Constants
    {
        public static class cbSearchBy
        {
            public const string Id = "رقم المريض";
            public const string Name = "اسم المريض";
            public const string Age = "السن";
            public const string Gender = "النوع";
            public const string PhoneNumber = "رقم الهاتف";
        }

        public static class cbGender
        {
            public const string Male = "ذكر";
            public const string Female = "أنثى";
        }
    }

    public ctrlSearchPatient()
    {
        InitializeComponent();
        _patientViewService = null;
        _patientService = null;
        _formFactory = null;
    }

    public void Initialize(
        IPatientViewService patientViewService,
        IPatientService patientService,
        IFormFactory fromFactory)
    {
        _patientViewService = patientViewService;
        _patientService = patientService;
        _formFactory = fromFactory;

        dataGridView.AutoGenerateColumns = false;
        dataGridView.DataSource = null;
    }

    private async void ctrlSearchPatient_Load(object sender, EventArgs e)
    {
        ResetUi();
        _isLoading = false;

        await ApplySearchAsync();
    }

    private async Task ApplySearchAsync()
    {
        if (_isLoading || _patientViewService == null)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;

            var patientViewDto = GetFilterDtoFromUi();
            var patients = await _patientViewService.GetAsync(patientViewDto);

            var patientsAfterGenderString = patients
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Age,
                    Gender = p.Gender.HasValue ?
                        GenderHelper.GenderToString(p.Gender.Value)
                        : string.Empty,
                    PhoneNumber = p.PhoneNumber ?? string.Empty
                }).ToList();

            dataGridView.DataSource = patientsAfterGenderString;

            Cursor = Cursors.Default;
        }
        catch (Exception)
        {
            MessageBoxExtensions.ShowError("حدث خطأ اثناء تحميل البيانات.");
        }
    }

    private PatientViewDto? GetFilterDtoFromUi()
    {
        if (string.IsNullOrWhiteSpace(txtSearchValue.Text)
            && cbSearchBy.Text != Constants.cbSearchBy.Gender)
            return null;

        PatientViewDto dto = new();
        var searchValue = txtSearchValue.Text.Trim();

        if (cbSearchBy.Text == Constants.cbSearchBy.Id)
        {
            if (!int.TryParse(searchValue, out int id))
                return null;
            else
                dto.Id = id;
        }
        else if (cbSearchBy.Text == Constants.cbSearchBy.Name)
            dto.Name = searchValue;
        else if (cbSearchBy.Text == Constants.cbSearchBy.Age)
        {
            if (!int.TryParse(searchValue, out int age))
                return null;
            else
                dto.Age = age;
        }
        else if (cbSearchBy.Text == Constants.cbSearchBy.PhoneNumber)
            dto.PhoneNumber = searchValue;
        else if (cbSearchBy.Text == Constants.cbSearchBy.Gender)
            dto.Gender = GenderHelper.GenderFromString(cbGender.Text);

        return dto;
    }

    private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (cbSearchBy.Text is Constants.cbSearchBy.Id
            or Constants.cbSearchBy.Age
            or Constants.cbSearchBy.PhoneNumber)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    protected virtual void OnPatientSelected(PatientResponseDto patient)
    {
        PatientSelected?.Invoke(this, patient);
    }

    private async void btnAddNewPatient_Click(object sender, EventArgs e)
    {
        if (_formFactory == null || _patientService == null)
            return;

        using var frm = _formFactory.Create_frmAddEditPatient();

        frm.PatientAdded += async (s, patientId) =>
        {
            var patientResult = await _patientService.GetByIdAsync(patientId);
            if (patientResult.IsSuccess)
            {
                LoadSinglePatientIntoUi(patientResult.Value);
                OnPatientSelected(patientResult.Value);
            }
        };

        await frm.ShowDialogAsync();
    }

    private void LoadSinglePatientIntoUi(PatientResponseDto patientResultValue)
    {
        _isLoading = true;
        ResetUi();

        dataGridView.DataSource = new List<object>
        {
            new
            {
                Id = patientResultValue.Id,
                Name = patientResultValue.Name,
                Age = patientResultValue.Age,
                Gender = GenderHelper.GenderToString(patientResultValue.Gender),
                PhoneNumber = patientResultValue.PhoneNumber ?? string.Empty
            }
        };

        txtSearchValue.Text = patientResultValue.Name;

        _isLoading = false;
    }

    private void ResetUi()
    {
        cbSearchBy.Text = Constants.cbSearchBy.Name;
        cbGender.Text = Constants.cbGender.Male;

        dataGridView.DataSource = null;
        cbGender.Visible = false;

        txtSearchValue.Visible = true;
        txtSearchValue.Clear();
    }

    private async void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isLoading = true;

        if (cbSearchBy.Text == Constants.cbSearchBy.Gender)
        {
            txtSearchValue.Visible = false;
            cbGender.Visible = true;
        }
        else
        {
            txtSearchValue.Clear();

            txtSearchValue.Visible = true;
            cbGender.Visible = false;
        }

        _isLoading = false;
        await ApplySearchAsync();
    }

    private void txtSearchValue_TextChanged(object sender, EventArgs e)
    {
        filterTimer.Start();
    }

    private async void filterTimer_Tick(object sender, EventArgs e)
    {
        filterTimer.Stop();
        await ApplySearchAsync();
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        var currentPatient = GetSelectedPatientFromGrid();

        if (currentPatient is null
            || !currentPatient.Id.HasValue
            || string.IsNullOrWhiteSpace(currentPatient.Name)
            || !currentPatient.Age.HasValue
            || !currentPatient.Gender.HasValue)
        {
            return;
        }

        var patientResponseDto = new PatientResponseDto(
            currentPatient.Id.Value,
            currentPatient.Name,
            currentPatient.Age.Value,
            currentPatient.Gender.Value,
            currentPatient.PhoneNumber);

        OnPatientSelected(patientResponseDto);
    }

    private PatientViewDto? GetSelectedPatientFromGrid()
    {
        var selectedRowIndex = dataGridView.CurrentRow?.Index;
        if (!selectedRowIndex.HasValue)
            return null;

        return new PatientViewDto
        {
            Id = GetPatientIdFromGrid(selectedRowIndex.Value),
            Name = GetPatientNameFromGrid(selectedRowIndex.Value),
            Age = GetPatientAgeFromGrid(selectedRowIndex.Value),
            Gender = GetPatientGenderFromGrid(selectedRowIndex.Value),
            PhoneNumber = GetPatientPhoneNumberFromGrid(selectedRowIndex.Value)
        };
    }

    private int? GetPatientIdFromGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            return null;

        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colId)].Value;

        if (int.TryParse(cellValue?.ToString(), out int patientId))
            return patientId;

        return null;
    }

    private string? GetPatientNameFromGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            return null;
        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colName)].Value;
        return cellValue?.ToString();
    }

    private int? GetPatientAgeFromGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            return null;
        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colAge)].Value;
        if (int.TryParse(cellValue?.ToString(), out int age))
            return age;
        return null;
    }

    private Gender? GetPatientGenderFromGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            return null;

        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colGender)].Value;
        if (cellValue is null)
            return null;

        return GenderHelper.GenderFromString(cellValue.ToString()!);
    }

    private string? GetPatientPhoneNumberFromGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            return null;
        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colPhoneNumber)].Value;
        return cellValue?.ToString();
    }

    private async void cbGender_VisibleChanged(object sender, EventArgs e)
    {
        if (_isLoading)
            return;

        if (cbGender.Visible)
            await ApplySearchAsync();
    }

    private async void cbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        await ApplySearchAsync();
    }

    private async void tsmiEditPatient_Click(object sender, EventArgs e)
    {
        if (_formFactory == null)
            return;

        var selectedRowIndex = dataGridView.CurrentRow?.Index;
        if (!selectedRowIndex.HasValue)
            return;

        var currentPatientId = GetPatientIdFromGrid(selectedRowIndex.Value);
        if (!currentPatientId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditPatient(currentPatientId.Value);
        await frm.ShowDialogAsync();
    }

    private async void tsmiDeletePatient_Click(object sender, EventArgs e)
    {
        if (_patientService is null)
            return;

        var selectedRowIndex = dataGridView.CurrentRow?.Index;
        if (!selectedRowIndex.HasValue)
            return;

        var currentPatientId = GetPatientIdFromGrid(selectedRowIndex.Value);
        if (!currentPatientId.HasValue)
            return;

        if (MessageBox.Show(
            "هل أنت متأكد من حذف المريض؟ سيتم حذف جميع البيانات المتعلقه بالمريض بما فيها الحجوزات والزيارات.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading) != DialogResult.Yes)
            return;

        var deleteResult = await _patientService.DeleteAsync(currentPatientId.Value);
        if (deleteResult.IsSuccess)
        {
            MessageBoxExtensions.ShowInfo("تم حذف المريض بنجاح.");
            ctrlSearchPatient_Load(null!, null!); // Reload the data after deletion
            return;
        }
    }

    private void tsmiAddPatient_Click(object sender, EventArgs e)
    {
        btnAddNewPatient_Click(null!, null!);
    }

    private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }
}
