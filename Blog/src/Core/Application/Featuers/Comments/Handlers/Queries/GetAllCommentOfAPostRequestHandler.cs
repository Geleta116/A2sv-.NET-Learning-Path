using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Queries;
using Blog.src.Core.Application.Persistance.Contracts;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Queries
{
    public class GetAllCommentsOfAPostRequestHandler
        : IRequestHandler<GetAllCommentsOfAPostRequest, List<CommentDto>>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;

        public GetAllCommentsOfAPostRequestHandler(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(
            GetAllCommentsOfAPostRequest request,
            CancellationToken cancellationToken
        )
        {
            var allCommentsOfThePost = await _CommentRepository.GetAllCommentsAsync(request.postId);
            return _mapper.Map<List<CommentDto>>(allCommentsOfThePost);
        }
    }
}
