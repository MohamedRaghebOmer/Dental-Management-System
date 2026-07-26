namespace Dental.WinForms.Extensions;

public static class MessageBoxExtensions
{
    public static void ShowError(string message, string caption = "خطأ")
    {
        MessageBox.Show(
            message,
            caption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RtlReading);
    }

    public static void ShowWarning(string message, string caption = "تحذير")
    {
        MessageBox.Show(
            message,
            caption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RtlReading);
    }

    public static DialogResult ShowQuestion(string question, string caption = "تنبيه")
    {
        return MessageBox.Show(
            question,
            caption,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2,
            MessageBoxOptions.RtlReading);
    }

    public static void ShowInfo(string message, string caption = "ملحوظه")
    {
        MessageBox.Show(
            message,
            caption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RtlReading);
    }
}