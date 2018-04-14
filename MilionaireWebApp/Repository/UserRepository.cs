using Microsoft.EntityFrameworkCore;
using MilionaireWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.Repository
{
    public class UserRepository : AbstractRepository<User>
    {

        public UserRepository(RestApiDbContext dbContext) : base(dbContext)
        {

        }

        public override IEnumerable<User> GetAll()
        {
            return _dbContext.Users.AsNoTracking().ToArray();
        }

        public override User GetById(long id)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public bool UsernameExists(string username)
        {
            return _dbContext.Users.AsNoTracking().Count(x => x.Username == username) > 0;
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault(x => x.Username == username);
        }
    }
}
