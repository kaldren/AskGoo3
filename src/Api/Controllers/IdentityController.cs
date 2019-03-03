using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskGoo3.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content("Hello World!");
        }
    }
}
