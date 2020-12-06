using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RomeApi.Dtos;
using RomeApi.Models;
using RomeApi.Profiles;
using Xunit;

namespace RomeApi.Testing.Profiles
{
    public class CategoryGroupsProfileTest
    {
        private static async Task<List<CategoryGroupReadDto>> GetData()
        {
            var cgs = await GetCategoryGroups();
            var mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CategoryGroupsProfile>(); }));
            return mapper.Map<List<CategoryGroupReadDto>>(cgs);
        }

        private static async Task<IEnumerable<CategoryGroup>> GetCategoryGroups()
        {
            var now = DateTimeOffset.Now;
            var cg1Id = Guid.NewGuid();
            var c1 = new Category
            {
                Id = Guid.NewGuid(),
                Rank = 1,
                CategoryGroupId = cg1Id,
                CreatedAt = now,
                UpdatedAt = now,
            };
            var cg1 = new CategoryGroup
            {
                Id = cg1Id,
                Name = "Category group one",
                Description = "Test Description",
                Rank = 1,
                Categories = {c1},
                CreatedAt = now,
                UpdatedAt = now,
            };
            var cg2 = new CategoryGroup
            {
                Id = Guid.NewGuid(),
                Name = "Category group two",
                Rank = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };
            var cgs = new List<CategoryGroup> {cg1, cg2};
            return await Task.FromResult(cgs);
        }

        [Fact]
        public async Task ShouldIncludeNames()
        {
            var data = await GetData();
            Assert.Equal("Category group one", data[0].Name);
            Assert.Equal("Category group two", data[1].Name);
        }

        [Fact]
        public async Task ShouldIncludeNullableDescriptions()
        {
            var data = await GetData();
            Assert.Equal("Test Description", data[0].Description);
            Assert.Null(data[1].Description);
        }

        [Fact]
        public async Task ShouldIncludeRanks()
        {
            var data = await GetData();
            Assert.Equal(1, data[0].Rank);
            Assert.Equal(2, data[1].Rank);
        }

        [Fact]
        public async Task ShouldIncludeCategories()
        {
            var data = await GetData();
            Assert.NotEmpty(data[0].Categories);
        }

        [Fact]
        public async Task ShouldReturnDates()
        {
            var data = await GetData();
            var currentYear = DateTimeOffset.Now.Year;
            Assert.Equal(currentYear, data[0].CreatedAt.Year);
            Assert.Equal(currentYear, data[0].UpdatedAt.Year);
        }
    }
}