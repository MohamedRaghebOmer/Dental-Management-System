using System.Windows.Forms.VisualStyles;

namespace Dental.WinForms.Extensions;

public static class MessageBoxExtensions
{
    public static void ShowError(string message, string caption = "خطأ")
    {
        MessageBox.Show(
            message, 
            caption,
            MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
    }

    public static void ShowWarning(string message, string caption = "تحذير")
    {
        MessageBox.Show(
            message,
            caption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    /// <summary>
    /// Show a question to the user with Yes and No buttons.
    /// </summary>
    /// <param name="question">
    /// The question asked to the user
    /// </param>
    /// <param name="caption">
    /// Message box caption, default is "تنبيه"
    /// </param>
    /// <returns>
    /// DialogResult.Yes: when the user click the Yes button.
    /// DialogResult.No: when the user click the No button.
    /// </returns>
    public static DialogResult ShowQuestion(string question, string caption = "تنبيه")
    {
        return MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}