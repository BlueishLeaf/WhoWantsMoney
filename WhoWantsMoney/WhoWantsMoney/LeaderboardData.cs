using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsMoney
{
    class LeaderboardData : ILeaderboard
    {
        private JsonControl jsonControl;
        private string path = "";

        public void SaveToLeaderboard(Ranking newRanking)
        {
            jsonControl.WriteJson<Ranking>(this.path, newRanking);
        }

        public List<Ranking> WriteToLeaderboard()
        {
            return jsonControl.ReadJson<List<Ranking>>(this.path);
        }
    }
}
