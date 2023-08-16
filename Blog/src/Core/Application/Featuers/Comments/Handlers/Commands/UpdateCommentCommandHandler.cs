using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Exceptions;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        ICommentRepository _Commentrepository;
        IMapper _iMapper;

        public UpdateCommentCommandHandler(ICommentRepository CommentRepository, IMapper iMapper)
        {
            _Commentrepository = CommentRepository;
            _iMapper = iMapper;
        }

        public async Task<Unit> Handle(
            UpdateCommentCommand command,
            CancellationToken cancellationToken
        )
        {
            var validator = new UpdateCommentDtoValidator();

            var validatedValue = await validator.ValidateAsync(command.UpdateCommentDto);

            if (validatedValue.IsValid)
                throw new ValidationException(validatedValue);

            var theCommentToBeUpdated = await _Commentrepository.GetAsync(
                command.UpdateCommentDto.Id
            );
            if (theCommentToBeUpdated is null)
            {
                throw new FileNotFoundException();
            }

            _iMapper.Map(command.UpdateCommentDto, theCommentToBeUpdated);

            await _Commentrepository.UpdateAsync(theCommentToBeUpdated);
            return Unit.Value;
        }
    }
}
