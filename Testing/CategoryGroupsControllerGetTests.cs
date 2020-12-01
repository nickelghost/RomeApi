using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RomeApi.Controllers;
using RomeApi.Data;
using RomeApi.Dtos;
using RomeApi.Models;
using RomeApi.Profiles;
using Xunit;

namespace RomeApi.Testing
{
    // TODO: Make those mapping tests instead of controller tests
    public class CategoryGroupsControllerGetTests
    {
        private static async Task<IEnumerable<CategoryGroup>> GetAllCategoryGroupsMock()
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
            return cgs;
        }

        private async Task<List<CategoryGroupReadDto>> GetData()
        {
            var mockRepo = new Mock<IRomeApiRepo>();
            mockRepo.Setup(repo => repo.GetAllCategoryGroups())
                .Returns(GetAllCategoryGroupsMock());
            var mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CategoriesProfile>(); }));
            var controller = new CategoryGroupsController(mockRepo.Object, mapper);
            var res = await controller.Get();
            return res.ToList();
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