using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.ViewsStuff.Interfaces.Appointments;
using Dental.Domain.Enums;
using Dental.Domain.Views.Appointment;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Global.Constants;
using Dental.WinForms.Global.Helpers;
using Dental.WinForms.Helpers;
using System.ComponentModel;

namespace Dental.WinForms.Views;

public partial class AppointmentsView : UserControl
{
    private readonly IFormFactory _formFactory;
    private readonly IAppointmentInfoService _appointmentInfoService;
    private readonly IAppointmentService _appointmentService;

    private bool _isLoading = true;

    private static class Constants
    {
        public static class cbFilterby
        {
            public const string Id = "رقم الحجز";
            public const string PatientId = "رقم المريض";
            public const string PatientName = "اسم المريض";
            public const string CreatedAt = "تاريخ إنشاء الحجز";
            public const string ScheduledVisitDateTime = "تاريخ الزياره المحجوز";
            public const string ActualVisitDateTime = "تاريخ الزياره الفعلي";
            public const string Status = "حالة الزياره";
        }
    }


    private enum GridColumns
    {
        Id,
        PatientId,
        PatientName,
        CreatedAt,
        ScheduledVisitDateTime,
        ActualVisitDateTime,
        Status
    }

    private GridColumns _currentFilterColumn = GridColumns.PatientName;

    public AppointmentsView(
        IFormFactory formFactory,
        IAppointmentInfoService appointmentInfoService,
        IAppointmentService appointmentService)
    {
        InitializeComponent();

        _formFactory = formFactory;
        _appointmentInfoService = appointmentInfoService;
        _appointmentService = appointmentService;

        dataGridView.AutoGenerateColumns = false;
        dataGridView.DataSource = null;
        dataGridView.AlternatingRowsDefaultCellStyle = null;

        _isLoading = true;
    }

    private async void AppointmentsView_Load(object sender, EventArgs e)
    {
        Initilaize();
        _isLoading = false;
    }

    private void Initilaize()
    {
        cbFilterList.Text = Constants.cbFilterby.PatientName;
        _currentFilterColumn = GridColumns.PatientName;

        dateTimePicker.MaxDate = DateTime.Now;
        dtpSearchAfter.MaxDate = DateTime.Now;

        cbAppointmentStatus.Visible = false;
        cbAppointmentStatus.Text = UiStrings.AppointmentStatusStrings.Pending;

        lblSearchAfter.Visible = false;
        dtpSearchAfter.Visible = false;

        txtFilterValue.Clear();
        txtFilterValue.Visible = true;

        rbToday.Checked = false;
        rbThisMonth.Checked = false;
        rbAllTime.Checked = true;

        timerUpdateDateTimePckerMaxDate.Start();
        filterTimer.Start();
        loadDataTimer.Start();
    }

    private async Task LoadDataAsync(AppointmentInfo? filterInfo = null)
    {
        if (_isLoading)
            return;

        Cursor = Cursors.WaitCursor;

        var appointments =
            await _appointmentInfoService.GetAllAppointmentsInfoAsync(filterInfo);

        var dataSource = appointments.Select(a => new
        {
            a.Id,
            a.PatientId,
            a.PatientName,

            CreatedAt = a.CreatedAt.HasValue ?
            DateTimeHelper.GetArabicDateTime(a.CreatedAt.Value) : null,

            ScheduledVisitDateTime = a.ScheduledVisitDateTime.HasValue ?
            DateTimeHelper.GetArabicDateTime(a.ScheduledVisitDateTime.Value) : null,

            ActualVisitDateTime = a.ActualVisitDateTime.HasValue ?
            DateTimeHelper.GetArabicDateTime(a.ActualVisitDateTime.Value)
            : "لم يتم إجراء الزياره بعد",

            Status = a.Status.HasValue ?
            AppointmentStatusHelper.AppointmentStatusToString(a.Status.Value) : null,
        }).ToList();

        dataGridView.DataSource = dataSource;

        LoadCards(appointments);

        Cursor = Cursors.Default;
    }

