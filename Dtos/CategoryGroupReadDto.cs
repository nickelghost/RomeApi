using System;
using System.Collections.Generic;
using AutoMapper.Configuration.Conventions;
using RomeApi.Models;

namespace RomeApi.Dtos
{
    public class CategoryGroupReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rank { get; set; }
        public List<CategoryGroupCategoryReadDto> Categories { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}