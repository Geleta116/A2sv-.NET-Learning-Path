using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.src.Core.Domain.Entity.Common;

namespace Blog.src.Core.Domain.Entity
{
    public class Post : BaseDomainEntity
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
