using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;
using survey.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace survey.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DatabaseContext _context = null;

        public QuestionRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            try
            {
                return await _context.Questions.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _context.Questions.Find(q => q.questionId == id).FirstOrDefaultAsync();
        }

    }


}
