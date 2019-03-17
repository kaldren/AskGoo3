using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskGoo3.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : Controller
    {
    }
}
