using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using survey.Interfaces;
using Microsoft.Extensions.Options;
using survey.Model;

namespace survey.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context = null;

        public UserRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<ResponseUser>> GetResponseUsers()
        {
            try
            {
                return await _context.ResponseUsers.Find(o => o.optIn == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserCoupon>> GetCouponList()
        {
            try
            {
                // get a join of responseUser and couponcode based on userid
                IEnumerable<UserCoupon> userCoupons = (from c in _context.CouponCodes.AsQueryable()
                                                       join u in _context.ResponseUsers.AsQueryable()
                                                         on c.userId equals u.internalId
                                                       where (u.optIn == true)
                                                       select new UserCoupon
                                                       {
                                                           internalId = u.internalId,
                                                           userName = u.userName,
                                                           userPhone = u.userPhone,
                                                           userEmail = u.userEmail,
                                                           code = c.code
                                                       }).ToList();
                return userCoupons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
