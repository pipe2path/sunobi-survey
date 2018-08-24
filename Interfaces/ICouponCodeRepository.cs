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
        int GetCouponCode(int code);

        // add new coupon code document
        Task AddCouponCode(CouponCode item);
        Task<bool> UpdateCouponCode(CouponCode item);
        
    }
}
