using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Commands
{
    public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, CommentDto>
    {
        ICommentRepository _Commentrepository;
        IMapper _iMapper;

        public UpdateCommentRequestHandler(ICommentRepository CommentRepository, IMapper iMapper)
        {
            _Commentrepository = CommentRepository;
            _iMapper = iMapper;
        }

        public async Task<CommentDto> Handle(
            UpdateCommentRequest request,
            CancellationToken cancellationToken
        )
        {
            var updatedComment = await _Commentrepository.UpdateAsync(
                _iMapper.Map<Comment>(request)
            );
            return _iMapper.Map<CommentDto>(updatedComment);
        }
    }
}
