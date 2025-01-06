using FluentValidation;
using ProniaOnion.Application.DTOs.Blogs;

namespace ProniaOnion.Application.Validators
{
    public class BlogPostDtoValidator : AbstractValidator<BlogPostDto>
    {
        public BlogPostDtoValidator()
        {
            RuleFor(b => b.Title)
                .MaximumLength(250)
                .NotEmpty();
            RuleFor(b => b.Article)
                .NotEmpty();


        }
    }
}
