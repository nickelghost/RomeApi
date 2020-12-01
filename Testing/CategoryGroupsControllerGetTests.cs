using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly List<CategoryGroupReadDto> _data;

        private static IEnumerable<CategoryGroup> GetAllCategoryGroupsMock()
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

        public CategoryGroupsControllerGetTests()
        {
            var mockRepo = new Mock<IRomeApiRepo>();
            mockRepo.Setup(repo => repo.GetAllCategoryGroups())
                .Returns(GetAllCategoryGroupsMock());
            var mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CategoriesProfile>(); }));
            var controller = new CategoryGroupsController(mockRepo.Object, mapper);
            var res = controller.Get();
            _data = res.ToList();
        }

        [Fact]
        public void ShouldIncludeNames()
        {
            Assert.Equal("Category group one", _data[0].Name);
            Assert.Equal("Category group two", _data[1].Name);
        }

        [Fact]
        public void ShouldIncludeNullableDescriptions()
        {
            Assert.Equal("Test Description", _data[0].Description);
            Assert.Null(_data[1].Description);
        }
        
        [Fact]
        public void ShouldIncludeRanks()
        {
            Assert.Equal(1, _data[0].Rank);
            Assert.Equal(2, _data[1].Rank);
        }

        [Fact]
        public void ShouldIncludeCategories()
        {
            Assert.NotEmpty(_data[0].Categories);
        }

        [Fact]
        public void ShouldReturnDates()
        {
            var currentYear = DateTimeOffset.Now.Year;
            Assert.Equal(currentYear, _data[0].CreatedAt.Year);
            Assert.Equal(currentYear, _data[0].UpdatedAt.Year);
        }
    }
}