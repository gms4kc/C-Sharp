using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GenevieveSaabPlainTextEditor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// @reference https://social.msdn.microsoft.com/Forums/windows/en-US/f31f34ed-8751-4792-99d6-7c080582d899/uwpxaml-make-a-multiline-textbox-accept-tab?forum=wpdevelop
    ///     lines 37-92 for implementation of tab
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Save.IsEnabled = false; 
            
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //https://social.msdn.microsoft.com/Forums/windows/en-US/f31f34ed-8751-4792-99d6-7c080582d899/uwpxaml-make-a-multiline-textbox-accept-tab?forum=wpdevelop
            if (e.Key == Windows.System.VirtualKey.Tab)
            {
                var textBox = (TextBox)e.OriginalSource;
                var originalStartPosition = textBox.SelectionStart;

                var startPosition = GetRealStartPositionTakingCareOfNewLines(originalStartPosition, textBox.Text);

                var beforeText = textBox.Text.Substring(0, startPosition);
                var afterText = textBox.Text.Substring(startPosition, textBox.Text.Length - startPosition);
                var tabSpaces = 8;
                var tab = new string(' ', tabSpaces);
                textBox.Text = beforeText + tab + afterText;
                textBox.SelectionStart = originalStartPosition + tabSpaces;

                e.Handled = true;
            }
        }

        private int GetRealStartPositionTakingCareOfNewLines(int startPosition, string text)
        {
            //https://social.msdn.microsoft.com/Forums/windows/en-US/f31f34ed-8751-4792-99d6-7c080582d899/uwpxaml-make-a-multiline-textbox-accept-tab?forum=wpdevelop
            int newStartPosition = startPosition;
            int currentPosition = 0;
            bool previousWasReturn = false;
            foreach (var character in text)
            {
                if (character == '\n')
                {
                    if (previousWasReturn)
                    {
                        newStartPosition++;
                    }
                }

                if (newStartPosition <= currentPosition)
                {
                    break;
                }

                if (character == '\r')
                {
                    previousWasReturn = true;
                }
                else
                {
                    previousWasReturn = false;
                }

                currentPosition++;
            }

            return newStartPosition;
        }

        TextDocument[] textDocumentStorage = new TextDocument[1];

        private async void Open_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file == null)
            {
                return;
            }
            
            TextDocument textDocument = new TextDocument(file);
            textDocumentStorage[0] = textDocument;
            if (file != null)
            {
                textDocument.Open(TextBox);
            }
            else
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = "Operation Cancelled.",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await dialog.ShowAsync();
            }
          
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = false;
            textDocumentStorage[0] = null; 
            TextBox.Text = "";
        }

        private async void Exit_Click(object sender, RoutedEventArgs e)
        {
            if(Save.IsEnabled == true)
            {
                ContentDialog Dialog = new ContentDialog
                {
                    Title = "Do you want to save your changes?",
                    Content = "This document has been changed since your last save.",
                    CloseButtonText = "Cancel",
                    PrimaryButtonText = "Save",
                    SecondaryButtonText = "Don't Save"
                };

                ContentDialogResult result = await Dialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    Save_Click(sender, e);
                }
                else if (result == ContentDialogResult.Secondary)
                {
                    Application.Current.Exit();
                }
            }
            else
            { 
                Application.Current.Exit(); 
            }
        }

        private async void About_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "About",
                Content = "This application is a plain text editor created by Genevieve Saab that allows users to open and save text files.",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Save.IsEnabled = true; 
        }

        private async void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //https://docs.microsoft.com/en-us/windows/uwp/files/quickstart-save-a-file-with-a-picker
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

            if (file == null)
            {
                return;
            }

            TextDocument textDocument = new TextDocument(file);
            textDocumentStorage[0] = textDocument;
            if (file != null)
            {
                textDocument.Save(TextBox.Text);
            }
            else
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = "Operation Cancelled.",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await dialog.ShowAsync();
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (textDocumentStorage[0] == null)
            {
                try
                {
                    SaveAs_Click(sender, e);
                }
                catch (Exception ex)
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
            else
            {
                try
                {
                    textDocumentStorage[0].Save(TextBox.Text);
                }
                catch (Exception ex)
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

            Save.IsEnabled = false;
        }
    }
}
