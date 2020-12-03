using System;
using System.Collections.Generic;
using RomeApi.Models;

# nullable enable

namespace RomeApi.Dtos
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public double Rank { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category>? ChildCategories { get; set; } = new List<Category>();
        public List<Topic>? Topics { get; set; } = new List<Topic>();
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}