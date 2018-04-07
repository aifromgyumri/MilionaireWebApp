using MilionaireWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.ViewModels
{
    public class QuestionViewModel
    {
        public long Id { get; set; }
        
        [Required]
        public string Question { get; set; }

        [Required]
        public string RightAnswer { get; set; }

        [Required]
        public string WrongAnswer1 { get; set; }

        [Required]
        public string WrongAnswer2 { get; set; }

        [Required]
        public string WrongAnswer3 { get; set; }

        public QuestionModel ToModel()
        {
            return new QuestionModel
            {
                Id = this.Id,
                Question = this.Question,
                WrongAnswer1 = this.WrongAnswer1,
                WrongAnswer2 = this.WrongAnswer2,
                WrongAnswer3 = this.WrongAnswer3,
                RightAnswer = this.RightAnswer,
            };
        }


    }
}
