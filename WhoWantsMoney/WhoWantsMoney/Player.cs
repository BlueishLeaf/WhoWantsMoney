using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsMoney
{
    class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Attempt> AttemptList { get; set; }
        public int Score { get; set; }
        public int LivesRemaining { get; set; }
    }
}
