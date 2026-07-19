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

    private async void button1_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditAppointment();
        await frm.ShowDialogAsync();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditAppointment(int.Parse(textBox1.Text));
        await frm.ShowDialogAsync();
    }
}
