using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace survey.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatabaseContext _context = null;

        public MessageRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            try
            {
                return await _context.Messages.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Message>> GetMessagesByUser(string id)
        {
            try
            {
                return await _context.Messages.Find(u => u.userId == id).SortByDescending(x => x.dateLastTextSent).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SaveMessage(Message item)
        {
            try
            {
                await _context.Messages.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
