using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GenevieveSaabFinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ChallengeModel challenge = new ChallengeModel();
        CreativeModel creative = new CreativeModel();

        public MainPage()
        {
            this.InitializeComponent();
            Open.IsEnabled = false;
            Save.IsEnabled = false;
            Creative.IsEnabled = false;
        }

        private void CircleMethod() //Determines which circle cake to display
        {
            if (Strawberry.IsChecked == true || Chocolate.IsChecked == true || Vanilla.IsChecked == true)
            {
                if (Red.IsChecked == true || Purple.IsChecked == true)
                {
                    CircleFlavorStripe();
                }
                else
                {
                    CircleFlavor();
                }

            }
            else if (Red.IsChecked == true || Purple.IsChecked == true)
            {
                CircleStripe();
            }
            else
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkCircle.png"));
            }
        }

        private void CircleFlavor() //Determines the color of a circle cake
        {
            if (Strawberry.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkCircle.png"));
            }
            else if (Chocolate.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/ChocolateCircle.png"));
            }
            else if (Vanilla.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/VanillaCircle.png"));
            }
        }

        private void CircleStripe() //Determines stripe color of circle cake
        {
            if (Red.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkCircleRed.png"));
            }
            else if (Purple.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkCirclePurple.png"));
            }
        }

        private void CircleFlavorStripe() //Determines flavor AND stripe color of a circle cake
        {
            if (Strawberry.IsChecked == true)
            {
                if (Red.IsChecked == true)
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkCircleRed.png"));
                }
                else
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkCirclePurple.png"));
                }
            }
            else if (Chocolate.IsChecked == true)
            {
                if (Red.IsChecked == true)
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/ChocolateCircleRed.png"));
                }
                else
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/ChocolateCirclePurple.png"));
                }
            }
            else if (Vanilla.IsChecked == true)
            {
                if (Red.IsChecked == true)
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/VanillaCircleRed.png"));
                }
                else
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/VanillaCirclePurple.png"));
                }
            }
        }

        private void RectangleMethod() //Determines which rectangular cake is displayed
        {
            if (Strawberry.IsChecked == true || Chocolate.IsChecked == true || Vanilla.IsChecked == true)
            {

                if(Red.IsChecked == true || Purple.IsChecked == true)
                {
                    RectangleFlavorStripe();
                }
                else
                {
                    RectangleFlavor();
                }

            }
            else if (Red.IsChecked == true || Purple.IsChecked == true)
            {
                RectangleStripe();
            }
            else
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkRectangle.png"));
            }
        }

        private void RectangleFlavor() //Determines flavor of rectangle cake
        {
            if (Strawberry.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkRectangle.png"));
            }
            else if (Chocolate.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/ChocolateRectangle.png"));
            }
            else if (Vanilla.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/VanillaRectangle.png"));
            }
        }

        private void RectangleStripe() //Determines stripe color of rectangle cake
        {
            if (Red.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkRectangleRed.png"));
            }
            else if (Purple.IsChecked == true)
            {
                CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkRectanglePurple.png"));
            }
        }

        private void RectangleFlavorStripe() //Determines flavor AND stripe color of rectangle cake
        {
            if (Strawberry.IsChecked == true)
            {
                if (Red.IsChecked == true)
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkRectangleRed.png"));
                }
                else
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/PinkRectanglePurple.png"));
                }
            }
            else if (Chocolate.IsChecked == true)
            {
                if (Red.IsChecked == true)
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/ChocolateRectangleRed.png"));
                }
                else
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/ChocolateRectanglePurple.png"));
                }
            }
            else if (Vanilla.IsChecked == true)
            {
                if (Red.IsChecked == true)
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/VanillaRectangleRed.png"));
                }
                else
                {
                    CakeDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/VanillaRectanglePurple.png"));
                }
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e) //Goes to appropriate method based on shape of cake
        {
            if (Circle.IsChecked == true)
            {
                CircleMethod();
            }
            else if(Rectangle.IsChecked == true)
            {
                RectangleMethod();
            }

        }

        private void ClearStripe_Click(object sender, RoutedEventArgs e) //Removes stripe
        {
            RadioButton_Click(sender, e);
        }

        private void HeartTopping_Click(object sender, RoutedEventArgs e) //Adds a heart topping on cake
        {
            if (Circle.IsChecked == true || Rectangle.IsChecked == true)
            {
                Topping.Source = new BitmapImage(new Uri("ms-appx:///Assets/Heart.png"));
               
            }
        }

        private void ClearTopping_Click(object sender, RoutedEventArgs e) //Removes topping
        {
            Topping.Source = null;
        }

        private void Smiley_Click(object sender, RoutedEventArgs e) //Adds a smiley topping on cake
        {
            if (Circle.IsChecked == true || Rectangle.IsChecked == true)
            {
                Topping.Source = new BitmapImage(new Uri("ms-appx:///Assets/Smiley.png"));

            }
        }

        private void Challenge_Click(object sender, RoutedEventArgs e) //Sets up the challenge display mode
        {
            CommentBox.Text = "";

            Open.IsEnabled = true;
            Save.IsEnabled = true;
            Creative.IsEnabled = true;
            Challenge.IsEnabled = false;

            TextBox.Visibility = Visibility.Visible;
            OrderReadyButton.Visibility = Visibility.Visible;
            ScoreLabel.Visibility = Visibility.Visible;
            Points.Visibility = Visibility.Visible;
            OrderNumber.Visibility = Visibility.Visible;
            OrderLabel.Visibility = Visibility.Visible;
            ReminderBox.Visibility = Visibility.Visible;
            CakeDoneButton.Visibility = Visibility.Collapsed;

            OrderNumber.Text = 1.ToString(); ;
            Points.Text = 0.ToString();
            challenge.orderNumber = 1;
            challenge.score = 0;
            TextBox.Text = challenge.Orders[0];
        }

        private void Creative_Click(object sender, RoutedEventArgs e) //Sets up creative display mode
        {
            CommentBox.Text = "";

            Open.IsEnabled = false;
            Save.IsEnabled = false;
            Creative.IsEnabled = false;
            Challenge.IsEnabled = true;

            TextBox.Visibility = Visibility.Collapsed;
            OrderReadyButton.Visibility = Visibility.Collapsed;
            ScoreLabel.Visibility = Visibility.Collapsed;
            Points.Visibility = Visibility.Collapsed;
            OrderNumber.Visibility = Visibility.Collapsed;
            OrderLabel.Visibility = Visibility.Collapsed;
            ReminderBox.Visibility = Visibility.Collapsed;
            CakeDoneButton.Visibility = Visibility.Visible;

            CommentBox.Text = "";
        }

        private void OrderReadyButton_Click(object sender, RoutedEventArgs e) //Event handler when player has completed order in challenge mode
        {

            if (challenge.orderNumber == 11)
            {
                CommentBox.Text = "All orders complete!";
                TextBox.Text = "";
                return;
            }

            bool check = CheckOrder();

            try
            {
                if (check == true) //Switch output based on result of order
                {
                    challenge.orderNumber++;
                    challenge.score += 5;
                    //CommentBox.Text = "";
                    CakeDoneButton_Click(sender, e);

                    if (challenge.orderNumber == 11) //Special case: All orders are complete
                    {
                        CommentBox.Text = "All orders complete!";
                        TextBox.Text = "";
                        Points.Text = challenge.score.ToString();
                        return;
                    }

                    TextBox.Text = challenge.Orders[challenge.orderNumber - 1];
                    OrderNumber.Text = challenge.orderNumber.ToString();
                    Points.Text = challenge.score.ToString();

                }
                else
                {
                    CommentBox.Text = "Try again!";
                }
            }
      
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private async void Error(Exception ex) //Shows an error dialog box
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Error",
                Content = ex.ToString(),
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }

        private bool CheckOrder() //Checks each order based on what number it is to determine if the cake is correct
        {
            if(challenge.orderNumber == 1)
            {
                if(Chocolate.IsChecked == true && Circle.IsChecked == true && Red.IsChecked == false && Purple.IsChecked == false
                        && Heart.IsChecked == false && Smiley.IsChecked == false)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 2)
            {
                if (Strawberry.IsChecked == true && Rectangle.IsChecked == true && Red.IsChecked == false && Purple.IsChecked == false
                        && Heart.IsChecked == false && Smiley.IsChecked == false)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 3)
            {
                if (Vanilla.IsChecked == true && Circle.IsChecked == true && Red.IsChecked == true
                       && Heart.IsChecked == false && Smiley.IsChecked == false)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 4) 
            {
                if (Strawberry.IsChecked == true && Circle.IsChecked == true && Red.IsChecked == false && Purple.IsChecked == false
                       && Heart.IsChecked == true)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 5)
            {
                if (Vanilla.IsChecked == true && Rectangle.IsChecked == true && Red.IsChecked == false && Purple.IsChecked == false
                       && Smiley.IsChecked == true)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 6) 
            {
                if (Strawberry.IsChecked == true && Circle.IsChecked == true && Purple.IsChecked == true
                       && Heart.IsChecked == true)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 7) 
            {
                if (Chocolate.IsChecked == true && Rectangle.IsChecked == true && Red.IsChecked == true
                       && Heart.IsChecked == false && Smiley.IsChecked == false)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 8) 
            {
                if (Vanilla.IsChecked == true && Rectangle.IsChecked == true && Purple.IsChecked == true
                       && Heart.IsChecked == true)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 9) 
            {
                if (Chocolate.IsChecked == true && Circle.IsChecked == true && Purple.IsChecked == true
                       && Heart.IsChecked == true)
                {
                    return true;
                }
            }
            else if(challenge.orderNumber == 10) 
            {
                if (Chocolate.IsChecked == true && Circle.IsChecked == true && Red.IsChecked == true
                       && Smiley.IsChecked == true)
                {
                    return true;
                }
            }

            return false; 
            
        }

        private void Window_Closed(object sender, EventArgs e) //Shuts down resources when app is exited 
        {
            creative.ShutDown();
        }

        private void HowToPlay_Click(object sender, RoutedEventArgs e)
        {
            HowToPlayDialog();
        }

        private async void HowToPlayDialog() //Shows a dialog box with instructions
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Instructions",
                Content = "Creative Mode: Design your cake by clicking the options below! Click the cake done button to get a comment!\n" +
                            "Challenge Mode: Create cakes that match all the customers' orders to win. You can save your points and open them " +
                                "up to continue playing later. Click the order ready button to submit a cake.",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }

        private void About_Click(object sender, RoutedEventArgs e) 
        {
            AboutDialog();
        }

        private async void AboutDialog() //Shows a dialog box with info about the creator
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Information",
                Content = "This game was created by Genevieve Saab! ^-^",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }

        private async void Open_Click(object sender, RoutedEventArgs e) //This method allows a text file to be opened
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file == null)
            {
                return;
            }

            if (file != null)
            {
                Points.Text = await Windows.Storage.FileIO.ReadTextAsync(file);
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

            try
            {
                challenge.score = int.Parse(Points.Text);
                challenge.orderNumber = (int.Parse(Points.Text) / 5) + 1;

                if(challenge.orderNumber == 11)
                {
                    CommentBox.Text = "All orders complete!";
                    TextBox.Text = "";
                    Points.Text = challenge.score.ToString();
                    return;
                }

                CommentBox.Text = "";
                OrderNumber.Text = challenge.orderNumber.ToString();
                TextBox.Text = challenge.Orders[challenge.orderNumber - 1];
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e) //This method allows point values to be saved in a text file
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

            if (file == null)
            {
                return;
            }

            if (file != null)
            {
                challenge.Save(Points.Text, file);
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

        private void CakeDoneButton_Click(object sender, RoutedEventArgs e) //This method displays a positive comment about the user's cake
        {
            try
            {
                ChallengeModel.index++;

                if (ChallengeModel.index > 9)
                {
                    ChallengeModel.index = -1;
                }

                if (ChallengeModel.index == -1)
                {
                    ChallengeModel.index++;
                    CommentBox.Text = ChallengeModel.Comments[0];
                }
                else
                {
                    CommentBox.Text = ChallengeModel.Comments[ChallengeModel.index];
                }

            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }
    }
}
