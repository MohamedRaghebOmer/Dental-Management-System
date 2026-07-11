using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.WinForms.Forms;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.Views
{
    public partial class VisitView : UserControl
    {
        private readonly ITreatmentService _treatmentService;
        private readonly ILogger _logger;

        public VisitView(ITreatmentService treatmentService,
            ILogger<VisitView> logger)
        {
            InitializeComponent();

            _treatmentService = treatmentService;
            _logger = logger;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmAddUpdateVisit(_treatmentService, _logger);
            frm.Show();
        }
    }
}
