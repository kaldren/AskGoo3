using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskGoo3.Core.Dtos;
using AskGoo3.Infrastructure.Data;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public MessagesController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ShowAllUserMessages()
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == "kdrenski");

            var messages = _context.Messages
                .Where(x => x.Sender == user)
                .Include(x => x.Recipient);

            var messageDto = _mapper.Map<List<MessageDto>>(messages);

            return Json(messageDto);
        }
    }
}
