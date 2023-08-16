using Blog.src.Core.Application.DTOs.CommentDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Requests.Commands
{
    public class UpdateCommentRequest : IRequest<CommentDto>
    {
        public required UpdateCommentDto UpdateCommentDto { get; set; }
    }
}
