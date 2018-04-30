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
using System.Windows.Shapes;

namespace WhoWantsMoney
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView : Window
    {
        Quiz appInstance = new Quiz();
        public QuizView()
        {
            InitializeComponent();
            ChangeQuestion();
        }

        public void ChangeQuestion()
        {
            if (appInstance.QuizIndex <= 10)
            {
                Question currentQ = appInstance.GetQuestion();
                lblQuestion.Content = currentQ.Text;
                btnA.Content = currentQ.Answers[0];
                btnB.Content = currentQ.Answers[1];
                btnC.Content = currentQ.Answers[2];
                btnD.Content = currentQ.Answers[3];
            }
            else
            {
                
                Completed resultWindow = new Completed(appInstance.CalculateScore());

                Console.WriteLine("Quiz ends....");

                resultWindow.Show();
                this.Close();
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

            lblLivesRemaining.Content = appInstance.CurrentPlayer.LivesRemaining;
            return $"Incorrect! It was actually {correctAnswer}";

        }

        //Close current window and open a new Main menu window
        private void btnReturnHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxPopUp confirmWindow = new MessageBoxPopUp();
            confirmWindow.Show();
        }


        private void answer_btn_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            Disable();
            string correctAnswerText;
            bool answerCorrect = appInstance.CheckAnswer(int.Parse(clicked.Tag.ToString()), out correctAnswerText);
            if (answerCorrect)
                lblFeedback.Content = FormatFeedback(true, correctAnswerText);
            else
                lblFeedback.Content = FormatFeedback(false, correctAnswerText);
        }

        private void btnNextQ_Click(object sender, RoutedEventArgs e)
        {
            this.appInstance.QuizIndex++;
            lblFeedback.Content = "";
            ChangeQuestion();
            Enable();
        }

        private void Enable()
        {
            btnA.IsEnabled = true;
            btnB.IsEnabled = true;
            btnC.IsEnabled = true;
            btnD.IsEnabled = true;
            btnNextQ.IsEnabled = false;

        }
        private void Disable()
        {
            btnA.IsEnabled = false;
            btnB.IsEnabled = false;
            btnC.IsEnabled = false;
            btnD.IsEnabled = false;
            btnNextQ.IsEnabled = true;

        }

    }
}
