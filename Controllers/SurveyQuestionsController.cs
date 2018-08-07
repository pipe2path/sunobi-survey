using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using survey.Data;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[EnableCors("AllowSpecificOrigin")]
    public class SurveyQuestionsController : Controller
    {
        public ISurveyQuestionRepository _surveyQuestionsRepository;
        
        public SurveyQuestionsController(ISurveyQuestionRepository surveyQuestionsRepository)
        {
            _surveyQuestionsRepository = surveyQuestionsRepository;
        }

        //[NoCache]
        [HttpGet]
        public async Task<IEnumerable<SurveyQuestion>> Get()
        {
            return await _surveyQuestionsRepository.GetQuestions();
        }

        [HttpGet("{id}")]
        public async Task<SurveyQuestion> Get(int id)
        {
            return await _surveyQuestionsRepository.GetQuestionById(id);
        }        
    }
}