using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using Newtonsoft.Json.Linq;

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

            Console.WriteLine($"Token: ${response.Json}");

            var client2 = new HttpClient();
            client2.SetBearerToken(token);

            var response2 = await client2.GetAsync("https://localhost:6001/identity");

            if (!response2.IsSuccessStatusCode)
            {
                Console.WriteLine(response2.StatusCode);
            }
            else
            {
                var content = await response2.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

        }
    }
}
