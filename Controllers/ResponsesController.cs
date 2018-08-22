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
    //[EnableCors("AllowAllOrigins")]
    public class ResponsesController : Controller
    {
        public IResponseRepository _surveyResponseRepository;
        public ICouponCodeRepository _couponCodeRepository;

        public ResponsesController(IResponseRepository surveyResponseRepository, ICouponCodeRepository couponCodeRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
            _couponCodeRepository = couponCodeRepository;
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

                    // generate random coupon code and insert into couponCode collection
                    int randomNum = GenerateRandomNo();
                    CouponCode coupon = new CouponCode();
                    coupon.userId = newUserId;
                    coupon.code = randomNum;
                    coupon.dateGenerated = DateTime.Today.ToShortDateString();
                    await _surveyResponseRepository.AddCouponCode(coupon);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            int rdmNum = _rdm.Next(_min, _max);
            while (rdmNum == _couponCodeRepository.GetCouponCode(rdmNum))
                rdmNum = _rdm.Next(_min, _max);
            return rdmNum;
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