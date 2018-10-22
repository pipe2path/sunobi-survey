using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Interfaces
{ 
    public interface IEntityRepository
    {
        Task<IEnumerable<Entity>> GetEntities();
        Task<Entity> GetEntity(string id);
        Task<bool> UpdateEntity(Entity entity);
    }
}
