﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsMoney
{
    class QuestionData : IGetQuestions
    {
        private string path = @"../../questions.json";
        private JsonControl jsonControl;

        public List<Question> GetQuestions()
        {
            jsonControl = new JsonControl();
            return jsonControl.ReadJson<List<Question>>(path);
        }
    }
}
