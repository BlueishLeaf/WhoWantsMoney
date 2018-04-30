using System.Collections.Generic;

namespace WhoWantsMoney
{
    interface IGetQuestions
    {
        List<Question> GetQuestions();
    }

    interface ILeaderboard
    {
        void SaveToLeaderboard(Ranking newRanking);
        List<Ranking> WriteToLeaderboard();
    }
}
