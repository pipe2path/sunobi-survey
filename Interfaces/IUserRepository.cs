﻿using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ResponseUser>> GetResponseUsers();
        Task<ResponseUser> GetResponseUserByPhone(string phone);
        Task<IEnumerable<UserCoupon>> GetCouponList();
    }
}
