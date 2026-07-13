using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.Services;
using Dental.Application.ViewsStuff.Interfaces;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Factories;
using Dental.WinForms.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace Dental.WinForms.Views;

public partial class VisitView : UserControl
{
    private readonly IFormFactory _formFactory;

    public VisitView(IFormFactory formFactory)
    {
        InitializeComponent();
        _formFactory = formFactory;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var frm = _formFactory.Create_frmAddUpdateVisit();
        frm.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (int.TryParse(textBox1.Text, out int visitId))
        {
            var frm = _formFactory.Create_frmAddUpdateVisit(visitId);
            frm.Show();
        }
    }
}
