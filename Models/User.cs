using System;
using System.Collections.Generic;

# nullable enable

namespace RomeApi.Models
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public List<Topic> Topics { get; } = new List<Topic>();
        public List<Post> Posts { get; } = new List<Post>();
    }
}