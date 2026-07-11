using Dental.Application.Abstractions.ServicesInterfaces;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.Forms;

public partial class frmAddUpdateVisit : Form
{
    private readonly int _id;
    private readonly ITreatmentService _treatmentService;
    private readonly ILogger _logger;

    private enum Mode { Add, Update }
    private Mode _mode = Mode.Add;

    private frmAddUpdateVisit() 
        => InitializeComponent();

    public frmAddUpdateVisit(
        ITreatmentService treatmentService,
        ILogger logger) : this()
    {
        _treatmentService = treatmentService;
        _logger = logger;
        _mode = Mode.Add;
    }

    public frmAddUpdateVisit(
        int id,
        ITreatmentService treatmentService,
        ILogger logger) : this()
    {
        _id = id;
        _treatmentService = treatmentService;
        _logger = logger;
        _mode = Mode.Update;
    }


    private async void AddUpdateVisit_Load(object sender, EventArgs e)
    {
        await InitializeAsync();
        
        if (_mode == Mode.Update)
            LoadVisitData();
    }

    private async Task InitializeAsync()
    {
        this.Text = _mode == Mode.Add ? "اضافة زياره" : "تعديل زياره";
        lblTitile.Text = _mode == Mode.Add ? "اضافة زياره جديده" : "تعديل بيانات زياره";

        try
        {
            var treatments = await _treatmentService.GetAllAsync();
            dgvToothNumAndTreatments.DataSource = treatments.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex, "Error occurred while initializing visit data. Error Occurred in {ClassName}", nameof(frmAddUpdateVisit));
            MessageBox.Show("حدث خطأ أثناء تهيئة بيانات الزياره برجاء التواصل مع المطور.", "خطأ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LoadVisitData()
    {

    }
}