using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AskGoo3.Core.Entities.UserAggregate;

namespace AskGoo3.Services.Api
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
