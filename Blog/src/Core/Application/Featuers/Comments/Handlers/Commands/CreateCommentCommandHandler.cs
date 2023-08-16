using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.Exceptions;
using Blog.src.Core.Application.Features.Comments.Requests.Commands;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Core.Application.Responses;
using Blog.src.Core.Domain.Entity;
using MediatR;

namespace Blog.src.Core.Application.Features.Comments.Handlers.Commands
{
    public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, BaseCommandResponse>
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IPostRepository _PostRepository;
        private readonly IMapper _mapper;

        public CreateCommentsCommandHandler(
            ICommentRepository CommentRepository,
            IPostRepository PostRepository,
            IMapper mapper
        )
        {
            _CommentRepository = CommentRepository;
            _PostRepository = PostRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(
            CreateCommentsCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCommentDtoValidator(_PostRepository);

            var validationResult = await validator.ValidateAsync(command.CreateCommentDto);

            if (!validationResult.IsValid)
            {
                response.Message = "Failed to create Comment";
                response.Success = false;
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var createdComment = await _CommentRepository.AddAsync(
                    _mapper.Map<Comment>(command)
                );
                response.Success = true;
                response.Message = "Creation successfull";
                response.Id = createdComment.Id;
                
            }
            return response;
        }
    }
}
