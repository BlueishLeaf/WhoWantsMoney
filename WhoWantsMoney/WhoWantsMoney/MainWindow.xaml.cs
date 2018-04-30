using System.Windows;

namespace WhoWantsMoney
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainScreen = new QuizView();
            mainScreen.Show();
            Close();
        }
    }
}
