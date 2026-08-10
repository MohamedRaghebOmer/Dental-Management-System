using System.ComponentModel;

namespace Dental.WinForms.Forms.Dialogs;

public partial class DateTimePickerDialog : Form
{
    public event EventHandler<DateTime>? Result;

    public DateTimePickerDialog()
    {
        InitializeComponent();
        AcceptButton = btnOk;
        CancelButton = btnClose;
    }

    public DateTimePickerDialog(DateTime currentValue, DateTime maxDate)
    {
        InitializeComponent();
        dtpDate.Value = currentValue.Date;
        dtpTime.Value = currentValue;
        MaxDate = maxDate;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DateTime MaxDate
    {
        get => dtpDate.MaxDate;
        set => dtpDate.MaxDate = value;
    }

    protected virtual void OnResult(DateTime e)
    {
        Result?.Invoke(this, e);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        OnResult(dtpDate.Value.Date + dtpTime.Value.TimeOfDay);
        Close();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}