using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using survey.Interfaces;
using Microsoft.Extensions.Options;
using survey.Model;

namespace survey.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context = null;

        public UserRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<ResponseUser>> GetResponseUsers()
        {
            try
            {
                return await _context.ResponseUsers.Find(o => o.optIn == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
