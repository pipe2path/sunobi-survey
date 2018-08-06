﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using survey.Data;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SurveyResponsesController : Controller
    {
        public ISurveyResponseRepository _surveyResponseRepository;

        public SurveyResponsesController(ISurveyResponseRepository surveyResponseRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SurveyResponse>> Get()
        {
            return await _surveyResponseRepository.GetResponses();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<SurveyResponse> GetById(int id)
        {
            return await _surveyResponseRepository.GetResponseById(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SurveyResponse response)
        {
            try
            {
                _surveyResponseRepository.AddResponse(response);
                return CreatedAtRoute("GetById", new { id = response.responseId }, response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}