    private void LoadCards(List<AppointmentInfo> appointments)
    {
        lblTotalAppointments.Text = appointments.Count.ToString();

        lblPendingAppointments.Text = appointments.Count(a => a.Status == Domain.Enums.AppointmentStatus.Pending).ToString();

        lblCompletedAppointment.Text = appointments.Count(a => a.Status == Domain.Enums.AppointmentStatus.Completed).ToString();

        lblMissedAppointments.Text = appointments.Count(a => a.Status == Domain.Enums.AppointmentStatus.Missed).ToString();

        lblCanceledAppointments.Text = appointments.Count(a => a.Status == Domain.Enums.AppointmentStatus.Canceled).ToString();
    }

    private AppointmentInfo GetFilterDto()
    {
        var textFilterValue = txtFilterValue.Text.Trim();
        AppointmentInfo filterDto = new();

        switch (_currentFilterColumn)
        {
            case GridColumns.Id:
                if (int.TryParse(textFilterValue, out int id))
                    filterDto.Id = id;
                break;

            case GridColumns.PatientId:
                if (int.TryParse(textFilterValue, out int patientId))
                    filterDto.PatientId = patientId;
                break;

            case GridColumns.PatientName:
                if (!string.IsNullOrWhiteSpace(textFilterValue))
                    filterDto.PatientName = textFilterValue;
                break;

            case GridColumns.CreatedAt:
                if (dateTimePicker.Visible)
                    filterDto.CreatedAt = dateTimePicker.Value.Date;
                break;

            case GridColumns.ScheduledVisitDateTime:
                if (dateTimePicker.Visible)
                    filterDto.ScheduledVisitDateTime = dateTimePicker.Value.Date;
                break;

            case GridColumns.ActualVisitDateTime:
                if (dateTimePicker.Visible)
                    filterDto.ActualVisitDateTime = dateTimePicker.Value.Date;
                break;

            case GridColumns.Status:
                if (cbAppointmentStatus.Visible && !string.IsNullOrWhiteSpace(cbAppointmentStatus.Text))
                    filterDto.Status =
                        AppointmentStatusHelper.AppointmentStatusFromString(cbAppointmentStatus.Text);
                break;

            default:
                throw new InvalidOperationException("Unknown filter column");
        }

        if (dtpSearchAfter.Visible)
            filterDto.GetAfter = dtpSearchAfter.Value.Date;
        else if (pnlSearchAtRadioButtons.Visible && rbAllTime.Checked)
            filterDto.GetAfter = null;

        return filterDto;
    }

    private void txtFilterValue_TextChanged(object sender, EventArgs e)
    {
        filterTimer.Start();
    }

    private async void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentFilterColumn = cbFilterList.Text switch
        {
            Constants.cbFilterby.Id => GridColumns.Id,
            Constants.cbFilterby.PatientId => GridColumns.PatientId,
            Constants.cbFilterby.PatientName => GridColumns.PatientName,
            Constants.cbFilterby.CreatedAt => GridColumns.CreatedAt,
            Constants.cbFilterby.ScheduledVisitDateTime => GridColumns.ScheduledVisitDateTime,
            Constants.cbFilterby.ActualVisitDateTime => GridColumns.ActualVisitDateTime,
            Constants.cbFilterby.Status => GridColumns.Status,

            _ => throw new InvalidOperationException("Unknown filter column")
        };

        EnableSearchAfter();

        if (_currentFilterColumn is GridColumns.CreatedAt
            or GridColumns.ActualVisitDateTime
            or GridColumns.ScheduledVisitDateTime)
        {
            txtFilterValue.Visible = false;
            dateTimePicker.Visible = true;
            cbAppointmentStatus.Visible = false;
            dateTimePicker.Focus();

            if (_currentFilterColumn is GridColumns.CreatedAt)
                DisableSearchAfter();

            if (_currentFilterColumn is GridColumns.ScheduledVisitDateTime)
                dateTimePicker.MaxDate = new(9998, 12, 31);
            else
                dateTimePicker.MaxDate = DateTime.Now;

            dateTimePicker.Value = DateTime.Now.AddSeconds(-1);
        }
        else if (_currentFilterColumn is GridColumns.Status)
        {
            cbAppointmentStatus.Visible = true;
            txtFilterValue.Visible = false;
            dateTimePicker.Visible = false;

            cbAppointmentStatus.Focus();
            cbAppointmentStatus.Text = UiStrings.AppointmentStatusStrings.Pending;
        }
        else
        {
            txtFilterValue.Visible = true;
            txtFilterValue.Clear();
            txtFilterValue.Focus();

            dateTimePicker.Visible = false;
            cbAppointmentStatus.Visible = false;
        }

