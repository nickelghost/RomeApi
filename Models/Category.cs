using System;
using System.Collections.Generic;

# nullable enable

namespace RomeApi.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public double Rank { get; set; }
        public Guid? CategoryGroupId { get; set; }
        public CategoryGroup? CategoryGroup { get; set; } = null;
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; } = null;
        public List<Category>? ChildCategories { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}