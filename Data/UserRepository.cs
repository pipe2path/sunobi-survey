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

        public async Task<ResponseUser> GetResponseUserByPhone(string phone)
        {
            try
            {
                return await _context.ResponseUsers.Find(p => p.userPhone == phone).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<UserCoupon>> GetCouponList()
        {
            var dateCutOff = DateTime.Today.AddDays(-15);
            
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
                                                           userId = c.userId,
                                                           userName = u.userName,
                                                           userPhone = u.userPhone,
                                                           userEmail = u.userEmail,
                                                           message = c.message,
                                                           code = c.code
                                                       }).ToList();

                // only return users who have not been sent a message in the last 15 days
                List<UserCoupon> filteredUsers = new List<UserCoupon>();
                Message msgSent = new Message();
                foreach (UserCoupon u in userCoupons)
                {
                    var userId = u.userId.ToString();
                    msgSent = (from m in _context.Messages.AsQueryable()
                               where m.userId == userId
                               select m).FirstOrDefault();

                    if (msgSent != null)
                    {
                        if (msgSent.dateLastTextSent <= dateCutOff)
                            filteredUsers.Add(u);
                    }
                    else
                    {
                        filteredUsers.Add(u);
                    }
                }
                
                return filteredUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
