using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Commands
{
    public class CreatePostsRequestHandler : IRequestHandler<CreatePostsRequest, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostsRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(
            CreatePostsRequest request,
            CancellationToken cancellationToken
        )
        {
            var createdPost = await _postRepository.AddAsync(_mapper.Map<Post>(request));
            return _mapper.Map<PostDto>(createdPost);
        }
    }
}
