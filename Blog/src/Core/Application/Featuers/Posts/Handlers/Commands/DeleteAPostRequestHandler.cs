using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Commands
{
    public class DeletePostRequestHandler : IRequestHandler<DeletePostRequest, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(
            DeletePostRequest request,
            CancellationToken cancellationToken
        )
        {
            var deletedPost = await _postRepository.DeleteAsync(request.Id);
            return _mapper.Map<PostDto>(deletedPost);
        }
    }
}
