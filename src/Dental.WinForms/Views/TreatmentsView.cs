using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using System.ComponentModel;

namespace Dental.WinForms.Views;

public partial class TreatmentsView : UserControl
{
    private readonly ITreatmentService _treatmentService;
    private readonly IFormFactory _formFactory;

    private BindingList<TreatmentResponseDto> _treatments = [];
    private bool _isLoading = true;

    public TreatmentsView(
        ITreatmentService treatmentService,
        IFormFactory formFactory)
    {
        InitializeComponent();

        _treatmentService = treatmentService;
        _formFactory = formFactory;

        dataGridView.DataSource = _treatments;
        dataGridView.AlternatingRowsDefaultCellStyle = null;
        dataGridView.AutoGenerateColumns = false;
    }

    private void TreatmentsView_Load(object sender, EventArgs e)
    {
        Initialize();
    }

    private void Initialize()
    {
        _isLoading = true;

        txtSearchValue.Clear();

        _isLoading = false;

        loadDataTimer.Start();
    }

    private async Task LoadGridAsync(string? filterTreatmentName = null)
    {
        if (_isLoading)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var treatments = await _treatmentService.GetAllAsync(filterTreatmentName);

            _treatments = new BindingList<TreatmentResponseDto>(treatments)
            {
                AllowEdit = true,
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true
            };

            dataGridView.DataSource = null;
            dataGridView.DataSource = _treatments;

            lblTreatmentsCount.Text = _treatments.Count.ToString();
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async void loadDataTimer_Tick(object sender, EventArgs e)
    {
        loadDataTimer.Stop();
        await LoadGridAsync();
    }

    private async void txtSearchValue_TextChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(txtSearchValue.Text.Trim());
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        Initialize();
    }

    private async void btnAddNewTreatment_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;

        try
        {
            using var frm = _formFactory.Create_frmAddEditTreatment();
            await frm.ShowDialogAsync();
        }
        finally
        {
            Cursor = Cursors.Default;
        }

        await LoadGridAsync(txtSearchValue.Text.Trim());
    }

    private async void tsmiEdit_Click(object sender, EventArgs e)
    {
        var treatmentId = SelectedTreatmentId;
        if (!treatmentId.HasValue)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            using var frm = _formFactory.Create_frmAddEditTreatment(treatmentId.Value);
            await frm.ShowDialogAsync();
        }
        finally
        {
            Cursor = Cursors.Default;
        }

        await LoadGridAsync(txtSearchValue.Text.Trim());
    }

    private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e is { Button: MouseButtons.Right, RowIndex: >= 0, ColumnIndex: >= 0 } &&
            e.RowIndex < dataGridView.Rows.Count)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }

    private void tsmiAdd_Click(object sender, EventArgs e)
    {
        btnAddNewTreatment_Click(sender, e);
    }

    private async void tsmiDelete_Click(object sender, EventArgs e)
    {
        var id = SelectedTreatmentId;
        if (!id.HasValue)
            return;

        // Show confirmation message
        if (MessageBox.Show(
            "هل أنت متأكد من حذف الخدمه؟",
            "تأكيد الحذف",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2,
            MessageBoxOptions.RtlReading) != DialogResult.Yes)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;

            var deleteResult = await _treatmentService.DeleteAsync(id.Value);

            if (deleteResult.IsFailure)
            {
                if (deleteResult.Error.Code == "InvalidId")
                {
                    MessageBoxExtensions.ShowError("رقم الخدمه يجب أن يكون اكبر من الصفر.");
                }
                else if (deleteResult.Error.Code == "NotFound")
                {
                    MessageBoxExtensions.ShowError("الخدمه غير موجوده.");
                }
                else
                {
                    MessageBoxExtensions.ShowError("حدث خطأ أثناء حذف الخدمه. " + deleteResult.Error.Message);
                }

                return;
            }
        }
        catch (Exception)
        {
            MessageBoxExtensions.ShowError("لا يمكن حذف الخدمه بسبب الزيارات المرتبطه بها.");
        }
        finally
        {
            Cursor = Cursors.Default;
        }

        await LoadGridAsync(txtSearchValue.Text.Trim());
    }

    private void tsmiCopyName_Click(object sender, EventArgs e)
    {
        var name = SelectedTreatmentName;
        if (string.IsNullOrWhiteSpace(name))
            return;

        Clipboard.SetText(name, TextDataFormat.Text);
    }

    private void tsmiRefresh_Click(object sender, EventArgs e)
    {
        Initialize();
    }

    private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        tsmiDelete.Enabled = false;

        var id = SelectedTreatmentId;
        if (id is not > 0)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;

            var canDeleteResult = await _treatmentService.CanDeleteAsync(id.Value);

            if (canDeleteResult.IsFailure)
            {
                if (canDeleteResult.Error.Code == "InvalidId")
                {
                    MessageBoxExtensions.ShowError("رقم الخدمه يجب أن يكون اكبر من الصفر.");
                }
                else if (canDeleteResult.Error.Code == "NotFound")
                {
                    MessageBoxExtensions.ShowError("الخدمه غير موجوده.");
                }
                else
                {
                    MessageBoxExtensions.ShowError("حدث خطأ. " + canDeleteResult.Error.Message);
                }

                return;
            }

            tsmiDelete.Enabled = canDeleteResult.Value;
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        tsmiEdit_Click(sender, e);
    }

    private int? SelectedTreatmentId
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (!currentRowIndex.HasValue)
                return null;

            var cellValue = dataGridView.Rows[currentRowIndex.Value]
                .Cells[nameof(colId)].Value;

            if (int.TryParse(cellValue?.ToString(), out int id))
                return id;

            return null;
        }
    }

    private string? SelectedTreatmentName
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (!currentRowIndex.HasValue)
                return null;

            var cellValue = dataGridView.Rows[currentRowIndex.Value]
                .Cells[nameof(colName)].Value;

            return cellValue?.ToString();
        }
    }
}