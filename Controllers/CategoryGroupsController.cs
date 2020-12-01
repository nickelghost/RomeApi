using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RomeApi.Data;
using RomeApi.Dtos;
using RomeApi.Models;

namespace RomeApi.Controllers
{
    // TODO: Make the actions return ActionResults
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
        public async Task<IEnumerable<CategoryGroupReadDto>> Get()
        {
            var cgs = await _repo.GetAllCategoryGroups();
            var res = _mapper.Map<IEnumerable<CategoryGroupReadDto>>(cgs);
            return res;
        }

        [HttpPost]
        public async Task<CategoryGroupReadDto> Create(CategoryGroupCreateDto categoryGroupCreateDto)
        {
            var cg = _mapper.Map<CategoryGroup>(categoryGroupCreateDto);
            await _repo.CreateCategoryGroup(cg);
            await _repo.SaveChanges();
            var res = _mapper.Map<CategoryGroupReadDto>(cg);
            return res;
        }

        [HttpDelete("{id}")]
        public async Task<CategoryGroupReadDto> Delete(Guid id)
        {
            var cg = await _repo.GetCategoryGroup(id);
            _repo.DeleteCategoryGroup(cg);
            await _repo.SaveChanges();
            var res = _mapper.Map<CategoryGroupReadDto>(cg);
            return res;
        }
    }
}