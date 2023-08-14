using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Core.Domain.Entity
{
    public class Comment: BaseFeature
    {
        public virtual Post Post { get; set; } = null!;

        public int PostId { get; set; }
        public string? Text { get; set; } = null!;
    }
}
