using System.Linq;
using System.Threading.Tasks;
using AskGoo3.Core.Dtos;
using AskGoo3.Core.Entities.User;
using AskGoo3.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskGoo3.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : Controller
    {
        private readonly DatabaseContext _context;

        public IdentityController(DatabaseContext context)
        {
            _context = context;
        }

        //public IActionResult Authenticate([FromBody] LoginUserDto dto)
        //{

        //}

        [HttpGet]
        public async Task<User> Get()
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == 1);
        }
    }
}
