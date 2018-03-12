using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsMoney
{
    public enum GameState { Started, InProgress, Concluded }
    class Quiz
    {
        public int QuizID { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Question> QuestionList { get; set; }
        public List<Attempt> AttemptList { get; set; }
        public GameState State { get; set; }
        private int _quizIndex = 0;

        public int QuizIndex
        {
            get
            {
                return this._quizIndex;
            }
        }

        public Quiz()
        {
            CurrentPlayer = new Player() { ID = 0, Name = "John Smith", LivesRemaining = 3, Score = 0 };
            QuestionList = new List<Question>();
            List<Question> allQuestions = new QuestionData().GetQuestions();
            QuestionList = SelectQuestions(allQuestions);
            AttemptList = new List<Attempt>();
        }
        public void WinGame()
        {
            Console.WriteLine("Congratulations cheater, you win the game! Here is your report: ");
            GameReport();
        }

        public void EndGame()
        {
            Console.WriteLine("You lose, heres your report:");
            GameReport();
        }

        private void GameReport()
        {
            Console.WriteLine("You answered the following questions: ");
            foreach (var attempt in AttemptList)
            {
                Console.WriteLine(attempt.QData.Text + ',' + attempt.IsCorrect);
            }
            Console.WriteLine("Your score was : " + CurrentPlayer.Score);
        }
        public Question GetQuestion()
        {
            return (QuestionList[_quizIndex]);
        }
        public void CorrectChoice()
        {
            AttemptList.Add(new Attempt() { QData = QuestionList[_quizIndex], IsCorrect=true });
            Console.WriteLine("Correct Answer, you gain a point");
            CurrentPlayer.Score++;
            if (CurrentPlayer.Score==10)
            {
                WinGame();
            }
            else
            {
                _quizIndex++;
            }

        }
        public void IncorrectChoice()
        {
            AttemptList.Add(new Attempt() { QData = QuestionList[_quizIndex], IsCorrect=false });
            CurrentPlayer.LivesRemaining -= 1;
            if (CurrentPlayer.LivesRemaining == 0)
            {
                EndGame();
            }
            else
            {
                Console.WriteLine("Incorrect answer. you lose a life");
            }
        }
        public void CheckAnswer(int index)
        {
            if (index == QuestionList[_quizIndex].CorrectIndex)
            {
                CorrectChoice();
            }
            else
            {
                IncorrectChoice();
            }
        }

        private List<Question> SelectQuestions(List<Question> SelectQuestions)
        {
            Random rand = new Random();
            List<Question> randomisedQuestions = new List<Question>();
            randomisedQuestions = QuestionList;
            List<Question> levelSpecificQuestions = new List<Question>();

            for (int i = 0; i < 10; i++)
            {
                
                if (i == 0)
                {
                    levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Easy).ToList();
                }
                else if (i == 3)
                {
                    levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Normal).ToList();
                }
                else if (i == 6)
                {
                    levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Hard).ToList();
                }
                else if (i == 8)
                {
                    levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Genius).ToList();
                }

                try
                {
                    Question chosen = levelSpecificQuestions[rand.Next(0, levelSpecificQuestions.Count)];
                    randomisedQuestions.Add(chosen);
                    SelectQuestions.Remove(chosen);
                    levelSpecificQuestions.Remove(chosen);
                }
                catch(Exception e)
                {
                    continue;
                }
                
            }

            if(randomisedQuestions.Count < 10)
            {
                for (int i = randomisedQuestions.Count; i <= 10; i++)
                {
                    Question chosen = SelectQuestions[rand.Next(0, SelectQuestions.Count)];
                    randomisedQuestions.Add(chosen);
                    SelectQuestions.Remove(chosen);
                }
            }

            return randomisedQuestions;
        }
    }
}
