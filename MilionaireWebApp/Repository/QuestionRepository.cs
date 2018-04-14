using Microsoft.EntityFrameworkCore;
using MilionaireWebApp.Models;
using MilionaireWebApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.Repository
{
    public class QuestionRepository : AbstractRepository<QuestionModel>
    {
        public QuestionRepository(RestApiDbContext dbContext) : base(dbContext)
        {

        }

        public override IEnumerable<QuestionModel> GetAll()
        {
            return _dbContext.Questions.AsNoTracking().ToArray();
        }

        public override QuestionModel GetById(long id)
        {
            return _dbContext.Questions.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<QuestionModel> GetUnansweredQuestion(long id)
        {
            var answeredQuestions = _dbContext.AnsweredQuestions
                .Include(x => x.User)
                .Include(x => x.Question)
                .AsNoTracking()
                .Where(x => x.User.Id == id)
                .Select(x => x.Question);


            return _dbContext.Questions.AsNoTracking()
                .Where(x => answeredQuestions.
                FirstOrDefault(y => y.Id == x.Id) == null)
                .ToArray();
        }
    }
}
