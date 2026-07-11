using Dental.WinForms.Helpers;
using System.Timers;

namespace Dental.WinForms.UserControls;

public partial class ctrlDateTime : UserControl
{
    public ctrlDateTime()
    {
        InitializeComponent();

        lblDate.Text = DateHelper.GetArabicDate(DateTime.Now);

        timer.Start();
        timer.Tick += (_, _) => lblTime.Text = DateTime.Now.ToString("hh:mm tt");
    }
}