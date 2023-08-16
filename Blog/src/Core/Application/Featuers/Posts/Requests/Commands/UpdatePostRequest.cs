using Blog.src.Core.Application.DTOs.PostDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Commands
{
    public class UpdatePostRequest : IRequest<PostDto>
    {
        public required UpdatePostDto UpdatePostDto { get; set; }
    }
}