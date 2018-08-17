using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        public IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseUser>> Get()
        {
            return await _userRepository.GetResponseUsers();
        }
    }
}