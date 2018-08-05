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
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        private readonly DatabaseContext _context = null;

        public SurveyResponseRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<SurveyResponse>> GetResponses()
        {
            try
            {
                return await _context.SurveyResponses.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<SurveyResponse> GetResponseById(int id)
        {
            return await _context.SurveyResponses.Find(r => r.responseId == id).FirstOrDefaultAsync();
        }

        public async Task AddResponse(SurveyResponse item)
        {
            try
            {
                await _context.SurveyResponses.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

    }


}
