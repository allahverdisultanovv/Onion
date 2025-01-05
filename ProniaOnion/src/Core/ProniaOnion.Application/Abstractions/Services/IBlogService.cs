using ProniaOnion.Application.DTOs.Blogs;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IBlogService
    {
        public Task<IEnumerable<BlogItemDto>> GetAllAsync(int page, int take);
        public Task<GetBlogDto> GetByIdAsync(int id);
        public Task CreateAsync(BlogPostDto blogDto);
        public Task Delete(int id);
        public Task Update(int id, BlogPutDto blogDto);
    }
}
