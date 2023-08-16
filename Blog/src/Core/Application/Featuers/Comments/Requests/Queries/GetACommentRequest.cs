using Blog.src.Core.Application.DTOs.CommentDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.COmments.Requests.Queries
{
    public class GetACommentRequest : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}
