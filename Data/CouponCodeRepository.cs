using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;
using survey.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace survey.Data
{
    public class CouponCodeRepository : ICouponCodeRepository
    {
        private readonly DatabaseContext _context = null;

        public CouponCodeRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<IEnumerable<CouponCode>> GetCouponCodes()
        {
            try
            {
                return await _context.CouponCodes.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCouponCode(int code)
        {
            try
            {
                var returnCode = 0;
                CouponCode couponCode = _context.CouponCodes.Find(r => r.code == code).FirstOrDefault();
                if (couponCode != null)
                    returnCode = couponCode.code;

                return returnCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddCouponCode(CouponCode item)
        {
            try
            {
                await _context.CouponCodes.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
