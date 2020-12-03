using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomeApi.Data;
using RomeApi.Dtos;
using RomeApi.Models;

namespace RomeApi.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController : Controller
    {
        private readonly IRomeApiRepo _repo;
        private readonly IMapper _mapper;

        public CategoriesController(IRomeApiRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet(":id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryReadDto>> Get(Guid id)
        {
            var c = await _repo.GetCategory(id, true, true);
            if (c == null) return NotFound();
            var res = _mapper.Map<CategoryReadDto>(c);
            return res;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryReadDto>> Create(CategoryCreateDto categoryCreateDto)
        {
            var c = _mapper.Map<Category>(categoryCreateDto);
            await _repo.CreateCategory(c);
            await _repo.SaveChanges();
            var res = _mapper.Map<CategoryReadDto>(c);
            return Created("", res);
        }

        [HttpDelete(":id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryReadDto>> Delete(Guid id)
        {
            var c = await _repo.GetCategory(id);
            if (c == null) return NotFound();
            _repo.DeleteCategory(c);
            await _repo.SaveChanges();
            var res = _mapper.Map<CategoryReadDto>(c);
            return res;
        }
    }
}