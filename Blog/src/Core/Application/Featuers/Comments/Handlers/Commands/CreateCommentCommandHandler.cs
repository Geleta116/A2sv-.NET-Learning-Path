using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Commands
{
    public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, CommentDto>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;

        public CreateCommentsCommandHandler(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(
            CreateCommentsCommand Command,
            CancellationToken cancellationToken
        )
        {
            var createdComment = await _CommentRepository.AddAsync(_mapper.Map<Comment>(Command));
            return _mapper.Map<CommentDto>(createdComment);
        }
    }
}
