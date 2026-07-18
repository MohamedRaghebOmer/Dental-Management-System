using Dental.WinForms.Forms;

namespace Dental.WinForms.Abstractions;

public interface IFormFactory
{
    frmAddUpdateVisit Create_frmAddUpdateVisit();
    frmAddUpdateVisit Create_frmAddUpdateVisit(int visitId);

    frmAddEditTreatment Create_frmAddEditTreatment();
    frmAddEditTreatment Create_frmAddEditTreatment(int treatmentId);

    frmAddEditPrescription Create_frmAddEditPrescription();
    frmAddEditPrescription Create_frmAddEditPrescription(int prescriptionId);

    frmAddEditAppointment Create_frmAddEditAppointment();
    frmAddEditAppointment Create_frmAddEditAppointment(int appointmentId);

    frmAddEditPatient Create_frmAddEditPatient();
    frmAddEditPatient Create_frmAddEditPatient(int patientId);
}
