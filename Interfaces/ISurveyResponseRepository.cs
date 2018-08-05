using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;

namespace survey.Interfaces
{
    public interface ISurveyResponseRepository
    {
        Task<IEnumerable<SurveyResponse>> GetResponses();
        Task<SurveyResponse> GetResponseById(int id);

        // add new response document
        Task AddResponse(SurveyResponse item);

        
    }
}
