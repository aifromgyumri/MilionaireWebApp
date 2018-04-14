using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.Models
{
    public class RestApiDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Databases\\questions.db");
        }
        

        public DbSet<QuestionModel> Questions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AnsweredQuestions> AnsweredQuestions { get; set; }
    }
}
