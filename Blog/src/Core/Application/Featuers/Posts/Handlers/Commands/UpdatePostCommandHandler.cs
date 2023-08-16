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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, BaseCommandResponse>
    {
        IPostRepository _postrepository;
        IMapper _iMapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper iMapper)
        {
            _postrepository = postRepository;
            _iMapper = iMapper;
        }

        public async Task<BaseCommandResponse> Handle(
            UpdatePostCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = new BaseCommandResponse();
            var validator = new UpdatePostDtoValidator();

            var validationResult = await validator.ValidateAsync(command.UpdatePostDto);

            if (validationResult.IsValid)
            {
                response.Success = false;
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                response.Message = "Failed to update the post";
            }
            else
            {
                var thePostToBeUpdated = await _postrepository.GetAsync(command.UpdatePostDto.Id);
                if (thePostToBeUpdated is null)
                {
                    throw new FileNotFoundException();
                }

                _iMapper.Map(command.UpdatePostDto, thePostToBeUpdated);

                await _postrepository.UpdateAsync(thePostToBeUpdated);
                response.Success = true;
                response.Message = "Succesfully created the post";
                response.Id = thePostToBeUpdated.Id;
            }
            return response;
        }
    }
}
