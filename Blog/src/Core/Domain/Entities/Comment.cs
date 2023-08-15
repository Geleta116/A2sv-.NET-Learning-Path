using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.src.Core.Domain.Entity.Common;

namespace Blog.src.Core.Domain.Entity
{
    public class Comment : BaseDomainEntity
    {
        public virtual Post Post { get; set; } = null!;
        public int PostId { get; set; }
        public string? Text { get; set; } = null!;
    }
}
