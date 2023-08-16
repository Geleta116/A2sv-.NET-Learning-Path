using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.COmments.Requests.Queries;
using Blog.src.Core.Application.Persistance.Contracts;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Queries
{
    public class GetACommentRequestHandler : IRequestHandler<GetACommentRequest, CommentDto>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;

        public GetACommentRequestHandler(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(
            GetACommentRequest request,
            CancellationToken cancellationToken
        )
        {
            var theComment = await _CommentRepository.GetAsync(request.Id);
            return _mapper.Map<CommentDto>(theComment);
        }
    }
}
