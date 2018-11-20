using Microsoft.Extensions.Options;
using MongoDB.Driver;
using survey.Interfaces;
using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Data
{
    public class EntityRepository : IEntityRepository
    {
        private readonly DatabaseContext _context = null;

        public EntityRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<Entity>> GetEntities()
        {
            try
            {
                return await _context.Entities.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Entity> GetEntity(string id)
        {
            try
            {
                return await _context.Entities.Find(e => e.entityId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateEntity(Entity item)
        {
            try
            {
                ReplaceOneResult actionResult
                = await _context.Entities
                                .ReplaceOneAsync(c => c.entityId.Equals(item.entityId)
                                        , item
                                        , new UpdateOptions { IsUpsert = false });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
