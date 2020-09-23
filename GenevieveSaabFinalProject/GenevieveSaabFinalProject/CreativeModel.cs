using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Core;

namespace GenevieveSaabFinalProject
{
    //Royalty Free Music from Bensound: https://www.bensound.com/royalty-free-music/track/jazzy-frenchy
    class CreativeModel
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        private Thread musicThread = null;

        public static List<String> Comments = new List<String>();
        public static int index = -1; 

        public CreativeModel()
        {
            InitializeMediaPlayer();
            InitializeThread();
            InitializeComments();
        }

        private void InitializeComments()
        {
            Comments.Add("Fantastic!");
            Comments.Add("Great job :)");
            Comments.Add("Well done!");
            Comments.Add("Excellent work");
            Comments.Add("Awesome cake!");
            Comments.Add("Super cute ^_^");
            Comments.Add("Wonderful");
            Comments.Add("That looks delicious!");
            Comments.Add("Splendid cake");
            Comments.Add("That's amazing!");
        }

        private void InitializeThread()
        {
            musicThread = new Thread(UpdateMusic);
            musicThread.Start();
        }

        private void InitializeMediaPlayer()
        {
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/bensound-jazzyfrenchy.mp3"));
            mediaPlayer.IsLoopingEnabled = true;
        }

        private void UpdateMusic()
        {
            while (true)
            {
              mediaPlayer.Play();

              Thread.Sleep(10);
            }
        }

        public void ShutDown()
        {
            mediaPlayer.Dispose();

            if (musicThread != null)
            {
                musicThread.Abort();
            }
        }
    }
}

