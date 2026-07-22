using Dental.WinForms.Abstractions;

namespace Dental.WinForms.Views;

public partial class AppointmentsView : UserControl
{
    private readonly IFormFactory _formFactory;

    public AppointmentsView(
        IFormFactory formFactory)
    {
        _formFactory = formFactory;
        InitializeComponent();
    }
}
