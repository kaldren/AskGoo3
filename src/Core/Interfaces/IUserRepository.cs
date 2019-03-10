using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AskGoo3.Core.Entities.UserAggregate;

namespace AskGoo3.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignInUserAsync(string username, string password);
    }
}
