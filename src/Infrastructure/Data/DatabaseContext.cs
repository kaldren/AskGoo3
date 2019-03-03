using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AskGoo3.Infrastructure.Data
{
    public sealed class DatabaseContext :  DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }
    }
}
