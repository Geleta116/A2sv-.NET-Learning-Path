using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Queries
{
    public class GetAllCommentsOfAPostRequest : IRequest<List<CommentDto>>
    {
        public int postId { get; set; }
    }
}
