using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Tags;

namespace ProniaOnion.Application.Validators
{
    public class TagPutDtoValidator : AbstractValidator<TagPutDto>
    {

        private readonly ITagRepository _tagRepository;

        public TagPutDtoValidator(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;


            RuleFor(c => c.Name)
                .MaximumLength(100).WithMessage("Uzunluq Max 100 ola biler")
                .NotEmpty()
                .Matches(@"^[A-Za-z\s0-9]*$");
            //.MustAsync(CheckNameExistence);
        }

    }
}
