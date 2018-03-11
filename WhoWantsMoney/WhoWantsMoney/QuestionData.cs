using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsMoney
{
    class QuestionData : IGetQuestions
    {
        private string path = "";
        private JsonControl jsonControl;

        public List<Question> GetQuestions()
        {
            return jsonControl.ReadJson<List<Question>>(this.path);
        }
    }
}
