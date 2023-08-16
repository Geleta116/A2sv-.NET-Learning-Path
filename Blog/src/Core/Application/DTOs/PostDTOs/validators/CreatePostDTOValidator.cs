using Blog.src.Core.Application.DTOs.PostDtos;
using FluentValidation;

public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostDtoValidator()
    {
        RuleFor(post => post.Title)
            .NotEmpty()
            .WithMessage("{ProprtyName} can not be empty")
            .NotNull()
            .MinimumLength(1)
            .WithMessage("{propertyName} must be atleast one character")
            .MaximumLength(50)
            .WithMessage("{proprtyName} can not exceed 50 characters");

        RuleFor(post => post.Content)
            .NotEmpty()
            .WithMessage("{ProprtyName} can not be empty")
            .NotNull()
            .MinimumLength(1)
            .WithMessage("{propertyName} must be atleast one character")
            .MaximumLength(500)
            .WithMessage("{proprtyName} can not exceed 50 characters");
    }
}
