using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace GenevieveSaabFinalProject
{
    class ChallengeModel: CreativeModel
    {
        public List<String> Orders = new List<String>();
        public int orderNumber = 1;
        public int score = 0;

        public ChallengeModel()
        {
            InitializeOrders();
        }

        void InitializeOrders()
        {
            Orders.Add("A circle chocolate cake please!");
            Orders.Add("I'd like a strawberry rectangular cake.");
            Orders.Add("Can I get a vanilla circle with a red stripe?");
            Orders.Add("Get me a strawberry circle cake with a heart on top!");
            Orders.Add("I need a vanilla rectangle cake. Don't forget the smiley.");
            Orders.Add("Can I have a strawberry circle with a purple stripe and a heart?");
            Orders.Add("I want a chocolate rectangle cake. I also would love a red stripe.");
            Orders.Add("Vanilla. Square. Purple. Heart.");
            Orders.Add("Heeeeeeey ^_^ Can you get me a chocolate circle cake!! Don't forget my favorite color is purple!! Do you have any romantic cake toppers?");
            Orders.Add("Make me something chocolaty. I hate anything with angles. Something red and something happy would be nice details.");
        }


        public async void Save(String text, StorageFile file)
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
