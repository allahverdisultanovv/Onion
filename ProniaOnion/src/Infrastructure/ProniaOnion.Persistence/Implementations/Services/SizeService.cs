using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class SizeService : ISizeService
    {
        private readonly ISizeRepository _repository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<Size, bool>> expression)
        {
            return await _repository.AnyAsync(expression);

        }

        public async Task CreateAsync(SizePostDto sizeDto)
        {

            Size size = _mapper.Map<Size>(sizeDto);
            await _repository.AddAsync(size);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Size size = await _repository.GetByIdAsync(id);
            _repository.Delete(size);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SizeItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Size> sizes = await _repository
                .GetAll(skip: (page - 1) * take, take: take)

                .ToListAsync();
            return _mapper.Map<IEnumerable<SizeItemDto>>(sizes);
        }

        public async Task<GetSizeDto> GetByIdAsync(int id)
        {
            Size size = await _repository.GetByIdAsync(id);
            if (size == null) throw new Exception("SALAM. ERROR .TAPIlADI");

            GetSizeDto sizeDto = _mapper.Map<GetSizeDto>(size);

            return sizeDto;
        }

        public async Task Update(int id, SizePutDto sizeDto)
        {
            Size size = await _repository.GetByIdAsync(id);
            if (size == null) throw new Exception("Not Found");
            size = _mapper.Map(sizeDto, size);
            _repository.Update(size);
            await _repository.SaveChangesAsync();
        }
    }
}
