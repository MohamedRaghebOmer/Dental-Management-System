using Dental.WinForms.Forms;

namespace Dental.WinForms.Abstractions;

public interface IFormFactory
{
    frmAddUpdateVisit Create_frmAddUpdateVisit();
    frmAddUpdateVisit Create_frmAddUpdateVisit(int visitId);
    frmAddEditTreatment Create_frmAddEditTreatment();
}
