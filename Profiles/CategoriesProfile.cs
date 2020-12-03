using AutoMapper;
using RomeApi.Dtos;
using RomeApi.Models;

namespace RomeApi.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}