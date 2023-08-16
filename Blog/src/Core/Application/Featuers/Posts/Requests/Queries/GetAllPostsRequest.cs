

using Blog.src.Core.Application.DTOs.PostDtos;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Requests.Queries
{
    public class GetAllPostsRequest: IRequest<List<PostDto>>
    {
        
    }
}