using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class ResponseUser
    {
        [BsonId]
        public ObjectId internalId { get; set; }

        public int surveyId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
    }
}