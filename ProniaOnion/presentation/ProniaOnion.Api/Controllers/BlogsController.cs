using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Blogs;

namespace ProniaOnion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _blogService.GetAllAsync(page, take));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id < 1) return BadRequest();
            GetBlogDto blogDto = await _blogService.GetByIdAsync(id);
            return Ok(blogDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogPostDto blogDto)
        {
            await _blogService.CreateAsync(blogDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            _blogService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] BlogPutDto blogDto)
        {
            if (id == null || id < 1) return BadRequest();
            _blogService.Update(id, blogDto);
            return NoContent();
        }
    }
}
