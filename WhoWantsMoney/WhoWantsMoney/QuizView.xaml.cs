using System.Windows;
using System.Windows.Controls;

namespace WhoWantsMoney
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView
    {
        private readonly QuizControl _appInstance = new QuizControl();
        public QuizView()
        {
            InitializeComponent();
            ChangeQuestion();
        }

        public void ChangeQuestion()
        {
            if (_appInstance.QuizIndex <= 10)
            {
                var currentQ = _appInstance.GetCurrentQuestion();
                LblQuestion.Content = currentQ.Text;
                BtnA.Content = currentQ.Answers[0];
                BtnB.Content = currentQ.Answers[1];
                BtnC.Content = currentQ.Answers[2];
                BtnD.Content = currentQ.Answers[3];
            }
            else
            {            
                var resultWindow = new Completed(_appInstance.CalculateScore());
                resultWindow.Show();
                Close();
            }
        }


        /// <summary>
        /// Formats the response for the feedback portion of the question.
        /// </summary>
        /// <param name="answeredCorrectly"></param>
        /// <param name="correctAnswer"></param>
        /// <returns></returns>
        private string FormatFeedback(bool answeredCorrectly, string correctAnswer)
        {
            if (answeredCorrectly)
            {
                return $"Correct! The answer was {correctAnswer}";
            }

            LblLivesRemaining.Content = _appInstance.CurrentPlayer.LivesRemaining;
            return $"Incorrect! It was actually {correctAnswer}";

        }

        //Close current window and open a new Main menu window
        private void BtnReturnHome_Click(object sender, RoutedEventArgs e)
        {
            var confirmWindow = new MessageBoxPopUp(){Owner = this};
            confirmWindow.Show();
        }


        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            var clicked = (Button)sender;
            Disable();
            var answerCorrect = _appInstance.CheckAnswer(int.Parse(clicked.Tag.ToString()), out var correctAnswerText);
            LblFeedback.Content = FormatFeedback(answerCorrect, correctAnswerText);
        }

        private void BtnNextQ_Click(object sender, RoutedEventArgs e)
        {
            _appInstance.QuizIndex++;
            LblFeedback.Content = "";
            ChangeQuestion();
            Enable();
        }

        private void Enable()
        {
            BtnA.IsEnabled = true;
            BtnB.IsEnabled = true;
            BtnC.IsEnabled = true;
            BtnD.IsEnabled = true;
            BtnNextQ.IsEnabled = false;

        }
        private void Disable()
        {
            BtnA.IsEnabled = false;
            BtnB.IsEnabled = false;
            BtnC.IsEnabled = false;
            BtnD.IsEnabled = false;
            BtnNextQ.IsEnabled = true;

        }

    }
}
