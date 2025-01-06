using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Colors;

namespace ProniaOnion.Application.Validators
{
    public class ColorPostDtoValidator : AbstractValidator<ColorPostDto>
    {

        private readonly IColorRepository _colorRepository;

        public ColorPostDtoValidator(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;


            RuleFor(c => c.Name)
                .MaximumLength(25).WithMessage("Uzunluq Max 25 ola biler")
                .NotEmpty()
                .Matches(@"^[A-Za-z]*$");
            //.MustAsync(CheckNameExistence);
        }
        private async Task<bool> CheckNameExistence(string name, CancellationToken cancellationToken)
        {
            return await _colorRepository.AnyAsync(c => c.Name == name);
        }
    }
}
