using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;

namespace survey.Interfaces
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> GetResponses();
        //Task<Response> GetResponseById(string id);

        // add new response document
        Task AddResponse(Response item);
        Task AddResponseUser(ResponseUser user);

        
    }
}
