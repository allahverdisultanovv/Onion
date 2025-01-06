using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Authors;

namespace ProniaOnion.Application.Validators
{
    public class AuthorPutDtoValidator : AbstractValidator<AuthorPutDto>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorPutDtoValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;


            RuleFor(c => c.Name)
                .MaximumLength(50).WithMessage("Uzunluq Max 50 ola biler")
                .NotEmpty()
                .Matches(@"^[A-Za-z]*$");
            RuleFor(c => c.Surname)
                .MaximumLength(50).WithMessage("Uzunluq Max 50 ola biler")
                .NotEmpty()
                .Matches(@"^[A-Za-z]*$");
        }

    }
}
