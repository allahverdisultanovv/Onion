using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take);
        public Task<GetCategoryDto> GetByIdAsync(int id);
        public Task CreateAsync(CategoryPostDto categoryDto);
        public Task Delete(int id);
        public Task Update(int id, CategoryPutDto categoryDto);
        public Task SoftDelete(int id);


    }
}
