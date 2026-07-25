using Dental.Application.ViewsStuff.Interfaces.Appointments;
using Dental.Domain.Enums;
using Dental.Domain.Views.Appointment;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Global.Constants;
using Dental.WinForms.Global.Helpers;
using Dental.WinForms.Helpers;

namespace Dental.WinForms.UserControls.Search;

public partial class ctrlSearchAppointment : UserControl
{
    private IFormFactory? _formFactory = null;
    private IAppointmentInfoService? _appointmentInfoService = null;
    private bool _isLoading = true;

    public event EventHandler<ShortAppointmentInfo>? AppointmentSelected;

    private static class Constants
    {
        public static class SearchBy
        {
            public const string AppointmentId = "رقم الحجز";
            public const string PatientId = "رقم المريض";
            public const string PatientName = "اسم المريض";
            public const string ScheduledVisitDateTime = "تاريخ الزياره المحجوز";
            public const string AppointmentStatus = "حالة الحجز";
        }
    }

    private List<ShortAppointmentInfo>? _currentGridData = null;

    public ctrlSearchAppointment()
    {
        InitializeComponent();
        dataGridView.DataSource = null;
        dataGridView.AutoGenerateColumns = false;

        _formFactory = null;
        _appointmentInfoService = null;
    }

    public void Initialize(
        IFormFactory formFactory,
        IAppointmentInfoService appointmentInfoService)
    {
        _formFactory = formFactory;
        _appointmentInfoService = appointmentInfoService;


        _isLoading = true;
        cbSearchBy.Text = Constants.SearchBy.PatientName;
        cbAppointmentStatus.Text =
            AppointmentStatusHelper.AppointmentStatusToString(AppointmentStatus.Pending);

        _isLoading = false;
    }


    private void ctrlSearchAppointment_Load(object sender, EventArgs e)
    {
        ApplyRowSearch();
    }

    private async void ApplyRowSearch()
    {
        if (_appointmentInfoService == null)
            return;

        if (_isLoading)
            return;

        Cursor = Cursors.WaitCursor;

        var filterDto = GetFilterDtoFromUi();

        var data =
            await _appointmentInfoService.GetAllShortAppointmentsInfoAsync(filterDto);

        var dataSource = data.Select(a => new
        {
            a.AppointmentId,
            a.PatientId,
            a.PatientName,
            ScheduledVisitDateTime = a.ScheduledVisitDateTime.HasValue
                ? DateTimeHelper.GetArabicDateTime(a.ScheduledVisitDateTime.Value)
                : string.Empty,
            Status = a.Status.HasValue ? AppointmentStatusHelper.AppointmentStatusToString(a.Status.Value) : string.Empty
        }).ToList();

        if (dataSource.Count > 0)
        {
            _currentGridData = data;
            dataGridView.DataSource = dataSource;
        }
        else
        {
            _currentGridData = null;
            dataGridView.DataSource = null;
        }

        Cursor = Cursors.Default;
    }

    private ShortAppointmentInfo? GetFilterDtoFromUi()
    {
        ShortAppointmentInfo filterDto = new();

        if (cbSearchBy.Text == Constants.SearchBy.AppointmentId)
        {
            if (int.TryParse(txtSearchValue.Text, out int appointmentId))
                filterDto = filterDto with { AppointmentId = appointmentId };
            else
                return null;
        }
        else if (cbSearchBy.Text == Constants.SearchBy.PatientId)
        {
            if (int.TryParse(txtSearchValue.Text, out int patientId))
                filterDto = filterDto with { PatientId = patientId };
            else
                return null;
        }
        else if (cbSearchBy.Text == Constants.SearchBy.PatientName)
        {
            filterDto = filterDto with { PatientName = txtSearchValue.Text.Trim() };
        }
        else if (cbSearchBy.Text == Constants.SearchBy.ScheduledVisitDateTime)
        {
            filterDto = filterDto with { ScheduledVisitDateTime = dtpScheduledVisitDateTime.Value.Date };
        }
        else if (cbSearchBy.Text == Constants.SearchBy.AppointmentStatus)
        {
            filterDto = filterDto with { Status = AppointmentStatusHelper.AppointmentStatusFromString(cbAppointmentStatus.Text) };
        }

        return filterDto;
    }

