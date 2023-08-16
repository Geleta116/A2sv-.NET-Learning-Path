using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Persistance.Contracts;
using FluentValidation;

public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
{
    private IPostRepository _IPostRepository;

    public CreateCommentDtoValidator(IPostRepository IPostRepository)
    {
        _IPostRepository = IPostRepository;

        RuleFor(Comment => Comment.Text)
            .NotEmpty()
            .WithMessage("{ProprtyName} can not be empty")
            .NotNull()
            .MinimumLength(1)
            .WithMessage("{propertyName} must be atleast one character")
            .MaximumLength(50)
            .WithMessage("{proprtyName} can not exceed 50 characters");

        RuleFor(Comment => Comment.PostId)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    var postExists = await _IPostRepository.GetAsync(id);
                    if (postExists != null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            )
            .WithMessage("{PropertyName} doesn't exist");
    }
}
