using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskGoo3.Core.Dtos;
using AskGoo3.Infrastructure.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskGoo3.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public ProfileController(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{profileId}")]
        [AllowAnonymous]
        public IActionResult GetSingleProfile([FromRoute] int profileId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == profileId);

            if (user == null)
            {
                return BadRequest("Invalid profile id");
            }

            var profileDto = _mapper.Map<UserDto>(user);

            return Json(profileDto);
        }
    }
}
