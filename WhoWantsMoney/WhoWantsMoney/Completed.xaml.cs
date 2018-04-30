using System.Windows;

namespace WhoWantsMoney
{
    /// <summary>
    /// Interaction logic for Completed.xaml
    /// </summary>
    public partial class Completed : Window
    {
        int result;
        public Completed(int _result)
        {
            InitializeComponent();

            result = _result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblResult.Content = $"{result} / 12";
        }

        private void btnReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();

            main.Show();
            this.Close();
        }
    }
}
