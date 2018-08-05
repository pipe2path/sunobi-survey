using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;

namespace survey.Interfaces
{
    public interface ISurveyQuestionRepository
    {
        Task<IEnumerable<SurveyQuestion>> GetQuestions();
        Task<SurveyQuestion> GetQuestionById(int id);
    }
}
