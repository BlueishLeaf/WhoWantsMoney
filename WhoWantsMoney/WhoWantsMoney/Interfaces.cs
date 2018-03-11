using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
