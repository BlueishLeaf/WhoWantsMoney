using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WhoWantsMoney
{
    public enum GameState { Started, InProgress, Concluded }

    internal class QuizControl
    {
        public int QuizId { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Question> QuestionList { get; set; }
        public List<Attempt> AttemptList { get; set; }
        public GameState State { get; set; }
        public int QuizIndex { get; set; } = 0;

        public QuizControl()
        {
            State = GameState.Started;
            CurrentPlayer = new Player { Id = 0, Name = "John Smith", LivesRemaining = 3, Score = 0 };
            QuestionList = new List<Question>();
            var allQuestions = new QuestionData().GetQuestions();
            QuestionList = SelectQuestions(allQuestions);
            AttemptList = new List<Attempt>();
            State = GameState.InProgress;
        }
        public void WinGame()
        {
            State = GameState.Concluded;
            var comp = new Completed(CurrentPlayer.Score);
            Application.Current.Windows[0]?.Close();
            comp.Show();
        }

        public void EndGame()
        {
            State = GameState.Concluded;
            var comp = new Completed(CurrentPlayer.Score);
            Application.Current.Windows[0]?.Close();
            comp.Show();

        }

        public Question GetCurrentQuestion() => QuestionList[QuizIndex];

        public void CorrectChoice()
        {
            AttemptList.Add(new Attempt { QData = QuestionList[QuizIndex], IsCorrect=true });
            CurrentPlayer.Score++;
            if (CurrentPlayer.Score==10)
            {
                WinGame();
            }
        }
        public void IncorrectChoice()
        {
            AttemptList.Add(new Attempt { QData = QuestionList[QuizIndex], IsCorrect=false });
            CurrentPlayer.LivesRemaining -= 1;
            if (CurrentPlayer.LivesRemaining == 0)
            {
                EndGame();
            }
        }
        public bool CheckAnswer(int index, out string answer)
        {
            if (index == QuestionList[QuizIndex].CorrectIndex)
            {
                answer = QuestionList[QuizIndex].Answers[QuestionList[QuizIndex].CorrectIndex]; 
                CorrectChoice();
                return true;
            }
            answer = QuestionList[QuizIndex].Answers[QuestionList[QuizIndex].CorrectIndex];
            IncorrectChoice();
            return false;
        }

        private List<Question> SelectQuestions(IList<Question> selectQuestions)
        {
            var rand = new Random();
            var randomisedQuestions = QuestionList;
            var levelSpecificQuestions = new List<Question>();

            for (var i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        levelSpecificQuestions = selectQuestions.Where(x => x.Difficulty == Difficulty.Easy).ToList();
                        break;
                    case 3:
                        levelSpecificQuestions = selectQuestions.Where(x => x.Difficulty == Difficulty.Normal).ToList();
                        break;
                    case 6:
                        levelSpecificQuestions = selectQuestions.Where(x => x.Difficulty == Difficulty.Hard).ToList();
                        break;
                    case 8:
                        levelSpecificQuestions = selectQuestions.Where(x => x.Difficulty == Difficulty.Genius).ToList();
                        break;
                }
                try
                {
                    var chosenQuestion = levelSpecificQuestions[rand.Next(0, levelSpecificQuestions.Count)];
                    randomisedQuestions.Add(chosenQuestion);
                    selectQuestions.Remove(chosenQuestion);
                    levelSpecificQuestions.Remove(chosenQuestion);
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            if (randomisedQuestions.Count >= 10) return randomisedQuestions;
            {
                for (var i = randomisedQuestions.Count; i <= 10; i++)
                {
                    var chosenQuestion = selectQuestions[rand.Next(0, selectQuestions.Count)];
                    randomisedQuestions.Add(chosenQuestion);
                    selectQuestions.Remove(chosenQuestion);
                }
            }
            return randomisedQuestions;
        }
        public int CalculateScore() => CurrentPlayer.Score;
    }
}
