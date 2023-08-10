using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public virtual Post Post { get; set; } = null!;

        public int PostId { get; set; }
        public string? Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
