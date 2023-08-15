using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogApi.Core.Domain.Entity.Common;

namespace BlogApi.Core.Domain.Entity
{
    public class Comment : BaseDomainEntity
    {
        public virtual Post Post { get; set; } = null!;
        public int PostId { get; set; }
        public string? Text { get; set; } = null!;
    }
}
