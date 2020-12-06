#nullable enable

namespace RomeApi.Dtos
{
    public class CategoryGroupCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}