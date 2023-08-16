using Blog.src.Core.Application.DTOs.CommentDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Requests.Commands
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public required UpdateCommentDto UpdateCommentDto { get; set; }
    }
}
