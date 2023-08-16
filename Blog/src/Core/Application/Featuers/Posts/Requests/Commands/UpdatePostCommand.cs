using Blog.src.Core.Application.DTOs.PostDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Commands
{
    public class UpdatePostCommand : IRequest<PostDto>
    {
        public required UpdatePostDto UpdatePostDto { get; set; }
    }
}