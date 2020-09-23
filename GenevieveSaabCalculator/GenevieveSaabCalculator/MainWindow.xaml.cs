using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace GenevieveSaabCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = "";
        }

        private void One(object sender, RoutedEventArgs e) //1
        {
            TextBlock.Text = TextBlock.Text + "1";
        }

        private void Two(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "2";
        }

        private void Three(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "3";
        }

        private void Four(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "4";
        }

        private void Five(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "5";
        }

        private void Six(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "6";
        }

        private void Seven(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "7";
        }

        private void Eight(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "8";
        }

        private void Nine(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "9";
        }

        private void Zero(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "0";
        }

        private void Decimal(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + ".";
        }

        private void Plus(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + " + ";
        }

        private void Minus(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + " - ";
        }

        private void Multiply(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + " x ";
        }

        private void Divide(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + " / ";
        }

        private void Remainder(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + " % ";
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            string[] userInput = TextBlock.Text.Split();

            if(userInput.Length != 3)
            {
                TextBlock.Text = "Incorrect Input. Clear and try again.";
                return;
            }

            float left = float.Parse(userInput[0]);
            float right = float.Parse(userInput[2]);

            if(userInput[1].Equals("+"))
            {
                float result = left + right;
                TextBlock.Text = result.ToString();
            }
            else if (userInput[1].Equals("-"))
            {
                float result = left - right;
                TextBlock.Text = result.ToString();
            }
            else if (userInput[1].Equals("x"))
            {
                float result = left * right;
                TextBlock.Text = result.ToString();
            }
            else if (userInput[1].Equals("/"))
            {
                float result = left / right;
                TextBlock.Text = result.ToString();
            }
            else if (userInput[1].Equals("%"))
            {
                float result = left % right;
                TextBlock.Text = result.ToString();
            }

        }

        private void Negative(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = TextBlock.Text + "-";
        }

    }
}
