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
    public class ResponseRepository : IResponseRepository
    {
        private readonly DatabaseContext _context = null;

        public ResponseRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<Response>> GetResponses()
        {
            try
            {
                return await _context.Responses.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<Response> GetResponseById(string id)
        //{
        //    return await _context.Responses.Find(r => r.responseId == id).FirstOrDefaultAsync();
        //}

        public async Task AddResponse(Response item)
        {
            try
            {
                await _context.Responses.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddResponseUser(ResponseUser user)
        {
            try
            {
                await _context.ResponseUsers.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

    }


}
