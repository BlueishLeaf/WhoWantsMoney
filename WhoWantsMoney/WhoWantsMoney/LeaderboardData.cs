using System.Collections.Generic;

namespace WhoWantsMoney
{
    internal class LeaderboardData : ILeaderboard
    {
        private JsonControl _jsonControl;
        private const string Path = "";

        public void SaveToLeaderboard(Ranking newRanking) => _jsonControl.WriteJson<Ranking>(Path, newRanking);

        public List<Ranking> WriteToLeaderboard() => _jsonControl.ReadJson<List<Ranking>>(Path);
    }
}