    private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isLoading = true;
        if (cbSearchBy.Text == Constants.SearchBy.ScheduledVisitDateTime)
        {
            dtpScheduledVisitDateTime.Visible = true;
            dtpScheduledVisitDateTime.Value = DateTime.Today;

            txtSearchValue.Visible = false;
            cbAppointmentStatus.Visible = false;
        }
        else if (cbSearchBy.Text == Constants.SearchBy.AppointmentStatus)
        {
            cbAppointmentStatus.Visible = true;
            cbAppointmentStatus.Text = UiStrings.AppointmentStatusStrings.Pending;
            txtSearchValue.Visible = false;
            dtpScheduledVisitDateTime.Visible = false;
        }
        else
        {
            txtSearchValue.Clear();
            txtSearchValue.Visible = true;
            cbAppointmentStatus.Visible = false;
            dtpScheduledVisitDateTime.Visible = false;
        }

        _isLoading = false;
        ApplyRowSearch();
    }

    private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (cbSearchBy.Text is Constants.SearchBy.AppointmentId or Constants.SearchBy.PatientId)
        {
            // Allow only digits and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        var appointmentRowIndex = dataGridView.CurrentRow?.Index;
        if (appointmentRowIndex is null)
            return;

        // Select the row in the DataGridView
        dataGridView.Rows[appointmentRowIndex.Value].Selected = true;

        var appointmentId = GetAppointmentIdFromGrid(appointmentRowIndex.Value);
        if (appointmentId is { } appointmentIdValue)
        {
            var currentRowData =
                _currentGridData?.FirstOrDefault(
                    a => a.AppointmentId == appointmentIdValue);

            if (currentRowData is null)
            {
                MessageBoxExtensions.ShowError("حدث خطأ أثناء جلب بيانات الحجز", "خطأ");
            }
            else
            {
                OnAppointmentSelected(currentRowData!);
            }
        }
    }

    private int? GetAppointmentIdFromGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            return null;

        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colAppointmentId)].Value;
        if (cellValue is not null && int.TryParse(cellValue?.ToString(), out int appointmentId))
            return appointmentId;

        return null;
    }

    protected virtual void OnAppointmentSelected(ShortAppointmentInfo appointmentInfo)
    {
        AppointmentSelected?.Invoke(this, appointmentInfo);
    }

    private async void btnAddAppointment_Click(object sender, EventArgs e)
    {
        if (_formFactory is null)
            return;

        using var frm = _formFactory.Create_frmAddEditAppointment();
        frm.AppointmentAdded += frmAddEditAppointment_AppointmentAdded;
        await frm.ShowDialogAsync();
    }

    private void frmAddEditAppointment_AppointmentAdded(object? sender, int e)
    {
        cbSearchBy.Text = Constants.SearchBy.AppointmentId;
        dtpScheduledVisitDateTime.Visible = false;
        cbAppointmentStatus.Visible = false;
        txtSearchValue.Visible = true;
        txtSearchValue.Text = e.ToString();

        // Trigger the search after adding a new appointment
        ApplyRowSearch();

        // Select the newly added appointment in the DataGridView
        for (int i = 0; i < dataGridView.Rows.Count; i++)
        {
            var rowAppointmentId = GetAppointmentIdFromGrid(i);
            if (rowAppointmentId == e)
            {
                dataGridView.ClearSelection();
                dataGridView.Rows[i].Selected = true;
                dataGridView.FirstDisplayedScrollingRowIndex = i;
                break;
            }
        }

        // Raise the AppointmentSelected event for the newly added appointment
        var newlyAddedAppointment = _currentGridData?.FirstOrDefault(
            a => a.AppointmentId == e);
        if (newlyAddedAppointment != null)
            OnAppointmentSelected(newlyAddedAppointment);
    }

    private void dtpScheduledVisitDateTime_ValueChanged(object sender, EventArgs e)
    {
        ApplyRowSearch();
    }

    private void cbAppointmentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        ApplyRowSearch();
    }

    private void cbAppointmentStatus_VisibleChanged(object sender, EventArgs eventArgs)
    {
        if (cbAppointmentStatus.Visible)
            ApplyRowSearch();
    }

    private void filterTimer_Tick(object sender, EventArgs e)
    {
        filterTimer.Stop();
        ApplyRowSearch();
    }

    private void txtSearchValue_TextChanged(object sender, EventArgs e)
    {
        filterTimer.Start();
    }
}
