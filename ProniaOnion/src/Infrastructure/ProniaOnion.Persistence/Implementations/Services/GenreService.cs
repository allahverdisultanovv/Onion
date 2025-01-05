using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Genres;
using ProniaOnion.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<object, bool>> expression)
        {
            return await _repository.AnyAsync(expression);

        }

        public async Task CreateAsync(GenrePostDto genreDto)
        {

            Genre genre = _mapper.Map<Genre>(genreDto);

            genre.CreatedAt = DateTime.Now;
            genre.UpdatedAt = DateTime.Now;
            await _repository.AddAsync(genre);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Genre genre = await _repository.GetByIdAsync(id);
            _repository.Delete(genre);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Genre> genres = await _repository
                .GetAll(skip: (page - 1) * take, take: take)

                .ToListAsync();
            return _mapper.Map<IEnumerable<GenreItemDto>>(genres);
        }

        public async Task<GetGenreDto> GetByIdAsync(int id)
        {
            Genre genre = await _repository.GetByIdAsync(id);
            if (genre == null) throw new Exception("SALAM. ERROR .TAPIlADI");

            GetGenreDto genreDto = _mapper.Map<GetGenreDto>(genre);

            return genreDto;
        }

        public async Task Update(int id, GenrePutDto genreDto)
        {
            Genre genre = await _repository.GetByIdAsync(id);
            if (genre == null) throw new Exception("Not Found");
            genre = _mapper.Map(genreDto, genre);
            genre.UpdatedAt = DateTime.Now;
            _repository.Update(genre);
            await _repository.SaveChangesAsync();
        }
    }
}
