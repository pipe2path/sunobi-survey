using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    public class UsersController : Controller
    {
        public IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<IEnumerable<ResponseUser>> Get()
        {
            return await _userRepository.GetResponseUsers();
        }

        [Route("api/users/couponlist")]
        public async Task<IEnumerable<UserCoupon>> GetCouponList()
        {
            return await _userRepository.GetCouponList();
        }
    }
}