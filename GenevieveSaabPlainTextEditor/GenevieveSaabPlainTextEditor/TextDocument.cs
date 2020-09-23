using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GenevieveSaabPlainTextEditor
{
    class TextDocument
    {
        StorageFile file; 
        public string filePath;

        public TextDocument() { }

        public TextDocument(StorageFile file)
        {
            filePath = file.Path;
            this.file = file; 
        }
        public async void Open(TextBox textBox)
        {
            //https://docs.microsoft.com/en-us/windows/uwp/files/quickstart-reading-and-writing-files
            try
            {
                textBox.Text = await Windows.Storage.FileIO.ReadTextAsync(file);
            }
            catch(Exception ex)
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = ex.ToString(),
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await dialog.ShowAsync();
            }
        }

        public async void Save(String text)
        {
            Windows.Storage.CachedFileManager.DeferUpdates(file);
            await Windows.Storage.FileIO.WriteTextAsync(file, text);
            Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
            if (status == Windows.Storage.Provider.FileUpdateStatus.Complete) { }
            else
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Save Error",
                    Content = "This file couldn't be saved.",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await dialog.ShowAsync();
            }
        }
    }
}
