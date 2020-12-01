using AutoMapper;
using RomeApi.Dtos;
using RomeApi.Models;

namespace RomeApi.Profiles
{
    public class CategoryGroupsProfile : Profile
    {
        public CategoryGroupsProfile()
        {
            CreateMap<CategoryGroup, CategoryGroupReadDto>();
            CreateMap<Category, CategoryGroupCategoryReadDto>();
            CreateMap<CategoryGroupCreateDto, CategoryGroup>();
        }
    }
}