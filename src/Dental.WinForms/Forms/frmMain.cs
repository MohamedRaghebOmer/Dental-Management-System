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
    private readonly VisitsView _VisitView = default!;
    private readonly PatientsView _patientView = default!;
    private readonly AppointmentsView _appointmentsView = default!;
    private Guna2Button? _selectedButton;

    public frmMain(
        MainMenuView mainMenuView,
        VisitsView visitView,
        PatientsView patientView,
        AppointmentsView appointmentsView)
    {
        InitializeComponent();

        _mainMenuView = mainMenuView;
        _VisitView = visitView;
        _patientView = patientView;
        _appointmentsView = appointmentsView;

        btnMainMenu_Click(null!, null!);
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

    private void btnPatients_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_patientView);
        SelectMenuButton(btnPatients);
        Cursor = Cursors.Default;
    }

    private void btnAppointments_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_appointmentsView);
        SelectMenuButton(btnAppointments);
        Cursor = Cursors.Default;
    }
}