using System;
using System.Collections.Generic;
using System.Text;
using AskGoo3.Core.Entities.UserAggregate;

namespace AskGoo3.Core.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        //public UserDto Recipient { get; set; }
        //public UserDto Sender { get; set; }
    }
}
