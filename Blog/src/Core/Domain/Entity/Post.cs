using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BlogApi.Core.Domain.Entity
{
    public class Post : BaseFeature
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
