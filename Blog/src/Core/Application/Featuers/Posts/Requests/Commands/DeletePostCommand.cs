using Blog.src.Core.Application.DTOs.PostDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Commands
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
