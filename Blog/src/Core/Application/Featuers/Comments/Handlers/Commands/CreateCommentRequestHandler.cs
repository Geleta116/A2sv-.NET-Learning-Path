using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Commands
{
    public class CreateCommentsRequestHandler : IRequestHandler<CreateCommentsRequest, CommentDto>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;

        public CreateCommentsRequestHandler(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(
            CreateCommentsRequest request,
            CancellationToken cancellationToken
        )
        {
            var createdComment = await _CommentRepository.AddAsync(_mapper.Map<Comment>(request));
            return _mapper.Map<CommentDto>(createdComment);
        }
    }
}
