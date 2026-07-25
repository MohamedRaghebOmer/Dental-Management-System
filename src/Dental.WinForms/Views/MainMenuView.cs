using Dental.WinForms.Abstractions;

namespace Dental.WinForms.Views;

public partial class MainMenuView : UserControl
{
    private readonly IFormFactory _formFactory;

    public MainMenuView(
        IFormFactory formFactory)
    {
        InitializeComponent();
        _formFactory = formFactory;
    }
}
