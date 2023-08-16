using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Responses;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Commands
{
    public class UpdatePostCommand : IRequest<BaseCommandResponse>
    {
        public required UpdatePostDto UpdatePostDto { get; set; }
    }
}