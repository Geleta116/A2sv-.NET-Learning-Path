using Blog.src.Core.Application.DTOs.CommentDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Requests.Commands
{
    public class DeleteCommentCommand : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}
