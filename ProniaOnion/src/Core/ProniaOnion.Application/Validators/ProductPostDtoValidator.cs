using FluentValidation;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Validators
{
    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public const int NAME_MAX_LENGTH = 100;
        public ProductPostDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
                   .WithMessage("Name is required")
               .MaximumLength(NAME_MAX_LENGTH)
                   .WithMessage("Name should be less than 100 characters");

            RuleFor(p => p.SKUCode)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(10);

            RuleFor(p => p.Description)
                .NotEmpty();

            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(3)
                .LessThanOrEqualTo(9999.99m);

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .Must(categoryId => categoryId > 0);

            RuleForEach(p => p.ColorIds)
                .NotEmpty()
                .Must(colorId => colorId > 0);
        }
    }
}