        if (rbAllTime.Checked)
        {
            lblSearchAfter.Visible = false;
            dtpSearchAfter.Visible = false;
        }

        await LoadDataAsync(GetFilterDto());
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

    private void raidoButtonsFilterPeriod_CheckedChanged(object sender, EventArgs e)
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

    private void timerUpdateDateTimePckerMaxDate_Tick(object sender, EventArgs e)
    {
        dtpSearchAfter.MaxDate = DateTime.Now;
    }

    private async void loadDataTimer_Tick(object sender, EventArgs e)
    {
        loadDataTimer.Stop();
        await LoadDataAsync();
    }

    private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (_currentFilterColumn is GridColumns.Id or GridColumns.PatientId)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    private async void filterTimer_Tick(object sender, EventArgs e)
    {
        filterTimer.Stop();
        await LoadDataAsync(GetFilterDto());
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    private new void Refresh()
    {
        Cursor = Cursors.WaitCursor;
        _isLoading = true;
        Initilaize();
        _isLoading = false;
        Cursor = Cursors.Default;
    }

    private async void btnAddNewAppointment_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        using var frm = _formFactory.Create_frmAddEditAppointment();
        await frm.ShowDialogAsync();
        Cursor = Cursors.Default;

        Refresh();
    }

    private async void dateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        await LoadDataAsync(GetFilterDto());
    }

    private async void cbAppointmentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        await LoadDataAsync(GetFilterDto());
    }

    private void contextMenuStrip_Opening(
        object sender, CancelEventArgs e)
    {
        int? currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue)
        {
            e.Cancel = true;
            return;
        }

        tsmiShowDetails.Enabled = true;
        tsmiEditAppointment.Enabled = true;
        tsmiStartVisit.Enabled = true;
        tsmiCancelAppointment.Enabled = true;
        tsmiDeleteAppointment.Enabled = true;

        var currentAppStatus = GetAppointmentStatusFromGrid(currentRowIndex.Value);
        switch (currentAppStatus)
        {
            case null:
                e.Cancel = true;
                return;

            case AppointmentStatus.Canceled or AppointmentStatus.Completed:
                tsmiEditAppointment.Enabled = false;
                tsmiStartVisit.Enabled = false;
                tsmiCancelAppointment.Enabled = false;

                if (currentAppStatus == AppointmentStatus.Completed)
                    tsmiDeleteAppointment.Enabled = false;
                break;
        }
    }

    private AppointmentStatus? GetAppointmentStatusFromGrid(int currentRowIndex)
    {
        if (currentRowIndex < 0 || currentRowIndex >= dataGridView.Rows.Count)
            return null;

        var cellValue = dataGridView.Rows[currentRowIndex].Cells[nameof(colStatus)].Value;
        if (cellValue is null)
            return null;

        return AppointmentStatusHelper.AppointmentStatusFromString(cellValue.ToString()!);
    }

    private int? GetAppointmentIdFromGrid(int currentRowIndex)
    {
        if (currentRowIndex < 0 || currentRowIndex >= dataGridView.Rows.Count)
            return null;

        var cellValue = dataGridView.Rows[currentRowIndex].Cells[nameof(colId)].Value;
        if (int.TryParse(cellValue?.ToString(), out int appointmentId))
            return appointmentId;

        return null;
    }

    private int? GetPatientIdFromGrid(int currentRowIndex)
    {
        if (currentRowIndex < 0 || currentRowIndex >= dataGridView.Rows.Count)
            return null;

        var cellValue = dataGridView.Rows[currentRowIndex].Cells[nameof(colPatientId)].Value;
        if (cellValue is null)
            return null;

        if (int.TryParse(cellValue.ToString(), out int patientId))
            return patientId;

        return null;
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

    private async void tsmiShowDetails_Click(object sender, EventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue)
            return;

        var currentAppId = GetAppointmentIdFromGrid(currentRowIndex.Value);
        if (!currentAppId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAppointmentInfo(currentAppId.Value);
        await frm.ShowDialogAsync();
    }

    private async void tsmiEditAppointment_Click(object sender, EventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue)
            return;

        var currentAppId = GetAppointmentIdFromGrid(currentRowIndex.Value);
        if (!currentAppId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditAppointment(currentAppId.Value);
        await frm.ShowDialogAsync();
        Refresh();
    }

    private async void tsmiStartVisit_Click(object sender, EventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue)
            return;

        var currentAppId = GetAppointmentIdFromGrid(currentRowIndex.Value);
        if (!currentAppId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditVisit(
            Forms.frmAddEditVisit.VisitType.PreAppointment);
        frm.Id = currentAppId.Value;
        await frm.ShowDialogAsync();
        Refresh();
    }

    private async void tsmiCancelAppointment_Click(object sender, EventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue)
            return;

        var currentAppId = GetAppointmentIdFromGrid(currentRowIndex.Value);
        if (!currentAppId.HasValue)
            return;

        if (MessageBoxExtensions.ShowQuestion(
            "هل أنت متأكد من إلغاء الحجز؟",
            "تأكيد الإلغاء") != DialogResult.Yes)
            return;

        try
        {
            var cancelResult = await _appointmentService.CancelAsync(currentAppId.Value);
            if (cancelResult.IsSuccess)
            {
                MessageBoxExtensions.ShowInfo("تم إلغاء الحجز بنجاح.");
                Refresh();
            }
            else
            {
                var errorMessage = cancelResult.Error.Code switch
                {
                    "Id.LessThanOrEqualToZero" => "رقم الحجز يجب أن يكون أكبر من الصفر.",
                    "NotFound" => "الحجز غير موجود.",
                    "Status.CannotBeCanceledWhenAlreadyCanceled" => "الحجز ملغي بالفعل.",
                    "Status.CannotBeCanceledWhenCompleted" => $"لا يمكن إلغاء الحجز عندما يكون مكتمل.",
                    _ => $"حدث خطأ أثناء إلغاء الحجز. {cancelResult.Error}"
                };

                MessageBoxExtensions.ShowError(errorMessage);
            }
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError($"حدث خطأ أثناء إلغاء الحجز. {ex.Message}");
        }
    }

    private async void tsmiDeleteAppointment_Click(object sender, EventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue)
            return;

        var currentAppStatus = GetAppointmentStatusFromGrid(currentRowIndex.Value);
        if (currentAppStatus is AppointmentStatus.Completed)
        {
            MessageBoxExtensions.ShowWarning(
                "لا يمكن حذف الحجز إذا كان مكتمل.",
                "تحذير");
            return;
        }

        var currentAppId = GetAppointmentIdFromGrid(currentRowIndex.Value);
        if (!currentAppId.HasValue)
            return;

        if (MessageBoxExtensions.ShowQuestion(
                "هل أنت متأكد من حذف الحجز؟",
                "تأكيد الحذف") != DialogResult.Yes)
            return;

        try
        {
            var deleteResult = await _appointmentService.DeleteAsync(currentAppId.Value);
            if (deleteResult.IsSuccess)
            {
                MessageBoxExtensions.ShowInfo("تم حذف الحجز بنجاح.");
                Refresh();
            }
            else
            {
                var errorMessage = deleteResult.Error.Code switch
                {
                    "Id.LessThanOrEqualToZero" => "رقم الحجز يجب أن يكون أكبر من الصفر.",
                    "NotFound" => "الحجز غير موجود.",
                    _ => $"حدث خطأ أثناء حذف الحجز. {deleteResult.Error}"
                };

                MessageBoxExtensions.ShowError(errorMessage);
            }
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError($"حدث خطأ أثناء حذف الحجز. {ex.Message}");
        }
    }

    private async void dtpSearchAfter_ValueChanged(object sender, EventArgs e)
    {
        await LoadDataAsync(GetFilterDto());
    }

    private async void dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue)
            return;

        var currentAppId = GetAppointmentIdFromGrid(currentRowIndex.Value);
        if (!currentAppId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAppointmentInfo(currentAppId.Value);
        await frm.ShowDialogAsync();
    }
}
