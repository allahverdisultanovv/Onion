using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Authors;

namespace ProniaOnion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _authorService.GetAllAsync(page, take));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id < 1) return BadRequest();
            GetAuthorDto authorDto = await _authorService.GetByIdAsync(id);
            return Ok(authorDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AuthorPostDto authorDto)
        {
            await _authorService.CreateAsync(authorDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            _authorService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] AuthorPutDto authorDto)
        {
            if (id == null || id < 1) return BadRequest();
            _authorService.Update(id, authorDto);
            return NoContent();
        }
    }
}
