using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskGoo3.Core.Dtos;
using AskGoo3.Core.Entities.MessageAggregate;
using AskGoo3.Core.Entities.UserAggregate;

namespace AskGoo3.Web
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserDto>();
            CreateMap<Message, MessageDto>();
            CreateMap<List<Message>, List<MessageDto>>();
        }
    }
}
