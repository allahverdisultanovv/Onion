using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Sizes;

namespace ProniaOnion.Application.Validators
{
    public class SizePutDtoValidator : AbstractValidator<SizePutDto>
    {

        private readonly ISizeRepository _sizeRepository;

        public SizePutDtoValidator(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;


            RuleFor(c => c.Name)
                .MaximumLength(10).WithMessage("Uzunluq Max 10 ola biler")
                .NotEmpty();
            //.MustAsync(CheckNameExistence);
        }
        //private async Task<bool> CheckNameExistence(string name, CancellationToken cancellationToken)
        //{
        //    return await _sizeRepository.AnyAsync(s => s.Name == name);
        //}
    }
}
