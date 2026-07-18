namespace Dental.WinForms.Forms;

public partial class frmAddEditAppointment : Form
{
    public frmAddEditAppointment()
    {
        InitializeComponent();
    }

    public frmAddEditAppointment(
        int appointmentId) : this()
    {
        Text = appointmentId.ToString();
    }
}
