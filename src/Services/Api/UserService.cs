using System;
using System.Net.Http;
using IdentityModel.Client;
using System.Threading.Tasks;
using AskGoo3.Core.Entities.UserAggregate;
using AskGoo3.Core.Interfaces;

namespace AskGoo3.Services.Api
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.SignInUserAsync(username, password);

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
