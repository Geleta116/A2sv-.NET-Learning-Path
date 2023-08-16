using Blog.src.Core.Application.DTOs.Common;

namespace Blog.src.Core.Application.DTOs.CommentDtos
{
    public class UpdateCommentDto : BaseDto
    {
        public string Text { get; set; } = null!;
    }
}
