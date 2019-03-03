using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AskGoo3.Core.Entities.User;
using AskGoo3.Core.Interfaces;
using AskGoo3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AskGoo3.Infrastructure.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> SignInUserAsync(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
