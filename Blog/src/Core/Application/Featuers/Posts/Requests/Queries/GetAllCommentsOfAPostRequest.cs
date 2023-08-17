using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Queries
{
    public class GetAllCommentsOfAPostRequest : IRequest<PostDto>
    {
        public int postId { get; set; }
    }
}
