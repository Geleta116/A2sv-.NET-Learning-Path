using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(
            CreatePostCommand command,
            CancellationToken cancellationToken
        )
        {
            var validator = new CreatePostDtoValidator();

            var validatedValue = await validator.ValidateAsync(command.CreatePostDto);

            if (validatedValue.IsValid)
                throw new Exception();
                
            var createdPost = await _postRepository.AddAsync(_mapper.Map<Post>(command));
            return _mapper.Map<PostDto>(createdPost);
        }
    }
}
