using System.Collections.Generic;

namespace MilionaireWebApp.Models
{
    public class QuestionModel
    {
        public long Id { get; set; }

        public string Question { get; set; }

        public string RightAnswer { get; set; }

        public string WrongAnswer1 { get; set; }

        public string WrongAnswer2 { get; set; }

        public string WrongAnswer3 { get; set; }
    }
}