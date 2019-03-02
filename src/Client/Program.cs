﻿using IdentityModel.Client;
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

            Console.WriteLine(response.Json);
            Console.ReadLine();
        }
    }
}
