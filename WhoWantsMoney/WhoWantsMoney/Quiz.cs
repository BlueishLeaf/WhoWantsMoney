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

        public Quiz()
        {
            Player newPlayer = new Player() { ID = 0, Name = "John Smith", LivesRemaining = 3 };
            QuestionList = new List<Question>();
            List<Question> allQuestions = new QuestionData().GetQuestions();
            //QuestionList = SelectQuestions(allQuestions);
            QuestionList = allQuestions;
            AttemptList = new List<Attempt>();
        }
        public void StartGame()
        {

        }

        public void EndGame()
        {
            GameReport();
        }

        private void GameReport()
        {

        }
        public Question GetQuestion()
        {
            return (QuestionList[_quizIndex]);
        }
        public void CorrectChoice()
        {
            AttemptList.Add(new Attempt() { QData = QuestionList[_quizIndex] });
            _quizIndex++;
        }
        public void IncorrectChoice()
        {
            AttemptList.Add(new Attempt() { QData = QuestionList[_quizIndex] });
            EndGame();
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

            //for (int i = 0; i < 10; i++)
            //{
            //    List<Question> levelSpecificQuestions = new List<Question>();
            //    if (i == 0)
            //    {
            //        levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Easy).ToList();
            //    }
            //    else if (i == 3)
            //    {
            //        levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Normal).ToList();
            //    }
            //    else if (i == 6)
            //    {
            //        levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Hard).ToList();
            //    }
            //    else if (i == 8)
            //    {
            //        levelSpecificQuestions = SelectQuestions.Where(x => x.Difficulty == Difficulty.Genius).ToList();
            //    }

            //    randomisedQuestions.Add(levelSpecificQuestions[rand.Next(0, levelSpecificQuestions.Count)]);
            //}

            return randomisedQuestions;
        }
    }
}
