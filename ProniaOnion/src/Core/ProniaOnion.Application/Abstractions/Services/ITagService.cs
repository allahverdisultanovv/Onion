using ProniaOnion.Application.DTOs.Tags;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ITagService
    {
        public Task<IEnumerable<TagItemDto>> GetAllAsync(int page, int take);
        public Task<GetTagDto> GetByIdAsync(int id);
        public Task CreateAsync(TagPostDto tagDto);
        public Task Delete(int id);
        public Task Update(int id, TagPutDto tagDto);
    }
}
