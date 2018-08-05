﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace survey.Model
{
    public class SurveyResponse
    {
        //[BsonId]
        // standard BSonId generated by MongoDb
        //public ObjectId InternalId { get; set; }

        public int responseId { get; set; }
        public int entityId { get; set; }
        public int questionId { get; set; }
        public int choiceId { get; set; }
    }
}
