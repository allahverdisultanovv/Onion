using ProniaOnion.Application.DTOs.Colors;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IColorService
    {
        public Task<IEnumerable<ColorItemDto>> GetAllAsync(int page, int take);
        public Task<GetColorDto> GetByIdAsync(int id);
        public Task CreateAsync(ColorPostDto colorDto);
        public Task Delete(int id);
        public Task Update(int id, ColorPutDto colorDto);
    }
}