using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Commands
{
    public class UpdatePostRequestHandler : IRequestHandler<UpdatePostRequest, PostDto>
    {
        IPostRepository _postrepository;
        IMapper _iMapper;

        public UpdatePostRequestHandler(IPostRepository postRepository, IMapper iMapper)
        {
            _postrepository = postRepository;
            _iMapper = iMapper;
        }

        public async Task<PostDto> Handle(
            UpdatePostRequest request,
            CancellationToken cancellationToken
        )
        {
            var updatedPost = await _postrepository.UpdateAsync(_iMapper.Map<Post>(request));
            return _iMapper.Map<PostDto>(updatedPost);
        }
    }
}
