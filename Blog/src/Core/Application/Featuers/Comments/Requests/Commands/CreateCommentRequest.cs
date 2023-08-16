using Blog.src.Core.Application.DTOs.CommentDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Requests.Commands
{
    public class CreateCommentsRequest : IRequest<CommentDto>
    {
        public required CreateCommentDto CreateCommentDto { get; set; }
    }
}