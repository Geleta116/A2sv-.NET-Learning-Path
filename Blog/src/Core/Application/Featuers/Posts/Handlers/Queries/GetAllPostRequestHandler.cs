using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Queries;
using Blog.src.Core.Application.Persistance.Contracts;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Queries
{
    public class GetAllPostsRequestHandler : IRequestHandler<GetAllPostsRequest, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostsRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> Handle(
            GetAllPostsRequest request,
            CancellationToken cancellationToken
        )
        {
            var allPosts = await _postRepository.GetAllAsync();
            return _mapper.Map<List<PostDto>>(allPosts);
        }
    }
}
