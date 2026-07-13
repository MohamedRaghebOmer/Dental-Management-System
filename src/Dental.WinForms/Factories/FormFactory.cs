using Dental.WinForms.Abstractions;
using Dental.WinForms.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.WinForms.Factories;

public class FormFactory : IFormFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FormFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public frmAddUpdateVisit Create_frmAddUpdateVisit()
    {
        return _serviceProvider.GetRequiredService<frmAddUpdateVisit>();
    }

    public frmAddUpdateVisit Create_frmAddUpdateVisit(int visitId)
    {
        return ActivatorUtilities.CreateInstance<frmAddUpdateVisit>(_serviceProvider, visitId);
    }

    public frmAddEditTreatment Create_frmAddEditTreatment()
    {
        return _serviceProvider.GetRequiredService<frmAddEditTreatment>();
    }
}
