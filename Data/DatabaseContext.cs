using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using survey.Model;

namespace survey.Data
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _database = null;

        public DatabaseContext(IOptions<Settings> settings)
        {

            var cred = MongoCredential.CreateCredential("feedback", "surveyapp", "sunobi1");
            var sett = new MongoClientSettings
            {
                Server = new MongoServerAddress("ds033047.mlab.com", 33047),
                Credentials = new List<MongoCredential> { cred }
            };

            //var client = new MongoClient(settings.Value.ConnectionString);
            var client = new MongoClient(sett);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Question> Questions
        {
            get
            {
                return _database.GetCollection<Question>("surveyQuestions");
            }
        }
        public IMongoCollection<Response> Responses
        {
            get
            {
                return _database.GetCollection<Response>("surveyResponses");
            }
        }
        public IMongoCollection<ResponseUser> ResponseUsers
        {
            get
            {
                return _database.GetCollection<ResponseUser>("responseUser");
            }
        }

    }
}
