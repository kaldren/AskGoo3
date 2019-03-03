using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using AskGoo3.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AskGoo3.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .UseUrls("https://localhost:6001/")
                .Build();
                //.Run();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Seed InMemory when in Development
            if (environment == EnvironmentName.Development)
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var databaseContext = services.GetRequiredService<DatabaseContext>();
                        DatabaseContextSeed.SeedAsync(databaseContext).Wait();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
