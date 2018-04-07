using Microsoft.EntityFrameworkCore;
using MilionaireWebApp.Models;
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
    }
}
