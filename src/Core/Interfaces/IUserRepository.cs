using AskGoo3.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AskGoo3.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignInUserAsync(string username, string password);
    }
}
