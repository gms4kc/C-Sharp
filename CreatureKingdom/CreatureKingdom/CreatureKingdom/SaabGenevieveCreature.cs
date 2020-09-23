using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Diagnostics;

namespace CreatureKingdom
{
    class SaabGenevieveCreature: Creature 
    {
        Image image = new Image();
        BitmapImage bitmapImage;
        private Thread posnThread = null;

        String imageFilePath = @"SaabGenevieve\left.png";
        public SaabGenevieveCreature(Canvas kingdom, Dispatcher dispatcher, Int32 waitTime = 100) 
            : base(kingdom, dispatcher, waitTime)
        {
            this.kingdom = kingdom;
            this.dispatcher = dispatcher;
            this.WaitTime = waitTime;
            bitmapImage = LoadBitmap(imageFilePath, 200);
            image.Source = bitmapImage;
            kingdom.Children.Add(image);
            InitializeThread();
        }

        void InitializeThread()
        {
            posnThread = new Thread(UpdatePlace);
            posnThread.Start();
        }

        override
        public void Place(double x = 100, double y = 200)
        {
            Action action = () => { image.SetValue(Canvas.LeftProperty, x); image.SetValue(Canvas.TopProperty, y); };
            dispatcher.BeginInvoke(action);
        }

        void UpdatePlace()
        {
            Boolean forward = true;
            Boolean down = true;

            while (true)
            {
                if (Paused == false)
                {
                    int width = Convert.ToInt32(kingdom.ActualWidth);
                    int height = Convert.ToInt32(kingdom.ActualHeight);

                    if (forward == true)
                    {
                        x += 1.0;

                        if (x > (width - 200))
                        {
                            forward = false;
                        }
                    }
                    else
                    {
                        x -= 1.0;

                        if (x < 2)
                        {
                            forward = true; ;
                        }
                    }

                    if (down == true)
                    {
                        y -= 1.0;

                        if (y < 2)
                        {
                            down = false;
                        }
                    }
                    else
                    {
                        y += 1.0;

                        if (y > (height - 200))
                        {
                            down = true; ;
                        }
                    }

                    Place(x, y);
                    Thread.Sleep(WaitTime);
                }
                else
                {
                    continue; 
                }
            }
        }


        override
        public void Shutdown()
        {
            if (posnThread != null)
            {
                posnThread.Abort();
            }
        }


    }
}
