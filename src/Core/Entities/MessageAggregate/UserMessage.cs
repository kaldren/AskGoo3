using AskGoo3.Core.Entities.UserAggregate;

namespace AskGoo3.Core.Entities.MessageAggregate
{
    public class UserMessage : BaseEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}
