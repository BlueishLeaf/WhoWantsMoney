using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoWantsMoney
{
    public enum Difficulty { Easy, Normal, Hard, Genius}

    internal class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Answers { get; set; }

        [JsonConverter(typeof(DifficultyEnumConverter))]
        public Difficulty Difficulty { get; set; }
        public int CorrectIndex { get; set; }
        public Question()
        {
            Answers = new List<string>();
        }
    }
}
