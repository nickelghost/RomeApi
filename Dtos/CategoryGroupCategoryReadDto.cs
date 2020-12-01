using System;

#nullable enable

namespace RomeApi.Dtos
{
    public class CategoryGroupCategoryReadDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public double Rank { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}