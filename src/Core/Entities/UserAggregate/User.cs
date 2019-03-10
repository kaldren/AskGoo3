using System.Collections;
using System.Collections.Generic;
using AskGoo3.Core.Entities.MessageAggregate;

namespace AskGoo3.Core.Entities.UserAggregate
{
    public class User : BaseEntity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }

        public ICollection<UserMessage> UserMessage { get; set; }
    }
}
