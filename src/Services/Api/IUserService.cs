using AskGoo3.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AskGoo3.Services.Api
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
