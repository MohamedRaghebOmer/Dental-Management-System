using Dental.Infrastructure.Constants;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Views;
using Guna.UI2.WinForms;
using System.Diagnostics;
using Color = System.Drawing.Color;

namespace Dental.WinForms;

public partial class frmMain : Form
{
    private readonly MainMenuView _mainMenuView = default!;
    private readonly VisitView _VisitView = default!;
    private readonly IFormFactory _formFactory;
    private Guna2Button? _selectedButton;

    public frmMain(
        MainMenuView mainMenuView,
        VisitView visitView,
        IFormFactory formFactory)
    {
        InitializeComponent();

        _mainMenuView = mainMenuView;
        _VisitView = visitView;

        btnMainMenu_Click(null!, null!);
        _formFactory = formFactory;
    }

    private void ShowView(UserControl view)
    {
        view.Dock = DockStyle.Fill;
        pnlView.Controls.Clear();
        pnlView.Controls.Add(view);
    }

    private void SelectMenuButton(Guna2Button button)
    {
        if (_selectedButton != null)
        {
            _selectedButton.FillColor = Color.FromArgb(243, 244, 246);
            _selectedButton.HoverState.FillColor = Color.Gainsboro;
            _selectedButton.ForeColor = Color.FromArgb(55, 65, 81);
        }

        _selectedButton = button;

        _selectedButton.FillColor = Color.DarkTurquoise;
        _selectedButton.HoverState.FillColor = Color.DarkTurquoise;
        _selectedButton.ForeColor = Color.FromArgb(37, 99, 235);
    }

    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_mainMenuView);
        SelectMenuButton(btnMainMenu);
        Cursor = Cursors.Default;
    }

    private void btnVisits_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_VisitView);
        SelectMenuButton(btnVisits);
        Cursor = Cursors.Default;
    }

    private void btnHelp_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = DataStoragePaths.LogsFolderPath,
            UseShellExecute = true
        });
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        if (int.TryParse(textBox1.Text, out int value))
        {
            using var frm = _formFactory.Create_frmAddEditAppointment(value);
            await frm.ShowAsync();
        }
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditAppointment();
        await frm.ShowAsync();
    }
}