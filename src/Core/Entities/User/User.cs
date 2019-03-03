using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AskGoo3.Core.Entities.User
{
    public class User : BaseEntity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
