﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace survey.Model
{
    public class SurveyQuestion
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }
                
        public int entityId { get; set; }
        public int surveyId { get; set; }
        public int questionId { get; set; }
        public string questionDesc { get; set; }
        public string questionType { get; set; }
        public string[] choices { get; set; }
        public int activeChoice { get; set; }
    }
}
