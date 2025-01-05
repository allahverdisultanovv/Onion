using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Genres;

namespace ProniaOnion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _genreService.GetAllAsync(page, take));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id < 1) return BadRequest();
            GetGenreDto genreDto = await _genreService.GetByIdAsync(id);
            return Ok(genreDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] GenrePostDto genreDto)
        {
            await _genreService.CreateAsync(genreDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            _genreService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] GenrePutDto genreDto)
        {
            if (id == null || id < 1) return BadRequest();
            _genreService.Update(id, genreDto);
            return NoContent();
        }
    }

}
