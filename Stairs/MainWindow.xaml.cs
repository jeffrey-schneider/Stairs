using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;


namespace Stairs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string reference_uri = "https://hopific.com/how-to-calculate-stairs-in-architecture/";
        private Dictionary<Int32, Double> itemsDictionary;

        public MainWindow()
        {
            
            InitializeComponent();
            itemsDictionary = new Dictionary<int, double>();
            
            
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to exit?", "Exit",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if(result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Photo by <a href="https://unsplash.com/@alexbrisbey?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash">Alex Brisbey</a> on <a href="https://unsplash.com/photos/white-wall-paint-stairs-OfZ9g03P-OQ?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash">Unsplash</a>
            
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nStairs\n\nVersion 1.0.1");
        }

        private void OpenStairs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nPrint Stairs\n\nVersion 1.0.1");
        }

        private void OnClick1(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("\nOnClick1 Event Fired\n\n");
            double rise, bottomAdj, topAdj, totalRise, numberRisers, riserTest = 0.0;

            rise = checkInput(TxtRise);
            bottomAdj = checkInput(TxtBottomAdj);
            topAdj = checkInput(TxtTopAdj);
            totalRise = rise - bottomAdj + topAdj;
            TxtTotalRise.Text = totalRise.ToString();
            double minRise = 7.0;
            double maxRise = 8.0;
            double meanRise = ((totalRise / minRise) + (totalRise / maxRise)) / 2.0;
            numberRisers = Math.Round(meanRise, 0);
            TxtNumberRisers.Text = numberRisers.ToString();

            riserTest = totalRise / numberRisers;
            if ((minRise <= riserTest) && (maxRise >= riserTest))
            {
                TxtRiserTest.Background = new SolidColorBrush(Colors.LightGreen);
            }
            TxtRiserTest.Text = riserTest.ToString();

            double runPerStep = checkInput(TxtRunPerStep);
            double totalRun = runPerStep * numberRisers;
            TxtRun.Text = totalRun.ToString();

            double angle = Math.Atan(totalRise / totalRun) / Math.PI * 180.0;

            if((25.0 <= angle) && (angle <= 40)){
                TxtAngle.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                TxtAngle.Background = new SolidColorBrush(Colors.Red);
            }
            TxtAngle.Text = angle.ToString();

            double summaryHeight = 0.0;
            itemsDictionary.Clear();
            for (int i = 0; i < numberRisers; i++)
            {
                summaryHeight += riserTest;
                itemsDictionary.Add(i, summaryHeight);
            }


            FillTheListBox(itemsDictionary, ListItemsBox);
        }

        private void FillTheListBox(Dictionary<int, double> itemsDictionary, ListBox listItemsBox)
        {
            // Clear the ListBox
            listItemsBox.Items.Clear();
            //Use a counter to indicate step number. Users won't understand zero indexed lists.
            int counter = 0;
            //System.Convert.ToDouble(value, CultureInfo.CurrentCulture).
            // Display all items in the dictionary in the ListBox
            foreach (var item in itemsDictionary)
            {
                counter = item.Key + 1;
                //listItemsBox.Items.Add($"{item.Key}: {item.Value:N2}");
                listItemsBox.Items.Add($"{counter}: {item.Value:N2}");
            }
        }

        private double checkInput(TextBox textBoxToCheck)
        {
            double retVal = 0.0;
            while(!double.TryParse(textBoxToCheck.Text, out retVal))
            {
                textBoxToCheck.Clear();
                textBoxToCheck.Focus();
            }
            return retVal;
        }

        
    }
}
