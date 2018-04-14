using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.Models
{
    public class AnsweredQuestions
    {
        public long Id { get; set; }

        public QuestionModel Question { get; set; }

        public User User { get; set; }
    }
}
