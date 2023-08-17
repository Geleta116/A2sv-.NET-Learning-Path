using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            DeleteCommentCommand command,
            CancellationToken cancellationToken
        )
        {
            await _CommentRepository.DeleteCommentAsync(command.Id);
            return Unit.Value;
        }
    }
}
