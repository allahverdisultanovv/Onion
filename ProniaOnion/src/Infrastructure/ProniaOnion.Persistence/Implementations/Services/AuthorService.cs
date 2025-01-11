using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Authors;
using ProniaOnion.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<Author, bool>> expression)
        {
            return await _repository.AnyAsync(expression);

        }


        public async Task CreateAsync(AuthorPostDto authorDto)
        {

            Author author = _mapper.Map<Author>(authorDto);

            await _repository.AddAsync(author);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Author author = await _repository.GetByIdAsync(id);
            _repository.Delete(author);
            await _repository.SaveChangesAsync();
        }


        public async Task<IEnumerable<AuthorItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Author> categories = await _repository
                .GetAll(skip: (page - 1) * take, take: take)

                .ToListAsync();
            return _mapper.Map<IEnumerable<AuthorItemDto>>(categories);
        }

        public async Task<GetAuthorDto> GetByIdAsync(int id)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author == null) throw new Exception("SALAM. ERROR .TAPIlADI");

            GetAuthorDto authorDto = _mapper.Map<GetAuthorDto>(author);

            return authorDto;
        }

        public async Task Update(int id, AuthorPutDto authorDto)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author == null) throw new Exception("Not Found");
            author = _mapper.Map(authorDto, author);
            _repository.Update(author);
            await _repository.SaveChangesAsync();
        }
    }
}
