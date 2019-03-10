using System;
using System.Collections.Generic;
using System.Text;
using AskGoo3.Core.Entities.MessageAggregate;
using AskGoo3.Core.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace AskGoo3.Infrastructure.Data
{
    public sealed class DatabaseContext :  DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserMessage>().HasKey(um => new {um.MessageId, um.UserId});

            builder.Entity<UserMessage>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMessage)
                .HasForeignKey(um => um.UserId);

            builder.Entity<UserMessage>()
                .HasOne(um => um.Message)
                .WithMany(u => u.UserMessage)
                .HasForeignKey(um => um.MessageId);
        }
    }
}
