using ProniaOnion.Application.DTOs.Authors;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorItemDto>> GetAllAsync(int page, int take);
        public Task<GetAuthorDto> GetByIdAsync(int id);
        public Task CreateAsync(AuthorPostDto authorDto);
        public Task Delete(int id);
        public Task Update(int id, AuthorPutDto authorDto);
    }
}
