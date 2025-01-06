using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Colors;

namespace ProniaOnion.Application.Validators
{
    public class ColorPutDtoValidator : AbstractValidator<ColorPutDto>
    {

        private readonly IColorRepository _colorRepository;

        public ColorPutDtoValidator(IColorRepository colorRepository)
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
