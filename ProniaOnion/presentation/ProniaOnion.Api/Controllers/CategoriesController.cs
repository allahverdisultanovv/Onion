﻿using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _categoryService.GetAllAsync(page, take));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id < 1) return BadRequest();
            GetCategoryDto categoryDto = await _categoryService.GetByIdAsync(id);
            return Ok(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryPostDto categoryDto)
        {
            await _categoryService.CreateAsync(categoryDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            _categoryService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] CategoryPutDto categoryDto)
        {
            if (id == null || id < 1) return BadRequest();
            _categoryService.Update(id, categoryDto);
            return NoContent();
        }
    }
}
