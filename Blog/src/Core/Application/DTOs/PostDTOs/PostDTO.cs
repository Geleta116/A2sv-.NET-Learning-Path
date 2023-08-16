using Blog.src.Core.Application.DTOs.Common;
using Blog.src.Core.Domain.Entity;

namespace Blog.src.Core.Application.DTOs.PostDtos
{
    public class PostDto : BaseDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
