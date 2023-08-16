using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentDto>
    {
        ICommentRepository _Commentrepository;
        IMapper _iMapper;

        public UpdateCommentCommandHandler(ICommentRepository CommentRepository, IMapper iMapper)
        {
            _Commentrepository = CommentRepository;
            _iMapper = iMapper;
        }

        public async Task<CommentDto> Handle(
            UpdateCommentCommand command,
            CancellationToken cancellationToken
        )
        {
            var updatedComment = await _Commentrepository.UpdateAsync(
                _iMapper.Map<Comment>(command)
            );
            return _iMapper.Map<CommentDto>(updatedComment);
        }
    }
}
