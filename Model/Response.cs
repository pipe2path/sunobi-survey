﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace survey.Model
{
    public class Response
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId internalId { get; set; }

        public string responseId { get; set; }
        public int surveyId { get; set; }
        public int questionId { get; set; }
        public int choiceId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
    }
}
