using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Colors;

namespace ProniaOnion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _colorService.GetAllAsync(page, take));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id < 1) return BadRequest();
            GetColorDto colorDto = await _colorService.GetByIdAsync(id);
            return Ok(colorDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ColorPostDto colorDto)
        {
            await _colorService.CreateAsync(colorDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            _colorService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] ColorPutDto colorDto)
        {
            if (id == null || id < 1) return BadRequest();
            _colorService.Update(id, colorDto);
            return NoContent();
        }
    }
}
