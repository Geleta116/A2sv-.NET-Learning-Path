using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Exceptions;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Commands
{
    public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, CommentDto>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IPostRepository _PostRepository;
        private readonly IMapper _mapper;

        public CreateCommentsCommandHandler(ICommentRepository CommentRepository,IPostRepository PostRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _PostRepository = PostRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(
            CreateCommentsCommand command,
            CancellationToken cancellationToken
        )
        {
            var validator = new CreateCommentDtoValidator(_PostRepository);

            var validatedValue = await validator.ValidateAsync(command.CreateCommentDto);

            if (validatedValue.IsValid)
                throw new ValidationException(validatedValue);

            var createdComment = await _CommentRepository.AddAsync(_mapper.Map<Comment>(command));
            return _mapper.Map<CommentDto>(createdComment);
        }
    }
}
