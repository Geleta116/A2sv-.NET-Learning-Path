using Blog.src.Core.Application.DTOs.CommentDtos;
using FluentValidation;

public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidator()
    {
        RuleFor(Comment => Comment.Text)
            .NotEmpty()
            .WithMessage("{ProprtyName} can not be empty")
            .NotNull()
            .MinimumLength(1)
            .WithMessage("{propertyName} must be atleast one character")
            .MaximumLength(50)
            .WithMessage("{proprtyName} can not exceed 50 characters");
    }
}
