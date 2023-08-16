using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Queries;
using Blog.src.Core.Application.Persistance.Contracts;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Queries
{
    public class GetAllCommentsRequestHandler
        : IRequestHandler<GetAllCommentsRequest, List<CommentDto>>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;

        public GetAllCommentsRequestHandler(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(
            GetAllCommentsRequest request,
            CancellationToken cancellationToken
        )
        {
            var allComments = await _CommentRepository.GetAllCommentsAsync(request.postId);
            return _mapper.Map<List<CommentDto>>(allComments);
        }
    }
}
