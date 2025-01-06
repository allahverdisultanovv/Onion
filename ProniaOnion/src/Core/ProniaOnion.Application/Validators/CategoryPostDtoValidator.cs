using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Validators
{
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryPostDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;


            RuleFor(c => c.Name)
                .MaximumLength(100).WithMessage("Uzunluq Max 100 ola biler")
                .NotEmpty()
                .Matches(@"^[A-Za-z\s0-9]*$");
            //.MustAsync(CheckNameExistence);
        }
        private async Task<bool> CheckNameExistence(string name, CancellationToken cancellationToken)
        {
            return await _categoryRepository.AnyAsync(c => c.Name == name);
        }
    }
}
