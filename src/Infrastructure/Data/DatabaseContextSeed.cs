using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AskGoo3.Core.Entities.MessageAggregate;
using AskGoo3.Core.Entities.UserAggregate;

namespace AskGoo3.Infrastructure.Data
{
    public class DatabaseContextSeed
    {
        public static async Task SeedAsync(DatabaseContext context)
        {
            // Create Users
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    FirstName = "John",
                    LastName = "Doe",
                    Token = "faketoken",
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


            // Create Messages
            var messagesUserId1 = new List<Message>
            {
                new Message
                {
                    Id = 1,
                    Content = "Hello kdrenski!",
                    Sender = users[0],
                    Recipient = users[1],
                },
                new Message
                {
                    Id = 2,
                    Content = "By the way, love C#!",
                    Sender = users[0],
                    Recipient = users[1],
                }
            };
            var messagesUserId2 = new List<Message>
            {
                new Message
                {
                    Id = 3,
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Sender = users[1],
                    Recipient = users[0],
                },
                new Message
                {
                    Id = 4,
                    Content = "I haven't seen you in a while...",
                    Sender = users[1],
                    Recipient = users[0],
                }
            };

            await context.Messages.AddRangeAsync(messagesUserId1);
            await context.Messages.AddRangeAsync(messagesUserId2);
            await context.SaveChangesAsync();
        }
    }
}
