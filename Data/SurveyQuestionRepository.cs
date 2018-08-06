using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;
using survey.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace survey.Data
{
    public class SurveyQuestionRepository : ISurveyQuestionRepository
    {
        private readonly DatabaseContext _context = null;

        public SurveyQuestionRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<SurveyQuestion>> GetQuestions()
        {
            try
            {
                return await _context.SurveyQuestions.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<SurveyQuestion> GetQuestionById(int id)
        {
            return await _context.SurveyQuestions.Find(q => q.questionId == id).FirstOrDefaultAsync();
        }

    }


}
