﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class UserCoupon : ResponseUser
    {
        public int code { get; set; }

        public UserCoupon() { }
        public UserCoupon(ResponseUser responseUser)
        {
            this.internalId = responseUser.internalId;
            this.userName = responseUser.userName;
            this.userPhone = responseUser.userPhone;
            this.userEmail = responseUser.userEmail;
            this.code = 0;
        }

    }
}