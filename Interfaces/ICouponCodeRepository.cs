using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Interfaces
{
    public interface ICouponCodeRepository
    {
        Task<IEnumerable<CouponCode>> GetCouponCodes();
        Task<CouponCode> GetCouponCodeByCode(int code);
        int CreateCouponCode(int code);

        // add new coupon code document
        Task AddCouponCode(CouponCode item);
        Task<bool> UpdateCoupon(CouponCode item);
        
    }
}
