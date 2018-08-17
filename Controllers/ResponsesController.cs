using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using survey.Data;
using survey.Interfaces;
using survey.Model;
using Newtonsoft.Json.Linq;

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

        //[HttpGet("{id}", Name = "GetById")]
        //public async Task<Response> GetById(string id)
        //{
        //    return await _surveyResponseRepository.GetResponseById(id);
        //}

        [HttpPost]
        public async Task Create([FromBody] JsonPayload payload)
        {
            try
            {
                if (payload != null && payload.responseDetails != null)
                {

                    ResponseUser user = new ResponseUser();
                    user.surveyId = payload.surveyId;
                    user.userName = payload.userName;
                    user.userPhone = payload.userPhone;
                    user.userEmail = payload.userEmail;
                    user.optIn = payload.optIn;

                    await _surveyResponseRepository.AddResponseUser(user);

                    // get _id of inserted item
                    var newUserId = user.internalId;

                    // construct response and user objects
                    var responseDetails = payload.responseDetails;
                    foreach (var rd in responseDetails)
                    {
                        Response responseObj = new Response();
                        responseObj.surveyId = rd.surveyId;
                        responseObj.questionId = rd.questionId;
                        responseObj.choiceId = rd.choiceId;
                        responseObj.userId = newUserId;
                        
                        await _surveyResponseRepository.AddResponse(responseObj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class JsonPayload
    {
        public int surveyId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
        public bool optIn { get; set; }
        public Response[] responseDetails { get;set;}
    }
}