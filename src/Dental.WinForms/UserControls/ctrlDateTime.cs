using Dental.WinForms.Helpers;

namespace Dental.WinForms.UserControls;

public partial class ctrlDateTime : UserControl
{
    public ctrlDateTime()
    {
        InitializeComponent();
        timer.Start();
    }


    private void OnTimerOnTick(object sender, EventArgs e)
    {
        lblDate.Text = DateTimeHelper.GetArabicDate(DateTime.Now);
        lblTime.Text = DateTimeHelper.GetArabicTime(DateTime.Now);
    }
}