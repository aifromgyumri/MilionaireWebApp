using MilionaireWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MilionaireWebApp.Utility;

namespace MilionaireWebApp.ViewModels
{
    public class UserQuestionViewModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }

        public IEnumerable<string> Answers { get; set; }

        public static UserQuestionViewModel ToUserQuestionViewModel(QuestionModel questionModel)
        {
            var questionViewModel = new UserQuestionViewModel
            {
                QuestionId=questionModel.Id,
                Question = questionModel.Question,
                Answers=GetAnswersViewQuestionModel(questionModel)
            };
            return questionViewModel;
        }

        private static IEnumerable<string> GetAnswersViewQuestionModel(QuestionModel questionModel)
        {
            var lst = new List<string>
            {
                questionModel.RightAnswer,
                questionModel.WrongAnswer1,
                questionModel.WrongAnswer2,
                questionModel.WrongAnswer3
            };
            return lst.Shuffle();
        }
    }
}
