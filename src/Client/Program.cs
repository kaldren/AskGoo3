using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var client = new HttpClient();

            var response = await client.RequestTokenAsync(new TokenRequest
            {
                Address = "https://localhost:5001/connect/token",
                GrantType = OidcConstants.GrantTypes.ClientCredentials,

                ClientId = "client",
                ClientSecret = "secret",

                Parameters =
                {
                    { "scope", "api1" }
                }
            });

            if (response.IsError)
            {
                throw new Exception(response.Error);
            }

            var token = response.AccessToken;

            Console.WriteLine(response.Json);
            Console.ReadLine();
        }
    }
}
