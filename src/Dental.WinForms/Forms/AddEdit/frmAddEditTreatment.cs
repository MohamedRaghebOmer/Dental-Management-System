namespace Dental.WinForms.Forms;

public partial class frmAddEditTreatment : Form
{
    public frmAddEditTreatment()
    {
        InitializeComponent();
    }

    public frmAddEditTreatment(int treatmentId) : this()
    {
        InitializeComponent();
        label1.Text = treatmentId.ToString();
    }
}