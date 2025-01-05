using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Tags;
using ProniaOnion.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<object, bool>> expression)
        {
            return await _repository.AnyAsync(expression);

        }

        public async Task CreateAsync(TagPostDto tagDto)
        {

            Tag tag = _mapper.Map<Tag>(tagDto);

            tag.CreatedAt = DateTime.Now;
            tag.UpdatedAt = DateTime.Now;
            await _repository.AddAsync(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            _repository.Delete(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TagItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Tag> tags = await _repository
                .GetAll(skip: (page - 1) * take, take: take)

                .ToListAsync();
            return _mapper.Map<IEnumerable<TagItemDto>>(tags);
        }

        public async Task<GetTagDto> GetByIdAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag == null) throw new Exception("SALAM. ERROR .TAPIlADI");

            GetTagDto tagDto = _mapper.Map<GetTagDto>(tag);

            return tagDto;
        }

        public async Task Update(int id, TagPutDto tagDto)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag == null) throw new Exception("Not Found");
            tag = _mapper.Map(tagDto, tag);
            tag.UpdatedAt = DateTime.Now;
            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }
    }
}
