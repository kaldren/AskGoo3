using System;
using System.Collections;
using System.Collections.Generic;
using AskGoo3.Core.Entities.UserAggregate;

namespace AskGoo3.Core.Entities.MessageAggregate
{
    public class Message : BaseEntity<int>
    {
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public string DateTimeFormatted { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }

        public ICollection<UserMessage> UserMessage { get; set; }

        public Message()
        {
            DateTime = DateTime.Now;
            DateTimeFormatted = DateTime.ToLongDateString() + " " + DateTime.ToLongTimeString();
        }
    }
}
