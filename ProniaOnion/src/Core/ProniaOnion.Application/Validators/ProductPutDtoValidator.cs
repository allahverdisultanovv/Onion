using FluentValidation;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Validators
{
    public class ProductPutDtoValidator : AbstractValidator<ProductPutDto>
    {
        public const int NAME_MAX_LENGTH = 100;
        public const decimal PRICE_MAX_LENGTH = 9999.99m;
        public ProductPutDtoValidator()
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
                    .WithMessage("Price must be minimum 3")
                .LessThanOrEqualTo(PRICE_MAX_LENGTH)
                    .WithMessage("Price limit has been reached");

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .Must(categoryId => categoryId > 0)
                    .WithMessage("Category cant be empty");

            RuleForEach(p => p.ColorIds)
                .NotEmpty()
                .Must(colorId => colorId > 0)
                    .WithMessage("Color cant be empty");



            RuleForEach(p => p.TagIds)
                .NotEmpty()
                .Must(tagId => tagId > 0)
                    .WithMessage("Tag cant be empty");



            RuleForEach(p => p.SizeIds)
                .NotEmpty()
                .Must(sizeId => sizeId > 0)
                    .WithMessage("Size cant be empty");

        }
    }
}
