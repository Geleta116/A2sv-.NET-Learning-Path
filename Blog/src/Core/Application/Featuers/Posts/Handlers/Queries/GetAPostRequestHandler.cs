using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Queries;
using Blog.src.Core.Application.Persistance.Contracts;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Queries
{
    public class GetAPostRequestHandler : IRequestHandler<GetAPostsRequest, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAPostRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(
            GetAPostsRequest request,
            CancellationToken cancellationToken
        )
        {
            var thePost = await _postRepository.GetAsync(request.Id);
            return _mapper.Map<PostDto>(thePost);
        }
    }
}
