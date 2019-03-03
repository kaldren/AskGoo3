using System.Linq;
using System.Threading.Tasks;
using AskGoo3.Core.Dtos;
using AskGoo3.Core.Entities.User;
using AskGoo3.Services.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskGoo3.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<User> Authenticate([FromBody] LoginUserDto dto)
        {
            return await _userService.AuthenticateAsync(dto.Username, dto.Password);
        }

        [HttpGet]
        public async Task<User> Get()
        {
            //return await _context.Users.SingleOrDefaultAsync(u => u.Id == 1);
            return null;
        }
    }
}
