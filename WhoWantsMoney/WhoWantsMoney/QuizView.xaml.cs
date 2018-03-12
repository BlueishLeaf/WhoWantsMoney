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
            Question currentQ = appInstance.GetQuestion();
            lblQuestion.Content = currentQ.Text;
            btnA.Content = currentQ.Answers[0];
            btnB.Content = currentQ.Answers[1];
            btnC.Content = currentQ.Answers[2];
            btnD.Content = currentQ.Answers[3];
        }

        /// <summary>
        /// Checks which answer was clicked and checks with control if correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            string buttonClicked = clicked.Content.ToString();

            switch (buttonClicked)
            {
                case "btnA":
                    appInstance.CheckAnswer(0);
                    break;
                case "btnB":
                    appInstance.CheckAnswer(1);
                    break;
                case "btnC":
                    appInstance.CheckAnswer(2);
                    break;
                case "btnD":
                    appInstance.CheckAnswer(3);
                    break;
                default:
                    break;
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

            return $"Incorrect! It was actually {correctAnswer}";
        }

        //Close current window and open a new Main menu window
        private void btnReturnHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxPopUp confirmWindow = new MessageBoxPopUp();
            confirmWindow.Owner = this;
            confirmWindow.ShowDialog();
            
        }
    }
}
