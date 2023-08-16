using Blog.src.Core.Application.DTOs.PostDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Commands
{
    public class DeletePostRequest : IRequest<PostDto>
    {
        public int Id { get; set; }
    }
}
