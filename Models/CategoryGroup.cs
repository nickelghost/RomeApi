using System;
using System.Collections.Generic;

# nullable enable

namespace RomeApi.Models
{
    public class CategoryGroup : BaseEntity
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public double Rank { get; set; }
        public List<Category> Categories { get; } = new List<Category>();
    }
}