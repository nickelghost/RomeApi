using System;
using System.Collections.Generic;

# nullable enable

namespace RomeApi.Models
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Post> Posts { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
    }
}