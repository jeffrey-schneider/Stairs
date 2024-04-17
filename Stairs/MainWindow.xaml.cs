using System.Windows;

namespace Stairs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string reference_uri = "https://hopific.com/how-to-calculate-stairs-in-architecture/";

        public MainWindow()
        {
            
            InitializeComponent();
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
            MessageBox.Show("\nStairs\n\nVersion 1.0.0");
        }

        private void OpenStairs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nPrint Stairs\n\nVersion 1.0.0");
        }

        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            if(BtnFixedRise.IsChecked == true)
            {
                MessageBox.Show(BtnFixedRise.Content.ToString());
            }
            if(BtnFixedStep.IsChecked == true)
                {
                MessageBox.Show(BtnFixedStep.Content.ToString());
            }
        }
    }
}
