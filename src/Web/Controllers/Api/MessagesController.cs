using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskGoo3.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskGoo3.Web.Controllers.Api
{
    [Route("api/[controller]")]
    //[Authorize]
    public class MessagesController : Controller
    {
        private readonly DatabaseContext _context;

        public MessagesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ShowAllUserMessages()
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == "kdrenski");

            var messages = _context.Messages
                .Where(x => x.Sender == user)
                .Include(x => x.Recipient);

            return Json(messages);
        }
    }
}
