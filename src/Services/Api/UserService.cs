using AskGoo3.Core.Entities.User;
using AskGoo3.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using IdentityModel.Client;
using System.Threading.Tasks;

namespace AskGoo3.Services.Api
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                return null;
            }

            // Token generating
            var client = new HttpClient();

            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:5001/connect/token",

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });

            if (response.IsError)
            {
                throw new Exception(response.Error);
            }

            var token = response.AccessToken;

            user.Token = token;

            return user;
        }
    }
}
