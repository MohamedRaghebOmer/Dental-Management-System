using Dental.WinForms.Abstractions;
using Dental.WinForms.Forms;
using Dental.WinForms.Forms.AddEdit;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.WinForms.Factories;

public class FormFactory : IFormFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FormFactory(IServiceProvider serviceProvider)
       => _serviceProvider = serviceProvider;


    public frmAddEditVisit Create_frmAddEditVisit(frmAddEditVisit.VisitType visitType)
    {
        return ActivatorUtilities.CreateInstance<frmAddEditVisit>(_serviceProvider, visitType);
    }

    public frmAddEditVisit Create_frmAddEditVisit(int visitId)
    {
        return ActivatorUtilities.CreateInstance<frmAddEditVisit>(_serviceProvider, visitId);
    }


    public frmAddEditTreatment Create_frmAddEditTreatment()
    {
        return _serviceProvider.GetRequiredService<frmAddEditTreatment>();
    }

    public frmAddEditTreatment Create_frmAddEditTreatment(int treatmentId)
    {
        return ActivatorUtilities.CreateInstance<frmAddEditTreatment>(_serviceProvider, treatmentId);
    }


    public frmAddEditAppointment Create_frmAddEditAppointment()
    {
        return _serviceProvider.GetRequiredService<frmAddEditAppointment>();
    }

    public frmAddEditAppointment Create_frmAddEditAppointment(int appointmentId)
    {
        return ActivatorUtilities.CreateInstance<frmAddEditAppointment>(
            _serviceProvider, appointmentId);
    }


    public frmAddEditPatient Create_frmAddEditPatient()
    {
        return _serviceProvider.GetRequiredService<frmAddEditPatient>();
    }

    public frmAddEditPatient Create_frmAddEditPatient(int patientId)
    {
        return ActivatorUtilities.CreateInstance<frmAddEditPatient>
            (_serviceProvider, patientId);
    }


    public frmAppointmentInfo Create_frmAppointmentInfo(int appointmentInfo)
    {
        return ActivatorUtilities.CreateInstance<frmAppointmentInfo>
            (_serviceProvider, appointmentInfo);
    }

    public frmAddEditLabTransaction Create_frmAddEditLabTransaction()
    {
        return _serviceProvider.GetRequiredService<frmAddEditLabTransaction>();
    }

    public frmAddEditLabTransaction Create_frmAddEditLabTransaction(int labTranId)
    {
        return ActivatorUtilities.CreateInstance<frmAddEditLabTransaction>
            (_serviceProvider, labTranId);
    }
}
