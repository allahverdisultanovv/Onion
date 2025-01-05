using ProniaOnion.Application.DTOs.Genres;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreItemDto>> GetAllAsync(int page, int take);
        public Task<GetGenreDto> GetByIdAsync(int id);
        public Task CreateAsync(GenrePostDto genreDto);
        public Task Delete(int id);
        public Task Update(int id, GenrePutDto genreDto);
    }
}
