using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RomeApi.Data;
using RomeApi.Dtos;
using RomeApi.Models;

namespace RomeApi.Controllers
{
    // TODO: Make the actions return ActionResults and be async
    // TODO: Add complete validation
    [ApiController]
    [Route("category-groups")]
    public class CategoryGroupsController
    {
        private readonly IRomeApiRepo _repo;
        private readonly IMapper _mapper;

        public CategoryGroupsController(IRomeApiRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CategoryGroupReadDto> Get()
        {
            var cgs = _repo.GetAllCategoryGroups();
            var res = _mapper.Map<IEnumerable<CategoryGroupReadDto>>(cgs);
            return res;
        }

        [HttpPost]
        public CategoryGroupReadDto Create(CategoryGroupCreateDto categoryGroupCreateDto)
        {
            var cg = _mapper.Map<CategoryGroup>(categoryGroupCreateDto);
            _repo.CreateCategoryGroup(cg);
            _repo.SaveChanges();
            var res = _mapper.Map<CategoryGroupReadDto>(cg);
            return res;
        }

        [HttpDelete("{id}")]
        public CategoryGroupReadDto Delete(Guid id)
        {
            var cg = _repo.GetCategoryGroup(id);
            _repo.DeleteCategoryGroup(cg);
            _repo.SaveChanges();
            var res = _mapper.Map<CategoryGroupReadDto>(cg);
            return res;
        }
    }
}