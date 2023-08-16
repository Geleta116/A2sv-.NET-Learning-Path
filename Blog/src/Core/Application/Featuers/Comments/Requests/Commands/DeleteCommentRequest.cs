using Blog.src.Core.Application.DTOs.CommentDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Requests.Commands
{
    public class DeleteCommentRequest : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}
