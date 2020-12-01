using System;

# nullable enable

namespace RomeApi.Models
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
    }
}