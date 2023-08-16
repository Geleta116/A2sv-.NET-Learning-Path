using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Exceptions;
using Blog.src.Core.Application.Features.Posts.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Application.Responses;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(
            CreatePostCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePostDtoValidator();

            var validationResult = await validator.ValidateAsync(command.CreatePostDto);

            if (validationResult.IsValid)
            {
                response.Message = "Failed to create the post";
                response.Success = false;
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var createdPost = await _postRepository.AddAsync(_mapper.Map<Post>(command));
                response.Message = "Succesfully created the post";
                response.Success = true;
                response.Id = createdPost.Id;
            }
            return response;
        }
    }
}
