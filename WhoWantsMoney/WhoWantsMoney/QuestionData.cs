using System.Collections.Generic;

namespace WhoWantsMoney
{
    internal class QuestionData : IGetQuestions
    {
        private const string Path = @"../../questions.json";
        private JsonControl _jsonControl;

        public List<Question> GetQuestions()
        {
            _jsonControl = new JsonControl();
            return _jsonControl.ReadJson<List<Question>>(Path);
        }
    }
}
