using Dental.WinForms.Views;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System.Diagnostics;
using System.Windows.Media;
using Dental.Infrastructure.Constants;
using Color = System.Drawing.Color;

namespace Dental.WinForms;

public partial class frmMain : Form
{
    private readonly MainMenuView _mainMenuView = default!;
    private readonly VisitView _VisitView = default!;
    private Guna2Button? _selectedButton;

    public frmMain(
        MainMenuView mainMenuView,
        VisitView visitView)
    {
        InitializeComponent();

        _mainMenuView = mainMenuView;
        _VisitView = visitView;

        btnMainMenu_Click(null!, null!);
    }

    private void ShowView(UserControl view)
    {
        //splitContainer1.Panel2.Controls.Clear();
        view.Dock = DockStyle.Fill;
        splitContainer1.Panel2.Controls.Add(view);
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

        _selectedButton.FillColor = Color.DarkCyan;
        _selectedButton.HoverState.FillColor = Color.DarkCyan;
        _selectedButton.ForeColor = Color.FromArgb(37, 99, 235);
    }

    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ShowView(_mainMenuView);
        SelectMenuButton(btnMainMenu);
    }

    private void btnVisits_Click(object sender, EventArgs e)
    {
        ShowView(_VisitView);
        SelectMenuButton(btnVisits);
    }

    private void btnHelp_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = DataStoragePaths.LogsFolderPath,
            UseShellExecute = true
        });
    }
}