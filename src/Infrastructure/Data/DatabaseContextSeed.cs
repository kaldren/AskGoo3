using AskGoo3.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AskGoo3.Infrastructure.Data
{
    public class DatabaseContextSeed
    {
        public static async Task SeedAsync(DatabaseContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    FirstName = "John",
                    LastName = "Doe",
                    Token = "faketoken"
                }
                , new User
                {
                    Id = 2,
                    Username = "kdrenski",
                    Password = "kdrenski",
                    FirstName = "Kaloyan",
                    LastName = "Drenski",
                    Token = "faketoken"
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
