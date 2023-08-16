using Blog.src.Core.Application.DTOs.PostDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Commands
{
    public class CreatePostCommand : IRequest<PostDto>
    {
        public required CreatePostDto CreatePostDto { get; set; }
    }
}
