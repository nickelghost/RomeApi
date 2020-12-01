using AutoMapper;
using RomeApi.Dtos;
using RomeApi.Models;

namespace RomeApi.Profiles
{
    // TODO: Actually name it CategoryGroupsProfile 🤦
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoryGroup, CategoryGroupReadDto>();
            CreateMap<Category, CategoryGroupCategoryReadDto>();
            CreateMap<CategoryGroupCreateDto, CategoryGroup>();
        }
    }
}