using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SimpleUWPTraineeProject
{
    public static class ConfirmDialog
    {
        public static async Task<bool> AskAsync(string title, string content, string approveButtonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = approveButtonText,
                CloseButtonText = "Відмінити"
            };

            var result = await dialog.ShowAsync();
            return result == ContentDialogResult.Primary;
        }
    }
}
