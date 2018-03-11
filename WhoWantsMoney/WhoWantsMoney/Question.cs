using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsMoney
{
    public enum Difficulty { Easy, Normal, Hard, Genius}
    class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public Difficulty Difficulty { get; set; }
        public int CorrectIndex { get; set; }
        public Question()
        {
            Answers = new List<string>();
        }
    }
}
