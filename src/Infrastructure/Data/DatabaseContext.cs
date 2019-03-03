using System;
using System.Collections.Generic;
using System.Text;
using AskGoo3.Core.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace AskGoo3.Infrastructure.Data
{
    public sealed class DatabaseContext :  DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }
    }
}
