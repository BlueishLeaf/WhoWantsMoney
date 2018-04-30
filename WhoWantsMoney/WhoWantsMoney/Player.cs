using System.Collections.Generic;

namespace WhoWantsMoney
{
    internal class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Attempt> AttemptList { get; set; }
        public int Score { get; set; }
        public int LivesRemaining { get; set; }
    }
}
