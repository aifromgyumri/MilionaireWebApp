using MilionaireWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.Utility
{
    public class QuestionModelIdComparer : EqualityComparer<QuestionModel>
    {
        

        public override bool Equals(QuestionModel x, QuestionModel y)
        {
            return x.Id == y.Id;
        }

        public override int GetHashCode(QuestionModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
