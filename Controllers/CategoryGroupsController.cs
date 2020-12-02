using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomeApi.Data;
using RomeApi.Dtos;
using RomeApi.Models;

namespace RomeApi.Controllers
{
    // TODO: Add complete validation
    [ApiController]
    [Route("category-groups")]
    public class CategoryGroupsController : Controller
    {
        private readonly IRomeApiRepo _repo;
        private readonly IMapper _mapper;

        public CategoryGroupsController(IRomeApiRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CategoryGroupReadDto>>> Get()
        {
            var cgs = await _repo.GetAllCategoryGroups();
            var res = _mapper.Map<List<CategoryGroupReadDto>>(cgs);
            return res;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryGroupReadDto>> Create(CategoryGroupCreateDto categoryGroupCreateDto)
        {
            var cg = _mapper.Map<CategoryGroup>(categoryGroupCreateDto);
            await _repo.CreateCategoryGroup(cg);
            await _repo.SaveChanges();
            var res = _mapper.Map<CategoryGroupReadDto>(cg);
            return Created("", res);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryGroupReadDto>> Delete(Guid id)
        {
            var cg = await _repo.GetCategoryGroup(id);
            if (cg == null) return NotFound();
            _repo.DeleteCategoryGroup(cg);
            await _repo.SaveChanges();
            var res = _mapper.Map<CategoryGroupReadDto>(cg);
            return res;
        }
    }
}