using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Genres;

namespace ProniaOnion.Application.Validators
{
    public class GenrePutDtoValidator : AbstractValidator<GenrePutDto>
    {
        private readonly IGenreRepository _genreRepository;

        public GenrePutDtoValidator(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;


            RuleFor(c => c.Name)
                .MaximumLength(100).WithMessage("Uzunluq Max 100 ola biler")
                .NotEmpty()
                .Matches(@"^[A-Za-z]*$");
            //.MustAsync(CheckNameExistence);
        }
        private async Task<bool> CheckNameExistence(string name, CancellationToken cancellationToken)
        {
            return await _genreRepository.AnyAsync(g => g.Name == name);
        }
    }
}
