using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Queries;
using Blog.src.Core.Application.Persistance.Contracts;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Queries
{
    public class GetAllCommentsOfAPostRequestHandler
        : IRequestHandler<GetAllCommentsOfAPostRequest, PostDto>
    {
        private readonly IPostRepository _PostRepository;
        private readonly IMapper _mapper;

        public GetAllCommentsOfAPostRequestHandler(IPostRepository PostRepository, IMapper mapper)
        {
            _PostRepository = PostRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(
            GetAllCommentsOfAPostRequest request,
            CancellationToken cancellationToken
        )
        {
            var allCommentsOfThePost = await _PostRepository.GetAllCommentsOfAPostAsync(request.postId);
            return _mapper.Map<PostDto>(allCommentsOfThePost);
        }
    }
}
