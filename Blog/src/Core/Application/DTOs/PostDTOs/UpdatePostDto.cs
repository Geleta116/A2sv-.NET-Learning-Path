using Blog.src.Core.Application.DTOs.Common;

namespace Blog.src.Core.Application.DTOs.PostDtos
{
    public class UpdatePostDto : BaseDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
