using MeasuringBehavior.Core.Models.Domain;
using MeasuringBehavior.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.EF.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Question> GetAllQuestions()
        {
            var questions = (from ques in _dbContext.Questions
                                join cho in _dbContext.Choices
                                on ques.QuestionId equals cho.QuestionId
                                group ques by ques.QuestionId into QuestionGroup
                                select new Question
                                {
                                    QuestionId= QuestionGroup.Key,
                                    Name = QuestionGroup.First().Name,
                                    Choices = _dbContext.Choices
                                                .Where(c => c.QuestionId == QuestionGroup.Key).ToList(),
                                }
                           ).ToList();

            return questions;
        }
    }
  }
