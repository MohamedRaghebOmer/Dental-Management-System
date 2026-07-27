using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.WinForms.Views;
using Guna.UI2.WinForms;
using Color = System.Drawing.Color;

namespace Dental.WinForms;

public partial class frmMain : Form
{
    private readonly VisitsView _VisitView = default!;
    private readonly PatientsView _patientView = default!;
    private readonly AppointmentsView _appointmentsView = default!;
    private readonly TreatmentsView _treatmentsView = default!;
    private readonly LabTransactionsView _labTransactionsView = default!;
    private readonly MaterialsView _materialsView = default!;
    private readonly SettingsView _settingsView = default!;
    private readonly IDentalInfoService _dentalInfoService;
    private Guna2Button? _selectedButton;

    public frmMain(
        VisitsView visitView,
        PatientsView patientView,
        AppointmentsView appointmentsView,
        TreatmentsView treatmentsView,
        LabTransactionsView labTransactionsView,
        MaterialsView materialsView,
        SettingsView settingsView,
        IDentalInfoService dentalInfoService)
    {
        InitializeComponent();

        _VisitView = visitView;
        _patientView = patientView;
        _appointmentsView = appointmentsView;
        _treatmentsView = treatmentsView;
        _labTransactionsView = labTransactionsView;
        _materialsView = materialsView;
        _settingsView = settingsView;
        _dentalInfoService = dentalInfoService;

        settingsView.SettingsSaved += LoadDentalInfo;
        ctrlProfile1.ControlClicked += ctrlProfile1_ControlClicked;

        btnVisits_Click(null!, null!);
        LoadDentalInfo(null, null);
    }

    private async void LoadDentalInfo(object? sender, SettingsView.SettingsSavedEventArgs? e)
    {
        var dentalInfo = e?.DentalInfo ?? await _dentalInfoService.GetAsync();

        lblDentalName.Text = dentalInfo.DentalName ?? string.Empty;

        SetPictureBoxImage(
            pbDentalImage,
            !string.IsNullOrWhiteSpace(dentalInfo.DentalPicturePath)
            && File.Exists(dentalInfo.DentalPicturePath)
                ? LoadImageFromFile(dentalInfo.DentalPicturePath)
                : Properties.Resources.tooth_512);

        ctrlProfile1.SetDoctorName(dentalInfo.DoctorName);
        ctrlProfile1.SetDoctorImage(
            !string.IsNullOrWhiteSpace(dentalInfo.DoctorPicturePath)
            && File.Exists(dentalInfo.DoctorPicturePath)
                ? LoadImageFromFile(dentalInfo.DoctorPicturePath)
                : Properties.Resources.user_512);

        ctrlProfile1.SetPhoneNumber(dentalInfo.PhoneNumber);
        ctrlProfile1.SetDescription(dentalInfo.DentalDescription);
    }

    private static void SetPictureBoxImage(PictureBox pictureBox, Image image)
    {
        var oldImage = pictureBox.Image;
        pictureBox.Image = new Bitmap(image);
        oldImage?.Dispose();
    }

    private static Image LoadImageFromFile(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var tempImage = Image.FromStream(stream);
        return new Bitmap(tempImage);
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

    private void btnTreatments_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_treatmentsView);
        SelectMenuButton(btnTreatments);
        Cursor = Cursors.Default;
    }

    private void btnLabsTrans_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_labTransactionsView);
        SelectMenuButton(btnLabsTrans);
        Cursor = Cursors.Default;
    }

    private void btnMaterials_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_materialsView);
        SelectMenuButton(btnMaterials);
        Cursor = Cursors.Default;
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        ShowView(_settingsView);
        SelectMenuButton(btnSettings);
        Cursor = Cursors.Default;
    }

    private void ctrlProfile1_ControlClicked(object? sender, EventArgs? e)
    {
        btnSettings_Click(null!, null!);

    }
}