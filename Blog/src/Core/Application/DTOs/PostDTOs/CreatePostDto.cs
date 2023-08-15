using Blog.src.Core.Application.DTOs.Common;

namespace Blog.src.Core.Application.DTOs.PostDtos
{
    public class CreatePostDto : BaseDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
