using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Blogs;
using ProniaOnion.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<Blog, bool>> expression)
        {
            return await _repository.AnyAsync(expression);

        }

        public async Task CreateAsync(BlogPostDto blogDto)
        {

            Blog blog = _mapper.Map<Blog>(blogDto);

            blog.CreatedAt = DateTime.Now;
            blog.UpdatedAt = DateTime.Now;
            await _repository.AddAsync(blog);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Blog blog = await _repository.GetByIdAsync(id);
            _repository.Delete(blog);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Blog> blogs = await _repository
                .GetAll(skip: (page - 1) * take, take: take)

                .ToListAsync();
            return _mapper.Map<IEnumerable<BlogItemDto>>(blogs);
        }

        public async Task<GetBlogDto> GetByIdAsync(int id)
        {
            Blog blog = await _repository.GetByIdAsync(id);
            if (blog == null) throw new Exception("SALAM. ERROR .TAPIlADI");

            GetBlogDto blogDto = _mapper.Map<GetBlogDto>(blog);

            return blogDto;
        }

        public async Task Update(int id, BlogPutDto blogDto)
        {
            Blog blog = await _repository.GetByIdAsync(id);
            if (blog == null) throw new Exception("Not Found");
            blog = _mapper.Map(blogDto, blog);
            blog.UpdatedAt = DateTime.Now;
            _repository.Update(blog);
            await _repository.SaveChangesAsync();
        }
    }
}
