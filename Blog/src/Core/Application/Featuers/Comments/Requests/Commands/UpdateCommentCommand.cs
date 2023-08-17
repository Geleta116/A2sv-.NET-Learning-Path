using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Responses;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Requests.Commands
{
    public class UpdateCommentCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateCommentDto UpdateCommentDto { get; set; }
    }
}
