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
    [Route("api/[Controller]")]
    public class ResponsesController : Controller
    {
        public IResponseRepository _surveyResponseRepository;

        public ResponsesController(IResponseRepository surveyResponseRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Response>> Get()
        {
            return await _surveyResponseRepository.GetResponses();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<Response> GetById(string id)
        {
            return await _surveyResponseRepository.GetResponseById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Response response)
        {
            try
            {
                await _surveyResponseRepository.AddResponse(response);
                var url = Url.Action(" ", "surveyquestions");                       // return a blank questionnaire
                return Content(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}