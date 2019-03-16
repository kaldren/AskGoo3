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
using Microsoft.Extensions.Options;

namespace AskGoo3.Web.Controllers.Api
{
    [Route("api/[controller]")]
    //[Authorize]
    public class MessagesController : Controller
    {
        private readonly IOptions<ApiSettings> _appSettings;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        // Settings
        private readonly int _messageContentLength;

        public MessagesController(IOptions<ApiSettings> appSettings, DatabaseContext context, IMapper mapper)
        {
            _appSettings = appSettings;
            _context = context;
            _mapper = mapper;

            // App Settings
            _messageContentLength = appSettings.Value.ShowAllUserMessagesContentLength;
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleMessage([FromRoute] int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == "kdrenski");

            var message = _context.Messages
                .Where(x => x.Id == id && x.Sender.Username == user.Username)
                .Include(x => x.Sender)
                .Include(x => x.Recipient)
                .SingleOrDefault();

            var messageDto = _mapper.Map<MessageDto>(message);

            return Json(messageDto);
        }

        [HttpGet]
        public IActionResult GetAllMessages()
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == "kdrenski");

            var messages = _context.Messages
                .Where(x => x.Sender == user)
                .Include(x => x.Recipient)
                .ToArray();

            var messagesListDto = _mapper.Map<List<MessageDto>>(messages);

            // Return max content allowed by Config settings
            foreach (var message in messagesListDto)
            {
                if (message.Content.Length > _messageContentLength)
                {
                    message.Content = message.Content.Substring(0, _messageContentLength);
                }
            }
            
            return Json(messagesListDto);
        }
    }
}
