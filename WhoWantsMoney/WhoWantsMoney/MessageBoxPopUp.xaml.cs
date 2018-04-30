using System.Windows;

namespace WhoWantsMoney
{
    /// <summary>
    /// Interaction logic for MessageBoxPopUp.xaml
    /// </summary>
    public partial class MessageBoxPopUp
    {
        public MessageBoxPopUp() => InitializeComponent();

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            Close();
            Owner.Close();
        }
    }
}
