using Dental.WinForms.Forms;

namespace Dental.WinForms.Abstractions;

public interface IFormFactory
{
    frmAddUpdateVisit Create_frmAddUpdateVisit();
    frmAddUpdateVisit Create_frmAddUpdateVisit(int visitId);

    frmAddEditTreatment Create_frmAddEditTreatment();
    frmAddEditTreatment Create_frmAddEditTreatment(int treatmentId);

    frmAddEditPrescription Create_frmAddEditPrescription();
    frmAddEditPrescription Create_frmAddEditPrescription(int visitId);
}
