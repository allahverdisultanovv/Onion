using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ColorService : IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ColorPostDto colorDto)
        {
            Color color = _mapper.Map<Color>(colorDto);

            color.CreatedAt = DateTime.Now;
            color.UpdatedAt = DateTime.Now;
            await _repository.AddAsync(color);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Color color = await _repository.GetByIdAsync(id);
            _repository.Delete(color);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ColorItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Color> colors = await _repository
                .GetAll(skip: (page - 1) * take, take: take)

                .ToListAsync();
            return _mapper.Map<IEnumerable<ColorItemDto>>(colors);
        }

        public async Task<GetColorDto> GetByIdAsync(int id)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color == null) throw new Exception("SALAM. ERROR .TAPIlADI");

            GetColorDto colorDto = _mapper.Map<GetColorDto>(color);

            return colorDto;
        }

        public async Task Update(int id, ColorPutDto colorDto)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color == null) throw new Exception("Not Found");
            color = _mapper.Map<Color>(colorDto);
            color.UpdatedAt = DateTime.Now;
            _repository.Update(color);
            await _repository.SaveChangesAsync();
        }
    }
}
