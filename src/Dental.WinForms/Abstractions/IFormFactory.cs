using Dental.WinForms.Forms;
using Dental.WinForms.Forms.AddEdit;
using Dental.WinForms.Forms.Dialogs;

namespace Dental.WinForms.Abstractions;

public interface IFormFactory
{
    frmAddEditVisit Create_frmAddEditVisit(frmAddEditVisit.VisitType visitType);
    frmAddEditVisit Create_frmAddEditVisit(int visitId);

    frmAddEditTreatment Create_frmAddEditTreatment();
    frmAddEditTreatment Create_frmAddEditTreatment(int treatmentId);

    frmAddEditAppointment Create_frmAddEditAppointment();
    frmAddEditAppointment Create_frmAddEditAppointment(int appointmentId);

    frmAddEditPatient Create_frmAddEditPatient();
    frmAddEditPatient Create_frmAddEditPatient(int patientId);

    frmAppointmentInfo Create_frmAppointmentInfo(int appointmentInfo);


    frmAddEditLabTransaction Create_frmAddEditLabTransaction();
    frmAddEditLabTransaction Create_frmAddEditLabTransaction(int labTranId);

    frmAddEditMaterial Create_frmAddEditMaterial();
    frmAddEditMaterial Create_frmAddEditMaterial(int materialId);

    frmAbout Create_frmAbout();

    frmAddEditVisitRadioghraph Create_frmAddEditVisitRadioghraph();
    frmAddEditVisitRadioghraph Create_frmAddEditVisitRadioghraph(int visitRadiographId);

    DateTimePickerDialog Create_DateTimePickerDialog();
    DateTimePickerDialog Create_DateTimePickerDialog(DateTime currentValue, DateTime maxValue);
}
