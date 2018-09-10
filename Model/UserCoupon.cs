using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class UserCoupon : ResponseUser
    {
        [BsonId]
        public ObjectId userId { get; set; }
        public string message { get; set; }
        public int code { get; set; }

        public UserCoupon() { }
        public UserCoupon(ResponseUser responseUser)
        {
            this.internalId = responseUser.internalId;
            this.userId = new ObjectId();
            this.userName = responseUser.userName;
            this.userPhone = responseUser.userPhone;
            this.userEmail = responseUser.userEmail;
            this.message = "";
            this.code = 0;
        }

    }
}
