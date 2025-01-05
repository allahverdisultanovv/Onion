using ProniaOnion.Application.DTOs.Sizes;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ISizeService
    {
        public Task<IEnumerable<SizeItemDto>> GetAllAsync(int page, int take);
        public Task<GetSizeDto> GetByIdAsync(int id);
        public Task CreateAsync(SizePostDto sizeDto);
        public Task Delete(int id);
        public Task Update(int id, SizePutDto sizeDto);
    }
}
