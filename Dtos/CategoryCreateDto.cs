using System;

# nullable enable

namespace RomeApi.Dtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid? CategoryGroupId { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}