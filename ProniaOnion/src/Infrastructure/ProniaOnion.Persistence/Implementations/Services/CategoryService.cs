using AutoMapper;
using Microsoft.EntityFrameworkCore;

using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<object, bool>> expression)
        {
            return await _repository.AnyAsync(expression);

        }

        public async Task CreateAsync(CategoryPostDto categoryDto)
        {

            Category category = _mapper.Map<Category>(categoryDto);

            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Category> categories = await _repository
                .GetAll(skip: (page - 1) * take, take: take)

                .ToListAsync();
            return _mapper.Map<IEnumerable<CategoryItemDto>>(categories);
        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("SALAM. ERROR .TAPIlADI");

            GetCategoryDto categoryDto = _mapper.Map<GetCategoryDto>(category);

            return categoryDto;
        }

        public async Task Update(int id, CategoryPutDto categoryDto)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not Found");
            category = _mapper.Map<Category>(categoryDto);
            category.UpdatedAt = DateTime.Now;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }
    }
}
