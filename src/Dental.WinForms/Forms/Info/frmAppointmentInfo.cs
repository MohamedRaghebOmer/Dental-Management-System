using Dental.Application.ViewsStuff.Interfaces;
using Dental.WinForms.Extensions;

namespace Dental.WinForms.Forms;

public partial class frmAppointmentInfo : Form
{
    private readonly int _appointmentId;
    private readonly IAppointmentInfoService _appointmentInfoService;

    public frmAppointmentInfo(
        int appointmentId,
        IAppointmentInfoService appointmentInfoService)
    {
        InitializeComponent();
        _appointmentId = appointmentId;
        _appointmentInfoService = appointmentInfoService;

        ctrlAppointmentInfo1.WhenAppointmentIsNotFound += (s, args) => Close();
    }

    private void frmAppointmentInfo_Load(object sender, EventArgs e)
    {
        if (_appointmentId <= 0)
        {
            MessageBoxExtensions.ShowError("رقم الحجز يجب ان يكون اكبر من الصفر.");
            Close();
            return;
        }

        ctrlAppointmentInfo1.Initialize(_appointmentId, _appointmentInfoService);
    }
}
