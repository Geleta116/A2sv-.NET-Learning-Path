using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Exceptions;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Application.Responses;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Commands
{
    public class UpdateCommentCommandHandler
        : IRequestHandler<UpdateCommentCommand, BaseCommandResponse>
    {
        ICommentRepository _Commentrepository;
        IMapper _iMapper;

        public UpdateCommentCommandHandler(ICommentRepository CommentRepository, IMapper iMapper)
        {
            _Commentrepository = CommentRepository;
            _iMapper = iMapper;
        }

        public async Task<BaseCommandResponse> Handle(
            UpdateCommentCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateCommentDtoValidator();

            var validationResult = await validator.ValidateAsync(command.UpdateCommentDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Failed to update comment";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var theCommentToBeUpdated = await _Commentrepository.GetAsync(
                    command.UpdateCommentDto.Id
                );
                if (theCommentToBeUpdated is null)
                {
                    throw new FileNotFoundException();
                }

                _iMapper.Map(command.UpdateCommentDto, theCommentToBeUpdated);

                await _Commentrepository.UpdateAsync(theCommentToBeUpdated);

                response.Success = true;
                response.Message = "Succesfully updated the comment";
                response.Id = theCommentToBeUpdated.Id;
            }
            return response;
        }
    }
}
