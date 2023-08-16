using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Commands
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, CommentDto>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;

        public DeleteCommentRequestHandler(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(
            DeleteCommentRequest request,
            CancellationToken cancellationToken
        )
        {
            var deletedComment = await _CommentRepository.DeleteAsync(request.Id);
            return _mapper.Map<CommentDto>(deletedComment);
        }
    }
}
