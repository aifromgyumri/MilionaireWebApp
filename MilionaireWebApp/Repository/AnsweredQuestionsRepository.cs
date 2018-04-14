using Microsoft.EntityFrameworkCore;
using MilionaireWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.Repository
{
    public class AnsweredQuestionsRepository : AbstractRepository<AnsweredQuestions>
    {
        public AnsweredQuestionsRepository(RestApiDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<AnsweredQuestions> GetAll()
        {
            return _dbContext.AnsweredQuestions.Include(x=>x.Question).Include(x=>x.User).AsNoTracking().ToArray();
        }

        public override AnsweredQuestions GetById(long id)
        {
            return _dbContext.AnsweredQuestions.Include(x=>x.Question).Include(x=>x.User).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void DeleteAnsweredQuestions(long id)
        {
            var answeredQuestions = _dbContext
                .AnsweredQuestions
                .Include(x => x.Question)
                .Include(x => x.User)
                .AsNoTracking()
                .Where(x => x.User.Id == id);
               
            foreach (var item in answeredQuestions)
            {
                if (item.Question!=null)
                {
                    if (_dbContext.ChangeTracker.Entries<QuestionModel>()
                        .FirstOrDefault(x=>x.Entity.Id==item.Question.Id)==null)
                    {
                        _dbContext.Entry(item.Question).State = EntityState.Unchanged;

                    }
                }
                if (item.User!=null)
                {
                    if (_dbContext.ChangeTracker.Entries<User>()
                        .FirstOrDefault(x => x.Entity.Id == item.User.Id) == null)
                    {

                        _dbContext.Entry(item.User).State = EntityState.Unchanged;
                    }
                }
                _dbContext.Remove(item);
            }
            _dbContext.SaveChanges();
        }

        public override AnsweredQuestions Add(AnsweredQuestions model)
        {
            if (model.Question!=null)
            {
                _dbContext.Entry(model.Question).State = EntityState.Unchanged;
            }

            if (model.User != null)
            {
                _dbContext.Entry(model.User).State = EntityState.Unchanged;
            }
            return base.Add(model);
        }
    }
}
