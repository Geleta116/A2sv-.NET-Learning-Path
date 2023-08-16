using AutoMapper;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Application.Features.Posts.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Posts.Commands
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
    {
        IPostRepository _postrepository;
        IMapper _iMapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper iMapper)
        {
            _postrepository = postRepository;
            _iMapper = iMapper;
        }

        public async Task<Unit> Handle(
            UpdatePostCommand command,
            CancellationToken cancellationToken
        )
        {
            var thePostToBeUpdated = await _postrepository.GetAsync(command.UpdatePostDto.Id);
            if (thePostToBeUpdated is null)
            {
                throw new FileNotFoundException();
            }

            _iMapper.Map(command.UpdatePostDto, thePostToBeUpdated);

            await _postrepository.UpdateAsync(thePostToBeUpdated);
            return Unit.Value;
        }
    }
}
